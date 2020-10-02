using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RCT3启动器
{
    class SweetFX
    {
        /// <summary>
        /// 获取设定目录中SweetFX_settings.txt中的设置项的参数。
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="SettingItem"></param>
        /// <returns></returns>
        public static string[] FindSweetFXItem(string Address, string SettingItem)
        {
            if (File.Exists(Address + "\\SweetFX_settings.txt"))
            {
                //1、匹配选项
                StreamReader Txt = new StreamReader(Address + "\\SweetFX_settings.txt");//读取SweetFX配置文件
                Regex Setting = new Regex(SettingItem + @"\s{0,}\S{0,}\s{0,}\S{0,}\s{0,}\S{0,}\s{0,}/");//匹配选项
                //保存选项
                string str = null;
                foreach (Match n in Setting.Matches(Txt.ReadToEnd()))
                {
                    Regex n1 = new Regex(@"\d");
                    if (n1.IsMatch(n.Value))
                    {
                        str = n.Value;
                        break;
                    }
                }
                //保存选项
                Txt.Close();//关闭读取流
                //2、判断数据类型
                //(SweetFX内有三种数据:整数、小数、float数组)
                Regex Point = new Regex(@"\.", RegexOptions.RightToLeft);//匹配小数
                Regex Float = new Regex(@"\(", RegexOptions.RightToLeft);//匹配float数组
                Regex Float2Number = new Regex("float2", RegexOptions.RightToLeft);//匹配二维数组
                Regex Float3Number = new Regex("float3", RegexOptions.RightToLeft);//匹配三维数组
                Regex AllPoint = new Regex(@"\-{0,}\d{1,}\.\d{1,}", RegexOptions.RightToLeft);//匹配所有小数
                Regex AllInt = new Regex(@"\-{0,}\d{1,}", RegexOptions.RightToLeft);//匹配所有整数
                if (Float.Match(str).Success)//判断是否为float数组
                {//是
                    if (Point.Match(str).Success)//判断数组内是否带小数
                    {//是
                        if (Float2Number.Match(str).Success)//判断是否为二维数组
                        {//是
                            int i = 1;//循环计数
                            string[] Text = new string[2];//设定一个二维数组
                            foreach (Capture n in AllPoint.Matches(Float2Number.Replace(str, "")))//把float头从str中去除再进行小数匹配
                            {
                                Text[i] = n.Value;//把匹配到的数值赋给Text第i项
                                i--;
                            }
                            return Text;
                        }
                        else
                        {//否则为三维数组
                            int i = 2;
                            string[] Text = new string[3];
                            foreach (Capture n in AllPoint.Matches(Float3Number.Replace(str, "")))
                            {
                                Text[i] = n.Value;
                                i--;
                            }
                            return Text;
                        }
                    }
                    else
                    {//否
                        if (Float2Number.Match(str).Success)//判断是否为二维数组
                        {//是
                            int i = 1;
                            string[] Text = new string[2];
                            foreach (Capture n in AllInt.Matches(Float2Number.Replace(str, "")))
                            {
                                Text[i] = n.Value;
                                i--;
                            }
                            return Text;
                        }
                        else
                        {//否则为三维数组
                            int i = 2;
                            string[] Text = new string[3];
                            foreach (Capture n in AllInt.Matches(Float3Number.Replace(str, "")))
                            {
                                Text[i] = n.Value;
                                i--;
                            }
                            return Text;
                        }
                    }
                }
                else
                {//否
                    if (Point.Match(str).Success)//判断是否为小数
                    {//是
                        string[] Text = new string[1];
                        Text[0] = AllPoint.Match(str).Value;
                        return Text;
                    }
                    else
                    {//否则为整数
                        string[] Text = new string[1];
                        Text[0] = AllInt.Match(str).Value;
                        return Text;
                    }
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 更改设定目录中SweetFX_settings.txt中的设置项的参数。
        /// </summary>
        /// <param name="Address"></param>
        /// <param name="SettingItem"></param>
        /// <param name="Value"></param>
        public static void SetSweetFXItem(string Address, string SettingItem, string[] Value)
        {
            if (MainForm.Value.Only_SweetSettings_Reading == false)
            {
                //1、读取选项
                StreamReader Txt = new StreamReader(Address + "\\SweetFX_settings.txt");//读取SweetFX配置文件
                Regex Setting = new Regex(SettingItem + @"\s{0,}\S{0,}\s{0,}\S{0,}\s{0,}\S{0,}\s{0,}/");//匹配选项
                string str = Setting.Match(Txt.ReadToEnd()).Value;//保存选项
                Txt.Close();//关闭读取流
                            //2、读取配置文件
                string[] Settings = File.ReadAllLines(Address + "\\SweetFX_settings.txt");//保存配置文件到Settings
                                                                                          //3、替换参数
                int i = 0, t = 0;//都是循环计数变量
                string[] Set = FindSweetFXItem(Address, SettingItem);//获取参数
                string Changed, Change;//Change用于存储更改参数以后的正则匹配选项，Changed用于存储更改完成的完整选项
                Regex Float2Number = new Regex("float2");//匹配二维数组
                Regex Float3Number = new Regex("float3");//匹配三维数组
                if (Float2Number.Match(str).Success | Float3Number.Match(str).Success)
                {//处理数组数据
                    if (Set.Length == 2)
                    {
                        Regex r = new Regex(@"\([^a-z]{1,}\)");//匹配括号和内部的参数
                        Change = "(" + Value[0] + ", " + Value[1] + ")";//将输入的数据整理成数组形式
                        Changed = r.Replace(str, Change);//替换正则匹配选项中的参数
                        foreach (string x in Settings)//从所有设置项中逐行读取
                        {
                            if (Setting.Match(x).Value == str)//当读取到要更改的选项时
                            {
                                Settings[t] = Setting.Replace(x, Changed);//应用更改到存储所有选项的集合
                                break;
                            }
                            t++;
                        }
                        t = 0;//清空计数器变量
                        using (StreamWriter writer = new StreamWriter(Address + "\\SweetFX_settings.txt"))
                        {
                            foreach (string s in Settings)//按照更改后的选项逐行写入txt
                            {
                                writer.WriteLine(s);
                            }
                            writer.Close();
                        }
                    }
                    else
                    {
                        Regex r = new Regex(@"\([^a-z]{1,}\)");//匹配括号和内部的参数
                        Change = "(" + Value[0] + ", " + Value[1] + ", " + Value[2] + ")";//将输入的数据整理成数组形式
                        Changed = r.Replace(str, Change);//替换正则匹配选项中的参数
                        foreach (string x in Settings)//从所有设置项中逐行读取
                        {
                            if (Setting.Match(x).Value == str)//当读取到要更改的选项时
                            {
                                Settings[t] = Setting.Replace(x, Changed);//应用更改到存储所有选项的集合
                                break;
                            }
                            t++;
                        }
                        t = 0;//清空计数器变量
                        using (StreamWriter writer = new StreamWriter(Address + "\\SweetFX_settings.txt"))
                        {
                            foreach (string s in Settings)//按照更改后的选项逐行写入txt
                            {
                                writer.WriteLine(s);
                            }
                            writer.Close();
                        }
                    }
                }
                else
                {//处理非数组数据
                    string n = Set[0];
                    Regex r1 = new Regex(n);
                    Change = r1.Replace(str, Value[i]);//将正则匹配选项中的参数更改
                    foreach (string x in Settings)//从所有设置项中逐行读取
                    {
                        if (Setting.Match(x).Value == str)//当读取到要更改的选项时
                        {
                            Changed = Setting.Replace(x, Change);//保存更改的选项
                            Settings[t] = Changed;//将更改应用到存储所有选项的集合
                            break;
                        }
                        t++;
                    }
                    using (StreamWriter writer = new StreamWriter(Address + "\\SweetFX_settings.txt"))
                    {
                        foreach (string s in Settings)//按照更改后的选项逐行写入txt
                        {
                            writer.WriteLine(s);
                        }
                        writer.Close();
                    }
                }
            }
        }
    }
}

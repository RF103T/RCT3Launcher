using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Drawing;
using System.Reflection;
using System.Threading;
using RCT3启动器MessageBox;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;

namespace RCT3启动器
{
    public partial class MainForm : Form
    {
        private Form form;//全局窗体变量
        bool Setting_Open = false;//判断设置窗口是否打开的变量
        bool Button_Up = false;//判断按钮是否被放开的变量
        private Button button;//全局button变量
        int n,m = 0;//n,m为计时器变量
        int L, T, H, W;//记录按钮Left Top Height Width数据的变量
        int x = 1;//计时器Drop使用
        int Alpha;//计时器Drop使用
        string SavesFileName = null;//游戏存档路径
        //在两个注释内申明Dll
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwdn,int wMsg,int mParam,int lParam);
        public const int WS = 0x0112;
        public const int MOVE = 0xF010;
        public const int HT = 0x0002;
        //在两个注释内申明Dll
        public MainForm()
        {             
            //释放DLL
            if (!(File.Exists("RCT3启动器MessageBox.dll") & File.Exists("Win8 On.dll")))
            {
                Assembly a = Assembly.GetExecutingAssembly();
                RCT3启动器.SettingForm.CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.RCT3启动器MessageBox.dll"), File.Open("RCT3启动器MessageBox.dll", FileMode.Create));
                RCT3启动器.SettingForm.CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Win8 ON.dll"), File.Open("Win8 ON.dll", FileMode.Create));
            }
            //释放DLL           
            //更新
            if (File.Exists("Update.exe"))
                File.Delete("Update.exe");
            //更新
            //实例化设置文件
            if (!File.Exists("Setting.set"))
            {
                XmlDocument AllSettings = new XmlDocument();
                XmlDeclaration dec = AllSettings.CreateXmlDeclaration("1.0", "utf-8", null);
                AllSettings.AppendChild(dec);
                XmlElement S = AllSettings.CreateElement("设置");
                AllSettings.AppendChild(S);
                XmlElement QS = AllSettings.CreateElement("启动器设置");
                QS.SetAttribute("id", "启动器设置");
                S.AppendChild(QS);
                XmlElement S1 = AllSettings.CreateElement("允许启动器在游戏启动期间驻留在后台");
                S1.SetAttribute("id", "允许启动器在游戏启动期间驻留在后台");
                S1.InnerText = "False";
                XmlElement S2 = AllSettings.CreateElement("允许启动器收集您的配置信息以供分析");
                S2.SetAttribute("id", "允许启动器收集您的配置信息以供分析");
                S2.InnerText = "False";
                XmlElement S3 = AllSettings.CreateElement("启动器对低配置系统优化");
                S3.SetAttribute("id", "启动器对低配置系统优化");
                S3.InnerText = "False";
                XmlElement S4 = AllSettings.CreateElement("自动检查更新");
                S4.SetAttribute("id", "自动检查更新");
                S4.InnerText = "False";
                XmlElement S5 = AllSettings.CreateElement("游戏目录");
                S5.SetAttribute("id", "游戏目录");
                S5.InnerText = "";
                XmlElement GS = AllSettings.CreateElement("画面设置");
                GS.SetAttribute("id", "画面设置");
                S.AppendChild(GS);
                XmlElement S6 = AllSettings.CreateElement("游戏分辨率");
                S6.SetAttribute("id", "游戏分辨率");
                S6.InnerText = "800*600";
                XmlElement S7 = AllSettings.CreateElement("全屏幕");
                S7.SetAttribute("id", "全屏幕");
                S7.InnerText = "False";
                XmlElement S8 = AllSettings.CreateElement("开启SweetFX");
                S8.SetAttribute("id", "开启SweetFX");
                S8.InnerText = "False";
                XmlElement S9 = AllSettings.CreateElement("轨道重叠");
                S9.SetAttribute("id", "轨道重叠");
                S9.InnerText = "False";
                QS.AppendChild(S1);
                QS.AppendChild(S2);
                QS.AppendChild(S3);
                QS.AppendChild(S4);
                QS.AppendChild(S5);
                GS.AppendChild(S6);
                GS.AppendChild(S7);
                GS.AppendChild(S8);
                GS.AppendChild(S9);
                AllSettings.Save("Setting.set");
                MessageBox.Show("请到设置里更改游戏目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                XmlDocument Setting = new XmlDocument();
                Setting.Load("Setting.set");
                XmlElement Set = Setting.DocumentElement;
                XmlNodeList Settings = Set.ChildNodes;
                foreach (XmlNode S in Settings)
                {
                    if (S.Attributes["id"].InnerText == "启动器设置")
                    {
                        XmlNodeList QSettings = S.ChildNodes;
                        foreach (XmlNode AD in QSettings)
                        {
                            if (AD.Attributes["id"].InnerText == "允许启动器在游戏启动期间驻留在后台")
                            {
                                if (AD.InnerText == "True")
                                    Value.Started_Run = true;
                                else
                                    Value.Started_Run = false;
                            }
                            if (AD.Attributes["id"].InnerText == "允许启动器收集您的配置信息以供分析")
                            {
                                //不想写了
                            }
                            if (AD.Attributes["id"].InnerText == "启动器对低配置系统优化")
                            {
                                if (AD.InnerText == "True")
                                    Value.optimize = true;
                                else
                                    Value.optimize = false;
                            }
                            if (AD.Attributes["id"].InnerText == "自动检查更新")
                            {
                                if (AD.InnerText == "True")
                                    Value.Auto_Check_Update = true;
                                else
                                    Value.Auto_Check_Update = false;
                            }
                            if (AD.Attributes["id"].InnerText == "游戏目录")
                            {
                                if (!(AD.InnerText == ""))
                                    Value.Game_Address = AD.InnerText;
                                else
                                    MessageBox.Show("请到设置里更改游戏目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    if (S.Attributes["id"].InnerText == "画面设置")
                    {
                        string GSettings = null;
                        foreach (XmlNode AD in S)
                        {
                            GSettings = GSettings + AD.Attributes["id"].InnerText;
                        }
                        if (!GSettings.Contains("开启SweetFX"))
                        {
                            XmlElement S8 = Setting.CreateElement("开启SweetFX");
                            S8.SetAttribute("id", "开启SweetFX");
                            S8.InnerText = "False";
                            S.AppendChild(S8);
                        }
                        if (!GSettings.Contains("轨道重叠"))
                        {
                            XmlElement S9 = Setting.CreateElement("轨道重叠");
                            S9.SetAttribute("id", "轨道重叠");
                            S9.InnerText = "False";
                            S.AppendChild(S9);
                        }
                        Setting.Save("Setting.set");
                    }//升级以后添加新的设置项
                }
            }
            if(Value.Auto_Check_Update)
            {
                Thread Check_Update = new Thread(CheckUpdate);
            }
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Value.AC = Main_Function;
        }

        private void CheckUpdate()
        {
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest FTP = (FtpWebRequest)FtpWebRequest.Create("ftp://ourhomevpn.asuscomm.com/UPDATE/RCT3Running/");
                FTP.UseBinary = true;
                FTP.Credentials = new NetworkCredential("RCT3Running", "A!0S@9D#8");
                FTP.Method = WebRequestMethods.Ftp.ListDirectory;
                WebResponse response = FTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                string[] file = result.ToString().Split('\n');
                Regex n = new Regex(@"\d\D\d\D\d\D\d");
                foreach (string Update in file)
                {
                    if (n.Match(Update).Value != "")
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        //跟界面有关的代码
        private void MainFormMove_MouseDown(object sender,MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WS, MOVE + HT, 0);
        }

        private void Button_MouseEnter(object sender,EventArgs e)
        {
            this.Capture = true;         
            Button S = (Button)sender;
            this.Capture = false;
            S.FlatAppearance.BorderSize = 2; 
        }

        private void Button_MouseLeave(object sender,EventArgs e)
        {
            Button_Up = true;
            this.Capture = true;
            Button S = (Button)sender;
            this.Capture = false;
            S.FlatAppearance.BorderSize = 0;
        }

        private void Button_MouseDown(object sender,MouseEventArgs e)
        {
            Button_Up = false;
            this.Capture = true;
            Button S = (Button)sender;
            button = S;
            L = button.Left;
            T = button.Top;
            H = button.Height;
            W = button.Width;
            if (S.Name == "StartGame" | S.Name == "KAdd" | S.Name == "Web")
            {
                BigButtonOn.Enabled = true;
                BigButtonOn.Start();
            }
            else
            {
                ButtonOn.Enabled = true;
                ButtonOn.Start();
            }
            this.Capture = false;
        }

        private void Button_MouseUp(object sender,MouseEventArgs e)
        {
            Button_Up = true;
            this.Capture = true;
            Button S = (Button)sender;
            button = S;
            if (S.Name == "StartGame" | S.Name == "KAdd" | S.Name == "Web")
            {
                BigButtonOff.Enabled = true;
                BigButtonOff.Start();
            }
            else
            {
                ButtonOff.Enabled = true;
                ButtonOff.Start();
            }
            if (S.Name == "Exit")
            {
                try
                {
                    rcT_MessageBox2.Thread_Stop = true;
                    Environment.Exit(0);
                }
                catch(Exception err)
                {
                    MessageBox.Show("警告", "启动器退出的时候遇到了错误，请将以下信息报告开发者:" + err.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if(S.Name == "QSetting")
            {
                //这一段代码里面的Activate都是为了更新控件
                SettingForm Setting = new SettingForm();
                Value.Setting_Font_Page = "QSetting";
                if(Setting_Open==false)
                {
                    Setting.Show();
                    Setting_Open = true;
                    Setting.Activate();
                    form = Setting;
                }
                else
                {
                    Value.Activate_Checked = true;
                    form.Show();
                    form.Activate();
                }
            }
            if(S.Name == "GSetting")
            {
                //这一段代码里面的Activate都是为了更新控件
                SettingForm Setting = new SettingForm();
                Value.Setting_Font_Page = "GSetting";
                if (Setting_Open == false)
                {
                    Setting.Show();
                    Setting_Open = true;
                    Setting.Activate();
                    form = Setting;
                }
                else
                {
                    Value.Activate_Checked = true;
                    form.Show();
                    form.Activate();
                }
            }
            if(S.Name=="Web")
            {
                Process.Start("http://tieba.baidu.com/f?kw=%E8%BF%87%E5%B1%B1%E8%BD%A6%E5%A4%A7%E4%BA%A83&ie=utf-8");
            }
            if(S.Name== "StartGame")
            {
                if (!(Value.Game_Address == ""))
                {
                    Process RCT3S = new Process();
                    RCT3S.StartInfo.FileName = Value.Game_Address + "//RCT3plus.exe";
                    RCT3S.Start();
                    if (Value.Started_Run == false)
                        this.Close();
                    Say.Text = " ";
                }
                else
                {
                    Say.Text = "启动失败！";
                    MessageBox.Show("启动失败！请检查设置的游戏目录！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            if(S.Name== "KAdd")
            {
                if(!(Value.Game_Address==""))
                {
                    FolderBrowserDialog KuoChong = new FolderBrowserDialog();
                    KuoChong.ShowDialog();
                    if (!(KuoChong.SelectedPath == ""))
                    {
                        copyDirectory(KuoChong.SelectedPath, Value.Game_Address + @"\Style\Themed");
                        Say.Text = "添加完成！";
                    }
                }
                else
                {
                    MessageBox.Show("您还未设置游戏目录！该功能尚未启用！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if(S.Name=="MAdd")
            {
                if (!(Value.Game_Address == ""))
                {
                    OpenFileDialog YinYue = new OpenFileDialog();
                    YinYue.Filter = "mp3文件|*.mp3";
                    YinYue.ShowDialog();
                    if (!(YinYue.FileName == ""))
                    {
                        File.Copy(YinYue.FileName, Value.Game_Address + @"\Music" + Path.GetFileName(YinYue.FileName));
                        Say.Text = "添加完成！";
                    }
                }
                else
                {
                    MessageBox.Show("您还未设置游戏目录！该功能尚未启用！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if(S.Name== "CRepair")
            {
                if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//RCT3"))
                {
                    OpenFileDialog CunDang = new OpenFileDialog();
                    CunDang.Filter = "需要修复存档的bak文件|*.bak";
                    CunDang.ShowDialog();
                    if (!(CunDang.FileName == ""))
                    {
                        CRepair_Box.Visible = true;
                        CRepair.Text = "\r\r\r\r\r请选择存档类型";
                        CRepair.Image = null;
                        SavesFileName = CunDang.FileName;
                    }
                }
                else
                {
                    MessageBox.Show("未发现游戏存档目录，请检查！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (S.Name == "RCT3Live")
            {
                //MessageBox.Show("此功能还在构建中，敬请期待！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Process DEP = new Process();
                //DEP.StartInfo.FileName = "systempropertiesdataexecutionprevention.exe";
                //DEP.Start();
                GameFixForm GameFix = new GameFixForm();
                GameFix.Show();
            }
            this.Capture = false;
        }

        private void SavesRepair (object sender,EventArgs e)
        {
            this.Capture = true;
            Button S = (Button)sender;
            if (S.Name == "FreedomModeSave")
                File.Copy(SavesFileName, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//RCT3//Parks//" + "Repair_" + Path.GetFileNameWithoutExtension(SavesFileName));
            if (S.Name == "CustomSave")
                File.Copy(SavesFileName, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//RCT3//Start New Scenarios//" + "Repair_" + Path.GetFileNameWithoutExtension(SavesFileName));
            this.Capture = false;
            Say.Text = "修复完成！";
            CRepair_Box.Visible = false;
            CRepair.Text = "\r\r\r\r\r 存档修复";
            CRepair.Image = RCT3启动器.Properties.Resources.存档修复;
        }

        private void BigBottonOn_Tick(object sender, EventArgs e)
        {
            n++;
            if(n<2)
            {
                button.Height = button.Height - 2;
                button.Width = button.Width - 2;
                button.Left = button.Left + 1;
                button.Top = button.Top + 2;
            }
            else
            {
                BigButtonOn.Stop();
            }
            if (Button_Up == true)
            {
                BigButtonOn.Stop();
                BigButtonOff.Start();
            }
        }

        private void BigBottonOff_Tick(object sender, EventArgs e)
        {
            if(n!=0)
            {
                button.Height = button.Height + 2;
                button.Width = button.Width + 2;
                button.Left = button.Left - 1;
                button.Top = button.Top - 2;
            }
            else
            {
                if (button.Left != L | button.Top != T | button.Height != H | button.Width != W)
                {
                    button.Left = L;
                    button.Top = T;
                    button.Height = H;
                    button.Width = W;
                }
                BigButtonOff.Stop();
            }
            n--;
        }

        private void ButtonOn_Tick(object sender, EventArgs e)
        {    
            m++;
            if (m < 2)
            {
                button.Height = button.Height - 2;
                button.Width = button.Width - 1;
                button.Left = button.Left + 1;
                button.Top = button.Top + 2;
            }
            else
            {
                ButtonOn.Stop();
            }
            if (Button_Up == true)
            {
                ButtonOn.Stop();
                ButtonOff.Start();
            }
        }

        private void ButtonOff_Tick(object sender, EventArgs e)
        {     
            if (m!=0)
            {
                button.Height = button.Height + 2;
                button.Width = button.Width + 1;
                button.Left = button.Left - 1;
                button.Top = button.Top - 2;
            }
            else
            {
                if (button.Left != L | button.Top != T | button.Height != H | button.Width != W)
                {
                    button.Left = L;
                    button.Top = T;
                    button.Height = H;
                    button.Width = W;
                }
                ButtonOff.Stop();
            }
            m--;
        }

        private void Drop_Tick(object sender, EventArgs e)
        {
            if (x == 1)
            {
                Alpha = Alpha + 3;
                KAdd.BackColor = Color.FromArgb(Alpha, 235, 235, 235);
                MAdd.BackColor = Color.FromArgb(Alpha, 235, 235, 235);
                CRepair.BackColor = Color.FromArgb(Alpha, 235, 235, 235);
                if (Alpha == 120)
                {
                    x = 0;
                }
            }
            else
            {
                Alpha = Alpha - 3;
                KAdd.BackColor = Color.FromArgb(Alpha, 235, 235, 235);
                MAdd.BackColor = Color.FromArgb(Alpha, 235, 235, 235);
                CRepair.BackColor = Color.FromArgb(Alpha, 235, 235, 235);
                if (Alpha == 0)
                {
                    x = 1;
                }
            }
        }//拖动文件时触发
        //跟界面有关的代码
        //文件夹的复制
        public static void copyDirectory(string sourceDirectory, string destDirectory)
        {
            if (!(sourceDirectory == ""))
            {
                //判断源目录和目标目录是否存在，如果不存在，则创建一个目录
                if (!Directory.Exists(sourceDirectory))
                {
                    Directory.CreateDirectory(sourceDirectory);
                }
                if (!Directory.Exists(destDirectory))
                {
                    Directory.CreateDirectory(destDirectory);
                }
                //拷贝文件
                copyFile(sourceDirectory, destDirectory);

                //拷贝子目录       
                //获取所有子目录名称
                string[] directionName = Directory.GetDirectories(sourceDirectory);

                foreach (string directionPath in directionName)
                {
                    //根据每个子目录名称生成对应的目标子目录名称
                    string directionPathTemp = destDirectory + "\\" + directionPath.Substring(sourceDirectory.Length + 1);

                    //递归下去
                    copyDirectory(directionPath, directionPathTemp);
                }
            }
        }

        public static void copyFile(string sourceDirectory, string destDirectory)
        {
            //获取所有文件名称
            string[] fileName = Directory.GetFiles(sourceDirectory);

            foreach (string filePath in fileName)
            {
                //根据每个文件名称生成对应的目标文件名称
                string filePathTemp = destDirectory + "\\" + filePath.Substring(sourceDirectory.Length + 1);

                //若不存在，直接复制文件；若存在，覆盖复制
                if (File.Exists(filePathTemp))
                {
                    File.Copy(filePath, filePathTemp, true);
                }
                else
                {
                    File.Copy(filePath, filePathTemp);
                }
            }
        }

        //文件夹的复制
        //文件的复制
        public static void CopyFile(string sourceDirectory,string destDirectory)
        {
            string fileName = Path.GetFileName(sourceDirectory);
            string filePathTemp = destDirectory + "\\" + fileName;
            File.Copy(sourceDirectory, filePathTemp, true);
        }
        //文件的复制
        private void Optimize_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }//极限优化

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (Value.optimize == true)
                Optimize.Start();
            else
                Optimize.Stop();
        }//极限优化

        ////拖动进入主窗体
        //private void MainForm_DragEnter(object sender, DragEventArgs e)
        //{

        //}//拖动进入MainForm

        //private void MainForm_DragDrop(object sender, DragEventArgs e)
        //{
        //    Drop.Stop();
        //    KAdd.BackColor = Color.FromArgb(0, 235, 235, 235);
        //    MAdd.BackColor = Color.FromArgb(0, 235, 235, 235);
        //    CRepair.BackColor = Color.FromArgb(0, 235, 235, 235);
        //}//拖动完成

        //private void MainForm_DragLeave(object sender,EventArgs e)
        //{
        //    Drop.Stop();
        //    KAdd.BackColor = Color.FromArgb(0, 235, 235, 235);
        //    MAdd.BackColor = Color.FromArgb(0, 235, 235, 235);
        //    CRepair.BackColor = Color.FromArgb(0, 235, 235, 235);
        //}//拖动取消
        ////添加扩充按钮的拖动输入
        //private void KAdd_DragEnter(object sender, DragEventArgs e)
        //{

        //}

        //private void KAdd_DragDrop(object sender, DragEventArgs e)
        //{          
        //    copyDirectory(((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString(), Value.Game_Address + @"\Style\Themed");
        //    Say.Text = "添加完成！";
        //}
        ////添加音乐按钮的拖动输入
        //private void MAdd_DragEnter(object sender, DragEventArgs e)
        //{

        //}

        //private void MAdd_DragDrop(object sender, DragEventArgs e)
        //{
        //    CopyFile(((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString(), Value.Game_Address + @"\Music");
        //    Say.Text = "添加完成！";
        //}

        ////存档修复按钮的拖动输入
        //private void CRepair_DragEnter(object sender,DragEventArgs e)
        //{

        //}

        //private void CRepair_DragDrop(object sender,DragEventArgs e)
        //{

        //}

        internal class Value
        {
            public static string Setting_Font_Page;//设置 设置界面 显示的界面
            public static string Game_Address = "";
            public static bool optimize;//低配置优化
            public static Label AC;//低配置优化
            public static bool Activate_Checked = true;//设置是否进行Activate激活检测
            public static bool Started_Run;//后台驻留
            public static bool Only_SweetSettings_Reading = false;//设置SweetFX设置项被更改时读写权限
            public static bool Auto_Check_Update = false;//设置自动检测更新 
        }
    }
}

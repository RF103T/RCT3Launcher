using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace RCT3启动器
{
    public partial class GameFixForm : Form
    {
        int NowStep = 0;//指示修复进行到哪一步
        //在两个注释内申明Dll
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwdn, int wMsg, int mParam, int lParam);
        public const int WS = 0x0112;
        public const int MOVE = 0xF010;
        public const int HT = 0x0002;
        [DllImport("user32.dll", EntryPoint = "GetScrollPos")]
        public static extern int GetScrollPos(IntPtr hwnd, int nBar);
        //在两个注释内申明Dll
        public GameFixForm()
        {
            InitializeComponent();
        }

        private void GameFixForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WS, MOVE + HT, 0);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出此向导？某些正在进行的工作可能会被打断，还可能造成无法恢复的错误。", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                this.Close();
        }

        private void Form_MouseEnter(object sender, EventArgs e)
        {
            CheckScroll.Start();
        }//检测文本框竖向滚动条是否拉到最下面

        private void CheckScroll_Tick(object sender, EventArgs e)
        {
            if (GetScrollPos(this.Tips.Handle, 1) == 9)
            {
                StartGuide.Visible = true;
                CheckScroll.Stop();
            }
        }//检测文本框竖向滚动条是否拉到最下面

        private void StartGuide_Click(object sender, EventArgs e)
        {
            if(StartGuide.Text == "启动游戏")
            {
                Process RCT3S = new Process();
                RCT3S.StartInfo.FileName = MainForm.Value.Game_Address + "//RCT3plus.exe";
                RCT3S.Start();
                if (NowStep == 3)
                {
                    if (MessageBox.Show("游戏能正常运行吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        MessageBox.Show("请尝试在过山车大亨3吧求助，发贴时请详细描述问题，谢谢！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("修复完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                {
                    StartGuide.Text = "下一步";
                }
                return;
            }
            switch (NowStep)
            {
                case 0:
                    Directory.CreateDirectory("Backups");
                    Step1.Visible = true;
                    OptionsCheckInformation.Visible = true;
                    OptionsCheckInformation.BringToFront();
                    Step1.BringToFront();
                    OptionsCheck();
                    NowStep++;
                    StartGuide.Text = "启动游戏";
                    break;
                case 1:
                    if(MessageBox.Show("游戏能正常运行吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.No)
                    {
                        OptionsCheckInformation.Text += "进行下一步修复......\r\n";
                        Step1.Visible = false;
                        Step2.Visible = true;
                        RCT3plusReplace();
                        NowStep++;
                        StartGuide.Text = "启动游戏";
                    }
                    else
                    {
                        MessageBox.Show("修复完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    break;
                case 2:
                    if (MessageBox.Show("游戏能正常运行吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    {
                        OptionsCheckInformation.Text += "进行下一步修复......\r\n";
                        Step2.Visible = false;
                        Step3.Visible = true;
                        SetDEP();
                        NowStep++;
                        StartGuide.Text = "启动游戏";
                    }
                    else
                    {
                        MessageBox.Show("修复完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    break;
            }        
        }

        private void OptionsCheck()
        {
            string op = "Resolution 800 600\r\nCameraUserContro 1\r\nMode 0\r\nStaticBatchTriCutoff 80\r\nDynamicBatchTriCutoff 200\r\nMultiSample 4\r\nCycleMenuMusic 3\r\nGuestLOD 3.000000 3.000000\r\nAnimalLOD 3.000000 3.000000\r\nVegetationLOD 3.000000 3.000000\r\nFenceLOD 3.000000 3.000000\r\nBuildingLOD 3.000000 3.000000\r\nPathLOD 3.000000 3.000000\r\nSceneryLOD 3.000000 3.000000\r\nSupportLOD 3.000000 3.000000\r\nTrackLOD 3.000000 3.000000\r\nRideLOD 3.000000 3.000000\r\nGeometryImposterDistance 1100.000000\r\nGeometryImposterTolerance 0.300000\r\nSkipCacheWarming 3.000000\r\nReflectEnable 1\r\nWaterBumpEnable 1\r\nReflectTerrain 1\r\nReflectScenery 1\r\nReflectPeople 1\r\nReflectAnimals 1\r\nReflectParticles 1\r\nBlendSceneryLODs 1\r\nLaserRayHit 1\r\nDetailMapTerrain 0\r\n";
            OptionsCheckInformation.Text = "正在检测options.txt文件是否存在......\r\n";
            if(File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Atari//RCT3//Options.txt"))
            {
                OptionsCheckInformation.Text += "options.txt存在，更新options.txt内容......\r\n";
                File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Atari//RCT3//Options.txt", "Backups//Options_Backup.txt", true);
                FileStream Options = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Atari//RCT3//Options.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamWriter Option = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Atari//RCT3//Options.txt", false, Encoding.Default);
                Option.Write(op);
                Option.Flush();
                Option.Close();
                Options.Close();
            }
            else
            {
                OptionsCheckInformation.Text += "options.txt不存在，将创建options.txt......\r\n";
                FileStream Options = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//Atari//RCT3//Options.txt", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter Option = new StreamWriter(Options, Encoding.Default);
                Option.Write(op);
                Option.Flush();
                Option.Close();
                Options.Close();
            }
            OptionsCheckInformation.Text += "options.txt替换完成，请尝试是否能启动游戏。\r\n";
        }//options.txt文件检测

        private void RCT3plusReplace()
        {
            File.Copy(MainForm.Value.Game_Address + "//RCT3plus.exe", "Backups//RCT3plus_Backup.exe", true);
            OptionsCheckInformation.Text += "正在替换RCT3plus.exe......\r\n";
            Assembly a = Assembly.GetExecutingAssembly();
            SettingForm.CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.RCT3plus.exe"), File.Open(MainForm.Value.Game_Address + "//RCT3plus.exe", FileMode.Create));
            OptionsCheckInformation.Text += "替换成功，请尝试是否能启动游戏。\r\n";
        }//RCT3plus.exe文件替换

        private void SetDEP()
        {
            Process process = new Process();
            process.StartInfo.FileName = "SystemPropertiesDataExecutionPrevention.exe";//打开DEP
            process.Start();
            this.Activate();
            MessageBox.Show("请选择‘为除下列选定程序之外的所有程序和服务启用DEP’，然后选择添加，添加游戏目录下的RCT3.exe和RCT3plus.exe，然后点击应用，最后关闭界面即可。", "请根据步骤操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }//DEP设置

        private void Install4GB_Click(object sender, EventArgs e)
        {
            Assembly a = Assembly.GetExecutingAssembly();
            SettingForm.CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.4gb_patch.exe"), File.Open("4GB_Patch.exe", FileMode.Create));
            Process process = new Process();
            process.StartInfo.FileName = "4GB_Patch.exe";
            this.Activate();
            process.Start();
            MessageBox.Show("请允许程序获取管理员权限，选中游戏目录中的RCT3plus.exe，再点击打开。最后点击OK结束程序。", "请根据步骤操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("如果发现没有作用，请将游戏目录内的RCT3.exe和RCT3plus.exe的属性中的兼容性设置为XP SP3，而且选中以管理员运行程序。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }//4GB Patch补丁安装
    }
}

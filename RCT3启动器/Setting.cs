#define New_Game_Version

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Reflection;
using System.Collections.Generic;
using Win8_ON;

namespace RCT3启动器
{
    public partial class SettingForm : Form
    {
#if New_Game_Version
        string Game_Options_Path = "//Frontier//RCT3//Options.txt";
        string Game_Exe_Name = "RCT3.exe";
#else
        string Game_Options_Path = "//Atari//RCT3//Options.txt";
        string Game_Exe_Name = "RCT3plus.exe";
#endif

        int X, Y;//游戏分辨率调整值
        private Button button;//全局button变量
        bool Click_Bool = false;//点击判断值
        delegate void SetText();//用来跨线程发送数据的委托
        //在两个注释内申明Dll
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwdn, int wMsg, int mParam, int lParam);
        public const int WS = 0x0112;
        public const int MOVE = 0xF010;
        public const int HT = 0x0002;
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        //在两个注释内申明Dll
        public SettingForm()
        {
            InitializeComponent();
            //读取set文件
            XmlDocument Setting = new XmlDocument();
            Setting.Load("Setting.set");
            XmlElement Set = Setting.DocumentElement;
            XmlNodeList Settings = Set.ChildNodes;
            foreach (XmlNode S in Settings)
            {
                if (S.Attributes["id"].InnerText == "0")
                {
                    XmlNodeList QSettings = S.ChildNodes;
                    foreach (XmlNode AD in QSettings)
                    {
                        if (AD.Attributes["id"].InnerText == "1")
                        {
                            if (AD.InnerText == "True")
                            {
                                OnOff1.Checked = true;
                                On1.Text = "开";
                            }
                            else
                            {
                                OnOff1.Checked = false;
                                On1.Text = "关";
                            }
                        }
                        if (AD.Attributes["id"].InnerText == "2")
                        {
                            if (AD.InnerText == "True")
                            {
                                OnOff2.Checked = true;
                                On2.Text = "开";
                            }
                            else
                            {
                                OnOff2.Checked = false;
                                On2.Text = "关";
                            }
                        }
                        if (AD.Attributes["id"].InnerText == "3")
                        {
                            if (AD.InnerText == "True")
                            {
                                OnOff3.Checked = true;
                                On3.Text = "开";
                            }
                            else
                            {
                                OnOff3.Checked = false;
                                On3.Text = "关";
                            }
                        }
                        if (AD.Attributes["id"].InnerText == "4")
                        {
                            if (AD.InnerText == "True")
                            {
                                OnOff4.Checked = true;
                                On4.Text = "开";
                            }
                            else
                            {
                                OnOff4.Checked = false;
                                On4.Text = "关";
                            }
                        }
                        if (AD.Attributes["id"].InnerText == "5")
                        {
                            Address.Text = AD.InnerText;
                        }
                    }
                }
                if (S.Attributes["id"].InnerText == "6")
                {
                    XmlNodeList GSettings = S.ChildNodes;
                    foreach (XmlNode AD in GSettings)
                    {
                        if (AD.Attributes["id"].InnerText == "7")
                        {
                            if (AD.InnerText == "800*600")
                                Resolution_Set.SelectedIndex = 0;
                            if (AD.InnerText == "1024*600")
                                Resolution_Set.SelectedIndex = 1;
                            if (AD.InnerText == "1024*768")
                                Resolution_Set.SelectedIndex = 2;
                            if (AD.InnerText == "1152*864")
                                Resolution_Set.SelectedIndex = 3;
                            if (AD.InnerText == "1280*720")
                                Resolution_Set.SelectedIndex = 4;
                            if (AD.InnerText == "1280*768")
                                Resolution_Set.SelectedIndex = 5;
                            if (AD.InnerText == "1280*800")
                                Resolution_Set.SelectedIndex = 6;
                            if (AD.InnerText == "1280*960")
                                Resolution_Set.SelectedIndex = 7;
                            if (AD.InnerText == "1280*1024")
                                Resolution_Set.SelectedIndex = 8;
                            if (AD.InnerText == "1360*768")
                                Resolution_Set.SelectedIndex = 9;
                            if (AD.InnerText == "1366*768")
                                Resolution_Set.SelectedIndex = 10;
                            if (AD.InnerText == "1440*900")
                                Resolution_Set.SelectedIndex = 11;
                            if (AD.InnerText == "1600*900")
                                Resolution_Set.SelectedIndex = 12;
                            if (AD.InnerText == "1600*1024")
                                Resolution_Set.SelectedIndex = 13;
                            if (AD.InnerText == "1680*1050")
                                Resolution_Set.SelectedIndex = 14;
                            if (AD.InnerText == "1920*1080")
                                Resolution_Set.SelectedIndex = 15;
                        }
                        if (AD.Attributes["id"].InnerText == "8")
                        {
                            if (AD.InnerText == "True")
                            {
                                OnOff5.Checked = true;
                                On5.Text = "开";
                            }
                            else
                            {
                                OnOff5.Checked = false;
                                On5.Text = "关";
                            }
                        }
                        if (AD.Attributes["id"].InnerText == "10")
                        {
                            if (AD.InnerText == "True")
                            {
                                OnOff27.Checked = true;
                                On27.Text = "开";
                            }
                            else
                            {
                                OnOff27.Checked = false;
                                On27.Text = "关";
                            }
                        }
                        if (AD.Attributes["id"].InnerText == "9")
                        {
                            if (AD.InnerText == "True" & File.Exists(MainForm.Value.Game_Address + "\\SweetFX_settings.txt"))
                            {
                                int i = 26;
                                OnOff6.Checked = true;
                                On6.Text = "开";
                                OnOff7.NotAllowChecked = false;
                                OnOff8.NotAllowChecked = false;
                                OnOff9.NotAllowChecked = false;
                                OnOff10.NotAllowChecked = false;
                                OnOff11.NotAllowChecked = false;
                                OnOff12.NotAllowChecked = false;
                                OnOff13.NotAllowChecked = false;
                                OnOff14.NotAllowChecked = false;
                                OnOff15.NotAllowChecked = false;
                                OnOff16.NotAllowChecked = false;
                                OnOff17.NotAllowChecked = false;
                                OnOff18.NotAllowChecked = false;
                                OnOff19.NotAllowChecked = false;
                                OnOff20.NotAllowChecked = false;
                                OnOff21.NotAllowChecked = false;
                                OnOff22.NotAllowChecked = false;
                                OnOff23.NotAllowChecked = false;
                                OnOff24.NotAllowChecked = false;
                                OnOff25.NotAllowChecked = false;
                                OnOff26.NotAllowChecked = false;
                                SweetFX_Load_Box.Visible = false;
                                foreach (Control text in this.GSetting_Box.Controls)
                                {
                                    if (text.Name.StartsWith("L"))
                                    {
                                        text.ForeColor = Color.Black;
                                    }
                                    if (text.Name.StartsWith("On" + i.ToString()))
                                    {
                                        if (i > 6)
                                        {
                                            text.ForeColor = Color.Black;
                                        }
                                        i--;
                                    }
                                }

                            }
                            else
                            {
                                int i = 26;
                                OnOff6.Checked = false;
                                On6.Text = "关";
                                OnOff7.NotAllowChecked = true;
                                OnOff8.NotAllowChecked = true;
                                OnOff9.NotAllowChecked = true;
                                OnOff10.NotAllowChecked = true;
                                OnOff11.NotAllowChecked = true;
                                OnOff12.NotAllowChecked = true;
                                OnOff13.NotAllowChecked = true;
                                OnOff14.NotAllowChecked = true;
                                OnOff15.NotAllowChecked = true;
                                OnOff16.NotAllowChecked = true;
                                OnOff17.NotAllowChecked = true;
                                OnOff18.NotAllowChecked = true;
                                OnOff19.NotAllowChecked = true;
                                OnOff20.NotAllowChecked = true;
                                OnOff21.NotAllowChecked = true;
                                OnOff22.NotAllowChecked = true;
                                OnOff23.NotAllowChecked = true;
                                OnOff24.NotAllowChecked = true;
                                OnOff25.NotAllowChecked = true;
                                OnOff26.NotAllowChecked = true;
                                SweetFX_Load_Box.Visible = true;
                                foreach (Control text in this.GSetting_Box.Controls)
                                {
                                    if (text.Name.StartsWith("L"))
                                    {
                                        text.ForeColor = Color.FromArgb(100, 153, 153, 153);
                                    }
                                    if (text.Name.StartsWith("On" + i.ToString()))
                                    {
                                        if (i > 6)
                                        {
                                            text.ForeColor = Color.FromArgb(100, 163, 163, 163);
                                        }
                                        i--;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //if (OnOff6.Checked == true)
            //{
            //    Thread SweetFXLoading_Thread = new Thread(SweetFXLoading);
            //    SweetFXLoading_Thread.IsBackground = true;
            //    SweetFXLoading_Thread.Start();
            //}
            //读取数据
            MainForm.Value.Only_SweetSettings_Reading = true;
            SweetFX_Value_Change();
            MainForm.Value.Only_SweetSettings_Reading = false;
            //读取数据
        }

        private void Setting_Load(object sender, EventArgs e)
        {

        }
        //跟界面有关的代码
        private void SettingFormMove_MouseDown(object sender,MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,WS,MOVE + HT, 0);
        }

        private void SettingForm_MouseEnter(object sender,EventArgs e)
        {
            this.Capture = true;
            Button S = (Button)sender;
            S.BackColor = Color.FromArgb(222, 222, 222);
            if (Click_Bool == true)
            {
                button.BackColor = Color.FromArgb(148, 214, 0);
            }
            else
            {
                    if (RCT3启动器.MainForm.Value.Setting_Font_Page == "GSetting")
                    {
                        GSetting.BackColor = Color.FromArgb(148, 214, 0);
                    }
                    else
                    {
                        QSetting.BackColor = Color.FromArgb(148, 214, 0);
                    }
            }
            this.Capture = false;
        }

        private void SettingForm_MouseLeave(object sender,EventArgs e)
        {
            this.Capture = true;
            Button S = (Button)sender;
            S.BackColor = Color.FromArgb(244, 244, 244);
            if (Click_Bool == true)
            {
                button.BackColor = Color.FromArgb(148, 214, 0);
            }
            else
            {
                    if (RCT3启动器.MainForm.Value.Setting_Font_Page == "GSetting")
                    {
                        GSetting.BackColor = Color.FromArgb(148, 214, 0);
                    }
                    else
                    {
                        QSetting.BackColor = Color.FromArgb(148, 214, 0);
                    }
            }
            this.Capture = false;
        }

        private void SettingFormButton_Click(object sender, EventArgs e)
        {
            this.Capture = true;
            Button S = (Button)sender;
            button = S;
            Click_Bool = true;
            this.Capture = false;
            QSetting.BackColor = Color.FromArgb(244, 244, 244);
            GSetting.BackColor = Color.FromArgb(244, 244, 244);
            FXSetting.BackColor = Color.FromArgb(244, 244, 244);
            QUpdate.BackColor = Color.FromArgb(244, 244, 244);
            About.BackColor = Color.FromArgb(244, 244, 244);
            Exit.BackColor = Color.FromArgb(244, 244, 244);
            S.BackColor = Color.FromArgb(148, 214, 0);
            if (S.Name == "Exit")
            {
                this.Hide();
            }
            if (S.Name == "QSetting")
            {
                QSetting_Box.Visible = true;
                GSetting_Box.Visible = false;
                FXSetting_Box.Visible = false;
                QUpdate_Box.Visible = false;
                About_Box.Visible = false;
            }
            if (S.Name == "GSetting")
            {
                QSetting_Box.Visible = false;
                GSetting_Box.Visible = true;
                FXSetting_Box.Visible = false;
                QUpdate_Box.Visible = false;
                About_Box.Visible = false;
            }
            if (S.Name == "FXSetting")
            {
                QSetting_Box.Visible = false;
                GSetting_Box.Visible = false;
                FXSetting_Box.Visible = true;
                QUpdate_Box.Visible = false;
                About_Box.Visible = false;
            }
            if (S.Name == "QUpdate")
            {
                UpdateButton.Enabled = false;
                QSetting_Box.Visible = false;
                GSetting_Box.Visible = false;
                FXSetting_Box.Visible = false;
                QUpdate_Box.Visible = true;
                About_Box.Visible = false;
                //更新日志
                UpdateNews.Text = DateTime.Now.ToString() + " - 提示：启动器已经停止对更新的支持，新版本请关注过山车大亨3吧！";
            }
            if (S.Name == "About")
            {
                QSetting_Box.Visible = false;
                GSetting_Box.Visible = false;
                FXSetting_Box.Visible = false;
                QUpdate_Box.Visible = false;
                About_Box.Visible = true;
            }
        }

        private void SettingForm_Activate(object sender,EventArgs e)
        {
            if (MainForm.Value.Activate_Checked == true)
            {
                if (MainForm.Value.Setting_Font_Page == "QSetting")
                {
                    QSetting.BackColor = Color.FromArgb(148, 214, 0);
                    GSetting.BackColor = Color.FromArgb(244, 244, 244);
                    FXSetting.BackColor = Color.FromArgb(244, 244, 244);
                    QUpdate.BackColor = Color.FromArgb(244, 244, 244);
                    About.BackColor = Color.FromArgb(244, 244, 244);
                    Exit.BackColor = Color.FromArgb(244, 244, 244);
                    Click_Bool = false;
                    QSetting_Box.Visible = true;
                    GSetting_Box.Visible = false;
                    FXSetting_Box.Visible = false;
                    QUpdate_Box.Visible = false;
                    About_Box.Visible = false;
                }
                else
                {
                    QSetting.BackColor = Color.FromArgb(244, 244, 244);
                    GSetting.BackColor = Color.FromArgb(148, 214, 0);
                    FXSetting.BackColor = Color.FromArgb(244, 244, 244);
                    QUpdate.BackColor = Color.FromArgb(244, 244, 244);
                    About.BackColor = Color.FromArgb(244, 244, 244);
                    Exit.BackColor = Color.FromArgb(244, 244, 244);
                    Click_Bool = false;
                    QSetting_Box.Visible = false;
                    GSetting_Box.Visible = true;
                    FXSetting_Box.Visible = false;
                    QUpdate_Box.Visible = false;
                    About_Box.Visible = false;
                }
                MainForm.Value.Activate_Checked = false;
            }
        }

        private void FXSettings_MouseEnter(object sender,EventArgs e)
        {
            this.Capture = true;
            Button S = (Button)sender;
            if (!(S.BackColor == Color.FromArgb(255, 210, 210, 210)))
            {
                S.BackColor = Color.FromArgb(230, 230, 230);
            }
            this.Capture = false;
        }

        private void FXSettings_MouseLeave(object sender,EventArgs e)
        {
            this.Capture = true;
            Button S = (Button)sender;
            if (!(S.BackColor == Color.FromArgb(255, 210, 210, 210)))
            {
                S.BackColor = Color.FromArgb(255, 255, 255);
            }
            this.Capture = false;
        }

        private void FXSettingsButton_Click(object sender, EventArgs e)
        {
            this.Capture = true;
            Button S = (Button)sender;
            button1.BackColor = Color.FromArgb(255, 255, 255);
            button2.BackColor = Color.FromArgb(255, 255, 255);
            button3.BackColor = Color.FromArgb(255, 255, 255);
            button4.BackColor = Color.FromArgb(255, 255, 255);
            S.BackColor = Color.FromArgb(210, 210, 210);
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            for (int i = 1; i < 5; i++)
            {
                if (S.Name == "button" + i.ToString())
                {
                    foreach (Control panel in this.FXSetting_Box.Controls)
                    {
                        if (panel.Name == "panel" + i.ToString())
                        {
                            panel.Visible = true;
                        }
                    }
                }
            }
            this.Capture = false;
        }
        //跟界面有关的代码

        private void Update_Setting_Set(string root,string setting_item,string value)
        {
            XmlDocument Setting = new XmlDocument();
            Setting.Load("Setting.set");
            XmlElement Set = Setting.DocumentElement;
            XmlNodeList Settings = Set.ChildNodes;
            foreach (XmlNode QS in Settings)
            {
                if (QS.Attributes["id"].InnerText == root)
                {
                    XmlNodeList QSettings = QS.ChildNodes;
                    foreach (XmlNode AD in QSettings)
                    {
                        if (AD.Attributes["id"].InnerText == setting_item)
                        {
                            AD.InnerText = value;
                        }
                    }
                }
            }
            Setting.Save("Setting.set");
        }//更新set文件

        private void OnOff1_Click(object sender, EventArgs e)
        {
            if (OnOff1.Checked == true)
            {
                On1.Text = "开";
                MainForm.Value.Started_Run = true;
            }
            else
            {
                On1.Text = "关";
                MainForm.Value.Started_Run = false;
            }
            Update_Setting_Set("0", "1", OnOff1.Checked.ToString());
        }

        private void OnOff2_Click(object sender, EventArgs e)
        {
            if (OnOff2.Checked == true)
                On2.Text = "开";
            else
                On2.Text = "关";
            Update_Setting_Set("0", "2", OnOff2.Checked.ToString());
        }

        private void OnOff3_Click(object sender, EventArgs e)
        {
            if (OnOff3.Checked == true)
            {
                MainForm.Value.optimize = true;
                On3.Text = "开";
            }
            else
            {
                MainForm.Value.optimize = false;
                On3.Text = "关";
            }
            MainForm.Value.AC.Focus();
            Update_Setting_Set("0", "3", OnOff3.Checked.ToString());
        }

        private void OnOff4_Click(object sender, EventArgs e)
        {
            if (OnOff4.Checked == true)
            {
                On4.Text = "开";
                MainForm.Value.Auto_Check_Update = true;
            }
            else
            {
                On4.Text = "关";
                MainForm.Value.Auto_Check_Update = false;
            }
            Update_Setting_Set("0", "4", OnOff4.Checked.ToString());
        }

        private void OnOff5_Click(object sender, EventArgs e)
        {
            bool old = OnOff5.Checked;
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path))
            {
                int S;
                if (OnOff5.Checked == true)
                {
                    On5.Text = "开";
                    S = 1;
                }
                else
                {
                    On5.Text = "关";
                    S = 0;
                }
                //更改Options.txt
                FileStream Options = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader Option = new StreamReader(Options, Encoding.Default);
                string Change = Option.ReadToEnd();
                Regex r = new Regex(@"Fullscreen\s{1,}\d");
                if (r.IsMatch(Change))
                {
                    Change = r.Replace(Change, "Fullscreen " + S);
                    StreamWriter New_Options = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path, false, Encoding.Default);
                    New_Options.Write(Change);
                    New_Options.Flush();
                    New_Options.Close();
                }
                else
                {
                    Change = Change + " Fullscreen " + S;
                    StreamWriter New_Options = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path, false, Encoding.Default);
                    New_Options.Write(Change);
                    New_Options.Flush();
                    New_Options.Close();                    
                }
                Option.Close();
                Options.Close();
                Update_Setting_Set("6", "8", OnOff5.Checked.ToString());
            }
            else
            {
                OnOff5.Checked = old;
            }
        }

        private void OnOff27_Click(object sender, EventArgs e)
        {
            bool old = OnOff27.Checked;
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path))
            {
                int S;
                if (OnOff27.Checked == true)
                {
                    On27.Text = "开";
                    S = 1;
                }
                else
                {
                    On27.Text = "关";
                    S = 0;
                }
                //更改Options.txt
                FileStream Options = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader Option = new StreamReader(Options, Encoding.Default);
                string Change = Option.ReadToEnd();
                Regex r = new Regex(@"TrackAllowSameTrackIntersect\s{1,}\d");
                if (r.IsMatch(Change))
                {
                    Change = r.Replace(Change, "TrackAllowSameTrackIntersect " + S);
                    StreamWriter New_Options = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path, false, Encoding.Default);
                    New_Options.Write(Change);
                    New_Options.Flush();
                    New_Options.Close();
                }
                else
                {
                    Change = Change + " TrackAllowSameTrackIntersect " + S;
                    StreamWriter New_Options = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path, false, Encoding.Default);
                    New_Options.Write(Change);
                    New_Options.Flush();
                    New_Options.Close();
                }
                Option.Close();
                Options.Close();
                Update_Setting_Set("6", "10", OnOff27.Checked.ToString());
            }
            else
            {
                OnOff27.Checked = old;
            }
        }

        private void OnOff6_Click(object sender, EventArgs e)
        {
            int i = 26;
            if (OnOff6.Checked == true & !File.Exists(Address.Text + "\\SweetFX_settings.txt"))
            {
                if (MessageBox.Show("SweetFX为第三方插件，本启动器仅作为增强插件使用，故如您因使用SweetFX所造成的一切后果均与本启动器无关，作者不会承担责任！点击确定以后将会开始安装SweetFX，安装完成会出现提示！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    OnOff6.NotAllowChecked = true;
                    On6.Text = "正在安装....";
                    //安装SweetFX
                    Directory.CreateDirectory(Address.Text + "\\SweetFX");
                    Directory.CreateDirectory(Address.Text + "\\SweetFX\\Shaders");
                    Directory.CreateDirectory(Address.Text + "\\SweetFX\\Presets");
                    Directory.CreateDirectory(Address.Text + "\\SweetFX\\dlls");
                    Directory.CreateDirectory(Address.Text + "\\SweetFX\\dlls\\SMAA dlls");
                    Directory.CreateDirectory(Address.Text + "\\SweetFX\\dlls\\FXAA DX9 dll");
                    Assembly a = Assembly.GetExecutingAssembly();
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.SweetFX_settings.txt"), File.Open(Address.Text + "\\SweetFX_settings.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.SweetFX_preset.txt"), File.Open(Address.Text + "\\SweetFX_preset.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.SweetFX readme.txt"), File.Open(Address.Text + "\\SweetFX readme.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.shader.fx"), File.Open(Address.Text + "\\shader.fx", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.log.log"), File.Open(Address.Text + "\\log.log", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.injector.ini"), File.Open(Address.Text + "\\injector.ini", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.dxgi.fx"), File.Open(Address.Text + "\\dxgi.fx", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.dxgi.dll"), File.Open(Address.Text + "\\dxgi.dll", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.d3d9.fx"), File.Open(Address.Text + "\\d3d9.fx", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.d3d9.dll"), File.Open(Address.Text + "\\d3d9.dll", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.SweetFX_compatibility_settings.txt"), File.Open(Address.Text + "\\SweetFX\\SweetFX_compatibility_settings.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Making shaders.txt"), File.Open(Address.Text + "\\SweetFX\\Making shaders.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Game_compability.txt"), File.Open(Address.Text + "\\SweetFX\\Game_compability.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Vignette.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Vignette.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Vibrance.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Vibrance.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Tonemap.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Tonemap.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Technicolor.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Technicolor.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.SweetCRT.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\SweetCRT.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Splitscreen.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Splitscreen.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.SMAA.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\SMAA.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Sepia.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Sepia.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Monochrome.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Monochrome.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Main.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Main.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.LumaSharpen.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\LumaSharpen.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.LiftGammaGain.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\LiftGammaGain.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Levels.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Levels.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.HDR.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\HDR.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Fxaa3_11.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Fxaa3_11.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Explosion.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Explosion.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.DPX.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\DPX.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Dither.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Dither.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Custom.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Custom.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Curves.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Curves.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Cartoon.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Cartoon.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Border.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Border.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Bloom.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\Bloom.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.AdvancedCRT.h"), File.Open(Address.Text + "\\SweetFX\\Shaders\\AdvancedCRT.h", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Torchlight2_TFL.txt"), File.Open(Address.Text + "\\SweetFX\\Presets\\Torchlight2_TFL.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Torchlight2_BetA.txt"), File.Open(Address.Text + "\\SweetFX\\Presets\\Torchlight2_BetA.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Mount&Blade_Warband_TFL.txt"), File.Open(Address.Text + "\\SweetFX\\Presets\\Mount&Blade_Warband_TFL.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Default_1.5_settings.txt"), File.Open(Address.Text + "\\SweetFX\\Presets\\Default_1.5_settings.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Black_Mesa_CeeJay.txt"), File.Open(Address.Text + "\\SweetFX\\Presets\\Black_Mesa_CeeJay.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.Battlefield 3_Derko1.txt"), File.Open(Address.Text + "\\SweetFX\\Presets\\Battlefield 3_Derko1.txt", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.d3d9SMAA.dll"), File.Open(Address.Text + "\\SweetFX\\dlls\\SMAA dlls\\d3d9.dll", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.dxgiSMAA.dll"), File.Open(Address.Text + "\\SweetFX\\dlls\\SMAA dlls\\dxgi.dll", FileMode.Create));
                    CopyStream(a.GetManifestResourceStream("RCT3启动器.Resources.d3d9FXAA.dll"), File.Open(Address.Text + "\\SweetFX\\dlls\\FXAA DX9 dll\\d3d9.dll", FileMode.Create));
                    //读取数据
                    MainForm.Value.Only_SweetSettings_Reading = true;
                    SweetFX_Value_Change();
                    MainForm.Value.Only_SweetSettings_Reading = false;
                    //读取数据
                    MessageBox.Show("SweetFX已经安装完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    On6.Text = "开";
                    OnOff6.NotAllowChecked = false;
                    //控制设置项能否被设置
                    OnOff7.NotAllowChecked = false;
                    OnOff8.NotAllowChecked = false;
                    OnOff9.NotAllowChecked = false;
                    OnOff10.NotAllowChecked = false;
                    OnOff11.NotAllowChecked = false;
                    OnOff12.NotAllowChecked = false;
                    OnOff13.NotAllowChecked = false;
                    OnOff14.NotAllowChecked = false;
                    OnOff15.NotAllowChecked = false;
                    OnOff16.NotAllowChecked = false;
                    OnOff17.NotAllowChecked = false;
                    OnOff18.NotAllowChecked = false;
                    OnOff19.NotAllowChecked = false;
                    OnOff20.NotAllowChecked = false;
                    OnOff21.NotAllowChecked = false;
                    OnOff22.NotAllowChecked = false;
                    OnOff23.NotAllowChecked = false;
                    OnOff24.NotAllowChecked = false;
                    OnOff25.NotAllowChecked = false;
                    OnOff26.NotAllowChecked = false;
                    SweetFX_Load_Box.Visible = false;
                    foreach (Control text in this.GSetting_Box.Controls)
                    {
                        if (text.Name.StartsWith("L"))
                        {
                            text.ForeColor = Color.Black;
                        }
                        if (text.Name.StartsWith("On" + i.ToString()))
                        {
                            if (i > 6)
                            {
                                text.ForeColor = Color.Black;
                            }
                            i--;
                        }
                    }
                }
                else
                {
                    OnOff6.Checked = false;
                    //控制设置项能否被设置
                    OnOff7.NotAllowChecked = true;
                    OnOff8.NotAllowChecked = true;
                    OnOff9.NotAllowChecked = true;
                    OnOff10.NotAllowChecked = true;
                    OnOff11.NotAllowChecked = true;
                    OnOff12.NotAllowChecked = true;
                    OnOff13.NotAllowChecked = true;
                    OnOff14.NotAllowChecked = true;
                    OnOff15.NotAllowChecked = true;
                    OnOff16.NotAllowChecked = true;
                    OnOff17.NotAllowChecked = true;
                    OnOff18.NotAllowChecked = true;
                    OnOff19.NotAllowChecked = true;
                    OnOff20.NotAllowChecked = true;
                    OnOff21.NotAllowChecked = true;
                    OnOff22.NotAllowChecked = true;
                    OnOff23.NotAllowChecked = true;
                    OnOff24.NotAllowChecked = true;
                    OnOff25.NotAllowChecked = true;
                    OnOff26.NotAllowChecked = true;
                    SweetFX_Load_Box.Visible = true;
                    foreach (Control text in this.GSetting_Box.Controls)
                    {
                        if (text.Name.StartsWith("L"))
                        {
                            text.ForeColor = Color.FromArgb(100, 153, 153, 153);
                        }
                        if (text.Name.StartsWith("On" + i.ToString()))
                        {
                            if (i > 6)
                            {
                                text.ForeColor = Color.FromArgb(100, 163, 163, 163);
                            }
                            i--;
                        }
                    }
                }
            }
            else
            {
                if (MessageBox.Show("此操作会卸载SweetFX，如要继续点击确定！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    On6.Text = "正在卸载....";
                    OnOff6.NotAllowChecked = true;
                    //清理SweetFX文件
                    DirectoryInfo SweetFX = new DirectoryInfo(Address.Text+"\\SweetFX");
                    SweetFX.Delete(true);
                    File.Delete(Address.Text + "\\SweetFX_settings.txt");
                    File.Delete(Address.Text + "\\SweetFX_preset.txt");
                    File.Delete(Address.Text + "\\SweetFX readme.txt");
                    File.Delete(Address.Text + "\\shader.fx");
                    File.Delete(Address.Text + "\\log.log");
                    File.Delete(Address.Text + "\\injector.ini");
                    File.Delete(Address.Text + "\\dxgi.fx");
                    File.Delete(Address.Text + "\\dxgi.dll");
                    File.Delete(Address.Text + "\\d3d9.fx");
                    File.Delete(Address.Text + "\\d3d9.dll");
                    MessageBox.Show("SweetFX已经卸载完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    On6.Text = "关";
                    OnOff6.NotAllowChecked = false;
                    //控制设置项能否被设置
                    OnOff7.NotAllowChecked = true;
                    OnOff8.NotAllowChecked = true;
                    OnOff9.NotAllowChecked = true;
                    OnOff10.NotAllowChecked = true;
                    OnOff11.NotAllowChecked = true;
                    OnOff12.NotAllowChecked = true;
                    OnOff13.NotAllowChecked = true;
                    OnOff14.NotAllowChecked = true;
                    OnOff15.NotAllowChecked = true;
                    OnOff16.NotAllowChecked = true;
                    OnOff17.NotAllowChecked = true;
                    OnOff18.NotAllowChecked = true;
                    OnOff19.NotAllowChecked = true;
                    OnOff20.NotAllowChecked = true;
                    OnOff21.NotAllowChecked = true;
                    OnOff22.NotAllowChecked = true;
                    OnOff23.NotAllowChecked = true;
                    OnOff24.NotAllowChecked = true;
                    OnOff25.NotAllowChecked = true;
                    OnOff26.NotAllowChecked = true;
                    SweetFX_Load_Box.Visible = true;
                    foreach (Control text in this.GSetting_Box.Controls)
                    {
                        if (text.Name.StartsWith("L"))
                        {
                            text.ForeColor = Color.FromArgb(100, 153, 153, 153);
                        }
                        if (text.Name.StartsWith("On" + i.ToString()))
                        {
                            if (i > 6)
                            {
                                text.ForeColor = Color.FromArgb(100, 163, 163, 163);
                            }
                            i--;
                        }
                    }
                }
                else
                {
                    OnOff6.Checked = true;
                    //控制设置项能否被设置
                    OnOff7.NotAllowChecked = false;
                    OnOff8.NotAllowChecked = false;
                    OnOff9.NotAllowChecked = false;
                    OnOff10.NotAllowChecked = false;
                    OnOff11.NotAllowChecked = false;
                    OnOff12.NotAllowChecked = false;
                    OnOff13.NotAllowChecked = false;
                    OnOff14.NotAllowChecked = false;
                    OnOff15.NotAllowChecked = false;
                    OnOff16.NotAllowChecked = false;
                    OnOff17.NotAllowChecked = false;
                    OnOff18.NotAllowChecked = false;
                    OnOff19.NotAllowChecked = false;
                    OnOff20.NotAllowChecked = false;
                    OnOff21.NotAllowChecked = false;
                    OnOff22.NotAllowChecked = false;
                    OnOff23.NotAllowChecked = false;
                    OnOff24.NotAllowChecked = false;
                    OnOff25.NotAllowChecked = false;
                    OnOff26.NotAllowChecked = false;
                    SweetFX_Load_Box.Visible = false;
                    foreach (Control text in this.GSetting_Box.Controls)
                    {
                        if (text.Name.StartsWith("L"))
                        {
                            text.ForeColor = Color.Black;
                        }
                        if (text.Name.StartsWith("On" + i.ToString()))
                        {
                            if (i > 6)
                            {
                                text.ForeColor = Color.Black;
                            }
                            i--;
                        }
                    }
                }
            }
            Update_Setting_Set("6", "9", OnOff6.Checked.ToString());
        }

        public static void CopyStream(Stream i, Stream o)
        {
            byte[] b = new byte[32768];
            while (true)
            {
                int r = i.Read(b, 0, b.Length);
                if (r <= 0)
                {
                    i.Close();
                    o.Close();
                    return;
                }
                o.Write(b, 0, r);
            }
        }//安装SweetFX

        private void OnOff7_Click(object sender, EventArgs e)
        {
            if (OnOff7.Checked == true)
            {
                On7.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_SMAA_ANTIALIASING",S);
            }
            else
            {
                On7.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_SMAA_ANTIALIASING", S);
            }
        }

        private void OnOff8_Click(object sender, EventArgs e)
        {
            if (OnOff8.Checked == true)
            {
                On8.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_EXPLOSION", S);
            }
            else
            {
                On8.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_EXPLOSION", S);
            }
        }

        private void OnOff9_Click(object sender, EventArgs e)
        {
            if (OnOff9.Checked == true)
            {
                On9.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_CARTOON", S);
            }
            else
            {
                On9.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_CARTOON", S);
            }
        }

        private void OnOff10_Click(object sender, EventArgs e)
        {
            if (OnOff10.Checked == true)
            {
                On10.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_ADVANCED_CRT", S);
            }
            else
            {
                On10.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_ADVANCED_CRT", S);
            }
        }

        private void OnOff11_Click(object sender, EventArgs e)
        {
            if (OnOff11.Checked == true)
            {
                On11.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_BLOOM", S);
            }
            else
            {
                On11.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_BLOOM", S);
            }
        }

        private void OnOff12_Click(object sender, EventArgs e)
        {
            if (OnOff12.Checked == true)
            {
                On12.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_HDR", S);
            }
            else
            {
                On12.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_HDR", S);
            }
        }

        private void OnOff13_Click(object sender, EventArgs e)
        {
            if (OnOff13.Checked == true)
            {
                On13.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_LUMASHARPEN", S);
            }
            else
            {
                On13.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_LUMASHARPEN", S);
            }
        }

        private void OnOff14_Click(object sender, EventArgs e)
        {
            if (OnOff14.Checked == true)
            {
                On14.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_LEVELS", S);
            }
            else
            {
                On14.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_LEVELS", S);
            }
        }

        private void OnOff15_Click(object sender, EventArgs e)
        {
            if (OnOff15.Checked == true)
            {
                On15.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_TECHNICOLOR", S);
            }
            else
            {
                On15.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_TECHNICOLOR", S);
            }
        }

        private void OnOff16_Click(object sender, EventArgs e)
        {
            
            if (OnOff16.Checked == true)
            {
                On16.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_DPX", S);
            }
            else
            {
                On16.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_DPX", S);
            }
        }

        private void OnOff17_Click(object sender, EventArgs e)
        {
            
            if (OnOff17.Checked == true)
            {
                On17.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_MONOCHROME", S);
            }
            else
            {
                On17.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_MONOCHROME", S);
            }
        }

        private void OnOff18_Click(object sender, EventArgs e)
        {
            
            if (OnOff18.Checked == true)
            {
                On18.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_LIFTGAMMAGAIN", S);
            }
            else
            {
                On18.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_LIFTGAMMAGAIN", S);
            }
        }

        private void OnOff19_Click(object sender, EventArgs e)
        {
            
            if (OnOff19.Checked == true)
            {
                On19.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_TONEMAP", S);
            }
            else
            {
                On19.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_TONEMAP", S);
            }
        }

        private void OnOff20_Click(object sender, EventArgs e)
        {
            
            if (OnOff20.Checked == true)
            {
                On20.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_VIBRANCE", S);
            }
            else
            {
                On20.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_VIBRANCE", S);
            }
        }

        private void OnOff21_Click(object sender, EventArgs e)
        {
            
            if (OnOff21.Checked == true)
            {
                On21.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_CURVES", S);
            }
            else
            {
                On21.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_CURVES", S);
            }
        }

        private void OnOff22_Click(object sender, EventArgs e)
        {
            
            if (OnOff22.Checked == true)
            {
                On22.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_SEPIA", S);
            }
            else
            {
                On22.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_SEPIA", S);
            }
        }

        private void OnOff23_Click(object sender, EventArgs e)
        {
            
            if (OnOff23.Checked == true)
            {
                On23.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_VIGNETTE", S);
            }
            else
            {
                On23.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_VIGNETTE", S);
            }
        }

        private void OnOff24_Click(object sender, EventArgs e)
        {
            
            if (OnOff24.Checked == true)
            {
                On24.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_DITHER", S);
            }
            else
            {
                On24.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_DITHER", S);
            }
        }

        private void OnOff25_Click(object sender, EventArgs e)
        {
            
            if (OnOff25.Checked == true)
            {
                On25.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_BORDER", S);
            }
            else
            {
                On25.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_BORDER", S);
            }
        }

        private void OnOff26_Click(object sender, EventArgs e)
        {
            
            if (OnOff26.Checked == true)
            {
                On26.Text = "开";
                string[] S = new string[1];
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "USE_SPLITSCREEN", S);
            }
            else
            {
                On26.Text = "关";
                string[] S = new string[1];
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "USE_SPLITSCREEN", S);
            }
        }

        private void ChooseAddress_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Game = new FolderBrowserDialog();
            Game.ShowDialog();       
            if (!File.Exists(Game.SelectedPath + "//" + Game_Exe_Name))
            {
                MessageBox.Show("请选择正确的游戏目录！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                MainForm.Value.Game_Address = Game.SelectedPath;
                Address.Text = MainForm.Value.Game_Address;
                XmlDocument Setting = new XmlDocument();
                Setting.Load("Setting.set");
                XmlElement Set = Setting.DocumentElement;
                XmlNodeList Settings = Set.ChildNodes;
                foreach (XmlNode QS in Settings)
                {
                    if (QS.Attributes["id"].InnerText == "0")
                    {
                        XmlNodeList QSettings = QS.ChildNodes;
                        foreach (XmlNode AD in QSettings)
                        {
                            if (AD.Attributes["id"].InnerText == "5")
                            {
                                AD.InnerText = MainForm.Value.Game_Address;
                            }
                        }
                    }
                }
                Setting.Save("Setting.set");
            }
        }

        private void Resolution_Set_SelectedIndexChanged(object sender, EventArgs e)
        {
            int old = Resolution_Set.SelectedIndex;
            if (this.Resolution_Set.SelectedIndex != -1)
            {
                switch (Resolution_Set.SelectedIndex)
                {
                    case 0:
                        X = 800;
                        Y = 600;
                        break;
                    case 1:
                        X = 1024;
                        Y = 600;
                        break;
                    case 3:
                        X = 1024;
                        Y = 768;
                        break;
                    case 4:
                        X = 1152;
                        Y = 864;
                        break;
                    case 5:
                        X = 1280;
                        Y = 720;
                        break;
                    case 6:
                        X = 1280;
                        Y = 768;
                        break;
                    case 7:
                        X = 1280;
                        Y = 800;
                        break;
                    case 8:
                        X = 1280;
                        Y = 960;
                        break;
                    case 9:
                        X = 1360;
                        Y = 768;
                        break;
                    case 10:
                        X = 1366;
                        Y = 768;
                        break;
                    case 11:
                        X = 1440;
                        Y = 900;
                        break;
                    case 12:
                        X = 1600;
                        Y = 900;
                        break;
                    case 13:
                        X = 1600;
                        Y = 1024;
                        break;
                    case 14:
                        X = 1600;
                        Y = 1050;
                        break;
                    case 15:
                        X = 1920;
                        Y = 1080;
                        break;
                }
                //更改Options.txt
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path))//Setting窗体一运行就会进行检测，无需再写
                {
                    FileStream Options = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader Option = new StreamReader(Options, Encoding.Default);
                    String Change = Option.ReadToEnd();
                    Regex r = new Regex(@"Resolution \d*? \d*");
                    if (r.IsMatch(Change))
                    {
                        Change = r.Replace(Change, "Resolution " + X + " " + Y);
                        StreamWriter New_Options = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path, false, Encoding.Default);
                        New_Options.Write(Change);
                        New_Options.Flush();
                        New_Options.Close();
                    }
                    else
                    {
                        Change = Change + "Resolution " + X + " " + Y;
                        StreamWriter New_Options = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Game_Options_Path, false, Encoding.Default);
                        New_Options.Write(Change);
                        New_Options.Flush();
                        New_Options.Close();
                    }
                    Option.Close();
                    Options.Close();
                    //更新set文件
                    XmlDocument Setting = new XmlDocument();
                    Setting.Load("Setting.set");
                    XmlElement Set = Setting.DocumentElement;
                    XmlNodeList Settings = Set.ChildNodes;
                    foreach (XmlNode GS in Settings)
                    {
                        if (GS.Attributes["id"].InnerText == "6")
                        {
                            XmlNodeList GSettings = GS.ChildNodes;
                            foreach (XmlNode AD in GSettings)
                            {
                                if (AD.Attributes["id"].InnerText == "7")
                                {
                                    AD.InnerText = X + "*" + Y;
                                }
                            }
                        }
                    }
                    Setting.Save("Setting.set");
                }
                else
                {
                    MessageBox.Show("请检查Options.txt文件是否存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Resolution_Set.SelectedIndex = old;
                }
            }
        }//更改分辨率

        private Control FindControl(string ControlName)
        {
            Control Q = null;//存放搜索结果的变量
            List<Control> panels = new List<Control> { };//定义一个空控件集合，用来储存panels
            List<Control> text = new List<Control> { };//测试
            foreach(Control control in this.FXSetting_Box.Controls)//从主窗体中查找控件
            {
                if(control.Name == ControlName)//如果符合便返回
                {
                    Q = control;
                }
                else
                {
                    if (control is Panel)//如果控件是Panel类型就存入panels
                    {
                        panels.Add(control);
                    }                    
                }
                text.Add(control);
            }
            for(int i=0;i<panels.Count;i++)//i是循环和搜索变量
            {
                foreach(Control control in panels[i].Controls)//从panels中取出第i个Panel搜索里面的控件
                {
                    if(control.Name==ControlName)//如果符合便返回
                    {
                        Q = control;
                    }
                    else
                    {
                        if(control is Panel)//如果控件是Panel类型就存入panels
                        {
                            panels.Add(control);
                        }
                    }
                    text.Add(control);
                }
            }
            return Q;//返回结果
        }

        private void SweetFX_Value_Change()
        {
            if (OnOff6.Checked)
            {
                int i = 7;//OnOff控件计数量
                StreamReader Txt = new StreamReader(MainForm.Value.Game_Address + "\\SweetFX_settings.txt");//读取SweetFX配置文件
                Regex Setting = new Regex(@"#\D{0,}\d{0,}\D{1,}\s");//匹配选项
                Regex Moved_Number = new Regex(@"\s\d{1,}");
                List<string> settings = new List<string> { };
                foreach (Match x in Setting.Matches(Txt.ReadToEnd()))
                {
                    string Q = x.Value.Replace("#define ", "");
                    string q = (Moved_Number.Replace(Q, "")).Replace(" ", "");
                    settings.Add(q);
                }//保存选项
                Txt.Close();//关闭读取流
                foreach (string x in settings)
                {
                    foreach (string X in SweetFX.FindSweetFXItem(MainForm.Value.Game_Address, x))
                    {
                        switch (x)
                        {
                            case "COLOR_EDGE_DETECTION":
                                if (X == "0")
                                {
                                    COLOR_EDGE_DETECTION_0.Checked = true;
                                }
                                else
                                {
                                    COLOR_EDGE_DETECTION_1.Checked = true;
                                }
                                break;
                            case "SMAA_DIRECTX9_LINEAR_BLEND":
                                if (X == "0")
                                {
                                    SMAA_DIRECTX9_LINEAR_BLEND_0.Checked = true;
                                }
                                else
                                {
                                    SMAA_DIRECTX9_LINEAR_BLEND_1.Checked = true;
                                }
                                break;
                            case "pattern":
                                switch (X)
                                {
                                    case "1":
                                        pattern_1.Checked = true;
                                        break;
                                    case "2":
                                        pattern_2.Checked = true;
                                        break;
                                    case "3":
                                        pattern_3.Checked = true;
                                        break;
                                    case "4":
                                        pattern_4.Checked = true;
                                        break;
                                }
                                break;
                            case "show_sharpen":
                                if (X == "0")
                                {
                                    show_sharpen_0.Checked = true;
                                }
                                else
                                {
                                    show_sharpen_1.Checked = true;
                                }
                                break;
                            case "CRTScanlineGaussian":
                                if (X == "0")
                                {
                                    CRTScanlineGaussian_0.Checked = true;
                                }
                                else
                                {
                                    CRTScanlineGaussian_1.Checked = true;
                                }
                                break;
                            case "CRTCurvature":
                                if (X == "0")
                                {
                                    CRTCurvature_0.Checked = true;
                                }
                                else
                                {
                                    CRTCurvature_1.Checked = true;
                                }
                                break;
                            case "CRTOversample":
                                if (X == "0")
                                {
                                    CRTOversample_0.Checked = true;
                                }
                                else
                                {
                                    CRTOversample_1.Checked = true;
                                }
                                break;
                            case "Curves_mode":
                                switch (X)
                                {
                                    case "0":
                                        Curves_mode_0.Checked = true;
                                        break;
                                    case "1":
                                        Curves_mode_1.Checked = true;
                                        break;
                                    case "2":
                                        Curves_mode_2.Checked = true;
                                        break;
                                }
                                break;
                            case "Curves_formula":
                                switch (X)
                                {
                                    case "1":
                                        Curves_formula_1.Checked = true;
                                        break;
                                    case "2":
                                        Curves_formula_2.Checked = true;
                                        break;
                                    case "3":
                                        Curves_formula_3.Checked = true;
                                        break;
                                    case "4":
                                        Curves_formula_4.Checked = true;
                                        break;
                                    case "5":
                                        Curves_formula_5.Checked = true;
                                        break;
                                    case "6":
                                        Curves_formula_6.Checked = true;
                                        break;
                                    case "7":
                                        Curves_formula_7.Checked = true;
                                        break;
                                    case "8":
                                        Curves_formula_8.Checked = true;
                                        break;
                                    case "9":
                                        Curves_formula_9.Checked = true;
                                        break;
                                    case "10":
                                        Curves_formula_10.Checked = true;
                                        break;
                                }
                                break;
                            case "VignetteType":
                                switch (X)
                                {
                                    case "1":
                                        VignetteType_1.Checked = true;
                                        break;
                                    case "2":
                                        VignetteType_2.Checked = true;
                                        break;
                                    case "3":
                                        VignetteType_3.Checked = true;
                                        break;
                                }
                                break;
                            case "dither_method":
                                switch (X)
                                {
                                    case "1":
                                        dither_method_1.Checked = true;
                                        break;
                                    case "2":
                                        dither_method_2.Checked = true;
                                        break;
                                }
                                break;
                            case "splitscreen_mode":
                                switch (X)
                                {
                                    case "1":
                                        splitscreen_mode_1.Checked = true;
                                        break;
                                    case "2":
                                        splitscreen_mode_2.Checked = true;
                                        break;
                                    case "3":
                                        splitscreen_mode_3.Checked = true;
                                        break;
                                    case "4":
                                        splitscreen_mode_4.Checked = true;
                                        break;
                                    case "5":
                                        splitscreen_mode_5.Checked = true;
                                        break;
                                    case "6":

                                        break;
                                }
                                break;
                            default:
                                if ((!(x.StartsWith("USE"))) & (!(x.StartsWith("FXAA"))) & (!(x.StartsWith("fxaa"))))
                                {
                                    string[] S = SweetFX.FindSweetFXItem(MainForm.Value.Game_Address, x);
                                    if (S.Length >= 2)
                                    {
                                        if (x == "Monochrome_conversion_values")
                                        {
                                            if (S[0] == null)
                                            {
                                                Monochrome_conversion_values_R.Value = 0;
                                            }
                                            else
                                            {
                                                Monochrome_conversion_values_R.Value = Double_To_ScrollValue(S[0]);
                                            }
                                            if (S[1] == null)
                                            {
                                                Monochrome_conversion_values_G.Value = 0;
                                            }
                                            else
                                            {
                                                Monochrome_conversion_values_G.Value = Double_To_ScrollValue(S[1]);
                                            }
                                            if (S[2] == null)
                                            {
                                                Monochrome_conversion_values_B.Value = 0;
                                            }
                                            else
                                            {
                                                Monochrome_conversion_values_B.Value = Double_To_ScrollValue(S[2]);
                                            }
                                        }
                                        if (x == "RGB_Lift")
                                        {
                                            if (S[0] == null)
                                            {
                                                RGB_Lift_R.Value = 0;
                                            }
                                            else
                                            {
                                                RGB_Lift_R.Value = Double_To_ScrollValue(S[0]);
                                            }
                                            if (S[1] == null)
                                            {
                                                RGB_Lift_G.Value = 0;
                                            }
                                            else
                                            {
                                                RGB_Lift_G.Value = Double_To_ScrollValue(S[1]);
                                            }
                                            if (S[2] == null)
                                            {
                                                RGB_Lift_B.Value = 0;
                                            }
                                            else
                                            {
                                                RGB_Lift_B.Value = Double_To_ScrollValue(S[2]);
                                            }
                                        }
                                        if (x == "RGB_Gamma")
                                        {
                                            if (S[0] == null)
                                            {
                                                RGB_Gamma_R.Value = 0;
                                            }
                                            else
                                            {
                                                RGB_Gamma_R.Value = Double_To_ScrollValue(S[0]);
                                            }
                                            if (S[1] == null)
                                            {
                                                RGB_Gamma_G.Value = 0;
                                            }
                                            else
                                            {
                                                RGB_Gamma_G.Value = Double_To_ScrollValue(S[1]);
                                            }
                                            if (S[2] == null)
                                            {
                                                RGB_Gamma_B.Value = 0;
                                            }
                                            else
                                            {
                                                RGB_Gamma_B.Value = Double_To_ScrollValue(S[1]);
                                            }
                                        }
                                        if (x == "RGB_Gain")
                                        {
                                            if (S[0] == null)
                                            {
                                                RGB_Gain_R.Value = 0;
                                            }
                                            else
                                            {
                                                RGB_Gain_R.Value = Double_To_ScrollValue(S[0]);
                                            }
                                            if (S[1] == null)
                                            {
                                                RGB_Gain_G.Value = 0;
                                            }
                                            else
                                            {
                                                RGB_Gain_G.Value = Double_To_ScrollValue(S[1]);
                                            }
                                            if (S[2] == null)
                                            {
                                                RGB_Gain_B.Value = 0;
                                            }
                                            else
                                            {
                                                RGB_Gain_B.Value = Double_To_ScrollValue(S[2]);
                                            }
                                        }
                                        if (x == "FogColor")
                                        {
                                            if (S[0] == null)
                                            {
                                                FogColor_R.Value = 0;
                                            }
                                            else
                                            {
                                                FogColor_R.Value = Double_To_ScrollValue(S[0]);
                                            }
                                            if (S[1] == null)
                                            {
                                                FogColor_G.Value = 0;
                                            }
                                            else
                                            {
                                                FogColor_G.Value = Double_To_ScrollValue(S[1]);
                                            }
                                            if (S[2] == null)
                                            {
                                                FogColor_B.Value = 0;
                                            }
                                            else
                                            {
                                                FogColor_B.Value = Double_To_ScrollValue(S[2]);
                                            }
                                        }
                                        if (x == "Vibrance_RGB_balance")
                                        {
                                            if (S[0] == null)
                                            {
                                                Vibrance_RGB_balance_R.Value = 0;
                                            }
                                            else
                                            {
                                                Vibrance_RGB_balance_R.Value = Double_To_ScrollValue(S[0]);
                                            }
                                            if (S[1] == null)
                                            {
                                                Vibrance_RGB_balance_G.Value = 0;
                                            }
                                            else
                                            {
                                                Vibrance_RGB_balance_G.Value = Double_To_ScrollValue(S[1]);
                                            }
                                            if (S[2] == null)
                                            {
                                                Vibrance_RGB_balance_B.Value = 0;
                                            }
                                            else
                                            {
                                                Vibrance_RGB_balance_B.Value = Double_To_ScrollValue(S[2]);
                                            }
                                        }
                                        if (x == "ColorTone")
                                        {
                                            if (S[0] == null)
                                            {
                                                ColorTone_R.Value = 0;
                                            }
                                            else
                                            {
                                                ColorTone_R.Value = Double_To_ScrollValue(S[0]);
                                            }
                                            if (S[1] == null)
                                            {
                                                ColorTone_G.Value = 0;
                                            }
                                            else
                                            {
                                                ColorTone_G.Value = Double_To_ScrollValue(S[1]);
                                            }
                                            if (S[2] == null)
                                            {
                                                ColorTone_B.Value = 0;
                                            }
                                            else
                                            {
                                                ColorTone_B.Value = Double_To_ScrollValue(S[2]);
                                            }
                                        }
                                        if (x == "border_width")
                                        {
                                            if (S[0] == null)
                                            {
                                                border_width_X.Value = 0;
                                            }
                                            else
                                            {
                                                border_width_X.Value = Double_To_ScrollValue(S[0]);
                                            }
                                            if (S[1] == null)
                                            {
                                                border_width_Y.Value = 0;
                                            }
                                            else
                                            {
                                                border_width_Y.Value = Double_To_ScrollValue(S[1]);
                                            }
                                        }
                                        if (x == "border_color")
                                        {
                                            if (S[0] == null)
                                            {
                                                border_color_R.Value = 0;
                                            }
                                            else
                                            {
                                                border_color_R.Value = Double_To_ScrollValue(S[0]);
                                            }
                                            if (S[1] == null)
                                            {
                                                border_color_G.Value = 0;
                                            }
                                            else
                                            {
                                                border_color_G.Value = Double_To_ScrollValue(S[1]);
                                            }
                                            if (S[2] == null)
                                            {
                                                border_color_B.Value = 0;
                                            }
                                            else
                                            {
                                                border_color_B.Value = Double_To_ScrollValue(S[2]);
                                            }
                                        }
                                        if (x == "VignetteCenter")
                                        {
                                            if (S[0] == null)
                                            {
                                                VignetteCenter_0.Value = 0;
                                            }
                                            else
                                            {
                                                VignetteCenter_0.Value = Double_To_ScrollValue(S[0]);
                                            }
                                            if (S[1] == null)
                                            {
                                                VignetteCenter_1.Value = 0;
                                            }
                                            else
                                            {
                                                VignetteCenter_1.Value = Double_To_ScrollValue(S[1]);
                                            }
                                        }
                                    }
                                    else
                                    {
										if (FindControl(x) is TrackBar n)
										{
											n.Value = Double_To_ScrollValue(S[0]);
											//最小值的处理
											if (n.Minimum == Double_To_ScrollValue(S[0]))
											{
												n.Value = n.Maximum;
												n.Value = n.Minimum;
											}
										}
									}
                                }
                                if (x.StartsWith("USE") & (x != "USE_FXAA_ANTIALIASING"))
                                {
                                    string[] S = SweetFX.FindSweetFXItem(MainForm.Value.Game_Address, x);
                                    Win8_OnOff onoff = null;
                                    foreach (Control n in Controls.Find("OnOff" + i.ToString(), true))
                                    {
                                        onoff = (Win8_OnOff)n;
                                        if (S[0] == "0")
                                        {
                                            onoff.Checked = false;
                                        }
                                        else
                                        {
                                            onoff.Checked = true;
                                        }
                                    }
                                    i++;
                                }
                                break;
                        }
                    }
                }
            }
        }

        private int Double_To_ScrollValue(string d)
        {
			int n;
            string re = null;
            //转换数值
            Regex Number = new Regex(@"\d");
            foreach(Match x in Number.Matches(d))
            {
                re += x.Value;
            }
            if (re.StartsWith("0") | re.EndsWith("0"))
            {
                re = re.TrimStart('0');
                //re = re.TrimEnd('0');
                if (re == "")
                {
                    re = "0";
                }
            }
            n = (int)(Convert.ToDouble(re));
            //判断符号
            Regex f = new Regex("-");
            if(f.IsMatch(d))
            {
                n = 0 - n;
            }
            return n;
        }

        private void SMAA_THRESHOLD_Scroll(object sender, EventArgs e)
        {
            Number1.Text = Math.Round(((double)SMAA_THRESHOLD.Value / 100), 2).ToString("f2");
            string[] S = { Number1.Text };
            SweetFX.SetSweetFXItem(Address.Text, "SMAA_THRESHOLD", S);
        }

        private void SMAA_MAX_SEARCH_STEPS_Scroll(object sender, EventArgs e)
        {
            Number2.Text = SMAA_MAX_SEARCH_STEPS.Value.ToString();
            string[] S = { Number2.Text };
            SweetFX.SetSweetFXItem(Address.Text, "SMAA_MAX_SEARCH_STEPS", S);
        }

        private void SMAA_MAX_SEARCH_STEPS_DIAG_Scroll(object sender, EventArgs e)
        {
            Number3.Text = SMAA_MAX_SEARCH_STEPS_DIAG.Value.ToString();
            string[] S = { Number3.Text };
            SweetFX.SetSweetFXItem(Address.Text, "SMAA_MAX_SEARCH_STEPS_DIAG", S);
        }

        private void SMAA_CORNER_ROUNDING_Scroll(object sender, EventArgs e)
        {
            Number4.Text = SMAA_CORNER_ROUNDING.Value.ToString();
            string[] S = { Number4.Text };
            SweetFX.SetSweetFXItem(Address.Text, "SMAA_CORNER_ROUNDING", S);
        }

        private void COLOR_EDGE_DETECTION_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if(COLOR_EDGE_DETECTION_0.Checked)
            {
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "COLOR_EDGE_DETECTION", S);
            }
            if(COLOR_EDGE_DETECTION_1.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "COLOR_EDGE_DETECTION", S);
            }
        }

        private void SMAA_DIRECTX9_LINEAR_BLEND_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if (SMAA_DIRECTX9_LINEAR_BLEND_0.Checked)
            {
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "SMAA_DIRECTX9_LINEAR_BLEND", S);
            }
            if (SMAA_DIRECTX9_LINEAR_BLEND_1.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "SMAA_DIRECTX9_LINEAR_BLEND", S);
            }
        }

        private void sharp_strength_Scroll(object sender, EventArgs e)
        {
            Number5.Text = Math.Round(((double)sharp_strength.Value / 100), 2).ToString("f2");
            string[] S = { Number5.Text };
            SweetFX.SetSweetFXItem(Address.Text, "sharp_strength", S);
        }

        private void pattern_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if (pattern_1.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "pattern", S);
            }
            if (pattern_2.Checked)
            {
                S[0] = "2";
                SweetFX.SetSweetFXItem(Address.Text, "pattern", S);
            }
            if (pattern_3.Checked)
            {
                S[0] = "3";
                SweetFX.SetSweetFXItem(Address.Text, "pattern", S);
            }
            if (pattern_4.Checked)
            {
                S[0] = "4";
                SweetFX.SetSweetFXItem(Address.Text, "pattern", S);
            }
        }

        private void offset_bias_Scroll(object sender, EventArgs e)
        {
            Number7.Text = Math.Round(((double)offset_bias.Value / 10), 1).ToString("f1");
            string[] S = { Number7.Text };
            SweetFX.SetSweetFXItem(Address.Text, "offset_bias", S);
        }

        private void show_sharpen_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if (show_sharpen_0.Checked)
            {
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "show_sharpen", S);
            }
            if (show_sharpen_1.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "show_sharpen", S);
            }
        }

        private void Explosion_Radius_Scroll(object sender, EventArgs e)
        {
            Number8.Text = Math.Round(((double)Explosion_Radius.Value / 10), 1).ToString("f1");
            string[] S = { Number8.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Explosion_Radius", S);
        }

        private void CartoonPower_Scroll(object sender, EventArgs e)
        {
            Number9.Text = Math.Round(((double)CartoonPower.Value / 10), 1).ToString("f1");
            string[] S = { Number9.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CartoonPower", S);
        }

        private void CartoonEdgeSlope_Scroll(object sender, EventArgs e)
        {
            Number10.Text = Math.Round(((double)CartoonEdgeSlope.Value / 10), 1).ToString("f1");
            string[] S = { Number10.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CartoonEdgeSlope", S);
        }

        private void CRTAmount_Scroll(object sender, EventArgs e)
        {
            Number11.Text = Math.Round(((double)CRTAmount.Value / 10), 1).ToString("f1");
            string[] S = { Number11.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTAmount", S);
        }

        private void CRTResolution_Scroll(object sender, EventArgs e)
        {
            Number12.Text = Math.Round(((double)CRTResolution.Value / 10), 1).ToString("f1");
            string[] S = { Number12.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTResolution", S);
        }

        private void CRTgamma_Scroll(object sender, EventArgs e)
        {
            Number13.Text = Math.Round(((double)CRTgamma.Value / 10), 1).ToString("f1");
            string[] S = { Number13.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTgamma", S);
        }

        private void CRTmonitorgamma_Scroll(object sender, EventArgs e)
        {
            Number14.Text = Math.Round(((double)CRTmonitorgamma.Value / 10), 1).ToString("f1");
            string[] S = { Number14.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTmonitorgamma", S);
        }

        private void CRTBrightness_Scroll(object sender, EventArgs e)
        {
            Number15.Text = Math.Round(((double)CRTBrightness.Value / 10), 1).ToString("f1");
            string[] S = { Number15.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTBrightness", S);
        }

        private void CRTScanlineIntensity_Scroll(object sender, EventArgs e)
        {
            Number16.Text = Math.Round(((double)CRTScanlineIntensity.Value / 10), 1).ToString("f1");
            string[] S = { Number16.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTScanlineIntensity", S);
        }

        private void CRTScanlineGaussian_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if (CRTScanlineGaussian_0.Checked)
            {
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "CRTScanlineGaussian", S);
            }
            if (CRTScanlineGaussian_1.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "CRTScanlineGaussian", S);
            }
        }

        private void CRTCurvature_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if (CRTCurvature_0.Checked)
            {
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "CRTCurvature", S);
            }
            if (CRTCurvature_1.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "CRTCurvature", S);
            }
        }

        private void CRTCurvatureRadius_Scroll(object sender, EventArgs e)
        {
            Number17.Text = Math.Round(((double)CRTCurvatureRadius.Value / 10), 1).ToString("f1");
            string[] S = { Number17.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTCurvatureRadius", S);
        }

        private void CRTCornerSize_Scroll(object sender, EventArgs e)
        {
            Number18.Text = Math.Round(((double)CRTCornerSize.Value / 10000), 4).ToString("f4");
            string[] S = { Number18.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTCornerSize", S);
        }

        private void CRTDistance_Scroll(object sender, EventArgs e)
        {
            Number19.Text = Math.Round(((double)CRTDistance.Value / 100), 2).ToString("f2");
            string[] S = { Number19.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTDistance", S);
        }

        private void CRTAngleX_Scroll(object sender, EventArgs e)
        {
            Number20.Text = Math.Round(((double)CRTAngleX.Value / 100), 2).ToString("f2");
            string[] S = { Number20.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTAngleX", S);
        }

        private void CRTAngleY_Scroll(object sender, EventArgs e)
        {
            Number21.Text = Math.Round(((double)CRTAngleY.Value / 100), 2).ToString("f2");
            string[] S = { Number21.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTAngleY", S);
        }

        private void CRTOverScan_Scroll(object sender, EventArgs e)
        {
            Number22.Text = Math.Round( ((double)CRTOverScan.Value / 100), 2).ToString("f2");
            string[] S = { Number22.Text };
            SweetFX.SetSweetFXItem(Address.Text, "CRTOverScan", S);
        }

        private void CRTOversample_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if (CRTOversample_1.Checked)
            {
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "CRTOversample", S);
            }
            if (CRTOversample_0.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "CRTOversample", S);
            }
        }

        private void BloomThreshold_Scroll(object sender, EventArgs e)
        {
            Number23.Text = Math.Round(((double)BloomThreshold.Value / 100), 2).ToString("f2");
            string[] S = { Number23.Text };
            SweetFX.SetSweetFXItem(Address.Text, "BloomThreshold", S);
        }

        private void BloomPower_Scroll(object sender, EventArgs e)
        {
           Number24.Text = Math.Round(((double)BloomPower.Value / 1000), 3).ToString("f3");
            string[] S = { Number24.Text };
            SweetFX.SetSweetFXItem(Address.Text, "BloomPower", S);
        }

        private void BloomWidth_Scroll(object sender, EventArgs e)
        {
            Number25.Text = Math.Round(((double)BloomWidth.Value / 10000), 4).ToString("f4");
            string[] S = { Number25.Text };
            SweetFX.SetSweetFXItem(Address.Text, "BloomWidth", S);
        }

        private void HDRPower_Scroll(object sender, EventArgs e)
        {
            Number26.Text = Math.Round(((double)HDRPower.Value / 100), 2).ToString("f2");
            string[] S = { Number26.Text };
            SweetFX.SetSweetFXItem(Address.Text, "HDRPower", S);
        }

        private void radius2_Scroll(object sender, EventArgs e)
        {
            Number27.Text = Math.Round(((double)radius2.Value / 100), 2).ToString("f2");
            string[] S = { Number27.Text };
            SweetFX.SetSweetFXItem(Address.Text, "radius2", S);
        }

        private void Levels_black_point_Scroll(object sender, EventArgs e)
        {
            Number28.Text = Levels_black_point.Value.ToString();
            string[] S = { Number28.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Levels_black_point", S);
        }

        private void Levels_white_point_Scroll(object sender, EventArgs e)
        {
            Number29.Text = Levels_white_point.Value.ToString();
            string[] S = { Number29.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Levels_white_point", S);
        }

        private void TechniAmount_Scroll(object sender, EventArgs e)
        {
            Number30.Text = Math.Round(((double)TechniAmount.Value / 100), 2).ToString("f2");
            string[] S = { Number30.Text };
            SweetFX.SetSweetFXItem(Address.Text, "TechniAmount", S);
        }

        private void TechniPower_Scroll(object sender, EventArgs e)
        {
            Number31.Text = Math.Round(((double)TechniPower.Value / 100), 2).ToString("f2");
            string[] S = { Number31.Text };
            SweetFX.SetSweetFXItem(Address.Text, "TechniPower", S);
        }

        private void redNegativeAmount_Scroll(object sender, EventArgs e)
        {
            Number32.Text = Math.Round(((double)redNegativeAmount.Value / 100), 2).ToString("f2");
            string[] S = { Number32.Text };
            SweetFX.SetSweetFXItem(Address.Text, "redNegativeAmount", S);
        }

        private void greenNegativeAmount_Scroll(object sender, EventArgs e)
        {
            Number33.Text = Math.Round(((double)greenNegativeAmount.Value / 100), 2).ToString("f2");
            string[] S = { Number33.Text };
            SweetFX.SetSweetFXItem(Address.Text, "greenNegativeAmount", S);
        }

        private void blueNegativeAmount_Scroll(object sender, EventArgs e)
        {
            Number34.Text = Math.Round(((double)blueNegativeAmount.Value / 100), 2).ToString("f2");
            string[] S = { Number34.Text };
            SweetFX.SetSweetFXItem(Address.Text, "blueNegativeAmount", S);
        }

        private void Red_Scroll(object sender, EventArgs e)
        {
            Number35.Text = Math.Round(((double)Red.Value / 10), 1).ToString("f1");
            string[] S = { Number35.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Red", S);
        }

        private void Green_Scroll(object sender, EventArgs e)
        {
            Number36.Text = Math.Round(((double)Green.Value / 10), 1).ToString("f1");
            string[] S = { Number36.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Green", S);
        }

        private void Blue_Scroll(object sender, EventArgs e)
        {
            Number37.Text = Math.Round(((double)Blue.Value / 10), 1).ToString("f1");
            string[] S = { Number37.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Blue", S);
        }

        private void ColorGamma_Scroll(object sender, EventArgs e)
        {
            Number38.Text = Math.Round(((double)ColorGamma.Value / 10), 1).ToString("f1");
            string[] S = { Number38.Text };
            SweetFX.SetSweetFXItem(Address.Text, "ColorGamma", S);
        }

        private void DPXSaturation_Scroll(object sender, EventArgs e)
        {
            Number39.Text = Math.Round(((double)DPXSaturation.Value / 10), 1).ToString("f1");
            string[] S = { Number39.Text };
            SweetFX.SetSweetFXItem(Address.Text, "DPXSaturation", S);
        }

        private void RedC_Scroll(object sender, EventArgs e)
        {
            Number40.Text = Math.Round(((double)RedC.Value / 10), 1).ToString("f1");
            string[] S = { Number40.Text };
            SweetFX.SetSweetFXItem(Address.Text, "RedC", S);
        }

        private void GreenC_Scroll(object sender, EventArgs e)
        {
            Number41.Text = Math.Round(((double)GreenC.Value / 10), 1).ToString("f1");
            string[] S = { Number41.Text };
            SweetFX.SetSweetFXItem(Address.Text, "GreenC", S);
        }

        private void BlueC_Scroll(object sender, EventArgs e)
        {
            Number42.Text = Math.Round(((double)BlueC.Value / 10), 1).ToString("f1");
            string[] S = { Number42.Text };
            SweetFX.SetSweetFXItem(Address.Text, "BlueC", S);
        }

        private void Blend_Scroll(object sender, EventArgs e)
        {
            Number43.Text = Math.Round(((double)Blend.Value / 10), 1).ToString("f1");
            string[] S = { Number43.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Blend", S);
        }

        private void dither_method_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if (dither_method_1.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "dither_method", S);
            }
            if (dither_method_2.Checked)
            {
                S[0] = "2";
                SweetFX.SetSweetFXItem(Address.Text, "dither_method", S);
            }
        }

        private void border_color_Scroll(object sender, EventArgs e)
        {
            string[] S = new string[3];
            TrackBar TB = (TrackBar)sender;
            if (TB.Name == "border_color_R")
            {
                Number46.Text = border_color_R.Value.ToString();
                S[0] = Number46.Text;
                S[1] = Number47.Text;
                S[2] = Number48.Text;
            }
            if (TB.Name == "border_color_G")
            {
                Number47.Text = border_color_G.Value.ToString();
                S[0] = Number46.Text;
                S[1] = Number47.Text;
                S[2] = Number48.Text;
            }
            if (TB.Name == "border_color_B")
            {
                Number48.Text = border_color_B.Value.ToString();
                S[0] = Number46.Text;
                S[1] = Number47.Text;
                S[2] = Number48.Text;
            }
            SweetFX.SetSweetFXItem(Address.Text, "border_color", S);
        }

        private void border_width_ValueChanged(object sender, EventArgs e)
        {
            string[] S = new string[2];
            TrackBar TB = (TrackBar)sender;
            if (TB.Name == "border_width_X")
            {
                Number44.Text = border_width_X.Value.ToString();
                S[0] = Number44.Text;
                S[1] = Number45.Text;
            }
            if (TB.Name == "border_width_Y")
            {
                Number45.Text = border_width_Y.Value.ToString();
                S[0] = Number44.Text;
                S[1] = Number45.Text;
            }
            SweetFX.SetSweetFXItem(Address.Text, "border_width", S);
        }

        private void splitscreen_mode_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if (splitscreen_mode_1.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "splitscreen_mode", S);
            }
            if (splitscreen_mode_2.Checked)
            {
                S[0] = "2";
                SweetFX.SetSweetFXItem(Address.Text, "splitscreen_mode", S);
            }
            if (splitscreen_mode_3.Checked)
            {
                S[0] = "3";
                SweetFX.SetSweetFXItem(Address.Text, "splitscreen_mode", S);
            }
            if (splitscreen_mode_4.Checked)
            {
                S[0] = "4";
                SweetFX.SetSweetFXItem(Address.Text, "splitscreen_mode", S);
            }
            if (splitscreen_mode_5.Checked)
            {
                S[0] = "5";
                SweetFX.SetSweetFXItem(Address.Text, "splitscreen_mode", S);
            }
        }

        private void Monochrome_conversion_values_Scroll(object sender, EventArgs e)
        {
            string[] S = new string[3];
            TrackBar TB = (TrackBar)sender;
            if (TB.Name == "Monochrome_conversion_values_R")
            {
                Number49.Text = Math.Round((double)Monochrome_conversion_values_R.Value / 100, 2).ToString("f2");
                S[0] = Number49.Text;
                S[1] = Number50.Text;
                S[2] = Number51.Text;
            }
            if (TB.Name == "Monochrome_conversion_values_G")
            {
                Number50.Text = Math.Round((double)Monochrome_conversion_values_G.Value / 100, 2).ToString("f2");
                S[0] = Number49.Text;
                S[1] = Number50.Text;
                S[2] = Number51.Text;
            }
            if (TB.Name == "Monochrome_conversion_values_B")
            {
                Number51.Text = Math.Round((double)Monochrome_conversion_values_B.Value / 100, 2).ToString("f2");
                S[0] = Number49.Text;
                S[1] = Number50.Text;
                S[2] = Number51.Text;
            }
            SweetFX.SetSweetFXItem(Address.Text, "Monochrome_conversion_values", S);
        }

        private void RGB_Lift_Scroll(object sender, EventArgs e)
        {
            string[] S = new string[3];
            TrackBar TB = (TrackBar)sender;
            if (TB.Name == "RGB_Lift_R")
            {
                Number52.Text = Math.Round(((double)RGB_Lift_R.Value / 1000), 3).ToString("f3");
                S[0] = Number52.Text;
                S[1] = Number53.Text;
                S[2] = Number54.Text;
            }
            if (TB.Name == "RGB_Lift_G")
            {
                Number53.Text = Math.Round(((double)RGB_Lift_G.Value / 1000), 3).ToString("f3");
                S[0] = Number52.Text;
                S[1] = Number53.Text;
                S[2] = Number54.Text;
            }
            if (TB.Name == "RGB_Lift_B")
            {
                Number54.Text = Math.Round(((double)RGB_Lift_B.Value / 1000), 3).ToString("f3");
                S[0] = Number52.Text;
                S[1] = Number53.Text;
                S[2] = Number54.Text;
            }
            SweetFX.SetSweetFXItem(Address.Text, "RGB_Lift", S);
        }

        private void RGB_Gamma_Scroll(object sender, EventArgs e)
        {
            string[] S = new string[3];
            TrackBar TB = (TrackBar)sender;
            if (TB.Name == "RGB_Gamma_R")
            {
                Number55.Text = Math.Round(((double)RGB_Gamma_R.Value / 1000), 3).ToString("f3");
                S[0] = Number55.Text;
                S[1] = Number56.Text;
                S[2] = Number57.Text;
            }
            if (TB.Name == "RGB_Gamma_G")
            {
                Number56.Text = Math.Round(((double)RGB_Gamma_G.Value / 1000), 3).ToString("f3");
                S[0] = Number55.Text;
                S[1] = Number56.Text;
                S[2] = Number57.Text;
            }
            if (TB.Name == "RGB_Gamma_B")
            {
                Number57.Text = Math.Round(((double)RGB_Gamma_B.Value / 1000), 3).ToString("f3");
                S[0] = Number55.Text;
                S[1] = Number56.Text;
                S[2] = Number57.Text;
            }
            SweetFX.SetSweetFXItem(Address.Text, "RGB_Gamma", S);
        }

        private void RGB_Gain_Scroll(object sender, EventArgs e)
        {
            string[] S = new string[3];
            TrackBar TB = (TrackBar)sender;
            if (TB.Name == "RGB_Gain_R")
            {
                Number58.Text = Math.Round(((double)RGB_Gain_R.Value / 1000), 3).ToString("f3");
                S[0] = Number58.Text;
                S[1] = Number59.Text;
                S[2] = Number60.Text;
            }
            if (TB.Name == "RGB_Gain_G")
            {
                Number59.Text = Math.Round(((double)RGB_Gain_G.Value / 1000), 3).ToString("f3");
                S[0] = Number58.Text;
                S[1] = Number59.Text;
                S[2] = Number60.Text;
            }
            if (TB.Name == "RGB_Gain_B")
            {
                Number60.Text = Math.Round(((double)RGB_Gain_B.Value / 1000), 3).ToString("f3");
                S[0] = Number58.Text;
                S[1] = Number59.Text;
                S[2] = Number60.Text;
            }
            SweetFX.SetSweetFXItem(Address.Text, "RGB_Gain", S);
        }

        private void Gamma_Scroll(object sender, EventArgs e)
        {
            Number61.Text = Math.Round(((double)Gamma.Value / 1000), 3).ToString("f3");
            string[] S = { Number61.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Gamma", S);
        }

        private void Exposure_Scroll(object sender, EventArgs e)
        {
            Number62.Text = Math.Round(((double)Exposure.Value / 1000), 3).ToString("f3");
            string[] S = { Number62.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Exposure", S);
        }

        private void Saturation_Scroll(object sender, EventArgs e)
        {
            Number63.Text = Math.Round(((double)Saturation.Value / 1000), 3).ToString("f3");
            string[] S = { Number63.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Saturation", S);
        }

        private void Bleach_Scroll(object sender, EventArgs e)
        {
            Number64.Text = Math.Round(((double)Bleach.Value / 1000), 3).ToString("f3");
            string[] S = { Number64.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Bleach", S);
        }

        private void Defog_Scroll(object sender, EventArgs e)
        {
            Number65.Text = Math.Round(((double)Defog.Value / 1000), 3).ToString("f3");
            string[] S = { Number65.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Defog", S);
        }

        private void FogColor_Scroll(object sender, EventArgs e)
        {
            string[] S = new string[3];
            TrackBar TB = (TrackBar)sender;
            if (TB.Name == "FogColor_R")
            {
                Number66.Text = Math.Round(((double)FogColor_R.Value / 100), 2).ToString("f2");
                S[0] = Number66.Text;
                S[1] = Number67.Text;
                S[2] = Number68.Text;
            }
            if (TB.Name == "FogColor_G")
            {
                Number67.Text = Math.Round(((double)FogColor_G.Value / 100), 2).ToString("f2");
                S[0] = Number66.Text;
                S[1] = Number67.Text;
                S[2] = Number68.Text;
            }
            if (TB.Name == "FogColor_B")
            {
                Number68.Text = Math.Round(((double)FogColor_B.Value / 100), 2).ToString("f2");
                S[0] = Number66.Text;
                S[1] = Number67.Text;
                S[2] = Number68.Text;
            }
            SweetFX.SetSweetFXItem(Address.Text, "FogColor", S);
        }

        private void Vibrance_Scroll(object sender, EventArgs e)
        {
            Number69.Text = Math.Round(((double)Vibrance.Value / 100), 2).ToString("f2");
            string[] S = { Number69.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Vibrance", S);
        }

        private void Vibrance_RGB_balance_Scroll(object sender, EventArgs e)
        {
            string[] S = new string[3];
            TrackBar TB = (TrackBar)sender;
            if (TB.Name == "Vibrance_RGB_balance_R")
            {
                Number70.Text = Math.Round(((double)Vibrance_RGB_balance_R.Value / 100), 2).ToString("f2");
                S[0] = Number70.Text;
                S[1] = Number71.Text;
                S[2] = Number72.Text;
            }
            if (TB.Name == "Vibrance_RGB_balance_G")
            {
                Number71.Text = Math.Round(((double)Vibrance_RGB_balance_G.Value / 100), 2).ToString("f2");
                S[0] = Number70.Text;
                S[1] = Number71.Text;
                S[2] = Number72.Text;
            }
            if (TB.Name == "Vibrance_RGB_balance_B")
            {
                Number72.Text = Math.Round(((double)Vibrance_RGB_balance_B.Value / 100), 2).ToString("f2");
                S[0] = Number70.Text;
                S[1] = Number71.Text;
                S[2] = Number72.Text;
            }
            SweetFX.SetSweetFXItem(Address.Text, "Vibrance_RGB_balance", S);
        }

        private void Curves_mode_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if (Curves_mode_0.Checked)
            {
                S[0] = "0";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_mode", S);
            }
            if (Curves_mode_1.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_mode", S);
            }
            if (Curves_mode_2.Checked)
            {
                S[0] = "2";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_mode", S);
            }
        }

        private void Curves_contrast_Scroll(object sender, EventArgs e)
        {
            Number63.Text = Math.Round(((double)Curves_contrast.Value / 100), 2).ToString("f2");
            string[] S = { Number63.Text };
            SweetFX.SetSweetFXItem(Address.Text, "Curves_contrast", S);
        }

        private void Curves_formula_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if (Curves_formula_1.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_formula", S);
            }
            if (Curves_formula_2.Checked)
            {
                S[0] = "2";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_formula", S);
            }
            if (Curves_formula_3.Checked)
            {
                S[0] = "3";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_formula", S);
            }
            if (Curves_formula_4.Checked)
            {
                S[0] = "4";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_formula", S);
            }
            if (Curves_formula_5.Checked)
            {
                S[0] = "5";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_formula", S);
            }
            if (Curves_formula_6.Checked)
            {
                S[0] = "6";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_formula", S);
            }
            if (Curves_formula_7.Checked)
            {
                S[0] = "7";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_formula", S);
            }
            if (Curves_formula_8.Checked)
            {
                S[0] = "8";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_formula", S);
            }
            if (Curves_formula_9.Checked)
            {
                S[0] = "9";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_formula", S);
            }
            if (Curves_formula_10.Checked)
            {
                S[0] = "10";
                SweetFX.SetSweetFXItem(Address.Text, "Curves_formula", S);
            }
        }

        private void ColorTone_Scroll(object sender, EventArgs e)
        {
            string[] S = new string[3];
            TrackBar TB = (TrackBar)sender;
            if (TB.Name == "ColorTone_R")
            {
                Number74.Text = Math.Round(((double)ColorTone_R.Value / 100), 2).ToString("f2");
                S[0] = Number74.Text;
                S[1] = Number75.Text;
                S[2] = Number76.Text;
            }
            if (TB.Name == "ColorTone_G")
            {
                Number75.Text = Math.Round(((double)ColorTone_G.Value / 100), 2).ToString("f2");
                S[0] = Number74.Text;
                S[1] = Number75.Text;
                S[2] = Number76.Text;
            }
            if (TB.Name == "ColorTone_B")
            {
                Number76.Text = Math.Round(((double)ColorTone_B.Value / 100), 2).ToString("f2");
                S[0] = Number74.Text;
                S[1] = Number75.Text;
                S[2] = Number76.Text;
            }
            SweetFX.SetSweetFXItem(Address.Text, "ColorTone", S);
        }

        private void GreyPower_Scroll(object sender, EventArgs e)
        {
            Number77.Text = Math.Round(((double)GreyPower.Value / 100), 2).ToString("f2");
            string[] S = { Number77.Text };
            SweetFX.SetSweetFXItem(Address.Text, "GreyPower", S);
        }

        private void SepiaPower_Scroll(object sender, EventArgs e)
        {
            Number78.Text = Math.Round(((double)SepiaPower.Value / 100), 2).ToString("f2");
            string[] S = { Number78.Text };
            SweetFX.SetSweetFXItem(Address.Text, "SepiaPower", S);
        }

        private void VignetteType_CheckedChanged(object sender, EventArgs e)
        {
            string[] S = new string[1];
            if (VignetteType_1.Checked)
            {
                S[0] = "1";
                SweetFX.SetSweetFXItem(Address.Text, "VignetteType", S);
            }
            if (VignetteType_2.Checked)
            {
                S[0] = "2";
                SweetFX.SetSweetFXItem(Address.Text, "VignetteType", S);
            }
            if (VignetteType_3.Checked)
            {
                S[0] = "3";
                SweetFX.SetSweetFXItem(Address.Text, "VignetteType", S);
            }
        }

        private void VignetteRatio_Scroll(object sender, EventArgs e)
        {
            Number79.Text = Math.Round(((double)VignetteRatio.Value / 100), 2).ToString("f2");
            string[] S = { Number79.Text };
            SweetFX.SetSweetFXItem(Address.Text, "VignetteRatio", S);
        }

        private void VignetteRadius_Scroll(object sender, EventArgs e)
        {
            Number80.Text = Math.Round(((double)VignetteRadius.Value / 100), 2).ToString("f2");
            string[] S = { Number80.Text };
            SweetFX.SetSweetFXItem(Address.Text, "VignetteRadius", S);
        }

        private void VignetteAmount_Scroll(object sender, EventArgs e)
        {
            Number81.Text = Math.Round(((double)VignetteAmount.Value / 100), 2).ToString("f2");
            string[] S = { Number81.Text };
            SweetFX.SetSweetFXItem(Address.Text, "VignetteAmount", S);
        }

        private void VignetteSlope_Scroll(object sender, EventArgs e)
        {
            Number82.Text = VignetteSlope.Value.ToString();
            string[] S = { Number82.Text };
            SweetFX.SetSweetFXItem(Address.Text, "VignetteSlope", S);
        }

        private void VignetteCenter_Scroll(object sender, EventArgs e)
        {
            string[] S = new string[2];
            TrackBar TB = (TrackBar)sender;
            if (TB.Name == "VignetteCenter_0")
            {
                Number83.Text = Math.Round(((double)VignetteCenter_0.Value / 1000), 3).ToString("f3");
                S[0] = Number83.Text;
                S[1] = Number84.Text;
            }
            if (TB.Name == "VignetteCenter_1")
            {
                Number84.Text = Math.Round(((double)VignetteCenter_1.Value / 1000), 3).ToString("f3");
                S[0] = Number83.Text;
                S[1] = Number84.Text;
            }
            SweetFX.SetSweetFXItem(Address.Text, "VignetteCenter", S);
        }

        private void sharp_clamp_Scroll(object sender, EventArgs e)
        {
            Number6.Text = Math.Round(((double)sharp_clamp.Value / 1000), 3).ToString("f3");
            string[] S = { Number6.Text };
            SweetFX.SetSweetFXItem(Address.Text, "sharp_clamp", S);
        }

        //SweetFX
    }
}

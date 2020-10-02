using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace RCT3启动器MessageBox
{
    public partial class RCT_MessageBox : UserControl
    {
        //定义变量
        private String Link1_Address = "about:blank", Link2_Address = "about:blank", Link3_Address = "about:blank", Link4_Address = "about:blank", Link5_Address = "about:blank", Link6_Address = "about:blank";
        private String TieBa_Name = "贴吧名称", link1 = "Link1", link2 = "Link2", link3 = "Link3", link4 = "Link4", link5 = "Link5";
        delegate void SetText();
        bool StopOrNot = false;
        Thread Message_Update_Out = null;
        //变量定义结束
        public RCT_MessageBox()
        {
            InitializeComponent();
            Link1.Left = 0;
            Link2.Left = 0;
            Link3.Left = 0;
            Link4.Left = 0;
            Link5.Left = 0;
            Link6.Left = 0;
            Link1.Top = 0;
            //连接服务器更新消息
            Thread Message_Update = new Thread(Loading);
            Message_Update.Start();
            Message_Update_Out = Message_Update;
            //连接服务器更新消息
        }
        //属性声明开始
        [Category("地址"), Description("设置贴吧名称"), DefaultValue("贴吧名称")]
        public String TieBa_Name_Set
        {
            get
            {
                return TieBa_Name;
            }
            set
            {
                TieBa_Name = value;
                Link1.Text = TieBa_Name.ToString();
            }
        }
        [Category("地址"), Description("设置第一个Button名称"), DefaultValue("Link1")]
        public String link1_Set
        {
            get
            {
                return link1;
            }
            set
            {
                link1 = value;
                Link2.Text = link1.ToString();
            }
        }
        [Category("地址"), Description("设置第二个Button名称"), DefaultValue("Link2")]
        public String link2_Set
        {
            get
            {
                return link2;
            }
            set
            {
                link2 = value;
                Link3.Text = link2.ToString();
            }
        }
        [Category("地址"), Description("设置第三个Button名称"), DefaultValue("Link3")]
        public String link3_Set
        {
            get
            {
                return link3;
            }
            set
            {
                link3 = value;
                Link4.Text = link3.ToString();
            }
        }
        [Category("地址"), Description("设置第四个Button名称"), DefaultValue("Link4")]
        public String link4_Set
        {
            get
            {
                return link4;
            }
            set
            {
                link4 = value;
                Link5.Text = link4.ToString();
            }
        }
        [Category("地址"), Description("设置第五个Button名称"), DefaultValue("Link5")]
        public String link5_Set
        {
            get
            {
                return link5;
            }
            set
            {
                link5 = value;
                Link6.Text = link5.ToString();
            }
        }
        [Category("地址"), Description("设置贴吧地址"), DefaultValue("about:blank")]
        public String TieBa_Name_Address_Set
        {
            get
            {
                return Link1_Address;
            }
            set
            {
                Link1_Address = value;
            }
        }
        [Category("地址"), Description("设置第一个按钮链接地址"), DefaultValue("about:blank")]
        public String link1_Address_Set
        {
            get
            {
                return Link2_Address;
            }
            set
            {
                Link2_Address = value;
            }
        }
        [Category("地址"), Description("设置第二个按钮链接地址"), DefaultValue("about:blank")]
        public String link2_Address_Set
        {
            get
            {
                return Link3_Address;
            }
            set
            {
                Link3_Address = value;
            }
        }
        [Category("地址"), Description("设置第三个按钮链接地址"), DefaultValue("about:blank")]
        public String link3_Address_Set
        {
            get
            {
                return Link4_Address;
            }
            set
            {
                Link4_Address = value;
            }
        }
        [Category("地址"), Description("设置第四个按钮链接地址"), DefaultValue("about:blank")]
        public String link4_Address_Set
        {
            get
            {
                return Link5_Address;
            }
            set
            {
                Link5_Address = value;
            }
        }
        [Category("地址"), Description("设置第五个按钮链接地址"), DefaultValue("about:blank")]
        public String link5_Address_Set
        {
            get
            {
                return Link6_Address;
            }
            set
            {
                Link6_Address = value;
            }
        }
        [Category("多线程"),Description("是否终止多线程"),DefaultValue(false)]
        public Boolean Thread_Stop
        {
            get
            {
                return StopOrNot;
            }
            set
            {
                StopOrNot = value;
                if (StopOrNot)
                    Message_Update_Out.Abort();
                else
                {
                    Message_Update_Out.Abort();
                    Thread Message_Update = new Thread(Loading);
                    Message_Update.Start();
                    Message_Update_Out = Message_Update;
                }
            }
        }
        //属性声明结束
        private void Link1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(Link1_Address);
        }

        private void Link2_Click(object sender, EventArgs e)
        {
            Process.Start(Link2_Address);
        }

        private void Link3_Click(object sender, EventArgs e)
        {
            Process.Start(Link3_Address);
        }

        private void Link4_Click(object sender, EventArgs e)
        {
            Process.Start(Link4_Address);
        }

        private void Link5_Click(object sender, EventArgs e)
        {
            Process.Start(Link5_Address);
        }

        private void Link6_Click(object sender, EventArgs e)
        {
            Process.Start(Link6_Address);
        }

        private void RCT_MessageBox_SizeChanged(object sender, EventArgs e)
        {
            Link1.Left = 0;
            Link2.Left = 0;
            Link3.Left = 0;
            Link4.Left = 0;
            Link5.Left = 0;
            Link6.Left = 0;
            Link1.Top = 0;
            Link2.Top = Link1.Top + Link1.Height;
            Link2.Height = (this.Height - Link1.Height) / 5;
            Link3.Top = Link2.Top + Link2.Height;
            Link3.Height = Link2.Height;
            Link4.Top = Link3.Top + Link3.Height;
            Link4.Height = Link2.Height;
            Link5.Top = Link4.Top + Link4.Height;
            Link5.Height = Link2.Height;
            Link6.Top = Link5.Top + Link5.Height;
            Link6.Height = Link2.Height;
            Link2.Width = this.Width;
            Link3.Width = this.Width;
            Link4.Width = this.Width;
            Link5.Width = this.Width;
            Link6.Width = this.Width;
        }

        private void Loading()
        {
            for (;;)
            {
                //死循环
                for (int n = 1; n < 7; n++)
                {
                    string value = NameLoad("Link" + n.ToString());
                    if (value != null)
                    {
                        foreach (Control item in this.Controls)
                        {
                            if (item.Name == "Link" + n.ToString())
                            {
                                SetText settext = delegate ()
                                {
                                    item.Text = value;
                                };
                                item.Invoke(settext);
                            }
                        }
                    }
                    value = NameLoad("Address" + n.ToString());
                    if (value != null)
                    {
                        value = value.Replace("$", "/");
                        switch (n)
                        {
                            case 1:
                                Link1_Address = value;
                                break;
                            case 2:
                                Link2_Address = value;
                                break;
                            case 3:
                                Link3_Address = value;
                                break;
                            case 4:
                                Link4_Address = value;
                                break;
                            case 5:
                                Link5_Address = value;
                                break;
                            case 6:
                                Link6_Address = value;
                                break;
                        }
                    }
                }
                GC.Collect();
                Thread.Sleep(900000);//挂起15分钟
            }
        }//加载消息

        private string NameLoad(string value)
        {
            string Name = null;
            try
            {
                StringBuilder result = new StringBuilder();
                FtpWebRequest FTP = (FtpWebRequest)FtpWebRequest.Create("ftp://ourhomevpn.asuscomm.com/UPDATE/RCT3Running/Message");
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
                result.Remove(result.ToString().LastIndexOf("\n"), 1);
                reader.Close();
                response.Close();
                string[] name = result.ToString().Split('\n');
                foreach (string n in name)
                {
                    if (n.StartsWith("/UPDATE/RCT3Running/Message/" + value + "#"))
                        Name = n.Replace("/UPDATE/RCT3Running/Message/" + value + "#", "");
                }
            }
            catch
            {
                Name = null;
            }
            return Name;
        }//从服务器获取消息
    }
}

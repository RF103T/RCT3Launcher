using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Win8_ON
{
    public partial class Win8_OnOff: UserControl
    {
        int Mouse_x;//鼠标的X坐标
        int Mouse_y;//鼠标的Y坐标
        public Win8_OnOff()
        {
            InitializeComponent();
         }

        private void Off_Click(object sender, EventArgs e)
        {
            Button.Left = 38;
            ON.Width = 50;
            Off.Width = 0;
            Checked = true;
            this.OnClick(null);
        }

        private void ON_MouseDown(object sender, MouseEventArgs e)
        {
            ON.Image = Properties.Resources.处理2;
        }

        private void ON_MouseUp(object sender, MouseEventArgs e)
        {
            ON.Image = Properties.Resources.处理1;
            ON.BringToFront();
            Off.BringToFront();
            Button.BringToFront();
            Button.Left = 0;
            Off.Width = 50;
            Checked = false;
            this.OnClick(null);
        }

        private void ON_MouseEnter(object sender, EventArgs e)
        {
            ON.Image = Properties.Resources.处理3;
        }

        private void ON_MouseLeave(object sender, EventArgs e)
        {
            ON.Image = Properties.Resources.处理1;
        }

        private void Button_MouseDown(object sender, MouseEventArgs e)
        {
            Button_On.Start();
            Off.Width = 50;
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            Button_On.Stop();
            Button_Move.Start();  
        }

        private void Button_On_Tick(object sender, EventArgs e)
        {
            Mouse_x = this.PointToClient(MousePosition).X;
            Mouse_y = this.PointToClient(MousePosition).Y;
            if (Button.Top == 0)
            {
                Button.Left = Mouse_x;
                ON.BringToFront();
                Button.BringToFront();
                ON.Width = Mouse_x;
                if (Button.Left >= 38)
                {
                    Button.Left = 38;
                }
                if (Button.Left <= 0)
                {
                    Button.Left = 0;
                    ON.BringToFront();
                    Off.BringToFront();
                    Button.BringToFront();
                }
            }
            else
            {
                Button.Top = 0;
            }
        }

        private void Button_Move_Tick(object sender, EventArgs e)
        {
            if (Button.Left <= 19)
            {
                if (Button.Left != 0)
                {
                    Button.Left = Button.Left - 1;
                    ON.Width = Button.Left;
                    Off.Width = 50;
                }
            }
            else
            {
                if (Button.Left != 38)
                {
                    Button.Left = Button.Left + 1;
                    ON.Width = Button.Left;
                }
            }
            if (Button.Left == 0 | Button.Left == 38)
            {
                Button_Move.Stop();
                if (Button.Left == 0)
                {
                    Checked = false;
                    this.OnClick(null);
                }
                if (Button.Left == 38)
                {
                    Checked = true;
                    this.OnClick(null);
                }
            }
        }
        //为控件添加复选属性
        private Boolean _Checked = false;
        [Description("控件是否为选中状态"),Category("行为")]
        public Boolean Checked
        { 
            get
            {
                return _Checked;
            }
            set
            {
                _Checked = value;
                if (_Checked == false)
                {
                    Button.Left = 0;
                    Off.Width = 50;
                    ON.Width = 0;
                }
                else
                {
                    Button.Left = 38;
                    Off.Width = 0;
                    ON.Width = 50;
                }
            }
        }
        //属性尾
        //为控件添加复选属性
        private Boolean _NotAllowChecked = false;
        [Description("控件是否为能被改变"), Category("行为")]
        public Boolean NotAllowChecked
        {
            get
            {
                return _NotAllowChecked;
            }
            set
            {
                _NotAllowChecked = value;
                if (_NotAllowChecked == false)
                {
                    this.Enabled = true;
                    NotOff.Visible = false;
                    NotOn.Visible = false;
                }
                else
                {
                    if(_Checked == false)
                    {
                        NotOff.Visible = true;
                        this.Enabled = false;
                    }
                    else
                    {
                        NotOn.Visible = true;
                        this.Enabled = false;
                    }
                }
            }
        }
        //属性尾
    }
}

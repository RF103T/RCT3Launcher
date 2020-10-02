namespace RCT3启动器
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BigButtonOn = new System.Windows.Forms.Timer(this.components);
            this.BigButtonOff = new System.Windows.Forms.Timer(this.components);
            this.ButtonOn = new System.Windows.Forms.Timer(this.components);
            this.ButtonOff = new System.Windows.Forms.Timer(this.components);
            this.Main_Function = new System.Windows.Forms.Label();
            this.Line1 = new System.Windows.Forms.Label();
            this.More_Function = new System.Windows.Forms.Label();
            this.Line2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rcT_MessageBox2 = new RCT3启动器MessageBox.RCT_MessageBox();
            this.Optimize = new System.Windows.Forms.Timer(this.components);
            this.Exit = new System.Windows.Forms.Button();
            this.CRepair = new System.Windows.Forms.Button();
            this.RCT3Live = new System.Windows.Forms.Button();
            this.MAdd = new System.Windows.Forms.Button();
            this.KAdd = new System.Windows.Forms.Button();
            this.Web = new System.Windows.Forms.Button();
            this.GSetting = new System.Windows.Forms.Button();
            this.QSetting = new System.Windows.Forms.Button();
            this.StartGame = new System.Windows.Forms.Button();
            this.Drop = new System.Windows.Forms.Timer(this.components);
            this.Say = new System.Windows.Forms.Label();
            this.CRepair_Box = new System.Windows.Forms.Panel();
            this.CustomSave = new System.Windows.Forms.Button();
            this.FreedomModeSave = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.CRepair_Box.SuspendLayout();
            this.SuspendLayout();
            // 
            // BigButtonOn
            // 
            this.BigButtonOn.Interval = 3;
            this.BigButtonOn.Tick += new System.EventHandler(this.BigBottonOn_Tick);
            // 
            // BigButtonOff
            // 
            this.BigButtonOff.Interval = 3;
            this.BigButtonOff.Tick += new System.EventHandler(this.BigBottonOff_Tick);
            // 
            // ButtonOn
            // 
            this.ButtonOn.Interval = 3;
            this.ButtonOn.Tick += new System.EventHandler(this.ButtonOn_Tick);
            // 
            // ButtonOff
            // 
            this.ButtonOff.Interval = 3;
            this.ButtonOff.Tick += new System.EventHandler(this.ButtonOff_Tick);
            // 
            // Main_Function
            // 
            this.Main_Function.AutoSize = true;
            this.Main_Function.BackColor = System.Drawing.Color.Transparent;
            this.Main_Function.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Main_Function.ForeColor = System.Drawing.Color.White;
            this.Main_Function.Location = new System.Drawing.Point(-3, 12);
            this.Main_Function.Name = "Main_Function";
            this.Main_Function.Size = new System.Drawing.Size(76, 16);
            this.Main_Function.TabIndex = 9;
            this.Main_Function.Text = "主要功能";
            // 
            // Line1
            // 
            this.Line1.AutoSize = true;
            this.Line1.BackColor = System.Drawing.Color.Transparent;
            this.Line1.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Line1.ForeColor = System.Drawing.Color.White;
            this.Line1.Location = new System.Drawing.Point(-6, 17);
            this.Line1.Name = "Line1";
            this.Line1.Size = new System.Drawing.Size(213, 33);
            this.Line1.TabIndex = 10;
            this.Line1.Text = "——————";
            // 
            // More_Function
            // 
            this.More_Function.AutoSize = true;
            this.More_Function.BackColor = System.Drawing.Color.Transparent;
            this.More_Function.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.More_Function.ForeColor = System.Drawing.Color.White;
            this.More_Function.Location = new System.Drawing.Point(289, 12);
            this.More_Function.Name = "More_Function";
            this.More_Function.Size = new System.Drawing.Size(76, 16);
            this.More_Function.TabIndex = 11;
            this.More_Function.Text = "更多功能";
            // 
            // Line2
            // 
            this.Line2.AutoSize = true;
            this.Line2.BackColor = System.Drawing.Color.Transparent;
            this.Line2.Font = new System.Drawing.Font("黑体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Line2.ForeColor = System.Drawing.Color.White;
            this.Line2.Location = new System.Drawing.Point(286, 17);
            this.Line2.Name = "Line2";
            this.Line2.Size = new System.Drawing.Size(213, 33);
            this.Line2.TabIndex = 12;
            this.Line2.Text = "——————";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.More_Function);
            this.panel1.Controls.Add(this.Main_Function);
            this.panel1.Controls.Add(this.Line2);
            this.panel1.Controls.Add(this.Line1);
            this.panel1.Location = new System.Drawing.Point(30, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 37);
            this.panel1.TabIndex = 14;
            // 
            // rcT_MessageBox2
            // 
            this.rcT_MessageBox2.BackColor = System.Drawing.Color.Transparent;
            this.rcT_MessageBox2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rcT_MessageBox2.link1_Address_Set = "http://tieba.baidu.com/p/3942366106";
            this.rcT_MessageBox2.link1_Set = "【游戏修改】破解游戏内存限制, 让你做更大更复杂的公园";
            this.rcT_MessageBox2.link2_Address_Set = "http://weibo.com/u/6080095420";
            this.rcT_MessageBox2.link2_Set = "【游戏修改】过山车大亨3 SweetFx";
            this.rcT_MessageBox2.link3_Address_Set = "http://tieba.baidu.com/p/4870748540";
            this.rcT_MessageBox2.link3_Set = "【测试版更新地址】RCT3启动器预告+更新专用";
            this.rcT_MessageBox2.link4_Address_Set = "http://tieba.baidu.com/p/4840719070";
            this.rcT_MessageBox2.link4_Set = "【小组作品宣传】真实工程I·温州站一期改造工程";
            this.rcT_MessageBox2.link5_Address_Set = "http://tieba.baidu.com/p/4889479553";
            this.rcT_MessageBox2.link5_Set = "【游戏补丁】过山车大亨3正体中文补丁";
            this.rcT_MessageBox2.Location = new System.Drawing.Point(593, 13);
            this.rcT_MessageBox2.Margin = new System.Windows.Forms.Padding(4);
            this.rcT_MessageBox2.Name = "rcT_MessageBox2";
            this.rcT_MessageBox2.Size = new System.Drawing.Size(194, 247);
            this.rcT_MessageBox2.TabIndex = 15;
            this.rcT_MessageBox2.TieBa_Name_Address_Set = "http://tieba.baidu.com/f?kw=%E8%BF%87%E5%B1%B1%E8%BD%A6%E5%A4%A7%E4%BA%A83";
            this.rcT_MessageBox2.TieBa_Name_Set = "贴吧动态";
            // 
            // Optimize
            // 
            this.Optimize.Enabled = true;
            this.Optimize.Interval = 200;
            this.Optimize.Tick += new System.EventHandler(this.Optimize_Tick);
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(154)))), ((int)(((byte)(161)))));
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("黑体", 11F);
            this.Exit.ForeColor = System.Drawing.Color.White;
            this.Exit.Image = global::RCT3启动器.Properties.Resources.退出;
            this.Exit.Location = new System.Drawing.Point(456, 358);
            this.Exit.Name = "Exit";
            this.Exit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Exit.Size = new System.Drawing.Size(128, 128);
            this.Exit.TabIndex = 8;
            this.Exit.Text = "\r\n\r\n\r\n\r\n\r\n\r\n 退出";
            this.Exit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.Exit.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.Exit.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.Exit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // CRepair
            // 
            this.CRepair.AllowDrop = true;
            this.CRepair.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.CRepair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CRepair.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(154)))), ((int)(((byte)(161)))));
            this.CRepair.FlatAppearance.BorderSize = 0;
            this.CRepair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.CRepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CRepair.Font = new System.Drawing.Font("黑体", 11F);
            this.CRepair.ForeColor = System.Drawing.Color.White;
            this.CRepair.Image = global::RCT3启动器.Properties.Resources.存档修复;
            this.CRepair.Location = new System.Drawing.Point(456, 222);
            this.CRepair.Name = "CRepair";
            this.CRepair.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CRepair.Size = new System.Drawing.Size(128, 128);
            this.CRepair.TabIndex = 7;
            this.CRepair.Text = "\r\n\r\n\r\n\r\n\r\n\r\n 存档修复";
            this.CRepair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CRepair.UseVisualStyleBackColor = false;
            this.CRepair.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.CRepair.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.CRepair.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.CRepair.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // RCT3Live
            // 
            this.RCT3Live.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.RCT3Live.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RCT3Live.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(154)))), ((int)(((byte)(161)))));
            this.RCT3Live.FlatAppearance.BorderSize = 0;
            this.RCT3Live.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.RCT3Live.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RCT3Live.Font = new System.Drawing.Font("黑体", 11F);
            this.RCT3Live.ForeColor = System.Drawing.Color.White;
            this.RCT3Live.Image = global::RCT3启动器.Properties.Resources.RCT3Live;
            this.RCT3Live.Location = new System.Drawing.Point(322, 358);
            this.RCT3Live.Name = "RCT3Live";
            this.RCT3Live.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RCT3Live.Size = new System.Drawing.Size(128, 128);
            this.RCT3Live.TabIndex = 6;
            this.RCT3Live.Text = "\r\n\r\n\r\n\r\n\r\n\r\n 游戏修复";
            this.RCT3Live.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RCT3Live.UseVisualStyleBackColor = false;
            this.RCT3Live.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.RCT3Live.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.RCT3Live.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.RCT3Live.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // MAdd
            // 
            this.MAdd.AllowDrop = true;
            this.MAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.MAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(154)))), ((int)(((byte)(161)))));
            this.MAdd.FlatAppearance.BorderSize = 0;
            this.MAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.MAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MAdd.Font = new System.Drawing.Font("黑体", 11F);
            this.MAdd.ForeColor = System.Drawing.Color.White;
            this.MAdd.Image = global::RCT3启动器.Properties.Resources.添加音乐;
            this.MAdd.Location = new System.Drawing.Point(322, 222);
            this.MAdd.Name = "MAdd";
            this.MAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MAdd.Size = new System.Drawing.Size(128, 128);
            this.MAdd.TabIndex = 5;
            this.MAdd.Text = "\r\n\r\n\r\n\r\n\r\n\r\n 添加音乐";
            this.MAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MAdd.UseVisualStyleBackColor = false;
            this.MAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.MAdd.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.MAdd.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.MAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // KAdd
            // 
            this.KAdd.AllowDrop = true;
            this.KAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.KAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.KAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.KAdd.FlatAppearance.BorderSize = 0;
            this.KAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.KAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.KAdd.Font = new System.Drawing.Font("黑体", 11F);
            this.KAdd.ForeColor = System.Drawing.Color.White;
            this.KAdd.Image = global::RCT3启动器.Properties.Resources.添加扩充;
            this.KAdd.Location = new System.Drawing.Point(322, 86);
            this.KAdd.Margin = new System.Windows.Forms.Padding(5);
            this.KAdd.Name = "KAdd";
            this.KAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.KAdd.Size = new System.Drawing.Size(262, 128);
            this.KAdd.TabIndex = 4;
            this.KAdd.Text = "\r\n\r\n\r\n\r\n\r\n\r\n 添加扩充";
            this.KAdd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.KAdd.UseVisualStyleBackColor = false;
            this.KAdd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.KAdd.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.KAdd.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.KAdd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // Web
            // 
            this.Web.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Web.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Web.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.Web.FlatAppearance.BorderSize = 0;
            this.Web.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.Web.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Web.Font = new System.Drawing.Font("黑体", 11F);
            this.Web.ForeColor = System.Drawing.Color.White;
            this.Web.Image = global::RCT3启动器.Properties.Resources.访问;
            this.Web.Location = new System.Drawing.Point(30, 358);
            this.Web.Margin = new System.Windows.Forms.Padding(5);
            this.Web.Name = "Web";
            this.Web.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Web.Size = new System.Drawing.Size(262, 128);
            this.Web.TabIndex = 3;
            this.Web.Text = "\r\n\r\n\r\n\r\n\r\n\r\n 访问过山车大亨3吧";
            this.Web.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Web.UseVisualStyleBackColor = false;
            this.Web.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.Web.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.Web.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.Web.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // GSetting
            // 
            this.GSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.GSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.GSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(154)))), ((int)(((byte)(161)))));
            this.GSetting.FlatAppearance.BorderSize = 0;
            this.GSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.GSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GSetting.Font = new System.Drawing.Font("黑体", 11F);
            this.GSetting.ForeColor = System.Drawing.Color.White;
            this.GSetting.Image = global::RCT3启动器.Properties.Resources.画面设置;
            this.GSetting.Location = new System.Drawing.Point(164, 222);
            this.GSetting.Name = "GSetting";
            this.GSetting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.GSetting.Size = new System.Drawing.Size(128, 128);
            this.GSetting.TabIndex = 2;
            this.GSetting.Text = "\r\n\r\n\r\n\r\n\r\n\r\n 游戏设置";
            this.GSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GSetting.UseVisualStyleBackColor = false;
            this.GSetting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.GSetting.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.GSetting.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.GSetting.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // QSetting
            // 
            this.QSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.QSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.QSetting.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(154)))), ((int)(((byte)(161)))));
            this.QSetting.FlatAppearance.BorderSize = 0;
            this.QSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.QSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QSetting.Font = new System.Drawing.Font("黑体", 11F);
            this.QSetting.ForeColor = System.Drawing.Color.White;
            this.QSetting.Image = global::RCT3启动器.Properties.Resources.启动器设置;
            this.QSetting.Location = new System.Drawing.Point(30, 222);
            this.QSetting.Name = "QSetting";
            this.QSetting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.QSetting.Size = new System.Drawing.Size(128, 128);
            this.QSetting.TabIndex = 1;
            this.QSetting.Text = "\r\n\r\n\r\n\r\n\r\n\r\n 启动器设置";
            this.QSetting.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QSetting.UseVisualStyleBackColor = false;
            this.QSetting.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.QSetting.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.QSetting.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.QSetting.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // StartGame
            // 
            this.StartGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.StartGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StartGame.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(199)))), ((int)(((byte)(199)))));
            this.StartGame.FlatAppearance.BorderSize = 0;
            this.StartGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.StartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartGame.Font = new System.Drawing.Font("黑体", 11F);
            this.StartGame.ForeColor = System.Drawing.Color.White;
            this.StartGame.Image = global::RCT3启动器.Properties.Resources.启动;
            this.StartGame.Location = new System.Drawing.Point(30, 86);
            this.StartGame.Margin = new System.Windows.Forms.Padding(5);
            this.StartGame.Name = "StartGame";
            this.StartGame.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartGame.Size = new System.Drawing.Size(262, 128);
            this.StartGame.TabIndex = 0;
            this.StartGame.Text = "\r\n\r\n\r\n\r\n\r\n\r\n 启动游戏";
            this.StartGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StartGame.UseVisualStyleBackColor = false;
            this.StartGame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.StartGame.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.StartGame.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            this.StartGame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // Drop
            // 
            this.Drop.Interval = 1;
            this.Drop.Tick += new System.EventHandler(this.Drop_Tick);
            // 
            // Say
            // 
            this.Say.AutoSize = true;
            this.Say.BackColor = System.Drawing.Color.Transparent;
            this.Say.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.Say.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Say.Location = new System.Drawing.Point(589, 467);
            this.Say.Name = "Say";
            this.Say.Size = new System.Drawing.Size(0, 19);
            this.Say.TabIndex = 16;
            // 
            // CRepair_Box
            // 
            this.CRepair_Box.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(81)))), ((int)(((byte)(85)))));
            this.CRepair_Box.Controls.Add(this.CustomSave);
            this.CRepair_Box.Controls.Add(this.FreedomModeSave);
            this.CRepair_Box.Location = new System.Drawing.Point(593, 269);
            this.CRepair_Box.Name = "CRepair_Box";
            this.CRepair_Box.Size = new System.Drawing.Size(194, 81);
            this.CRepair_Box.TabIndex = 17;
            this.CRepair_Box.Visible = false;
            // 
            // CustomSave
            // 
            this.CustomSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.CustomSave.FlatAppearance.BorderSize = 0;
            this.CustomSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CustomSave.ForeColor = System.Drawing.Color.White;
            this.CustomSave.Location = new System.Drawing.Point(0, 44);
            this.CustomSave.Name = "CustomSave";
            this.CustomSave.Size = new System.Drawing.Size(194, 37);
            this.CustomSave.TabIndex = 1;
            this.CustomSave.Text = "剧本编辑器存档";
            this.CustomSave.UseVisualStyleBackColor = true;
            this.CustomSave.Click += new System.EventHandler(this.SavesRepair);
            // 
            // FreedomModeSave
            // 
            this.FreedomModeSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.FreedomModeSave.FlatAppearance.BorderSize = 0;
            this.FreedomModeSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FreedomModeSave.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FreedomModeSave.ForeColor = System.Drawing.Color.White;
            this.FreedomModeSave.Location = new System.Drawing.Point(0, 0);
            this.FreedomModeSave.Name = "FreedomModeSave";
            this.FreedomModeSave.Size = new System.Drawing.Size(194, 37);
            this.FreedomModeSave.TabIndex = 0;
            this.FreedomModeSave.Text = "自由模式存档";
            this.FreedomModeSave.UseVisualStyleBackColor = true;
            this.FreedomModeSave.Click += new System.EventHandler(this.SavesRepair);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::RCT3启动器.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.CRepair_Box);
            this.Controls.Add(this.Say);
            this.Controls.Add(this.rcT_MessageBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.CRepair);
            this.Controls.Add(this.RCT3Live);
            this.Controls.Add(this.MAdd);
            this.Controls.Add(this.KAdd);
            this.Controls.Add(this.Web);
            this.Controls.Add(this.GSetting);
            this.Controls.Add(this.QSetting);
            this.Controls.Add(this.StartGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "RCT3启动器";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainFormMove_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.CRepair_Box.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Button QSetting;
        private System.Windows.Forms.Button GSetting;
        private System.Windows.Forms.Button Web;
        private System.Windows.Forms.Button KAdd;
        private System.Windows.Forms.Button MAdd;
        private System.Windows.Forms.Button RCT3Live;
        private System.Windows.Forms.Button CRepair;
        private System.Windows.Forms.Timer BigButtonOn;
        private System.Windows.Forms.Timer BigButtonOff;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Timer ButtonOn;
        private System.Windows.Forms.Timer ButtonOff;
        private System.Windows.Forms.Label Main_Function;
        private System.Windows.Forms.Label Line1;
        private System.Windows.Forms.Label More_Function;
        private System.Windows.Forms.Label Line2;
        private System.Windows.Forms.Panel panel1;
        private RCT3启动器MessageBox.RCT_MessageBox rcT_MessageBox2;
        private System.Windows.Forms.Timer Optimize;
        private System.Windows.Forms.Timer Drop;
        private System.Windows.Forms.Label Say;
        private System.Windows.Forms.Panel CRepair_Box;
        private System.Windows.Forms.Button CustomSave;
        private System.Windows.Forms.Button FreedomModeSave;
    }
}


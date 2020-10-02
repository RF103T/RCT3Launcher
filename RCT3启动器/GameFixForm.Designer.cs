namespace RCT3启动器
{
    partial class GameFixForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameFixForm));
            this.Exit = new System.Windows.Forms.Button();
            this.Tips = new System.Windows.Forms.TextBox();
            this.StartGuide = new System.Windows.Forms.Button();
            this.Step1 = new System.Windows.Forms.Panel();
            this.Step2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.OptionsCheckInformation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckScroll = new System.Windows.Forms.Timer(this.components);
            this.Install4GB = new System.Windows.Forms.Button();
            this.Step3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Step1.SuspendLayout();
            this.Step2.SuspendLayout();
            this.Step3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Exit.FlatAppearance.BorderSize = 0;
            this.Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.Exit.Location = new System.Drawing.Point(0, 360);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(350, 40);
            this.Exit.TabIndex = 23;
            this.Exit.Text = "退出此向导";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Tips
            // 
            this.Tips.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Tips.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tips.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Tips.Location = new System.Drawing.Point(12, 12);
            this.Tips.Multiline = true;
            this.Tips.Name = "Tips";
            this.Tips.ReadOnly = true;
            this.Tips.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Tips.Size = new System.Drawing.Size(326, 241);
            this.Tips.TabIndex = 24;
            this.Tips.Text = resources.GetString("Tips.Text");
            this.Tips.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFixForm_MouseDown);
            // 
            // StartGuide
            // 
            this.StartGuide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.StartGuide.FlatAppearance.BorderSize = 0;
            this.StartGuide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.StartGuide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartGuide.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.StartGuide.Location = new System.Drawing.Point(0, 320);
            this.StartGuide.Name = "StartGuide";
            this.StartGuide.Size = new System.Drawing.Size(350, 40);
            this.StartGuide.TabIndex = 25;
            this.StartGuide.Text = "开始向导";
            this.StartGuide.UseVisualStyleBackColor = false;
            this.StartGuide.Visible = false;
            this.StartGuide.Click += new System.EventHandler(this.StartGuide_Click);
            // 
            // Step1
            // 
            this.Step1.Controls.Add(this.label1);
            this.Step1.Location = new System.Drawing.Point(2, 2);
            this.Step1.Margin = new System.Windows.Forms.Padding(0);
            this.Step1.Name = "Step1";
            this.Step1.Size = new System.Drawing.Size(348, 93);
            this.Step1.TabIndex = 26;
            this.Step1.Visible = false;
            this.Step1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFixForm_MouseDown);
            // 
            // Step2
            // 
            this.Step2.Controls.Add(this.label2);
            this.Step2.Location = new System.Drawing.Point(0, 0);
            this.Step2.Margin = new System.Windows.Forms.Padding(0);
            this.Step2.Name = "Step2";
            this.Step2.Size = new System.Drawing.Size(350, 95);
            this.Step2.TabIndex = 27;
            this.Step2.Visible = false;
            this.Step2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFixForm_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 85);
            this.label2.TabIndex = 0;
            this.label2.Text = "———  第二步，共三步\r\n\r\n一些盗版游戏的主游戏文件版本已经落后，对新系统兼容性\r\n不佳，所以在这一步修复中会尝试用最新的RCT3plus.exe\r\n替换掉原" +
    "始文件。\r\n";
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFixForm_MouseDown);
            // 
            // OptionsCheckInformation
            // 
            this.OptionsCheckInformation.BackColor = System.Drawing.Color.White;
            this.OptionsCheckInformation.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OptionsCheckInformation.Location = new System.Drawing.Point(0, 95);
            this.OptionsCheckInformation.Margin = new System.Windows.Forms.Padding(0);
            this.OptionsCheckInformation.Multiline = true;
            this.OptionsCheckInformation.Name = "OptionsCheckInformation";
            this.OptionsCheckInformation.ReadOnly = true;
            this.OptionsCheckInformation.Size = new System.Drawing.Size(349, 225);
            this.OptionsCheckInformation.TabIndex = 1;
            this.OptionsCheckInformation.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(321, 85);
            this.label1.TabIndex = 0;
            this.label1.Text = "———  第一步，共三步\r\n\r\n有些游戏错误是因为无法创建在系统目录内的options.txt文\r\n件导致的，所以启动器会在这一步检测options.txt文件是" +
    "否\r\n存在，并且检查文件内容是否完整。\r\n";
            this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFixForm_MouseDown);
            // 
            // CheckScroll
            // 
            this.CheckScroll.Interval = 50;
            this.CheckScroll.Tick += new System.EventHandler(this.CheckScroll_Tick);
            // 
            // Install4GB
            // 
            this.Install4GB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.Install4GB.FlatAppearance.BorderSize = 0;
            this.Install4GB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(216)))), ((int)(((byte)(216)))));
            this.Install4GB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Install4GB.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.Install4GB.Location = new System.Drawing.Point(214, 259);
            this.Install4GB.Name = "Install4GB";
            this.Install4GB.Size = new System.Drawing.Size(124, 27);
            this.Install4GB.TabIndex = 28;
            this.Install4GB.Text = "安装4GB Patch";
            this.Install4GB.UseVisualStyleBackColor = false;
            this.Install4GB.Click += new System.EventHandler(this.Install4GB_Click);
            // 
            // Step3
            // 
            this.Step3.Controls.Add(this.label3);
            this.Step3.Location = new System.Drawing.Point(0, 0);
            this.Step3.Margin = new System.Windows.Forms.Padding(0);
            this.Step3.Name = "Step3";
            this.Step3.Size = new System.Drawing.Size(350, 95);
            this.Step3.TabIndex = 28;
            this.Step3.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(319, 68);
            this.label3.TabIndex = 0;
            this.label3.Text = "———  第三步，共三步\r\n\r\n某些情况下，系统的DEP保护会阻止游戏运行，所以需要针\r\n对游戏关闭DEP功能。\r\n";
            // 
            // GameFixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 400);
            this.ControlBox = false;
            this.Controls.Add(this.Step3);
            this.Controls.Add(this.OptionsCheckInformation);
            this.Controls.Add(this.Install4GB);
            this.Controls.Add(this.Step2);
            this.Controls.Add(this.Step1);
            this.Controls.Add(this.StartGuide);
            this.Controls.Add(this.Tips);
            this.Controls.Add(this.Exit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameFixForm";
            this.Text = "GameFix";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameFixForm_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Form_MouseEnter);
            this.Step1.ResumeLayout(false);
            this.Step1.PerformLayout();
            this.Step2.ResumeLayout(false);
            this.Step2.PerformLayout();
            this.Step3.ResumeLayout(false);
            this.Step3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TextBox Tips;
        private System.Windows.Forms.Button StartGuide;
        private System.Windows.Forms.Panel Step1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer CheckScroll;
        private System.Windows.Forms.TextBox OptionsCheckInformation;
        private System.Windows.Forms.Panel Step2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Install4GB;
        private System.Windows.Forms.Panel Step3;
        private System.Windows.Forms.Label label3;
    }
}
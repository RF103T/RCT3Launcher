namespace Win8_ON
{
    partial class Win8_OnOff
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Button_On = new System.Windows.Forms.Timer(this.components);
            this.Button_Move = new System.Windows.Forms.Timer(this.components);
            this.NotOff = new System.Windows.Forms.PictureBox();
            this.Button = new System.Windows.Forms.PictureBox();
            this.Off = new System.Windows.Forms.PictureBox();
            this.ON = new System.Windows.Forms.PictureBox();
            this.NotOn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NotOff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Off)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotOn)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_On
            // 
            this.Button_On.Interval = 5;
            this.Button_On.Tick += new System.EventHandler(this.Button_On_Tick);
            // 
            // Button_Move
            // 
            this.Button_Move.Interval = 10;
            this.Button_Move.Tick += new System.EventHandler(this.Button_Move_Tick);
            // 
            // NotOff
            // 
            this.NotOff.Image = global::Win8_ON.Properties.Resources.灰关;
            this.NotOff.Location = new System.Drawing.Point(0, 0);
            this.NotOff.Name = "NotOff";
            this.NotOff.Size = new System.Drawing.Size(50, 19);
            this.NotOff.TabIndex = 3;
            this.NotOff.TabStop = false;
            this.NotOff.Visible = false;
            // 
            // Button
            // 
            this.Button.Image = global::Win8_ON.Properties.Resources.滑块;
            this.Button.Location = new System.Drawing.Point(0, 0);
            this.Button.Margin = new System.Windows.Forms.Padding(0);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(12, 19);
            this.Button.TabIndex = 2;
            this.Button.TabStop = false;
            this.Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_MouseDown);
            this.Button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_MouseUp);
            // 
            // Off
            // 
            this.Off.Image = global::Win8_ON.Properties.Resources.处理4;
            this.Off.Location = new System.Drawing.Point(0, 0);
            this.Off.Margin = new System.Windows.Forms.Padding(0);
            this.Off.Name = "Off";
            this.Off.Size = new System.Drawing.Size(50, 19);
            this.Off.TabIndex = 1;
            this.Off.TabStop = false;
            this.Off.Click += new System.EventHandler(this.Off_Click);
            // 
            // ON
            // 
            this.ON.Image = global::Win8_ON.Properties.Resources.处理1;
            this.ON.Location = new System.Drawing.Point(0, 0);
            this.ON.Margin = new System.Windows.Forms.Padding(0);
            this.ON.Name = "ON";
            this.ON.Size = new System.Drawing.Size(50, 19);
            this.ON.TabIndex = 0;
            this.ON.TabStop = false;
            this.ON.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ON_MouseDown);
            this.ON.MouseEnter += new System.EventHandler(this.ON_MouseEnter);
            this.ON.MouseLeave += new System.EventHandler(this.ON_MouseLeave);
            this.ON.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ON_MouseUp);
            // 
            // NotOn
            // 
            this.NotOn.Image = global::Win8_ON.Properties.Resources.灰开;
            this.NotOn.Location = new System.Drawing.Point(0, 0);
            this.NotOn.Name = "NotOn";
            this.NotOn.Size = new System.Drawing.Size(50, 19);
            this.NotOn.TabIndex = 4;
            this.NotOn.TabStop = false;
            this.NotOn.Visible = false;
            // 
            // Win8_OnOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NotOn);
            this.Controls.Add(this.NotOff);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.Off);
            this.Controls.Add(this.ON);
            this.DoubleBuffered = true;
            this.Name = "Win8_OnOff";
            this.Size = new System.Drawing.Size(50, 19);
            ((System.ComponentModel.ISupportInitialize)(this.NotOff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Off)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotOn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ON;
        private System.Windows.Forms.PictureBox Off;
        private System.Windows.Forms.PictureBox Button;
        private System.Windows.Forms.Timer Button_On;
        private System.Windows.Forms.Timer Button_Move;
        private System.Windows.Forms.PictureBox NotOff;
        private System.Windows.Forms.PictureBox NotOn;
    }
}

namespace Project
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.slideTime = new System.Windows.Forms.Timer(this.components);
            this.bunifuElipse_Home = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel_main = new System.Windows.Forms.Panel();
            this.top_panel = new System.Windows.Forms.Panel();
            this.Line_Head = new System.Windows.Forms.Panel();
            this.lbl_name_th = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbl_name_eng = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Img_Rmuti = new System.Windows.Forms.PictureBox();
            this.Bottom_panel = new System.Windows.Forms.Panel();
            this.lbl_copy = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Mid_Panel = new System.Windows.Forms.Panel();
            this.btn_setPass = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btn_register = new Bunifu.Framework.UI.BunifuThinButton2();
            this.slidePic = new System.Windows.Forms.PictureBox();
            this.panel_main.SuspendLayout();
            this.top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Img_Rmuti)).BeginInit();
            this.Bottom_panel.SuspendLayout();
            this.Mid_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.slidePic)).BeginInit();
            this.SuspendLayout();
            // 
            // slideTime
            // 
            this.slideTime.Enabled = true;
            this.slideTime.Interval = 3000;
            this.slideTime.Tick += new System.EventHandler(this.slideTime_Tick);
            // 
            // bunifuElipse_Home
            // 
            this.bunifuElipse_Home.ElipseRadius = 5;
            this.bunifuElipse_Home.TargetControl = this;
            // 
            // panel_main
            // 
            this.panel_main.BackColor = System.Drawing.Color.Transparent;
            this.panel_main.BackgroundImage = global::Project.Properties.Resources.Home_bg;
            this.panel_main.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel_main.Controls.Add(this.top_panel);
            this.panel_main.Controls.Add(this.Bottom_panel);
            this.panel_main.Controls.Add(this.Mid_Panel);
            this.panel_main.Location = new System.Drawing.Point(0, 0);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(768, 1366);
            this.panel_main.TabIndex = 0;
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.Transparent;
            this.top_panel.Controls.Add(this.Line_Head);
            this.top_panel.Controls.Add(this.lbl_name_th);
            this.top_panel.Controls.Add(this.lbl_name_eng);
            this.top_panel.Controls.Add(this.Img_Rmuti);
            this.top_panel.Location = new System.Drawing.Point(0, 0);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(768, 201);
            this.top_panel.TabIndex = 10;
            // 
            // Line_Head
            // 
            this.Line_Head.BackColor = System.Drawing.Color.Black;
            this.Line_Head.Location = new System.Drawing.Point(127, 120);
            this.Line_Head.Name = "Line_Head";
            this.Line_Head.Size = new System.Drawing.Size(580, 2);
            this.Line_Head.TabIndex = 5;
            // 
            // lbl_name_th
            // 
            this.lbl_name_th.AutoSize = true;
            this.lbl_name_th.Font = new System.Drawing.Font("PSL Kanda Modern", 34.21782F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_name_th.Location = new System.Drawing.Point(115, 63);
            this.lbl_name_th.Name = "lbl_name_th";
            this.lbl_name_th.Size = new System.Drawing.Size(626, 59);
            this.lbl_name_th.TabIndex = 3;
            this.lbl_name_th.Text = "เครื่องบริการบัญชีสมาชิกอินเทอร์เน็ต มทร.อีสาน";
            // 
            // lbl_name_eng
            // 
            this.lbl_name_eng.AutoSize = true;
            this.lbl_name_eng.Font = new System.Drawing.Font("JS Junkaew", 24.23762F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name_eng.Location = new System.Drawing.Point(119, 126);
            this.lbl_name_eng.Name = "lbl_name_eng";
            this.lbl_name_eng.Size = new System.Drawing.Size(611, 37);
            this.lbl_name_eng.TabIndex = 4;
            this.lbl_name_eng.Text = "KIOSK FOR RMUTI INTERNET ACCOUNT SERVICE";
            // 
            // Img_Rmuti
            // 
            this.Img_Rmuti.Image = global::Project.Properties.Resources.RMUTI_logo_color2;
            this.Img_Rmuti.Location = new System.Drawing.Point(6, 9);
            this.Img_Rmuti.Name = "Img_Rmuti";
            this.Img_Rmuti.Size = new System.Drawing.Size(111, 168);
            this.Img_Rmuti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Img_Rmuti.TabIndex = 0;
            this.Img_Rmuti.TabStop = false;
            // 
            // Bottom_panel
            // 
            this.Bottom_panel.BackColor = System.Drawing.Color.Transparent;
            this.Bottom_panel.Controls.Add(this.lbl_copy);
            this.Bottom_panel.Location = new System.Drawing.Point(0, 1273);
            this.Bottom_panel.Name = "Bottom_panel";
            this.Bottom_panel.Size = new System.Drawing.Size(768, 93);
            this.Bottom_panel.TabIndex = 9;
            // 
            // lbl_copy
            // 
            this.lbl_copy.AutoSize = true;
            this.lbl_copy.Font = new System.Drawing.Font("PSL Similanya", 19.9604F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_copy.ForeColor = System.Drawing.Color.White;
            this.lbl_copy.Location = new System.Drawing.Point(30, 33);
            this.lbl_copy.Name = "lbl_copy";
            this.lbl_copy.Size = new System.Drawing.Size(713, 35);
            this.lbl_copy.TabIndex = 5;
            this.lbl_copy.Text = "Copyright © 2019. Computer Engineering, Rajamangala University of Technology ISAN" +
    "";
            // 
            // Mid_Panel
            // 
            this.Mid_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Mid_Panel.Controls.Add(this.btn_setPass);
            this.Mid_Panel.Controls.Add(this.btn_register);
            this.Mid_Panel.Controls.Add(this.slidePic);
            this.Mid_Panel.Location = new System.Drawing.Point(0, 201);
            this.Mid_Panel.Name = "Mid_Panel";
            this.Mid_Panel.Size = new System.Drawing.Size(768, 1072);
            this.Mid_Panel.TabIndex = 8;
            // 
            // btn_setPass
            // 
            this.btn_setPass.ActiveBorderThickness = 1;
            this.btn_setPass.ActiveCornerRadius = 70;
            this.btn_setPass.ActiveFillColor = System.Drawing.Color.Empty;
            this.btn_setPass.ActiveForecolor = System.Drawing.Color.Empty;
            this.btn_setPass.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(98)))), ((int)(((byte)(67)))));
            this.btn_setPass.BackColor = System.Drawing.Color.Transparent;
            this.btn_setPass.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_setPass.BackgroundImage")));
            this.btn_setPass.ButtonText = "เปลี่ยนรหัสผ่าน";
            this.btn_setPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_setPass.Font = new System.Drawing.Font("RSU", 19.9604F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_setPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(98)))), ((int)(((byte)(67)))));
            this.btn_setPass.IdleBorderThickness = 1;
            this.btn_setPass.IdleCornerRadius = 70;
            this.btn_setPass.IdleFillColor = System.Drawing.SystemColors.Control;
            this.btn_setPass.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(98)))), ((int)(((byte)(67)))));
            this.btn_setPass.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(98)))), ((int)(((byte)(67)))));
            this.btn_setPass.Location = new System.Drawing.Point(229, 727);
            this.btn_setPass.Margin = new System.Windows.Forms.Padding(5);
            this.btn_setPass.Name = "btn_setPass";
            this.btn_setPass.Size = new System.Drawing.Size(309, 81);
            this.btn_setPass.TabIndex = 2;
            this.btn_setPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_setPass.Click += new System.EventHandler(this.Btn_setPass_Click);
            this.btn_setPass.MouseDown += new System.EventHandler(this.Btn_setPass_MouseDown);
            this.btn_setPass.MouseHover += new System.EventHandler(this.Btn_setPass_MouseHover);
            this.btn_setPass.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_setPass_MouseUp);
            // 
            // btn_register
            // 
            this.btn_register.ActiveBorderThickness = 1;
            this.btn_register.ActiveCornerRadius = 70;
            this.btn_register.ActiveFillColor = System.Drawing.Color.Empty;
            this.btn_register.ActiveForecolor = System.Drawing.Color.Empty;
            this.btn_register.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
            this.btn_register.BackColor = System.Drawing.Color.Transparent;
            this.btn_register.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_register.BackgroundImage")));
            this.btn_register.ButtonText = "สมัครสมาชิก";
            this.btn_register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_register.Font = new System.Drawing.Font("RSU", 19.9604F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
            this.btn_register.IdleBorderThickness = 1;
            this.btn_register.IdleCornerRadius = 70;
            this.btn_register.IdleFillColor = System.Drawing.SystemColors.Control;
            this.btn_register.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
            this.btn_register.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
            this.btn_register.Location = new System.Drawing.Point(229, 621);
            this.btn_register.Margin = new System.Windows.Forms.Padding(5);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(309, 81);
            this.btn_register.TabIndex = 1;
            this.btn_register.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            this.btn_register.MouseDown += new System.EventHandler(this.Btn_register_MouseDown);
            this.btn_register.MouseHover += new System.EventHandler(this.Btn_register_MouseHover);
            this.btn_register.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_register_MouseUp);
            // 
            // slidePic
            // 
            this.slidePic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.slidePic.ErrorImage = null;
            this.slidePic.InitialImage = null;
            this.slidePic.Location = new System.Drawing.Point(-1, 240);
            this.slidePic.Name = "slidePic";
            this.slidePic.Size = new System.Drawing.Size(768, 330);
            this.slidePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.slidePic.TabIndex = 0;
            this.slidePic.TabStop = false;
            // 
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(768, 1366);
            this.Controls.Add(this.panel_main);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel_main.ResumeLayout(false);
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Img_Rmuti)).EndInit();
            this.Bottom_panel.ResumeLayout(false);
            this.Bottom_panel.PerformLayout();
            this.Mid_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.slidePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer slideTime;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Home;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Panel Line_Head;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_name_th;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_name_eng;
        private System.Windows.Forms.PictureBox Img_Rmuti;
        private System.Windows.Forms.Panel Bottom_panel;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_copy;
        private System.Windows.Forms.Panel Mid_Panel;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_setPass;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_register;
        private System.Windows.Forms.PictureBox slidePic;
    }
}


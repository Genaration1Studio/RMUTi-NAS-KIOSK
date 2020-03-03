namespace Project
{
    partial class ProfileUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfileUser));
            this.bunifuElipse_Profile = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel_main = new System.Windows.Forms.Panel();
            this.top_panel = new System.Windows.Forms.Panel();
            this.Line_Head = new System.Windows.Forms.Panel();
            this.lbl_name_th = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lbl_name_eng = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Img_Rmuti = new System.Windows.Forms.PictureBox();
            this.Bottom_panel = new System.Windows.Forms.Panel();
            this.lbl_copy = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.Mid_Panel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_head = new System.Windows.Forms.Label();
            this.btn_back = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_dept = new System.Windows.Forms.Label();
            this.lbl_fac = new System.Windows.Forms.Label();
            this.lbl_nameEN = new System.Windows.Forms.Label();
            this.Img_Profile = new System.Windows.Forms.PictureBox();
            this.lbl_nameTH = new System.Windows.Forms.Label();
            this.btn_submit = new Bunifu.Framework.UI.BunifuThinButton2();
            this.timer_removeC = new System.Windows.Forms.Timer(this.components);
            this.panel_main.SuspendLayout();
            this.top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Img_Rmuti)).BeginInit();
            this.Bottom_panel.SuspendLayout();
            this.Mid_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img_Profile)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse_Profile
            // 
            this.bunifuElipse_Profile.ElipseRadius = 5;
            this.bunifuElipse_Profile.TargetControl = this;
            // 
            // panel_main
            // 
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
            this.top_panel.TabIndex = 23;
            // 
            // Line_Head
            // 
            this.Line_Head.BackColor = System.Drawing.Color.Black;
            this.Line_Head.Location = new System.Drawing.Point(138, 127);
            this.Line_Head.Name = "Line_Head";
            this.Line_Head.Size = new System.Drawing.Size(580, 2);
            this.Line_Head.TabIndex = 17;
            // 
            // lbl_name_th
            // 
            this.lbl_name_th.AutoSize = true;
            this.lbl_name_th.Font = new System.Drawing.Font("PSL Kanda Modern", 34.21782F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_name_th.Location = new System.Drawing.Point(126, 70);
            this.lbl_name_th.Name = "lbl_name_th";
            this.lbl_name_th.Size = new System.Drawing.Size(626, 59);
            this.lbl_name_th.TabIndex = 2;
            this.lbl_name_th.Text = "เครื่องบริการบัญชีสมาชิกอินเทอร์เน็ต มทร.อีสาน";
            // 
            // lbl_name_eng
            // 
            this.lbl_name_eng.AutoSize = true;
            this.lbl_name_eng.Font = new System.Drawing.Font("JS Junkaew", 24.23762F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name_eng.Location = new System.Drawing.Point(130, 133);
            this.lbl_name_eng.Name = "lbl_name_eng";
            this.lbl_name_eng.Size = new System.Drawing.Size(611, 37);
            this.lbl_name_eng.TabIndex = 3;
            this.lbl_name_eng.Text = "KIOSK FOR RMUTI INTERNET ACCOUNT SERVICE";
            // 
            // Img_Rmuti
            // 
            this.Img_Rmuti.Image = global::Project.Properties.Resources.RMUTI_logo_color2;
            this.Img_Rmuti.Location = new System.Drawing.Point(17, 16);
            this.Img_Rmuti.Name = "Img_Rmuti";
            this.Img_Rmuti.Size = new System.Drawing.Size(111, 168);
            this.Img_Rmuti.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Img_Rmuti.TabIndex = 15;
            this.Img_Rmuti.TabStop = false;
            // 
            // Bottom_panel
            // 
            this.Bottom_panel.BackColor = System.Drawing.Color.Transparent;
            this.Bottom_panel.Controls.Add(this.lbl_copy);
            this.Bottom_panel.Location = new System.Drawing.Point(0, 1273);
            this.Bottom_panel.Name = "Bottom_panel";
            this.Bottom_panel.Size = new System.Drawing.Size(768, 93);
            this.Bottom_panel.TabIndex = 22;
            // 
            // lbl_copy
            // 
            this.lbl_copy.AutoSize = true;
            this.lbl_copy.Font = new System.Drawing.Font("PSL Similanya", 19.9604F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_copy.ForeColor = System.Drawing.Color.White;
            this.lbl_copy.Location = new System.Drawing.Point(28, 29);
            this.lbl_copy.Name = "lbl_copy";
            this.lbl_copy.Size = new System.Drawing.Size(713, 35);
            this.lbl_copy.TabIndex = 11;
            this.lbl_copy.Text = "Copyright © 2019. Computer Engineering, Rajamangala University of Technology ISAN" +
    "";
            // 
            // Mid_Panel
            // 
            this.Mid_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Mid_Panel.Controls.Add(this.pictureBox1);
            this.Mid_Panel.Controls.Add(this.lbl_head);
            this.Mid_Panel.Controls.Add(this.btn_back);
            this.Mid_Panel.Controls.Add(this.label6);
            this.Mid_Panel.Controls.Add(this.label5);
            this.Mid_Panel.Controls.Add(this.lbl_dept);
            this.Mid_Panel.Controls.Add(this.lbl_fac);
            this.Mid_Panel.Controls.Add(this.lbl_nameEN);
            this.Mid_Panel.Controls.Add(this.Img_Profile);
            this.Mid_Panel.Controls.Add(this.lbl_nameTH);
            this.Mid_Panel.Controls.Add(this.btn_submit);
            this.Mid_Panel.Location = new System.Drawing.Point(0, 201);
            this.Mid_Panel.Name = "Mid_Panel";
            this.Mid_Panel.Size = new System.Drawing.Size(768, 1072);
            this.Mid_Panel.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Project.Properties.Resources.next_480px;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(49, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(27, 36);
            this.pictureBox1.TabIndex = 40;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_head
            // 
            this.lbl_head.AutoSize = true;
            this.lbl_head.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_head.Font = new System.Drawing.Font("RSU", 15.68317F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lbl_head.ForeColor = System.Drawing.Color.Black;
            this.lbl_head.Location = new System.Drawing.Point(83, 37);
            this.lbl_head.Name = "lbl_head";
            this.lbl_head.Size = new System.Drawing.Size(296, 35);
            this.lbl_head.TabIndex = 4;
            this.lbl_head.Text = "ยืนยันข้อมูลส่วนตัว (ขั้นตอนที่ 3/4) ";
            // 
            // btn_back
            // 
            this.btn_back.Image = global::Project.Properties.Resources.Back_100px;
            this.btn_back.Location = new System.Drawing.Point(1, 341);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(75, 229);
            this.btn_back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_back.TabIndex = 38;
            this.btn_back.TabStop = false;
            this.btn_back.Click += new System.EventHandler(this.Btn_back_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Ekkamai Standard", 14.25742F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.label6.Location = new System.Drawing.Point(190, 618);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(425, 30);
            this.label6.TabIndex = 10;
            this.label6.Text = "จากนั้นกดสมัครสมาชิกเพื่อยืนยันการสมัครสมาชิก";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Ekkamai Standard", 14.25742F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.label5.Location = new System.Drawing.Point(216, 570);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(364, 30);
            this.label5.TabIndex = 9;
            this.label5.Text = ":: กรุณาตรวจสอบความถูกต้องของข้อมูล ::";
            // 
            // lbl_dept
            // 
            this.lbl_dept.AutoSize = true;
            this.lbl_dept.Font = new System.Drawing.Font("Ekkamai Standard", 15.68317F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_dept.Location = new System.Drawing.Point(178, 506);
            this.lbl_dept.Name = "lbl_dept";
            this.lbl_dept.Size = new System.Drawing.Size(115, 35);
            this.lbl_dept.TabIndex = 8;
            this.lbl_dept.Text = "สาขาวิชา :";
            // 
            // lbl_fac
            // 
            this.lbl_fac.AutoSize = true;
            this.lbl_fac.Font = new System.Drawing.Font("Ekkamai Standard", 15.68317F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fac.Location = new System.Drawing.Point(183, 444);
            this.lbl_fac.Name = "lbl_fac";
            this.lbl_fac.Size = new System.Drawing.Size(108, 35);
            this.lbl_fac.TabIndex = 7;
            this.lbl_fac.Text = "หลักสูตร :";
            // 
            // lbl_nameEN
            // 
            this.lbl_nameEN.AutoSize = true;
            this.lbl_nameEN.Font = new System.Drawing.Font("Ekkamai Standard", 15.68317F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nameEN.Location = new System.Drawing.Point(95, 390);
            this.lbl_nameEN.Name = "lbl_nameEN";
            this.lbl_nameEN.Size = new System.Drawing.Size(200, 35);
            this.lbl_nameEN.TabIndex = 6;
            this.lbl_nameEN.Text = "ชื่อ-สกุล (อังกฤษ) :";
            // 
            // Img_Profile
            // 
            this.Img_Profile.Image = global::Project.Properties.Resources.resume_520px;
            this.Img_Profile.Location = new System.Drawing.Point(307, 77);
            this.Img_Profile.Name = "Img_Profile";
            this.Img_Profile.Size = new System.Drawing.Size(241, 211);
            this.Img_Profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Img_Profile.TabIndex = 31;
            this.Img_Profile.TabStop = false;
            // 
            // lbl_nameTH
            // 
            this.lbl_nameTH.AutoSize = true;
            this.lbl_nameTH.Font = new System.Drawing.Font("Ekkamai Standard", 15.68317F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nameTH.Location = new System.Drawing.Point(186, 332);
            this.lbl_nameTH.Name = "lbl_nameTH";
            this.lbl_nameTH.Size = new System.Drawing.Size(103, 35);
            this.lbl_nameTH.TabIndex = 5;
            this.lbl_nameTH.Text = "ชื่อ-สกุล :";
            // 
            // btn_submit
            // 
            this.btn_submit.ActiveBorderThickness = 1;
            this.btn_submit.ActiveCornerRadius = 70;
            this.btn_submit.ActiveFillColor = System.Drawing.Color.Empty;
            this.btn_submit.ActiveForecolor = System.Drawing.Color.Empty;
            this.btn_submit.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
            this.btn_submit.BackColor = System.Drawing.Color.Transparent;
            this.btn_submit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_submit.BackgroundImage")));
            this.btn_submit.ButtonText = "สมัครสมาชิก";
            this.btn_submit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_submit.Font = new System.Drawing.Font("RSU", 19.9604F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
            this.btn_submit.IdleBorderThickness = 1;
            this.btn_submit.IdleCornerRadius = 70;
            this.btn_submit.IdleFillColor = System.Drawing.SystemColors.Control;
            this.btn_submit.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
            this.btn_submit.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(83)))), ((int)(((byte)(70)))));
            this.btn_submit.Location = new System.Drawing.Point(232, 711);
            this.btn_submit.Margin = new System.Windows.Forms.Padding(5);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(309, 81);
            this.btn_submit.TabIndex = 1;
            this.btn_submit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_submit.Click += new System.EventHandler(this.Btn_submit_Click);
            this.btn_submit.MouseDown += new System.EventHandler(this.Btn_submit_MouseDown);
            this.btn_submit.MouseHover += new System.EventHandler(this.Btn_submit_MouseHover);
            this.btn_submit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_submit_MouseUp);
            // 
            // timer_removeC
            // 
            this.timer_removeC.Interval = 1000;
            this.timer_removeC.Tick += new System.EventHandler(this.Timer_removeC_Tick);
            // 
            // ProfileUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(768, 1366);
            this.Controls.Add(this.panel_main);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProfileUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProfileUser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel_main.ResumeLayout(false);
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Img_Rmuti)).EndInit();
            this.Bottom_panel.ResumeLayout(false);
            this.Bottom_panel.PerformLayout();
            this.Mid_Panel.ResumeLayout(false);
            this.Mid_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img_Profile)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse_Profile;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Panel Line_Head;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_name_th;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_name_eng;
        private System.Windows.Forms.PictureBox Img_Rmuti;
        private System.Windows.Forms.Panel Bottom_panel;
        private Bunifu.Framework.UI.BunifuCustomLabel lbl_copy;
        private System.Windows.Forms.Panel Mid_Panel;
        private System.Windows.Forms.PictureBox btn_back;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_dept;
        private System.Windows.Forms.Label lbl_fac;
        private System.Windows.Forms.Label lbl_nameEN;
        private System.Windows.Forms.PictureBox Img_Profile;
        private System.Windows.Forms.Label lbl_nameTH;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_submit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_head;
        private System.Windows.Forms.Timer timer_removeC;
    }
}
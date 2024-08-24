namespace Driving_School_Management_System
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.PictureBox();
            this.btnclose = new System.Windows.Forms.PictureBox();
            this.btnMenu = new System.Windows.Forms.PictureBox();
            this.SideBar = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMain = new System.Windows.Forms.Button();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCondidtes = new System.Windows.Forms.Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.guna2Panel7 = new Guna.UI2.WinForms.Guna2Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnFinance = new System.Windows.Forms.Button();
            this.guna2Panel8 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.guna2Panel9 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnServices = new System.Windows.Forms.Button();
            this.guna2Panel6 = new Guna.UI2.WinForms.Guna2Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.UserNamePanel = new Sipaa.Framework.SPanel();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SideBarTimer = new System.Windows.Forms.Timer(this.components);
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).BeginInit();
            this.SideBar.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel7.SuspendLayout();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel8.SuspendLayout();
            this.guna2Panel5.SuspendLayout();
            this.guna2Panel9.SuspendLayout();
            this.guna2Panel6.SuspendLayout();
            this.UserNamePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.White;
            this.TopPanel.Controls.Add(this.btnMinimize);
            this.TopPanel.Controls.Add(this.btnclose);
            this.TopPanel.Controls.Add(this.btnMenu);
            resources.ApplyResources(this.TopPanel, "TopPanel");
            this.TopPanel.Name = "TopPanel";
            // 
            // btnMinimize
            // 
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnMinimize, "btnMinimize");
            this.btnMinimize.Image = global::Driving_School_Management_System.Properties.Resources.arrows_in_simple_fill;
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnclose
            // 
            this.btnclose.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnclose, "btnclose");
            this.btnclose.Image = global::Driving_School_Management_System.Properties.Resources.x_circle_fill;
            this.btnclose.Name = "btnclose";
            this.btnclose.TabStop = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.btnMenu, "btnMenu");
            this.btnMenu.Image = global::Driving_School_Management_System.Properties.Resources.list__2_;
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.TabStop = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.White;
            this.SideBar.Controls.Add(this.guna2Panel2);
            this.SideBar.Controls.Add(this.guna2Panel4);
            this.SideBar.Controls.Add(this.guna2Panel1);
            this.SideBar.Controls.Add(this.guna2Panel7);
            this.SideBar.Controls.Add(this.guna2Panel3);
            this.SideBar.Controls.Add(this.guna2Panel8);
            this.SideBar.Controls.Add(this.guna2Separator2);
            this.SideBar.Controls.Add(this.guna2Panel5);
            this.SideBar.Controls.Add(this.guna2Panel9);
            this.SideBar.Controls.Add(this.guna2Panel6);
            this.SideBar.Controls.Add(this.UserNamePanel);
            resources.ApplyResources(this.SideBar, "SideBar");
            this.SideBar.Name = "SideBar";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 8;
            this.guna2Panel2.Controls.Add(this.btnMain);
            this.guna2Panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.guna2Panel2, "guna2Panel2");
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(175)))), ((int)(((byte)(29)))));
            resources.ApplyResources(this.btnMain, "btnMain");
            this.btnMain.Image = global::Driving_School_Management_System.Properties.Resources.house;
            this.btnMain.Name = "btnMain";
            this.btnMain.UseVisualStyleBackColor = false;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderRadius = 8;
            this.guna2Panel4.Controls.Add(this.btnCondidtes);
            this.guna2Panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.guna2Panel4, "guna2Panel4");
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.Parent = this.guna2Panel4;
            // 
            // btnCondidtes
            // 
            resources.ApplyResources(this.btnCondidtes, "btnCondidtes");
            this.btnCondidtes.Image = global::Driving_School_Management_System.Properties.Resources.users;
            this.btnCondidtes.Name = "btnCondidtes";
            this.btnCondidtes.UseVisualStyleBackColor = true;
            this.btnCondidtes.Click += new System.EventHandler(this.btnCondidtes_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderRadius = 8;
            this.guna2Panel1.Controls.Add(this.button5);
            this.guna2Panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.guna2Panel1, "guna2Panel1");
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.Parent = this.guna2Panel1;
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Image = global::Driving_School_Management_System.Properties.Resources.book_bookmark;
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // guna2Panel7
            // 
            this.guna2Panel7.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel7.BorderRadius = 8;
            this.guna2Panel7.Controls.Add(this.button3);
            this.guna2Panel7.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.guna2Panel7, "guna2Panel7");
            this.guna2Panel7.Name = "guna2Panel7";
            this.guna2Panel7.ShadowDecoration.Parent = this.guna2Panel7;
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Image = global::Driving_School_Management_System.Properties.Resources.exam;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel3.BorderRadius = 8;
            this.guna2Panel3.Controls.Add(this.btnFinance);
            this.guna2Panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.guna2Panel3, "guna2Panel3");
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.ShadowDecoration.Parent = this.guna2Panel3;
            // 
            // btnFinance
            // 
            resources.ApplyResources(this.btnFinance, "btnFinance");
            this.btnFinance.Image = global::Driving_School_Management_System.Properties.Resources.coins1;
            this.btnFinance.Name = "btnFinance";
            this.btnFinance.UseVisualStyleBackColor = true;
            // 
            // guna2Panel8
            // 
            this.guna2Panel8.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel8.BorderRadius = 8;
            this.guna2Panel8.Controls.Add(this.btnStatistics);
            this.guna2Panel8.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.guna2Panel8, "guna2Panel8");
            this.guna2Panel8.Name = "guna2Panel8";
            this.guna2Panel8.ShadowDecoration.Parent = this.guna2Panel8;
            // 
            // btnStatistics
            // 
            resources.ApplyResources(this.btnStatistics, "btnStatistics");
            this.btnStatistics.Image = global::Driving_School_Management_System.Properties.Resources.gear;
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.UseVisualStyleBackColor = true;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.guna2Separator2, "guna2Separator2");
            this.guna2Separator2.Name = "guna2Separator2";
            // 
            // guna2Panel5
            // 
            this.guna2Panel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel5.BorderRadius = 8;
            this.guna2Panel5.Controls.Add(this.button1);
            this.guna2Panel5.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.guna2Panel5, "guna2Panel5");
            this.guna2Panel5.Name = "guna2Panel5";
            this.guna2Panel5.ShadowDecoration.Parent = this.guna2Panel5;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Image = global::Driving_School_Management_System.Properties.Resources.chart_line;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel9.BorderRadius = 8;
            this.guna2Panel9.Controls.Add(this.btnServices);
            this.guna2Panel9.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.guna2Panel9, "guna2Panel9");
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.ShadowDecoration.Parent = this.guna2Panel9;
            // 
            // btnServices
            // 
            resources.ApplyResources(this.btnServices, "btnServices");
            this.btnServices.Image = global::Driving_School_Management_System.Properties.Resources.scroll;
            this.btnServices.Name = "btnServices";
            this.btnServices.UseVisualStyleBackColor = true;
            // 
            // guna2Panel6
            // 
            this.guna2Panel6.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel6.BorderRadius = 8;
            this.guna2Panel6.Controls.Add(this.button2);
            this.guna2Panel6.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.guna2Panel6, "guna2Panel6");
            this.guna2Panel6.Name = "guna2Panel6";
            this.guna2Panel6.ShadowDecoration.Parent = this.guna2Panel6;
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Image = global::Driving_School_Management_System.Properties.Resources.sign_out;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // UserNamePanel
            // 
            this.UserNamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(186)))), ((int)(((byte)(188)))));
            this.UserNamePanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.UserNamePanel.BorderRadius = 12;
            this.UserNamePanel.BorderSize = 0;
            this.UserNamePanel.Controls.Add(this.lblUserName);
            this.UserNamePanel.Controls.Add(this.pictureBox2);
            this.UserNamePanel.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.UserNamePanel, "UserNamePanel");
            this.UserNamePanel.Name = "UserNamePanel";
            // 
            // lblUserName
            // 
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.lblUserName.Name = "lblUserName";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Driving_School_Management_System.Properties.Resources.user_circle_fill;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // SideBarTimer
            // 
            this.SideBarTimer.Interval = 10;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.SideBar);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMenu)).EndInit();
            this.SideBar.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel7.ResumeLayout(false);
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel8.ResumeLayout(false);
            this.guna2Panel5.ResumeLayout(false);
            this.guna2Panel9.ResumeLayout(false);
            this.guna2Panel6.ResumeLayout(false);
            this.UserNamePanel.ResumeLayout(false);
            this.UserNamePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.FlowLayoutPanel SideBar;
        private System.Windows.Forms.PictureBox btnMenu;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private System.Windows.Forms.Button btnFinance;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel8;
        private System.Windows.Forms.Button btnStatistics;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Button btnMain;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Button btnCondidtes;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private System.Windows.Forms.Button btnServices;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private System.Windows.Forms.Button button1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel6;
        private System.Windows.Forms.Button button2;
        private Sipaa.Framework.SPanel UserNamePanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Timer SideBarTimer;
        private System.Windows.Forms.PictureBox btnclose;
        private System.Windows.Forms.PictureBox btnMinimize;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Button button5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel7;
        private System.Windows.Forms.Button button3;
    }
}


namespace Driving_School_Management_System.Forms
{
    partial class CondidatesWindow
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
            this.SideBar = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnMain = new System.Windows.Forms.Button();
            this.guna2Panel4 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCondidtes = new System.Windows.Forms.Button();
            this.SideBar.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.White;
            this.SideBar.Controls.Add(this.guna2Panel2);
            this.SideBar.Controls.Add(this.guna2Panel4);
            this.SideBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.SideBar.Location = new System.Drawing.Point(849, 0);
            this.SideBar.Margin = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(203, 652);
            this.SideBar.TabIndex = 2;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 8;
            this.guna2Panel2.Controls.Add(this.btnMain);
            this.guna2Panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Panel2.Font = new System.Drawing.Font("Tahoma", 10F);
            this.guna2Panel2.Location = new System.Drawing.Point(3, 3);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.ShadowDecoration.Parent = this.guna2Panel2;
            this.guna2Panel2.Size = new System.Drawing.Size(234, 56);
            this.guna2Panel2.TabIndex = 6;
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(175)))), ((int)(((byte)(29)))));
            this.btnMain.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnMain.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnMain.Location = new System.Drawing.Point(-9, -10);
            this.btnMain.Name = "btnMain";
            this.btnMain.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnMain.Size = new System.Drawing.Size(252, 80);
            this.btnMain.TabIndex = 3;
            this.btnMain.Text = "إدارة المترشحين";
            this.btnMain.UseVisualStyleBackColor = false;
            // 
            // guna2Panel4
            // 
            this.guna2Panel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel4.BorderRadius = 8;
            this.guna2Panel4.Controls.Add(this.btnCondidtes);
            this.guna2Panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Panel4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.guna2Panel4.Location = new System.Drawing.Point(3, 65);
            this.guna2Panel4.Name = "guna2Panel4";
            this.guna2Panel4.ShadowDecoration.Parent = this.guna2Panel4;
            this.guna2Panel4.Size = new System.Drawing.Size(234, 56);
            this.guna2Panel4.TabIndex = 6;
            // 
            // btnCondidtes
            // 
            this.btnCondidtes.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnCondidtes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCondidtes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCondidtes.Location = new System.Drawing.Point(-9, -10);
            this.btnCondidtes.Name = "btnCondidtes";
            this.btnCondidtes.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.btnCondidtes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnCondidtes.Size = new System.Drawing.Size(252, 80);
            this.btnCondidtes.TabIndex = 3;
            this.btnCondidtes.Text = "إدارة الملفات";
            this.btnCondidtes.UseVisualStyleBackColor = true;
            // 
            // CondidatesWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1052, 652);
            this.Controls.Add(this.SideBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "CondidatesWindow";
            this.RightToLeftLayout = true;
            this.Text = "CondidatesWindow";
            this.SideBar.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel SideBar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Button btnMain;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel4;
        private System.Windows.Forms.Button btnCondidtes;
    }
}
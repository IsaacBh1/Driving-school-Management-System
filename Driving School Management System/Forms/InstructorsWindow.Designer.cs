namespace Driving_School_Management_System.Forms
{
    partial class InstructorsWindow
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
            this.flowLayoutPanelInstructors = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddInsructor = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // flowLayoutPanelInstructors
            // 
            this.flowLayoutPanelInstructors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelInstructors.AutoScroll = true;
            this.flowLayoutPanelInstructors.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanelInstructors.Location = new System.Drawing.Point(11, 101);
            this.flowLayoutPanelInstructors.Name = "flowLayoutPanelInstructors";
            this.flowLayoutPanelInstructors.Size = new System.Drawing.Size(1109, 593);
            this.flowLayoutPanelInstructors.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.label1.Location = new System.Drawing.Point(932, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 20, 20, 0);
            this.label1.Size = new System.Drawing.Size(200, 51);
            this.label1.TabIndex = 29;
            this.label1.Text = "إدارة المدربين";
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderRadius = 10;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.Black;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Image = global::Driving_School_Management_System.Properties.Resources.arrows_clockwise;
            this.guna2Button3.Location = new System.Drawing.Point(138, 28);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(41, 43);
            this.guna2Button3.TabIndex = 31;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // btnAddInsructor
            // 
            this.btnAddInsructor.BorderRadius = 10;
            this.btnAddInsructor.CheckedState.Parent = this.btnAddInsructor;
            this.btnAddInsructor.CustomImages.Parent = this.btnAddInsructor;
            this.btnAddInsructor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(175)))), ((int)(((byte)(29)))));
            this.btnAddInsructor.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddInsructor.ForeColor = System.Drawing.Color.Black;
            this.btnAddInsructor.HoverState.Parent = this.btnAddInsructor;
            this.btnAddInsructor.Image = global::Driving_School_Management_System.Properties.Resources.plus_bold;
            this.btnAddInsructor.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAddInsructor.Location = new System.Drawing.Point(6, 27);
            this.btnAddInsructor.Name = "btnAddInsructor";
            this.btnAddInsructor.ShadowDecoration.Parent = this.btnAddInsructor;
            this.btnAddInsructor.Size = new System.Drawing.Size(126, 44);
            this.btnAddInsructor.TabIndex = 28;
            this.btnAddInsructor.Text = "إضافة ";
            this.btnAddInsructor.Click += new System.EventHandler(this.btnAddInsructor_Click);
            // 
            // InstructorsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 708);
            this.Controls.Add(this.guna2Button3);
            this.Controls.Add(this.flowLayoutPanelInstructors);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddInsructor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InstructorsWindow";
            this.Text = "InstructorsWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelInstructors;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnAddInsructor;
    }
}
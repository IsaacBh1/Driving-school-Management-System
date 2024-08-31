namespace Driving_School_Management_System
{
    partial class CalenderDay
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.NumberDay = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.NumberDay);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(143, 127);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Click += new System.EventHandler(this.flowLayoutPanelClick_Paint);
            // 
            // NumberDay
            // 
            this.NumberDay.AutoSize = true;
            this.NumberDay.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberDay.Location = new System.Drawing.Point(51, 0);
            this.NumberDay.Name = "NumberDay";
            this.NumberDay.Size = new System.Drawing.Size(89, 26);
            this.NumberDay.TabIndex = 0;
            this.NumberDay.Text = "DayNum";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 29);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(137, 83);
            this.flowLayoutPanel2.TabIndex = 1;
            this.flowLayoutPanel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // CalenderDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(175)))), ((int)(((byte)(29)))));
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CalenderDay";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(145, 129);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.flowLayoutPanel1_Paint);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label NumberDay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}

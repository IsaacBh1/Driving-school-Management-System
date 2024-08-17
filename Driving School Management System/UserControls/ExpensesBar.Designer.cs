namespace Driving_School_Management_System
{
    partial class ExpensesBar
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
            this.NameOfExpence = new System.Windows.Forms.Label();
            this.ValueOfExpence = new System.Windows.Forms.Label();
            this.ExpenceProgressBar = new Guna.UI2.WinForms.Guna2ProgressBar();
            this.SuspendLayout();
            // 
            // NameOfExpence
            // 
            this.NameOfExpence.AutoSize = true;
            this.NameOfExpence.Font = new System.Drawing.Font("Tahoma", 10F);
            this.NameOfExpence.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.NameOfExpence.Location = new System.Drawing.Point(295, 6);
            this.NameOfExpence.Name = "NameOfExpence";
            this.NameOfExpence.Size = new System.Drawing.Size(148, 24);
            this.NameOfExpence.TabIndex = 0;
            this.NameOfExpence.Text = "Expence Name ";
            // 
            // ValueOfExpence
            // 
            this.ValueOfExpence.AutoSize = true;
            this.ValueOfExpence.ForeColor = System.Drawing.Color.Gray;
            this.ValueOfExpence.Location = new System.Drawing.Point(209, 10);
            this.ValueOfExpence.Name = "ValueOfExpence";
            this.ValueOfExpence.Size = new System.Drawing.Size(77, 19);
            this.ValueOfExpence.TabIndex = 1;
            this.ValueOfExpence.Text = "00.00 DA";
            // 
            // ExpenceProgressBar
            // 
            this.ExpenceProgressBar.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.ExpenceProgressBar.Location = new System.Drawing.Point(20, 34);
            this.ExpenceProgressBar.Name = "ExpenceProgressBar";
            this.ExpenceProgressBar.ShadowDecoration.Parent = this.ExpenceProgressBar;
            this.ExpenceProgressBar.Size = new System.Drawing.Size(420, 14);
            this.ExpenceProgressBar.TabIndex = 2;
            this.ExpenceProgressBar.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // ExpensesBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Controls.Add(this.ExpenceProgressBar);
            this.Controls.Add(this.ValueOfExpence);
            this.Controls.Add(this.NameOfExpence);
            this.Name = "ExpensesBar";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(456, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameOfExpence;
        private System.Windows.Forms.Label ValueOfExpence;
        private Guna.UI2.WinForms.Guna2ProgressBar ExpenceProgressBar;
    }
}

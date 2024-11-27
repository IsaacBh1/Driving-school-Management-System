namespace Driving_School_Management_System.Forms
{
    partial class ExamsWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.CboxExamType = new MetroFramework.Controls.MetroComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textbxCondidateFileID = new System.Windows.Forms.TextBox();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.cboxStatus = new MetroFramework.Controls.MetroComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CBoxExamsFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnSearchLesson = new Guna.UI2.WinForms.Guna2Button();
            this.DGVExams = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CondidateFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CondidateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operations = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnAddExam = new Guna.UI2.WinForms.Guna2Button();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVExams)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.Location = new System.Drawing.Point(-9, 52);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1196, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // CboxExamType
            // 
            this.CboxExamType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CboxExamType.FormattingEnabled = true;
            this.CboxExamType.ItemHeight = 23;
            this.CboxExamType.Items.AddRange(new object[] {
            "نظري",
            "تطبيقي"});
            this.CboxExamType.Location = new System.Drawing.Point(21, 34);
            this.CboxExamType.Name = "CboxExamType";
            this.CboxExamType.Size = new System.Drawing.Size(157, 29);
            this.CboxExamType.TabIndex = 25;
            this.CboxExamType.UseSelectable = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(66, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 28);
            this.label3.TabIndex = 23;
            this.label3.Text = "نوع الامتحان";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.CboxExamType);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(599, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(183, 83);
            this.panel5.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(110, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 28);
            this.label6.TabIndex = 23;
            this.label6.Text = "الملف";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textbxCondidateFileID);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(788, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(183, 83);
            this.panel4.TabIndex = 24;
            // 
            // textbxCondidateFileID
            // 
            this.textbxCondidateFileID.Location = new System.Drawing.Point(16, 36);
            this.textbxCondidateFileID.Name = "textbxCondidateFileID";
            this.textbxCondidateFileID.Size = new System.Drawing.Size(157, 27);
            this.textbxCondidateFileID.TabIndex = 26;
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(18, 35);
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(157, 27);
            this.txtBoxID.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(145, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 28);
            this.label5.TabIndex = 23;
            this.label5.Text = "ID";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtBoxID);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(977, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 83);
            this.panel3.TabIndex = 23;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(14, 125);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1163, 100);
            this.flowLayoutPanel1.TabIndex = 24;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.cboxStatus);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Location = new System.Drawing.Point(410, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(183, 83);
            this.panel6.TabIndex = 27;
            // 
            // cboxStatus
            // 
            this.cboxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxStatus.FormattingEnabled = true;
            this.cboxStatus.ItemHeight = 23;
            this.cboxStatus.Items.AddRange(new object[] {
            "مبرمج",
            "ناجح",
            "راسب"});
            this.cboxStatus.Location = new System.Drawing.Point(21, 34);
            this.cboxStatus.Name = "cboxStatus";
            this.cboxStatus.Size = new System.Drawing.Size(157, 29);
            this.cboxStatus.TabIndex = 25;
            this.cboxStatus.UseSelectable = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(120, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 28);
            this.label4.TabIndex = 23;
            this.label4.Text = "الحالة";
            // 
            // CBoxExamsFilter
            // 
            this.CBoxExamsFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBoxExamsFilter.BackColor = System.Drawing.Color.Transparent;
            this.CBoxExamsFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBoxExamsFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBoxExamsFilter.FocusedColor = System.Drawing.Color.Empty;
            this.CBoxExamsFilter.FocusedState.Parent = this.CBoxExamsFilter;
            this.CBoxExamsFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBoxExamsFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBoxExamsFilter.FormattingEnabled = true;
            this.CBoxExamsFilter.HoverState.Parent = this.CBoxExamsFilter;
            this.CBoxExamsFilter.ItemHeight = 30;
            this.CBoxExamsFilter.Items.AddRange(new object[] {
            "ID",
            "الملف",
            "نوع الامتحان",
            "الحالة"});
            this.CBoxExamsFilter.ItemsAppearance.Parent = this.CBoxExamsFilter;
            this.CBoxExamsFilter.Location = new System.Drawing.Point(836, 79);
            this.CBoxExamsFilter.Name = "CBoxExamsFilter";
            this.CBoxExamsFilter.ShadowDecoration.Parent = this.CBoxExamsFilter;
            this.CBoxExamsFilter.Size = new System.Drawing.Size(183, 36);
            this.CBoxExamsFilter.TabIndex = 35;
            // 
            // btnSearchLesson
            // 
            this.btnSearchLesson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchLesson.BorderRadius = 5;
            this.btnSearchLesson.CheckedState.Parent = this.btnSearchLesson;
            this.btnSearchLesson.CustomImages.Parent = this.btnSearchLesson;
            this.btnSearchLesson.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.btnSearchLesson.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSearchLesson.ForeColor = System.Drawing.Color.White;
            this.btnSearchLesson.HoverState.Parent = this.btnSearchLesson;
            this.btnSearchLesson.Location = new System.Drawing.Point(1025, 76);
            this.btnSearchLesson.Name = "btnSearchLesson";
            this.btnSearchLesson.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearchLesson.ShadowDecoration.Parent = this.btnSearchLesson;
            this.btnSearchLesson.Size = new System.Drawing.Size(89, 43);
            this.btnSearchLesson.TabIndex = 27;
            this.btnSearchLesson.Text = "بحث";
            this.btnSearchLesson.Click += new System.EventHandler(this.btnSearchLesson_Click);
            // 
            // DGVExams
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGVExams.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVExams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVExams.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVExams.BackgroundColor = System.Drawing.Color.White;
            this.DGVExams.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVExams.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVExams.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(186)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.NullValue = "\"\"";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(175)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVExams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVExams.ColumnHeadersHeight = 50;
            this.DGVExams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CondidateFile,
            this.CondidateName,
            this.Status,
            this.type,
            this.date,
            this.Operations});
            this.DGVExams.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVExams.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVExams.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGVExams.EnableHeadersVisualStyles = false;
            this.DGVExams.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVExams.Location = new System.Drawing.Point(6, 231);
            this.DGVExams.Name = "DGVExams";
            this.DGVExams.ReadOnly = true;
            this.DGVExams.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGVExams.RowHeadersVisible = false;
            this.DGVExams.RowHeadersWidth = 62;
            this.DGVExams.RowTemplate.Height = 40;
            this.DGVExams.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVExams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVExams.Size = new System.Drawing.Size(1171, 311);
            this.DGVExams.TabIndex = 25;
            this.DGVExams.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.DGVExams.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVExams.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVExams.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVExams.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVExams.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVExams.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVExams.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVExams.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(186)))), ((int)(((byte)(188)))));
            this.DGVExams.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVExams.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.DGVExams.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVExams.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVExams.ThemeStyle.HeaderStyle.Height = 50;
            this.DGVExams.ThemeStyle.ReadOnly = true;
            this.DGVExams.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVExams.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVExams.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.DGVExams.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGVExams.ThemeStyle.RowsStyle.Height = 40;
            this.DGVExams.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVExams.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // CondidateFile
            // 
            this.CondidateFile.HeaderText = "الملف";
            this.CondidateFile.MinimumWidth = 8;
            this.CondidateFile.Name = "CondidateFile";
            this.CondidateFile.ReadOnly = true;
            // 
            // CondidateName
            // 
            this.CondidateName.HeaderText = "المترشح";
            this.CondidateName.MinimumWidth = 8;
            this.CondidateName.Name = "CondidateName";
            this.CondidateName.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "الحالة";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // type
            // 
            this.type.HeaderText = "النوع";
            this.type.MinimumWidth = 8;
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "التاريخ";
            this.date.MinimumWidth = 8;
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // Operations
            // 
            this.Operations.HeaderText = "الإجراءات";
            this.Operations.Image = global::Driving_School_Management_System.Properties.Resources.dots_three_outline;
            this.Operations.MinimumWidth = 8;
            this.Operations.Name = "Operations";
            this.Operations.ReadOnly = true;
            this.Operations.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Operations.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.CBoxExamsFilter);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnSearchLesson);
            this.panel2.Controls.Add(this.guna2Button3);
            this.panel2.Controls.Add(this.DGVExams);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Controls.Add(this.guna2Separator1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1184, 575);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Driving_School_Management_System.Properties.Resources.funnel__1_;
            this.pictureBox1.Location = new System.Drawing.Point(788, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // guna2Button3
            // 
            this.guna2Button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button3.BorderRadius = 5;
            this.guna2Button3.CheckedState.Parent = this.guna2Button3;
            this.guna2Button3.CustomImages.Parent = this.guna2Button3;
            this.guna2Button3.FillColor = System.Drawing.Color.Black;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.HoverState.Parent = this.guna2Button3;
            this.guna2Button3.Image = global::Driving_School_Management_System.Properties.Resources.arrows_clockwise;
            this.guna2Button3.Location = new System.Drawing.Point(1122, 76);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(41, 43);
            this.guna2Button3.TabIndex = 26;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Image = global::Driving_School_Management_System.Properties.Resources.magnifying_glass__1_;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(950, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(234, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "    بحث متعدد المعايير";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 575);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.label1.Location = new System.Drawing.Point(987, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 20, 20, 0);
            this.label1.Size = new System.Drawing.Size(221, 51);
            this.label1.TabIndex = 8;
            this.label1.Text = "إدارة الامتحانات";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "الإجراءات";
            this.dataGridViewImageColumn1.Image = global::Driving_School_Management_System.Properties.Resources.dots_three_outline;
            this.dataGridViewImageColumn1.MinimumWidth = 8;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 162;
            // 
            // btnAddExam
            // 
            this.btnAddExam.BorderRadius = 10;
            this.btnAddExam.CheckedState.Parent = this.btnAddExam;
            this.btnAddExam.CustomImages.Parent = this.btnAddExam;
            this.btnAddExam.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(175)))), ((int)(((byte)(29)))));
            this.btnAddExam.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddExam.ForeColor = System.Drawing.Color.Black;
            this.btnAddExam.HoverState.Parent = this.btnAddExam;
            this.btnAddExam.Image = global::Driving_School_Management_System.Properties.Resources.plus_bold;
            this.btnAddExam.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnAddExam.Location = new System.Drawing.Point(12, 12);
            this.btnAddExam.Name = "btnAddExam";
            this.btnAddExam.ShadowDecoration.Parent = this.btnAddExam;
            this.btnAddExam.Size = new System.Drawing.Size(126, 44);
            this.btnAddExam.TabIndex = 9;
            this.btnAddExam.Text = "إضافة ";
            this.btnAddExam.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // ExamsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 677);
            this.Controls.Add(this.btnAddExam);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExamsWindow";
            this.Text = "ExamsWindow";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVExams)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnAddExam;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroComboBox CboxExamType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2ComboBox CBoxExamsFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnSearchLesson;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2DataGridView DGVExams;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CondidateFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn CondidateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewImageColumn Operations;
        private System.Windows.Forms.TextBox textbxCondidateFileID;
        private System.Windows.Forms.Panel panel6;
        private MetroFramework.Controls.MetroComboBox cboxStatus;
        private System.Windows.Forms.Label label4;
    }
}
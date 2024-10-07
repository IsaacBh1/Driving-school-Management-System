namespace Driving_School_Management_System.Forms
{
    partial class BoxWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutBox = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.CBoxExamsFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSearchLesson = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.DGVBoxes = new Guna.UI2.WinForms.Guna2DataGridView();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textbxCondidateFileID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CondidateFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CondidateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operations = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBoxes)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.label1.Location = new System.Drawing.Point(1088, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 20, 20, 0);
            this.label1.Size = new System.Drawing.Size(206, 51);
            this.label1.TabIndex = 6;
            this.label1.Text = "إدارة الصندوق";
            // 
            // flowLayoutBox
            // 
            this.flowLayoutBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutBox.Location = new System.Drawing.Point(12, 87);
            this.flowLayoutBox.Name = "flowLayoutBox";
            this.flowLayoutBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutBox.Size = new System.Drawing.Size(1270, 203);
            this.flowLayoutBox.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.guna2Button1);
            this.panel2.Controls.Add(this.CBoxExamsFilter);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.btnSearchLesson);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.DGVBoxes);
            this.panel2.Controls.Add(this.flowLayoutPanel2);
            this.panel2.Controls.Add(this.guna2Separator1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(22, 296);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1257, 473);
            this.panel2.TabIndex = 8;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(175)))), ((int)(((byte)(29)))));
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI Black", 10F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = global::Driving_School_Management_System.Properties.Resources.tray_arrow_down_fill;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button1.Location = new System.Drawing.Point(12, 7);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(178, 44);
            this.guna2Button1.TabIndex = 36;
            this.guna2Button1.Text = "غلق الصندوق";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
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
            this.CBoxExamsFilter.Location = new System.Drawing.Point(909, 79);
            this.CBoxExamsFilter.Name = "CBoxExamsFilter";
            this.CBoxExamsFilter.ShadowDecoration.Parent = this.CBoxExamsFilter;
            this.CBoxExamsFilter.Size = new System.Drawing.Size(183, 36);
            this.CBoxExamsFilter.TabIndex = 35;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Driving_School_Management_System.Properties.Resources.funnel__1_;
            this.pictureBox1.Location = new System.Drawing.Point(861, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
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
            this.btnSearchLesson.Location = new System.Drawing.Point(1098, 76);
            this.btnSearchLesson.Name = "btnSearchLesson";
            this.btnSearchLesson.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearchLesson.ShadowDecoration.Parent = this.btnSearchLesson;
            this.btnSearchLesson.Size = new System.Drawing.Size(89, 43);
            this.btnSearchLesson.TabIndex = 27;
            this.btnSearchLesson.Text = "بحث";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BorderRadius = 5;
            this.btnRefresh.CheckedState.Parent = this.btnRefresh;
            this.btnRefresh.CustomImages.Parent = this.btnRefresh;
            this.btnRefresh.FillColor = System.Drawing.Color.Black;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.HoverState.Parent = this.btnRefresh;
            this.btnRefresh.Image = global::Driving_School_Management_System.Properties.Resources.arrows_clockwise;
            this.btnRefresh.Location = new System.Drawing.Point(1195, 76);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnRefresh.ShadowDecoration.Parent = this.btnRefresh;
            this.btnRefresh.Size = new System.Drawing.Size(41, 43);
            this.btnRefresh.TabIndex = 26;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // DGVBoxes
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGVBoxes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVBoxes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVBoxes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVBoxes.BackgroundColor = System.Drawing.Color.White;
            this.DGVBoxes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVBoxes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVBoxes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(186)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.NullValue = "\"\"";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(175)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVBoxes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVBoxes.ColumnHeadersHeight = 50;
            this.DGVBoxes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CondidateFile,
            this.CondidateName,
            this.Status,
            this.type,
            this.Operations});
            this.DGVBoxes.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVBoxes.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVBoxes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGVBoxes.EnableHeadersVisualStyles = false;
            this.DGVBoxes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVBoxes.Location = new System.Drawing.Point(6, 231);
            this.DGVBoxes.Name = "DGVBoxes";
            this.DGVBoxes.ReadOnly = true;
            this.DGVBoxes.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGVBoxes.RowHeadersVisible = false;
            this.DGVBoxes.RowHeadersWidth = 62;
            this.DGVBoxes.RowTemplate.Height = 40;
            this.DGVBoxes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVBoxes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVBoxes.Size = new System.Drawing.Size(1244, 232);
            this.DGVBoxes.TabIndex = 25;
            this.DGVBoxes.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.DGVBoxes.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVBoxes.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVBoxes.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVBoxes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVBoxes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVBoxes.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVBoxes.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVBoxes.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(186)))), ((int)(((byte)(188)))));
            this.DGVBoxes.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVBoxes.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.DGVBoxes.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVBoxes.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVBoxes.ThemeStyle.HeaderStyle.Height = 50;
            this.DGVBoxes.ThemeStyle.ReadOnly = true;
            this.DGVBoxes.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVBoxes.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVBoxes.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.DGVBoxes.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGVBoxes.ThemeStyle.RowsStyle.Height = 40;
            this.DGVBoxes.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVBoxes.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.panel3);
            this.flowLayoutPanel2.Controls.Add(this.panel4);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(14, 125);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1236, 100);
            this.flowLayoutPanel2.TabIndex = 24;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtBoxID);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(1050, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 83);
            this.panel3.TabIndex = 23;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.textbxCondidateFileID);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Location = new System.Drawing.Point(861, 3);
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
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.Location = new System.Drawing.Point(-9, 52);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1269, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Image = global::Driving_School_Management_System.Properties.Resources.magnifying_glass__1_;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(1023, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(234, 37);
            this.label2.TabIndex = 0;
            this.label2.Text = "    بحث متعدد المعايير";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "الإجراءات";
            this.dataGridViewImageColumn1.Image = global::Driving_School_Management_System.Properties.Resources.dots_three_outline;
            this.dataGridViewImageColumn1.MinimumWidth = 8;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 178;
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
            this.CondidateFile.HeaderText = "المبلغ الأولي\n";
            this.CondidateFile.MinimumWidth = 8;
            this.CondidateFile.Name = "CondidateFile";
            this.CondidateFile.ReadOnly = true;
            // 
            // CondidateName
            // 
            this.CondidateName.HeaderText = "إجمالي المبلغ\n";
            this.CondidateName.MinimumWidth = 8;
            this.CondidateName.Name = "CondidateName";
            this.CondidateName.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "المبلغ الداخلي\n";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // type
            // 
            this.type.HeaderText = "الربح الصافي\n\n\n\n\n\n";
            this.type.MinimumWidth = 8;
            this.type.Name = "type";
            this.type.ReadOnly = true;
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
            // BoxWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 781);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.flowLayoutBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BoxWindow";
            this.Text = "BoxWindow";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBoxes)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutBox;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2ComboBox CBoxExamsFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnSearchLesson;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2DataGridView DGVBoxes;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textbxCondidateFileID;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CondidateFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn CondidateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewImageColumn Operations;
    }
}
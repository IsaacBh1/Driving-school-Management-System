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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CBoxStudentInfoFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSearchStudentinfo = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.DGVStudents = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName_Arabic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName_Arabic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdentityCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operations = new System.Windows.Forms.DataGridViewImageColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtBoxFirstName_Arabic = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtBoxLastName_Arabic = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtBoxIdentityNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2Separator1 = new Guna.UI2.WinForms.Guna2Separator();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudents)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridViewImageColumn1.Width = 112;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.CBoxStudentInfoFilter);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnSearchStudentinfo);
            this.panel1.Controls.Add(this.guna2Button3);
            this.panel1.Controls.Add(this.DGVStudents);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.guna2Separator1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(10, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1167, 724);
            this.panel1.TabIndex = 7;
            // 
            // CBoxStudentInfoFilter
            // 
            this.CBoxStudentInfoFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CBoxStudentInfoFilter.BackColor = System.Drawing.Color.Transparent;
            this.CBoxStudentInfoFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.CBoxStudentInfoFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBoxStudentInfoFilter.FocusedColor = System.Drawing.Color.Empty;
            this.CBoxStudentInfoFilter.FocusedState.Parent = this.CBoxStudentInfoFilter;
            this.CBoxStudentInfoFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.CBoxStudentInfoFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.CBoxStudentInfoFilter.FormattingEnabled = true;
            this.CBoxStudentInfoFilter.HoverState.Parent = this.CBoxStudentInfoFilter;
            this.CBoxStudentInfoFilter.ItemHeight = 30;
            this.CBoxStudentInfoFilter.Items.AddRange(new object[] {
            "ID",
            "الاسم",
            "النسب",
            "الكل"});
            this.CBoxStudentInfoFilter.ItemsAppearance.Parent = this.CBoxStudentInfoFilter;
            this.CBoxStudentInfoFilter.Location = new System.Drawing.Point(819, 79);
            this.CBoxStudentInfoFilter.Name = "CBoxStudentInfoFilter";
            this.CBoxStudentInfoFilter.ShadowDecoration.Parent = this.CBoxStudentInfoFilter;
            this.CBoxStudentInfoFilter.Size = new System.Drawing.Size(183, 36);
            this.CBoxStudentInfoFilter.TabIndex = 35;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::Driving_School_Management_System.Properties.Resources.funnel__1_;
            this.pictureBox1.Location = new System.Drawing.Point(771, 79);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(42, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // btnSearchStudentinfo
            // 
            this.btnSearchStudentinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchStudentinfo.BorderRadius = 5;
            this.btnSearchStudentinfo.CheckedState.Parent = this.btnSearchStudentinfo;
            this.btnSearchStudentinfo.CustomImages.Parent = this.btnSearchStudentinfo;
            this.btnSearchStudentinfo.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.btnSearchStudentinfo.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSearchStudentinfo.ForeColor = System.Drawing.Color.White;
            this.btnSearchStudentinfo.HoverState.Parent = this.btnSearchStudentinfo;
            this.btnSearchStudentinfo.Location = new System.Drawing.Point(1008, 76);
            this.btnSearchStudentinfo.Name = "btnSearchStudentinfo";
            this.btnSearchStudentinfo.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearchStudentinfo.ShadowDecoration.Parent = this.btnSearchStudentinfo;
            this.btnSearchStudentinfo.Size = new System.Drawing.Size(89, 43);
            this.btnSearchStudentinfo.TabIndex = 27;
            this.btnSearchStudentinfo.Text = "بحث";
            this.btnSearchStudentinfo.Click += new System.EventHandler(this.btnSearchStudentinfo_Click);
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
            this.guna2Button3.Location = new System.Drawing.Point(1105, 76);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2Button3.ShadowDecoration.Parent = this.guna2Button3;
            this.guna2Button3.Size = new System.Drawing.Size(41, 43);
            this.guna2Button3.TabIndex = 26;
            this.guna2Button3.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // DGVStudents
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGVStudents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVStudents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVStudents.BackgroundColor = System.Drawing.Color.White;
            this.DGVStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVStudents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(186)))), ((int)(((byte)(188)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.NullValue = "\"\"";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(175)))), ((int)(((byte)(29)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVStudents.ColumnHeadersHeight = 50;
            this.DGVStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.FirstName_Arabic,
            this.LastName_Arabic,
            this.IdentityCardNumber,
            this.Phone,
            this.Email,
            this.Operations});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVStudents.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGVStudents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.DGVStudents.EnableHeadersVisualStyles = false;
            this.DGVStudents.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVStudents.Location = new System.Drawing.Point(6, 231);
            this.DGVStudents.Name = "DGVStudents";
            this.DGVStudents.ReadOnly = true;
            this.DGVStudents.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.DGVStudents.RowHeadersVisible = false;
            this.DGVStudents.RowHeadersWidth = 62;
            this.DGVStudents.RowTemplate.Height = 40;
            this.DGVStudents.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVStudents.Size = new System.Drawing.Size(1154, 460);
            this.DGVStudents.TabIndex = 25;
            this.DGVStudents.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.DGVStudents.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVStudents.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGVStudents.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGVStudents.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGVStudents.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGVStudents.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGVStudents.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVStudents.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(186)))), ((int)(((byte)(188)))));
            this.DGVStudents.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGVStudents.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.DGVStudents.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGVStudents.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGVStudents.ThemeStyle.HeaderStyle.Height = 50;
            this.DGVStudents.ThemeStyle.ReadOnly = true;
            this.DGVStudents.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGVStudents.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGVStudents.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.DGVStudents.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGVStudents.ThemeStyle.RowsStyle.Height = 40;
            this.DGVStudents.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGVStudents.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // FirstName_Arabic
            // 
            this.FirstName_Arabic.HeaderText = "الاسم";
            this.FirstName_Arabic.MinimumWidth = 8;
            this.FirstName_Arabic.Name = "FirstName_Arabic";
            this.FirstName_Arabic.ReadOnly = true;
            // 
            // LastName_Arabic
            // 
            this.LastName_Arabic.HeaderText = "النسب";
            this.LastName_Arabic.MinimumWidth = 8;
            this.LastName_Arabic.Name = "LastName_Arabic";
            this.LastName_Arabic.ReadOnly = true;
            // 
            // IdentityCardNumber
            // 
            this.IdentityCardNumber.HeaderText = "رقم ب.ت.و";
            this.IdentityCardNumber.MinimumWidth = 8;
            this.IdentityCardNumber.Name = "IdentityCardNumber";
            this.IdentityCardNumber.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.HeaderText = "رقم الهاتف";
            this.Phone.MinimumWidth = 8;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "البريد الإلكتروني";
            this.Email.MinimumWidth = 8;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(14, 125);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1146, 100);
            this.flowLayoutPanel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtBoxID);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(960, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 83);
            this.panel2.TabIndex = 23;
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
            this.panel4.Controls.Add(this.txtBoxFirstName_Arabic);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(771, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(183, 83);
            this.panel4.TabIndex = 25;
            // 
            // txtBoxFirstName_Arabic
            // 
            this.txtBoxFirstName_Arabic.Location = new System.Drawing.Point(14, 35);
            this.txtBoxFirstName_Arabic.Name = "txtBoxFirstName_Arabic";
            this.txtBoxFirstName_Arabic.Size = new System.Drawing.Size(157, 27);
            this.txtBoxFirstName_Arabic.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(118, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 28);
            this.label7.TabIndex = 23;
            this.label7.Text = "الاسم";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtBoxLastName_Arabic);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Location = new System.Drawing.Point(582, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(183, 83);
            this.panel5.TabIndex = 26;
            // 
            // txtBoxLastName_Arabic
            // 
            this.txtBoxLastName_Arabic.Location = new System.Drawing.Point(14, 35);
            this.txtBoxLastName_Arabic.Name = "txtBoxLastName_Arabic";
            this.txtBoxLastName_Arabic.Size = new System.Drawing.Size(157, 27);
            this.txtBoxLastName_Arabic.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(110, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 28);
            this.label8.TabIndex = 23;
            this.label8.Text = "النسب";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtBoxIdentityNumber);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(393, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 83);
            this.panel3.TabIndex = 28;
            // 
            // txtBoxIdentityNumber
            // 
            this.txtBoxIdentityNumber.Location = new System.Drawing.Point(14, 35);
            this.txtBoxIdentityNumber.Name = "txtBoxIdentityNumber";
            this.txtBoxIdentityNumber.Size = new System.Drawing.Size(157, 27);
            this.txtBoxIdentityNumber.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(80, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 28);
            this.label6.TabIndex = 23;
            this.label6.Text = "رقم الهوية";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(26, 34);
            this.label4.TabIndex = 4;
            this.label4.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(135)))), ((int)(((byte)(255)))));
            this.label3.Image = global::Driving_School_Management_System.Properties.Resources.warning__1_;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(21, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(261, 34);
            this.label3.TabIndex = 3;
            this.label3.Text = "المرشحين بدون ملف     ";
            // 
            // guna2Separator1
            // 
            this.guna2Separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Separator1.Location = new System.Drawing.Point(-9, 52);
            this.guna2Separator1.Name = "guna2Separator1";
            this.guna2Separator1.Size = new System.Drawing.Size(1179, 10);
            this.guna2Separator1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Image = global::Driving_School_Management_System.Properties.Resources.magnifying_glass__1_;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(933, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(234, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "    بحث متعدد المعايير";
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
            this.guna2Button1.Image = global::Driving_School_Management_System.Properties.Resources.plus_bold;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button1.Location = new System.Drawing.Point(12, 12);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(126, 44);
            this.guna2Button1.TabIndex = 6;
            this.guna2Button1.Text = "إضافة ";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.label1.Location = new System.Drawing.Point(945, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 20, 20, 0);
            this.label1.Size = new System.Drawing.Size(244, 51);
            this.label1.TabIndex = 5;
            this.label1.Text = "إدارة المترشحين ";
            // 
            // CondidatesWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1189, 822);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CondidatesWindow";
            this.RightToLeftLayout = true;
            this.Text = "CondidatesWindow";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVStudents)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2ComboBox CBoxStudentInfoFilter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnSearchStudentinfo;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2DataGridView DGVStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName_Arabic;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName_Arabic;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdentityCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewImageColumn Operations;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtBoxFirstName_Arabic;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtBoxLastName_Arabic;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBoxIdentityNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label label1;
    }
}
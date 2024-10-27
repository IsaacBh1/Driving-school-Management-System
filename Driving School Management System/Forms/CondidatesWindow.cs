using Driving_school_BusinessLayer;
using Driving_School_Management_System.ShowInformationsForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class CondidatesWindow : Form
    {
        
        
        private ContextMenuStrip contextMenuStudent;
        private ContextMenuStrip contextMenuFile;
        private int selectedId = -1;
        private StatusMessageForm statusMessageForm; 
        public CondidatesWindow()
        {
            InitializeComponent();
            _initializeDrivingLicenseTypeCbox();
            DispalyStudentsInformations(clsStudent.GetAllStudentsInfo());
            DisplayCondidteFilesInformations(clsCondidateFile.GetAllCondidateFileInformations());
            InitializeContextMenuStudent(); // Initialize the context menu
            InitializeContextMenuFile(); 
            DGVStudents.CellMouseClick += DGVStudents_CellMouseClick; // Handle cell clicks
            DGVFiles.CellMouseClick += DGVFiles_CellMouseClick;
        }
        // this is for students 
        private void InitializeContextMenuStudent()
        {
            contextMenuStudent = new ContextMenuStrip();

            // Add menu items dynamically
            var ViewStudentInformationsItem = new ToolStripMenuItem("عرض معلومات الطالب" , Properties.Resources.eye);
            ViewStudentInformationsItem.Click += ViewStudentInformations_Click; // Define what happens when "Edit" is clicked

            var EditStudentInformationsItem = new ToolStripMenuItem("تعديل معلومات الطالب" , Properties.Resources.gear);
            EditStudentInformationsItem.Click += EditStudentInformations_Click;

            var DeleteStudentItem = new ToolStripMenuItem("حذف الطالب", Properties.Resources.trash__1_);
            DeleteStudentItem.Click += DeleteStudent_Click; 

            var AddStudentFileItem = new ToolStripMenuItem("إضافة ملف إلى الطالب", Properties.Resources.file_bold);
            AddStudentFileItem.Click += AddStudentFile_Click;

            var DownloadStudentInformationsItem = new ToolStripMenuItem("تنزيل معلومات الطالب" , Properties.Resources.download_simple);
            DownloadStudentInformationsItem.Click += DownloadStudentInformations_Click;


            contextMenuStudent.Items.Add(ViewStudentInformationsItem);
            contextMenuStudent.Items.Add(EditStudentInformationsItem);
            contextMenuStudent.Items.Add(DeleteStudentItem);
            contextMenuStudent.Items.Add(AddStudentFileItem);
            contextMenuStudent.Items.Add(DownloadStudentInformationsItem);
        }

        // this is for condidate files 

        private void InitializeContextMenuFile()
        {
            contextMenuFile = new ContextMenuStrip();
            // Add menu items dynamically
            var ViewStudentInformationsItem = new ToolStripMenuItem("إظهار معلومات الملف", Properties.Resources.eye);
            ViewStudentInformationsItem.Click += ViewFileInformations_Click; // Define what happens when "Edit" is clicked

            var EditStudentInformationsItem = new ToolStripMenuItem("تعديل معلومات الملف", Properties.Resources.gear);
            EditStudentInformationsItem.Click += EditFileInformations_Click;

            var DeleteStudentItem = new ToolStripMenuItem("حذف الملف", Properties.Resources.trash__1_);
            DeleteStudentItem.Click += DeleteStudent_Click;

            var AddStudentFileItem = new ToolStripMenuItem("إضافة دفعة", Properties.Resources.file_bold);
            AddStudentFileItem.Click += AddStudentFile_Click;

            var DownloadStudentInformationsItem = new ToolStripMenuItem("تنزيل معلومات الملف", Properties.Resources.download_simple);
            DownloadStudentInformationsItem.Click += DownloadStudentInformations_Click;


            contextMenuFile.Items.Add(ViewStudentInformationsItem);
            contextMenuFile.Items.Add(EditStudentInformationsItem);
            contextMenuFile.Items.Add(DeleteStudentItem);
            contextMenuFile.Items.Add(AddStudentFileItem);
            contextMenuFile.Items.Add(DownloadStudentInformationsItem);
        }

        private void EditFileInformations_Click(object sender, EventArgs e)
        {
            AddCondidateFileForm condidateFileForm = new AddCondidateFileForm(selectedId, false);
            condidateFileForm.ShowDialog();
        }

        private void ViewFileInformations_Click(object sender, EventArgs e)
        {
            ShowFileInformations fileinfoForm = new ShowFileInformations(selectedId);
            fileinfoForm.ShowDialog(); 
        }

        private void DownloadStudentInformations_Click(object sender, EventArgs e)
        {
            // this is for update the student informations
        }

        private void AddStudentFile_Click(object sender, EventArgs e)
        {
            AddCondidateFileForm AddFileForm = new AddCondidateFileForm(selectedId);
            AddFileForm.ShowDialog();
        }

        private void DeleteStudent_Click(object sender, EventArgs e)
        {
            // this is for delete student
            YesNoDesisionForm yesNoForm = new YesNoDesisionForm("هل تريد حذف الطالب ؟");
            yesNoForm.DoOperationEventHundler += DeleteStudent;
            yesNoForm.ShowDialog(); 
        }

        private void DeleteStudent()
        {
            clsStudent StudentToDelete = clsStudent.Find(selectedId);
            
            if (!(StudentToDelete is null) && clsExam.DeleteAllFileExams(selectedId) && (clsCondidateFile.DeleteCondidateFilesByStudentID(selectedId)) && (clsStudent.DeleteStudent(StudentToDelete.StudentID)))
            {
                statusMessageForm = new StatusMessageForm("Operation done Successfully");
                statusMessageForm.ShowSuccess();
                DispalyStudentsInformations(clsStudent.GetAllStudentsInfo());
                DisplayCondidteFilesInformations(clsCondidateFile.GetAllCondidateFileInformations());
            }
            else
            {
                statusMessageForm = new StatusMessageForm("Operation Failed");
                statusMessageForm.ShowFailed();
            }
        }
        // Event handler for cell clicks
        private void DGVStudents_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGVStudents.Rows[e.RowIndex].Cells[0].Value is null) return; 

            if (e.RowIndex >= 0 &&( e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) && e.ColumnIndex == 6) // Check for right-click
            {
                var cellRect = DGVStudents.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                selectedId = Convert.ToInt32(DGVStudents.Rows[e.RowIndex].Cells[0].Value); 
                Point menuLocation = DGVStudents.PointToScreen(new Point(cellRect.X, cellRect.Y + cellRect.Height));
                // Show the context menu at the calculated location
                contextMenuStudent.Show(menuLocation);
            }
        }


        private void DGVFiles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGVFiles.Rows[e.RowIndex].Cells[0].Value is null) return;

            if (e.RowIndex >= 0 && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) && e.ColumnIndex == 8) // Check for right-click
            {
                var cellRect = DGVFiles.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                selectedId = Convert.ToInt32(DGVFiles.Rows[e.RowIndex].Cells[0].Value);
                Point menuLocation = DGVFiles.PointToScreen(new Point(cellRect.X, cellRect.Y + cellRect.Height));
                // Show the context menu at the calculated location
                contextMenuFile.Show(menuLocation);
            }
        }





        // Edit item click handler
        private void ViewStudentInformations_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Edit option selected", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Add your logic to edit the selected student entry
            ShowStudentInformationsForm studentinfos = new ShowStudentInformationsForm(selectedId);
            studentinfos.ShowDialog(); 
        }

        // Delete item click handler
        private void EditStudentInformations_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Update option selected", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // Add your logic to delete the selected student entry
            AddStudentForm studentForm = new AddStudentForm(selectedId);
            studentForm.ShowDialog();
        }



        private string _getFileStatus(string s) => s == "False" ? "نشط" : "مؤرشف";
        private string _getStudentStatus(string s) => s == "True" ? "نشط" : "منقطع"; 
        private bool _getIsActive(string s)=> s == "نشط" ? true : false;
        private bool _getIsArchived(string s) => s == "مؤرشف" ? true : false; 

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.OnStudentAddedEventHundler += RefreshStudents; 
            addStudentForm.ShowDialog();
            //LoadAllStudentInfoToDataGrid(); 
        }

        private void RefreshStudents()
        {
            DispalyStudentsInformations(clsStudent.GetAllStudentsInfo());
        }

        private void btnCondidtes_Click(object sender, EventArgs e)
        {
            btnCondidtesFiles.BackColor = Color.FromArgb(166, 186, 188);
            btnManageStudents.BackColor = Color.Transparent;
            CondidatesWindowTab.SelectedIndex = 1; 
        }

        private void btnManageStudents_Click(object sender, EventArgs e)
        {
            btnCondidtesFiles.BackColor = Color.Transparent;
            btnManageStudents.BackColor =  Color.FromArgb(166, 186, 188);
            CondidatesWindowTab.SelectedIndex = 0;

        }
        public void DispalyStudentsInformations(DataTable AllStudents)
        {
            DGVStudents.Rows.Clear(); 
            //DataTable AllStudents = clsStudent.GetAllStudentsInfo();
            foreach (DataRow row in AllStudents.Rows)
            {
                // Loop through each column in the current row
                DGVStudents.Rows.Add(row[0] , row[1] , row[2] , row[3] , row[4] , row[5] );
            }

        }

        public void DisplayCondidteFilesInformations(DataTable AllFiles)
        {
            DGVFiles.Rows.Clear();
            foreach (DataRow row in AllFiles.Rows)
            {
                DGVFiles.Rows.Add(row[0], row[1], row[2], row[3], _getFileStatus(row[4].ToString()), _getStudentStatus(row[5].ToString()), row[6], row[7]); 
            }
        }
        //GetAllCondidateFileInformations() ; 
        private DataTable QueryByID(int Id)
        {
            return clsStudent.SearchStudentInfoByID(Id); 
        }

        private DataTable QueryByFirstName_Arabic(string FirstName)
        {
            return clsStudent.SearchStudentInfoByFirstName_Arabic(FirstName);        
        }


        private DataTable QueryByLast_Arabic(string LastName)
        {
            return clsStudent.SearchStudentInfoLastName_Arabic(LastName);

        }

        public DataTable QueryByIdentityNumber(string Number)
        {
            return clsStudent.SearchStudentInfoByIdentityNumber(Number); 
        }


        public DataTable QueryByAll(int id , string FirstName , string LastName , string IdentityNumber)
        {
            return clsStudent.SearchByAll(id , FirstName , LastName , IdentityNumber); 
        }


        private void SearchFiltersEmpty()
        {
            txtBoxID.Text = string.Empty;
            txtBoxFirstName_Arabic.Text = string.Empty;
            txtBoxLastName_Arabic.Text = string.Empty;
        }


        private void _initializeDrivingLicenseTypeCbox()
        {
            CboxDrivingLisence.DataSource = clsDrivingLicenseType.GetAllNames().DefaultView;
            CboxDrivingLisence.DisplayMember = "Name";
        }



        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SearchFiltersEmpty(); 
            DispalyStudentsInformations(clsStudent.GetAllStudentsInfo()); 
        }


        private void SearchFieldStudent()
        {
            try {
                switch (CBoxStudentInfoFilter.Text.ToString()){
                    case "رقم الهوية":
                        DispalyStudentsInformations(QueryByIdentityNumber(txtBoxIdentityNumber.Text));

                        break;
                    case "الاسم":
                        DispalyStudentsInformations(QueryByFirstName_Arabic(txtBoxFirstName_Arabic.Text));
                        break;

                    case "النسب":
                        DispalyStudentsInformations(QueryByLast_Arabic(txtBoxLastName_Arabic.Text));
                        break;
                    case "ID":
                        if (int.TryParse(txtBoxID.Text.ToString(), out int ID))
                            DispalyStudentsInformations(QueryByID(ID));
                        break;
                    case "الكل":
                        if (int.TryParse(txtBoxID.Text.ToString(), out int id))
                            DispalyStudentsInformations(QueryByAll(id, txtBoxFirstName_Arabic.Text, txtBoxLastName_Arabic.Text, txtBoxIdentityNumber.Text));
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void SearchFieldCondidteFile()
        {
            try
            {

                switch (CboxFilterCondidtateFile.Text.ToString())
                {
              
                    case "الاسم":
                        DisplayCondidteFilesInformations(clsCondidateFile.SearchCondidatesFileInfoFirstName_Arabic(textBoxFName_Arabic.Text)); 
                        break;
                    case "النسب":
                        DisplayCondidteFilesInformations(clsCondidateFile.SearchCondidatesFileInfoLastName_Arabic(textBoxLName_Arabic.Text)); 
                        break;
                    case "ID":
                        if (int.TryParse(textBoxID.Text.ToString(), out int ID))
                            DisplayCondidteFilesInformations(clsCondidateFile.SearchCondidateFileInfoByID(ID.ToString()));
                            break;
                    case "الكل":
                        if (int.TryParse(textBoxID.Text.ToString(), out int Id))
                            DisplayCondidteFilesInformations(clsCondidateFile.SearchByAll(Id, textBoxFName_Arabic.Text, textBoxLName_Arabic.Text, CboxDrivingLisence.Text, _getIsArchived(CboxFileStatus.Text), _getIsActive(CboxStudentStatus.Text))); 
                            break;
                    case "الرخصة":
                        DisplayCondidteFilesInformations(clsCondidateFile.SearchCondidtesFilesByDrivingLisence(CboxDrivingLisence.Text)); 
                        break;
                    case "حالة الملف":
                        DisplayCondidteFilesInformations(clsCondidateFile.SearchArchivedStudentsFiles(_getIsArchived(CboxFileStatus.Text))); 
                        break;
                    case "وضع المرشح":
                        DisplayCondidteFilesInformations(clsCondidateFile.SearchActiveStudentsFiles(_getIsActive(CboxStudentStatus.Text)));
                        break; 
                 }

            }catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btnSearchStudentinfo_Click(object sender, EventArgs e)
        {
            SearchFieldStudent(); 
        }

        private void btnAddCondidtefile_Click(object sender, EventArgs e)
        {
            AddCondidateFileForm CondidateFileForm = new AddCondidateFileForm();
            CondidateFileForm.OnCondidateFileAddedEventHundler += OnCondidateFileAdded; 
            CondidateFileForm.ShowDialog();
        }

        private void OnCondidateFileAdded()
        {
            DisplayCondidteFilesInformations(clsCondidateFile.GetAllCondidateFileInformations());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DisplayCondidteFilesInformations(clsCondidateFile.GetAllCondidateFileInformations());
        }

        private void btnSSearchCondidteFIle_Click(object sender, EventArgs e)
        {
            SearchFieldCondidteFile(); 
        }
    }
}

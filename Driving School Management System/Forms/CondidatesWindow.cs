using Driving_school_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class CondidatesWindow : Form
    {
        public CondidatesWindow()
        {
            InitializeComponent();
            _initializeDrivingLicenseTypeCbox(); 
            DispalyStudentsInformations(clsStudent.GetAllStudentsInfo());
            DisplayCondidteFilesInformations(clsCondidateFile.GetAllCondidateFileInformations());
        }
        private string _getFileStatus(string s) => s == "False" ? "نشط" : "مؤرشف";
        private string _getStudentStatus(string s) => s == "True" ? "نشط" : "منقطع"; 
        private bool _getIsActive(string s)=> s == "نشط" ? true : false;
        private bool _getIsArchived(string s) => s == "مؤرشف" ? true : false; 

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm(); 
            addStudentForm.ShowDialog();
            //LoadAllStudentInfoToDataGrid(); 
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


        //GetAllCondidateFileInformations()


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
            txtBoxIdentityNumber.Text = string.Empty;
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
                            //textBoxID
                            break;
                    case "الكل":
                        // it will be implemented later on 
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
            AddCondidateFileForm frm = new AddCondidateFileForm();
            frm.ShowDialog();
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

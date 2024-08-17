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
            DispalyStudentsInformations(clsStudent.GetAllStudentsInfo());

        }

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



        
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SearchFiltersEmpty(); 
            DispalyStudentsInformations(clsStudent.GetAllStudentsInfo()); 
        }


        private void SearchField()
        {
           switch (CBoxStudentInfoFilter.Text.ToString())
            {
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
                      if (int.TryParse(txtBoxID.Text.ToString(), out int ID)); 
                           DispalyStudentsInformations(QueryByID(ID));
                    break;
                case "الكل":
                    if (int.TryParse(txtBoxID.Text.ToString(), out int id)) ;
                        DispalyStudentsInformations(QueryByAll(id, txtBoxFirstName_Arabic.Text, txtBoxLastName_Arabic.Text, txtBoxIdentityNumber.Text)); 
                    break; 

            }


        }

        /*ID
        رقم الهوية
        الاسم
        النسب
        الكل*/



        private void btnSearchStudentinfo_Click(object sender, EventArgs e)
        {
            SearchField(); 
        }
    }
}

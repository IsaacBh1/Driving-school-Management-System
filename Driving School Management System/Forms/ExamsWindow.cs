using Driving_school_BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class ExamsWindow : Form
    {
        public ExamsWindow()
        {
            InitializeComponent();
            DisplayExamsInformations(clsExam.GetAllExamInformations()); 
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddExamForm examForm = new AddExamForm();
            examForm.OnExamAddedEventHundler += RefreshExams;
            examForm.ShowDialog();
        }

        private void RefreshExams()
        {
            DisplayExamsInformations(clsExam.GetAllExamInformations());
        }

        private string GetExamType(int typeid)
        {
            return typeid == 1 ? "نظري" : "تطبيقي"; 
        }

        private int GetExamType(string typeName)
        {
            return typeName == "نظري" ? 1 : 2;

        }


        private void DisplayExamsInformations(DataTable AllExams)
        {
            DGVExams.Rows.Clear();
            foreach (DataRow row in AllExams.Rows)
            {

                DGVExams.Rows.Add(row[0] ,row[1] ,row[2] ,row[3], GetExamType((int)row[4]),row[5]); 
                    
            }

        }

        private void MakeFieldsEmpty()
        {
            txtBoxID.Text = string.Empty;
            textbxCondidateFileID.Text = string.Empty ; 
        }

        private void DisplayExamsInformationsByField()
        {
            switch (CBoxExamsFilter.Text)
            {
                case "ID":
                    if (int.TryParse(txtBoxID.Text, out int ID))
                        DisplayExamsInformations(clsExam.GetExamByID(ID)); 
                    break;
                case "الملف":
                    if (int.TryParse(textbxCondidateFileID.Text, out int CondidateFileID))
                        DisplayExamsInformations(clsExam.GetExamsByCondidateFile(CondidateFileID)); 
                    break;
                case "نوع الامتحان":
                    DisplayExamsInformations(clsExam.GetExamsByExamType(GetExamType(CboxExamType.Text))); 
                    break;
                case "الحالة":
                    DisplayExamsInformations(clsExam.GetExamsByStatus(cboxStatus.Text)); 
                    break; 
            }
        }



        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DisplayExamsInformations(clsExam.GetAllExamInformations());
        }

        private void btnSearchLesson_Click(object sender, EventArgs e)
        {
            DisplayExamsInformationsByField(); 
            MakeFieldsEmpty(); 
        }
    }
}

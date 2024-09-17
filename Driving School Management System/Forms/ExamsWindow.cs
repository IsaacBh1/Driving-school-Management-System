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
            examForm.ShowDialog();
        }


        private string GetExamType(int typeid)
        {
            return typeid == 1 ? "نظري" : "تطبيقي"; 
        }


        public void DisplayExamsInformations(DataTable AllExams)
        {
            DGVExams.Rows.Clear();
            foreach (DataRow row in AllExams.Rows)
            {

                DGVExams.Rows.Add(row[0] ,row[1] ,row[2] ,row[3], GetExamType((int)row[4]),row[5]); 
            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            DisplayExamsInformations(clsExam.GetAllExamInformations());
        }

      
    }
}

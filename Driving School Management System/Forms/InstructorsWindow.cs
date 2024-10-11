using Driving_school_BusinessLayer;
using Driving_School_Management_System.UserControls;
using System;
using System.Data;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class InstructorsWindow : Form
    {


        public void LoadInstructorsToUI()
        {
            flowLayoutPanelInstructors.Controls.Clear(); 
            DataTable Instructors = clsInstructor.GatAllInsructors(); 
            foreach(DataRow row in Instructors.Rows)
                flowLayoutPanelInstructors.Controls.Add(new Instructor((int)row["InstructorID"], row["UserName"].ToString()));
        }


        public InstructorsWindow()
        {
            InitializeComponent();
            LoadInstructorsToUI(); 
        }

        private void btnAddInsructor_Click(object sender, EventArgs e)
        {
            AddInstructorForm InstructorForm = new AddInstructorForm();
            InstructorForm.OnInstructorAddedEventHundler += RefreshInstructor; 
            InstructorForm.ShowDialog();
        }

        private void RefreshInstructor()
        {
            LoadInstructorsToUI(); 
        }

        private void guna2Button3_Click(object sender, System.EventArgs e)
        {
            flowLayoutPanelInstructors.Controls.Clear();
            LoadInstructorsToUI();
    
        }

    }
}

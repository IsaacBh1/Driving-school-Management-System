using Driving_school_BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class ExpencesWindow : Form
    {

      ExpencesForm expencesForm = null; 


        public ExpencesWindow()
        {
            InitializeComponent();
            DisplayExpenceInformations(clsExpense.GetAllExpences());
        }

        
        private void DisplayExpenceInformations(DataTable ExpencesInformations)
        {
            DGVExpences.Rows.Clear();
            foreach (DataRow row in ExpencesInformations.Rows)
            {
                DGVExpences.Rows.Add(row[0] , clsExpense.GetFuelTypeNameByID(Convert.ToInt32(row[1])), row[2].ToString(), row[4].ToString());    
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            expencesForm = new ExpencesForm();
            expencesForm.ExpenceAddedEventHundler += RefreshExpence; 
            expencesForm.ShowDialog();
        }

        private void RefreshExpence()
        {
            DisplayExpenceInformations(clsExpense.GetAllExpences());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayExpenceInformations(clsExpense.GetAllExpences());

        }
    }
}

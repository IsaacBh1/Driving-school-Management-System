using System;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using Driving_school_BusinessLayer;

namespace Driving_School_Management_System.Forms
{
    public partial class Settings : Form
    {
        private bool expencesTypesToggle = true; // true if open
        public Settings()
        {
            InitializeComponent();
            ToggleExpencesTypesPanel();
            LoadExpencecsToDGVExpenceTypes(clsExpense.GetAllExpencesTypes()); 
        }


        private void ToggleExpencesTypesPanel()
        {
            if (expencesTypesToggle)// opened => close
            {
                pnlExpencesTypes.Height = 96;
                expencesTypes.Image = Properties.Resources.caret_circle_down;
                lblopen_close.Text = "اضغط للفتح";

            }
            else //close => open 
            {
                pnlExpencesTypes.Height = 444;
                expencesTypes.Image = Properties.Resources.caret_circle_up;
                lblopen_close.Text = "اضغط للإغلاق"; 

            }

            expencesTypesToggle = !expencesTypesToggle;
        }

        private void LoadExpencecsToDGVExpenceTypes(DataTable ExpenceTypes)
        {
            DGVExpenceTypes.Rows.Clear(); 
            foreach (DataRow item in ExpenceTypes.Rows)
                DGVExpenceTypes.Rows.Add(item[0], item[1], item[2]); 
            
        }


        private void expencesTypes_Click(object sender, EventArgs e)
        {
            ToggleExpencesTypesPanel(); 
        }

        private void btnAddNewExpenceType_Click(object sender, EventArgs e)
        {
            AddExpenceTypeForm expenceTypeForm = new AddExpenceTypeForm();
            expenceTypeForm.OnAddingExpenceType += RefreshExpenceTypes;
            expenceTypeForm.ShowDialog(); 
        }

        private void RefreshExpenceTypes()
        {
            LoadExpencecsToDGVExpenceTypes(clsExpense.GetAllExpencesTypes());

        }
    }
}

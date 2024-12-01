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
        private bool DrivingLicenseTypesToggle = true; // true if open
        private ContextMenuStrip contextMenuExpenceType;
        private ContextMenuStrip contextDrivingLisenceType;
        StatusMessageForm statusMessageForm; 
        private int selectedId; 
        public Settings()
        {
            InitializeComponent();
            ToggleExpencesTypesPanel();
            ToggleDrivingLicense();
            LoadExpencesToDGVExpenceTypes(clsExpense.GetAllExpencesTypes());
            LoadDrivingLicenseToDGVDrivingLicenseTypes(clsDrivingLicenseType.GetAll()); 
            InitializeContextMenuExpenceType();
            InitializeContextDrivingLicenseType(); 
            DGVExpenceTypes.CellMouseClick += DGVExpenceTypes_MouseClick;
            DGVDrivingLicenseTypes.CellMouseClick += DGVDrivingLicenseTypes_MouseClick; 
        }


        // this is for mouse click 
        private void DGVDrivingLicenseTypes_MouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > 0 && DGVDrivingLicenseTypes.Rows[e.RowIndex].Cells[0].Value is null) return;
            if (e.RowIndex >= 0 && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) && e.ColumnIndex == 8)
            {
                var cellRect = DGVDrivingLicenseTypes.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                selectedId = Convert.ToInt32(DGVDrivingLicenseTypes.Rows[e.RowIndex].Cells[0].Value);
                Point menuLocation = DGVDrivingLicenseTypes.PointToScreen(new Point(cellRect.X, cellRect.Y + cellRect.Height));
                // Show the context menu at the calculated location
                contextDrivingLisenceType.Show(menuLocation);
            }
        }

        private void DGVExpenceTypes_MouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DGVExpenceTypes.Rows[e.RowIndex].Cells[0].Value is null) return;
            if (e.RowIndex >= 0 && (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) && e.ColumnIndex == 3)
            {
                var cellRect = DGVExpenceTypes.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                selectedId = Convert.ToInt32(DGVExpenceTypes.Rows[e.RowIndex].Cells[0].Value);
                Point menuLocation = DGVExpenceTypes.PointToScreen(new Point(cellRect.X, cellRect.Y + cellRect.Height));
                // Show the context menu at the calculated location
                contextMenuExpenceType.Show(menuLocation);
            }

        }


        private void InitializeContextDrivingLicenseType()
        {
            contextDrivingLisenceType = new ContextMenuStrip();
            var deleteDrivingLicenseTypeItem = new ToolStripMenuItem("حذف نوع رخصة القيادة", Properties.Resources.trash__1_);
            deleteDrivingLicenseTypeItem.Click += DeleteDrivingLicenseType_confirm;

            var updateDrivingLicenseTypeItem = new ToolStripMenuItem("تعديل نوع رخصة القيادة", Properties.Resources.gear);
            updateDrivingLicenseTypeItem.Click += UpdateDrivingLisenceType;
            contextDrivingLisenceType.Items.Add(deleteDrivingLicenseTypeItem);
            contextDrivingLisenceType.Items.Add(updateDrivingLicenseTypeItem);
        }

        private void UpdateDrivingLisenceType(object sender, EventArgs e)
        {
            AddDrivingLiceseTypeForm drivingLiceseTypeForm = new AddDrivingLiceseTypeForm(selectedId);
            drivingLiceseTypeForm.OnAddNewDrivingLicenseTypeEventHundler += RefreshDGVDrivingLicenseTypes;
            drivingLiceseTypeForm.ShowDialog(); 

        }

        private void DeleteDrivingLicenseType_confirm(object sender, EventArgs e)
        {
            //this is for delete driving license type 
            YesNoDesisionForm yesNoDesisionForm = new YesNoDesisionForm("هل تريد حذف نوع رخصة القيادة؟");
            yesNoDesisionForm.DoOperationEventHundler += DeleteDrivingLicenseType; 
            yesNoDesisionForm.ShowDialog();
        }

        private void DeleteDrivingLicenseType()
        {
            // this is for deleting drivingLicense type 
        }

        private void InitializeContextMenuExpenceType()
        {
            contextMenuExpenceType = new ContextMenuStrip();
            var deleteExpenceTypeItem = new ToolStripMenuItem("حذف نوع النفقه", Properties.Resources.trash__1_);
            deleteExpenceTypeItem.Click += DelteExpenceType_confirm; 
            contextMenuExpenceType.Items.Add(deleteExpenceTypeItem);
        }

        private void DelteExpenceType_confirm(object sender, EventArgs e)
        {
            YesNoDesisionForm yesNoDesisionForm = new YesNoDesisionForm("هل تريد حذف نوع المصروف؟");
            yesNoDesisionForm.DoOperationEventHundler += DeleteExpenceType; 
            yesNoDesisionForm.ShowDialog();
        }

        private void DeleteExpenceType()
        {
            if(clsExpense.DeleteExpenceType(selectedId))
            {
                statusMessageForm = new StatusMessageForm("Operation done Successfully");
                LoadExpencesToDGVExpenceTypes(clsExpense.GetAllExpencesTypes());
                statusMessageForm.ShowSuccess();
                
            }
            else
            {
                statusMessageForm = new StatusMessageForm("Operation Failed");
                statusMessageForm.ShowFailed();
            }
        }

        private void lblDrivingLisenceType_Click(object sender, EventArgs e)
        {
            ToggleDrivingLicense(); 

        }


        private void ToggleDrivingLicense()
        {
            if (DrivingLicenseTypesToggle)// opened => close
            {
                pnlDrivingLicenses.Height = 96;
                lblDrivingLisenceType.Image = Properties.Resources.caret_circle_down;
                lblOpen_closeLicense.Text = "اضغط للفتح";

            }
            else //close => open 
            {
                pnlDrivingLicenses.Height = 444;
                lblDrivingLisenceType.Image = Properties.Resources.caret_circle_up;
                lblOpen_closeLicense.Text = "اضغط للإغلاق";

            }

            DrivingLicenseTypesToggle = !DrivingLicenseTypesToggle;
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

        private void LoadExpencesToDGVExpenceTypes(DataTable ExpenceTypes)
        {
            DGVExpenceTypes.Rows.Clear(); 
            foreach (DataRow item in ExpenceTypes.Rows)
                DGVExpenceTypes.Rows.Add(item[0], item[1], item[2]); 
            
        }


        private void LoadDrivingLicenseToDGVDrivingLicenseTypes(DataTable DrivingLicenseTypes)
        {
            DGVDrivingLicenseTypes.Rows.Clear();
            foreach (DataRow item in DrivingLicenseTypes.Rows)
            
                DGVDrivingLicenseTypes.Rows.Add(item[0] ,
                    item[1], 
                    item[2] , 
                    clsDrivingLicenseType.GetSituation(Convert.ToInt16(item[3])) , 
                    item[4] , 
                    item[5] , 
                    clsInstructor.Find(Convert.ToInt16 (item[7]))?.UserName , 
                    clsInstructor.Find(Convert.ToInt16(item[8]))?.UserName);    
            
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
            LoadExpencesToDGVExpenceTypes(clsExpense.GetAllExpencesTypes());
        }

        private void AddNewDrivingLicenseType_Click(object sender, EventArgs e)
        {
            AddDrivingLiceseTypeForm drivingLiceseTypeForm = new AddDrivingLiceseTypeForm();
            drivingLiceseTypeForm.OnAddNewDrivingLicenseTypeEventHundler += RefreshDGVDrivingLicenseTypes;
            drivingLiceseTypeForm.ShowDialog(); 
        }

        private void RefreshDGVDrivingLicenseTypes()
        {
            LoadDrivingLicenseToDGVDrivingLicenseTypes(clsDrivingLicenseType.GetAll());
        }
    }
}

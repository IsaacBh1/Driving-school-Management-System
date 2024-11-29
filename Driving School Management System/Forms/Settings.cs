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
        private ContextMenuStrip contextMenuExpenceType;
        StatusMessageForm statusMessageForm; 
        private int selectedId; 
        public Settings()
        {
            InitializeComponent();
            ToggleExpencesTypesPanel();
            LoadExpencecsToDGVExpenceTypes(clsExpense.GetAllExpencesTypes());
            InitializeContextMenuExpenceType();
            DGVExpenceTypes.CellMouseClick += DGVExpenceTypes_MouseClick; 
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
                LoadExpencecsToDGVExpenceTypes(clsExpense.GetAllExpencesTypes());
                statusMessageForm.ShowSuccess();
                
            }
            else
            {
                statusMessageForm = new StatusMessageForm("Operation Failed");
                statusMessageForm.ShowFailed();
            }
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

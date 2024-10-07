using Driving_school_BusinessLayer;
using Driving_School_Management_System.UserControls;
using System;
using System.Data;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class BoxWindow : Form
    {
        CloseBoxForm CloseBoxForm = null;
        
        public BoxWindow()
        {
            InitializeComponent();
            InetializeIncomeBox();
            AddBoxesInformations(clsMoneyBank.GetAllMoneyBanks()); 
        }

        private void AddBoxesInformations(DataTable BoxInformations)
        {
            DGVBoxes.Rows.Clear();
            foreach (DataRow row in BoxInformations.Rows)
            {
                DGVBoxes.Rows.Add(row[0],Convert.ToDecimal (row[1]).ToString("0.00"), Convert.ToDecimal( row[2]).ToString("0.00"),Convert.ToDecimal (row[3]).ToString("0.00"), Convert.ToDecimal(row[4]).ToString("0.00"));
            }
        }





        private void InetializeIncomeBox()
        {
            flowLayoutBox.Controls.Add(new BoxBankInos(182, 20000, 400, 200, 200)); 
        }

        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            CloseBoxForm = new CloseBoxForm(); 
            CloseBoxForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            AddBoxesInformations(clsMoneyBank.GetAllMoneyBanks());

        }
    }
}

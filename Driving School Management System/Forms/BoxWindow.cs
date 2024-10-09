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
        clsMoneyBank MoneyBank = null;
        public BoxWindow()
        {
            InitializeComponent();
            AddBoxesInformations(clsMoneyBank.GetAllMoneyBanks());
            MoneyBank = clsMoneyBank.Find(clsMoneyBank.GetCurrentMoneyBank());
            InetializeIncomeBox(MoneyBank);

        }

        private void AddBoxesInformations(DataTable BoxInformations)
        {
            DGVBoxes.Rows.Clear();
            foreach (DataRow row in BoxInformations.Rows)
            {
                DGVBoxes.Rows.Add(row[0],Convert.ToDecimal (row[1]).ToString("0.00"),Convert.ToDecimal (row[3]).ToString("0.00"), Convert.ToDecimal(row[4]).ToString("0.00") , (Convert.ToDecimal(row[2]) - Convert.ToDecimal(row[3])).ToString("0.00"));
            }
        }


        private void InetializeIncomeBox(clsMoneyBank moneyBank)
        {
            flowLayoutBox.Controls.Clear();
            flowLayoutBox.Controls.Add(new BoxBankInos( moneyBank.MoneyBankID, 
                                                        moneyBank.InitialAmount, 
                                                        moneyBank.NetProfit, 
                                                        moneyBank.AllAmount -  moneyBank.InternalAmount, 
                                                        moneyBank.InternalAmount
                                                       )
                                      ); 
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            CloseBoxForm = new CloseBoxForm();
            CloseBoxForm.MoneyBoxAddedEventHundler += RefreshMoneyBox;  
            CloseBoxForm.ShowDialog();
        }

        private void RefreshMoneyBox(int id)
        {
            InetializeIncomeBox(clsMoneyBank.Find(id));
            AddBoxesInformations(clsMoneyBank.GetAllMoneyBanks()); 
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            AddBoxesInformations(clsMoneyBank.GetAllMoneyBanks());

        }
    }
}

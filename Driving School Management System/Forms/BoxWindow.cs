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
                decimal NetProfit = (Convert.ToDecimal(row[3]) - Convert.ToDecimal(row[1]));
                if (NetProfit < 0) NetProfit = 0;
                DGVBoxes.Rows.Add(  row[0],
                                    Convert.ToDecimal (row[1]).ToString("0.00"),
                                    Convert.ToDecimal (row[3]).ToString("0.00"),
                                    NetProfit.ToString("0.00"), 
                                    Convert.ToDecimal(row[2]).ToString("0.00"));
            }
        }
        private void InetializeIncomeBox(clsMoneyBank moneyBank)
        {
            flowLayoutBox.Controls.Clear();
            if (moneyBank != null) { 
            
                BoxBankInos monayBox = new BoxBankInos(moneyBank); 
                monayBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                if (!(monayBox is null))
                    flowLayoutBox.Controls.Add(monayBox);
            }
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
            InetializeIncomeBox(clsMoneyBank.Find(clsMoneyBank.GetCurrentMoneyBank()));
        }

        private void BoxWindow_Activated(object sender, EventArgs e)
        {
            AddBoxesInformations(clsMoneyBank.GetAllMoneyBanks());
            InetializeIncomeBox(clsMoneyBank.Find(clsMoneyBank.GetCurrentMoneyBank()));
        }
    }
}

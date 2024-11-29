using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;
using System.Drawing;
using Driving_school_BusinessLayer;
namespace Driving_School_Management_System.UserControls
{
    public partial class BoxBankInos : UserControl
    {


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // width of ellipse
          int nHeightEllipse // height of ellipse
        );



        public BoxBankInos()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        public BoxBankInos(clsMoneyBank moneyBank)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            lblID.Text = moneyBank.MoneyBankID.ToString();
            lblFirstBalance.Text = moneyBank.InitialAmount.ToString("0.0") + " DA";
            if(moneyBank.Expences <= moneyBank.InternalAmount)
                lblIncomes.Text = (moneyBank.InternalAmount - moneyBank.Expences).ToString("0.0") + " DA";
            else
                lblIncomes.Text = "0 DA";

            lblExpences.Text = moneyBank.Expences.ToString("0.0") + " DA";
            internalAmount.Text = moneyBank.InternalAmount.ToString("0.0") + " DA"; 
        }


    }
}

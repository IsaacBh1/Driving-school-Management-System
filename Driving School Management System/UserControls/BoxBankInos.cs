using System.Runtime.InteropServices;
using System;
using System.Windows.Forms;
using System.Drawing;
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

        public BoxBankInos(int boxID , decimal FirstBalance , decimal Incomes  , decimal expences , decimal currentMoney)
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            lblID.Text = boxID.ToString();
            lblFirstBalance.Text = FirstBalance.ToString() + " DA";
            lblIncomes.Text = Incomes.ToString() + " DA";
            lblExpences.Text = expences.ToString() + " DA";
            label10.Text = currentMoney.ToString() + " DA"; 
        }


    }
}

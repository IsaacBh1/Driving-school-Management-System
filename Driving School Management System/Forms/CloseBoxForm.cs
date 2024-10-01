using Driving_school_BusinessLayer;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class CloseBoxForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        public ConfirmsClosingMoneyBankForm closeMoneyBoxForm = null;
        public clsMoneyBank moneyBank = null;
        private bool OperationIsCompletted = false;
        StatusMessageForm statusMessageForm = null; 
        public CloseBoxForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private bool CheckAmountGetted()
        {
            return !string.IsNullOrEmpty(numAmountGetted.Value.ToString()); 
        }




        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // this is the functionlity of closing the box
            if(!CheckAmountGetted())
            {
                MessageBox.Show("هناك معلومات مفقودة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            // create a new  Bankbox 
            closeMoneyBoxForm = new ConfirmsClosingMoneyBankForm();
            closeMoneyBoxForm.BoxClosedbtnClicked += CloseMoneyBank;  // this is the error  , 
            closeMoneyBoxForm.Show(); 
        }

        private void CloseMoneyBank()
        {
            if (clsMoneyBank.CloseCurrentMoneyBank())
                OperationIsCompletted = true;
            else
                OperationIsCompletted = false;
            AddingNewMoneyBank(AddNewMoneyBox()); 
        }


        private bool AddNewMoneyBox()
        {
            if (!OperationIsCompletted) return false;
            moneyBank = new clsMoneyBank() {
                InitialAmount = Convert.ToDecimal(numAmountGetted.Value),
            };
            return moneyBank.Save(); 

        }


        private void AddingNewMoneyBank(bool MoneyBankIsAdded)
        {
            if (MoneyBankIsAdded)
            {
                statusMessageForm = new StatusMessageForm(" Operation is Done Successfully");
                statusMessageForm.ShowSuccess();
                Close();
            }
            else
            {
                statusMessageForm = new StatusMessageForm("Operation is not Done Successfully");
                statusMessageForm.ShowFailed();
            }
        }


       



       
        private void pictureBox1_Click(object sender, EventArgs e)
        => Close();

        private void guna2Button2_Click(object sender, EventArgs e)
        => Close(); 
        
    }
}

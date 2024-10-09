using Driving_school_BusinessLayer;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class ExpencesForm : Form
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


        clsExpense expense = null;
        StatusMessageForm statusMessageForm = null;
        clsMoneyBank moneyBank = clsMoneyBank.Find(clsMoneyBank.GetCurrentMoneyBank()); 


        public ExpencesForm()
        {
            InitializeComponent();
            InetializeExpenceType(); 
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }
        
        private void InetializeExpenceType()
        {
            CboxType.DataSource = clsExpense.GetAllExpencesTypes().DefaultView;
            CboxType.DisplayMember = "Name";

        }


        private bool CheckInputs()
        {
            return !string.IsNullOrEmpty(CboxType.Text) && numupdownPrice.Value != 0; 
        }

        private bool  SaveExpence()
        {
            expense = new clsExpense() {
                ExpenseTypeID = clsExpense.GetExpenseTypeIDByName(CboxType.Text),   
                Amount = Convert.ToDecimal(numupdownPrice.Value) , 
                AdditionalNotes = txtbxNote.Text, 
                MoneyBankID = clsMoneyBank.GetCurrentMoneyBank(), 

            };
            if (!moneyBank.AddExpence(expense.Amount)) return false;    

            return expense.Save() && moneyBank.Save(); 
        }





        private void pictureBox1_Click(object sender, EventArgs e)
        => Close();

        private void guna2Button2_Click(object sender, EventArgs e)
        => Close();

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // this is the code fore saving into db 

            if (CheckInputs())
            {
                //this is the code to save on DB 
                if (SaveExpence())
                {
                    // MessageBox.Show("student is saved successfully with ID = " + student.StudentID);
                    statusMessageForm = new StatusMessageForm("Expence Saved Successfully");
                    statusMessageForm.ShowSuccess();
                    Close();
                }
                else
                {
                    statusMessageForm = new StatusMessageForm("Expence not Saved");
                    statusMessageForm.ShowFailed();
                }
            }
            else
                MessageBox.Show("هناك معلومات مفقودة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);




        }
    }
}

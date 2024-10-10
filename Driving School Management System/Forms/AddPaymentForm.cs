using Driving_school_BusinessLayer;
using Driving_School_Management_System.UserControls;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class AddPaymentForm : Form
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


        PaymentGridView paymentDGV = null; 
        private bool isInforCorrect = false ; 
        clsBatch batch = null;
        clsCondidateFile condidateFile = null;
        clsPayment payment = null;
        StatusMessageForm statusMessageForm = null; 
        clsMoneyBank moneyBank = null;
        public delegate void AddNewPayment();
        public event AddNewPayment PaymentHaddedEventHundler; 
        public AddPaymentForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        => Close();

        private void pictureBox1_Click_1(object sender, EventArgs e)
        => Close();
        

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private bool CheckCondidateFileInput()
        {
            bool isFound = !string.IsNullOrEmpty(txtboxID.Text);
            if (isFound)
            {
                return true; 
            }
            MessageBox.Show("هناك معلومات مفقودة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false; 

        }


        private void inetializeDGV(int id , decimal amount , decimal reminder)
        {
            paymentpanel.Controls.Clear();
            paymentDGV = new  PaymentGridView(id , amount , reminder);
            paymentpanel.Controls.Add(paymentDGV);
        }

        private void NotItemsFoundInDGV()
        {
            paymentpanel.Controls.Clear();
            paymentpanel.Controls.Add(new NoItemsFound());
            paymentDGV = null; 

        }



        //search for condidate file 
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            NotItemsFoundInDGV(); 
            if (CheckCondidateFileInput())
            {
                //search for that condidate file and his payment 
                if(int.TryParse(txtboxID.Text , out int CondidateFileID))
                {
                    condidateFile = clsCondidateFile.Find(CondidateFileID);
                    if (condidateFile is null)
                    {
                        MessageBox.Show(" لم يتم العثور على الملف", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isInforCorrect = false; 
                        return;
                    }
                    txtBoxPersonName.Text = condidateFile.Student.Person.FullName_Arabic;
                    // ADD THE BATCH HERE
                    inetializeDGV(CondidateFileID , condidateFile.Payment.FullAmount , condidateFile.Payment.FullAmount - condidateFile.Payment.AmountPayed);
                }
            }
        }

        private void CheckPaymentInformations()
        {
            if (!(paymentDGV is null || condidateFile is null))
            {
                isInforCorrect = (paymentDGV.AmountPayed != 0);
                return; 
            }

            isInforCorrect = false; 
        }
 
        private bool AddNewPayent()
        {
            CheckPaymentInformations();
            if (isInforCorrect)
            {
                batch = new clsBatch()
                {
                    Price = paymentDGV.AmountPayed,
                    PaymentDate = paymentDGV.PaymentDate,
                    PaymentID = condidateFile.PaymentID,
                };
                if (!batch.Save()) return false; 
                payment = clsPayment.Find(condidateFile.PaymentID);
                moneyBank = clsMoneyBank.Find(clsMoneyBank.GetCurrentMoneyBank());
                payment.AmountPayed += batch.Price;
                moneyBank.AddPayment (batch.Price); 
                return payment.Save() && moneyBank.Save();
            }
            return false; 
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (AddNewPayent())
            {
                // MessageBox.Show("student is saved successfully with ID = " + student.StudentID);
                statusMessageForm = new StatusMessageForm("تمت العملية بنجاح");
                statusMessageForm.ShowSuccess();
                PaymentHaddedEventHundler?.Invoke(); 
                Close();
            }
            else
            {
                statusMessageForm = new StatusMessageForm("لم تنجح العملية");
                statusMessageForm.ShowFailed();
            };
        }
    }
}

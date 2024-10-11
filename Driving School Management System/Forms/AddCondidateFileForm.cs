using DrivingSchool_BusinesseLayer;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Driving_school_BusinessLayer; 
namespace Driving_School_Management_System.Forms
{
    public partial class AddCondidateFileForm : Form
    {
        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------

        //constructor
        public AddCondidateFileForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            _initializeFormCboxes();
            GetDrivingLicensePrice(CbxDrivingLicenseType.Text);
            changeDrivingLicenseEvent(CbxDrivingLicenseType, null); 
        }

        //----------------------------------------------------------------------------------
        //---------------------------this is for window properties ------------------------------
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

        private void Form_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //----------------------------------------------------------------------------------
        //----------------------this is for closing the window-------------------------------

        private void pictureBox1_Click(object sender, EventArgs e) => Close();
        private void guna2Button2_Click(object sender, EventArgs e) => Close();

        //----------------------------------------------------------------------------------
        //------this is for searching the student by his id or his Identity number----------

        private int GetStudentIDfromIdentityNumber(string IdentityNumber)
        {
            return clsStudent.GetStudentIDByIdentityNumber(IdentityNumber); 
        }
        private string GetStudentIdentityNumberfromID(int ID)
        {
            return clsStudent.GetStudentIdentityNumberByID(ID);
        }
        //----------------------------------------------------------------------------------
        //----------------------this is for getting all IDs and infos in the form --------------------

        private int GetIDOfIndructor(string UserName)
        {
            return clsInstructor.GetInstructorIDByUserName(UserName); 
        }
        private int GetIDOfVehicleFromVehicleName(string VehicleName)
        {
            return clsVehicle.GetVehicleIDByVehicleName(VehicleName);  
        }
        private int GetIDOfDrivingLicenseTypeFromName(string Name)
        {
            return clsDrivingLicenseType.GetDrivingLicenseTypeIDByName(Name);
        }

        private decimal GetDrivingLicensePrice(string Name)
        {
            return clsDrivingLicenseType.GetDrivingLicenseTypePriceByID(GetIDOfDrivingLicenseTypeFromName(Name)); 
        }
        private int GetGruopIDFromName(string Name)
        {
            return clsGroup.GetGroupIDbyName(Name);
        }


        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------



        private bool InformationCorrect = true;
        private StatusMessageForm statusMessageForm;
        private clsCondidateFile condidateFile;
        //private clsStudent student;
        //private clsDrivingLicenseType drivingLicenseType; 
        //private clsGroup group;
        private clsPayment payment;
        //private clsInstructor Theo_instructor;
        //private clsInstructor App_instructor; 
        public delegate void AddNewCondidateFile();
        public event AddNewCondidateFile OnCondidateFileAddedEventHundler; 


        //----------------------------------------------------------------------------------
        //----------------this is for inetialize comboboxes of the form----------------------

        private void _initializeDrivingLicenseTypeCbox()
        {
            CbxDrivingLicenseType.DataSource = clsDrivingLicenseType.GetAllNames().DefaultView;
            CbxDrivingLicenseType.DisplayMember = "Name";
        }

        //GetAllGroupsNames()
        private void _initializeGroupsCbox()
        {
            CbxGroup.DataSource = clsGroup.GetAllGroupsNames().DefaultView;
            CbxGroup.DisplayMember = "Name";
        }

        private void _initializeInstructorsCbox()
        {
            CboxAppInsructor.DataSource = clsInstructor.GatAllInsructorsUserName().DefaultView;
            CboxAppInsructor.DisplayMember = "UserName";
            CboxTheoInsructor.DataSource = clsInstructor.GatAllInsructorsUserName().DefaultView;
            CboxTheoInsructor.DisplayMember = "UserName";
        }
       /* private void _initializeVehicleCbox()
        {
          CboxVehicle.DataSource =clsVehicle.GetAllVehiclesNames().DefaultView;
          CboxVehicle.DisplayMember = "Name";

        }*/
        private void _initializeFormCboxes()
        {
            _initializeDrivingLicenseTypeCbox();
            _initializeGroupsCbox();
            _initializeInstructorsCbox();
            //_initializeVehicleCbox();
        }
     
        //----------------------------------------------------------------------------------
        //--------------------ths is for checking if all required field is exist-----------

        public void CheckField(Control txtBoxField)
        {
            if (txtBoxField is Guna.UI2.WinForms.Guna2TextBox GunatextBox)
            {
                GunatextBox.BorderColor = string.IsNullOrEmpty(GunatextBox.Text) ? Color.IndianRed : Color.White;
                InformationCorrect = !string.IsNullOrEmpty(GunatextBox.Text) && InformationCorrect;

            }
            else if(txtBoxField is NumericUpDown NumInput)
            {
                NumInput.BackColor = string.IsNullOrEmpty(NumInput.Text) ? Color.Gray : Color.White;
                InformationCorrect = !string.IsNullOrEmpty(NumInput.Text) && InformationCorrect;
            }
            else if (txtBoxField is MetroFramework.Controls.MetroComboBox MetroInput)
            {
                MetroInput.BackColor = string.IsNullOrEmpty(MetroInput.Text) ? Color.Gray : Color.White;
                InformationCorrect = !string.IsNullOrEmpty(MetroInput.Text) && InformationCorrect;

            }
        }
        public void CheckCondidatesFileInformations()
        {
            InformationCorrect = true; 
            CheckField(txtbxCondidateID); 
            CheckField(txtbxIdentityNumber); 
            CheckField(txtbxPrice); 
            CheckField(CbxDrivingLicenseType); 
            CheckField(CbxGroup); 
            CheckField(CbxPaymentType); 
        }


        //----------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------


        private bool _SaveCondidatesFile()
        {

            if (int.TryParse (txtbxCondidateID.Text , out int studentID))
            {
            payment = new clsPayment() { AmountPayed = Convert.ToDecimal(txtbxAmountPayed.Text), 
                                        FullAmount = Convert.ToDecimal(txtbxPrice.Text),
                                        MoneyBankID = clsMoneyBank.GetCurrentMoneyBank()};
            payment.Save();
                condidateFile = new clsCondidateFile()
                {
                    StudentID = studentID,
                    DrivingLicenseTypeID = GetIDOfDrivingLicenseTypeFromName(CbxDrivingLicenseType.Text),
                    AdditionalNotes = txtBoxAdditionalNotes.Text,
                    IsActive = true,
                    CreatingFileDate = DateTime.Now,
                    IsArchived = false,
                    PaymentID = payment.PaymentID,
                    GroupID = GetGruopIDFromName(CbxGroup.Text) , 
                    ApplicationInstructorID = GetIDOfIndructor(CboxAppInsructor.Text), 
                    TheoreticalInstructorID = GetIDOfIndructor(CboxTheoInsructor.Text)
                };
                return condidateFile.Save(); 

            }                     

            return false; 
        }


        private void btnSubmit_Click(object sender, EventArgs e)
        {
            CheckCondidatesFileInformations(); 
            if (InformationCorrect)
            {
                //this is the code to save on DB 
                if (_SaveCondidatesFile())
                {
                    // MessageBox.Show("student is saved successfully with ID = " + student.StudentID);
                    statusMessageForm = new StatusMessageForm("File Saved Successfully");
                    statusMessageForm.ShowSuccess();
                    OnCondidateFileAddedEventHundler?.Invoke(); 
                    Close();
                }
                else
                {
                    statusMessageForm = new StatusMessageForm("File not Saved");
                    statusMessageForm.ShowFailed();
                }
            }
            else
                MessageBox.Show("هناك معلومات مفقودة", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void IDChangedEvent(object sender, EventArgs e)
        {
            if (int.TryParse(txtbxCondidateID.Text, out int ID)) {
                txtbxIdentityNumber.Text = GetStudentIdentityNumberfromID(ID); 
            }; 
        }

        private void IdentityNumberChangedEvent(object sender, EventArgs e)
        {
            int ID = GetStudentIDfromIdentityNumber(txtbxIdentityNumber.Text);
            if (ID > 0) txtbxCondidateID.Text = ID.ToString();
            else txtbxCondidateID.Text = ""; 


        }

        private void changeDrivingLicenseEvent(object sender, EventArgs e)
        {
            txtbxPrice.Text = GetDrivingLicensePrice(CbxDrivingLicenseType.Text).ToString(); 
        }
    }
}

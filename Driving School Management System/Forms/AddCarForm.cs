using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Driving_school_BusinessLayer;


namespace Driving_School_Management_System.Forms
{
    public partial class AddCarForm : Form
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


        public AddCarForm()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            _inetializeCboxes(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        => Close();

        private void guna2Button2_Click(object sender, EventArgs e)
        => Close();


        private void _initializeDrivingLicenseTypeCbox()
        {
            CboxDrivingLisence.DataSource = clsDrivingLicenseType.GetAllNames().DefaultView;
            CboxDrivingLisence.DisplayMember = "Name";
        }
        private void _initializeFuelTypeCbox()
        {
            CboxFuelType.DataSource = clsFuelType.GetAllFuelTypes();
            CboxFuelType.DisplayMember = "Name";
        }

        private void _inetializeCboxes() {
            _initializeDrivingLicenseTypeCbox();
            _initializeFuelTypeCbox(); 
        }



        private void btnGetCarImagePath_Click(object sender, EventArgs e)
        {
            openFileDialogCarImage.Multiselect = false;
            openFileDialogCarImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialogCarImage.ShowDialog() == DialogResult.OK)
            {
                // The selected file path
                string filePath = openFileDialogCarImage.FileName;
                if (File.Exists(filePath))
                {
                txtbxImagePath.Text = filePath;
                    // Proceed with the file, e.g., display the image or process it
                }
                else
                {
                    MessageBox.Show("الملف غير موجود.");
                }

            }

        }
    }
}

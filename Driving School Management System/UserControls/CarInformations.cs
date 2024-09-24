using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving_School_Management_System.UserControls
{
    public partial class lblCarInformations : UserControl
    {

        public int Id { get; set; } = 0; 

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

        public lblCarInformations(int Id ,  string RegistratioNumber = "None" , string DrivingLicense = "None" , string Marka = "None" , string Type = "None" , string UsageDate = "None" , string FuelType = "None" , string ImagePath = "None")
        {
            InitializeComponent();
            this.Id = Id;
            lblmarka.Text = Marka;
            lblType.Text = Type;    
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            lbleRegistratioNumber.Text = RegistratioNumber;
            lblDrivingLisence.Text = DrivingLicense;
            lblUsageDate.Text = UsageDate;
            lblFuelType.Text = FuelType;
            if (File.Exists(ImagePath)) picVehicleImage.Image = Image.FromFile(ImagePath);  
            else picVehicleImage.Image = Properties.Resources.electric_car;
        }


        public lblCarInformations()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }

        private void lblCarInformations_MouseHover(object sender, EventArgs e)
        {
            BackColor = ColorTranslator.FromHtml("#fcfafa");
            
        }

        private void lblCarInformations_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.White;

        }

        private void lblmarka_MouseHover(object sender, EventArgs e)
        {
            BackColor = ColorTranslator.FromHtml("#fcfafa");
        }
    }
}

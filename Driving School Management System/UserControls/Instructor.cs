using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Driving_School_Management_System.UserControls
{
    public partial class Instructor : UserControl
    {


        public int ID {  get; set; }
        public string FullName {  get; set; }

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
        public Instructor()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }


        public Instructor(int id , string UserName)
        {
            InitializeComponent();
            ID = id;
            FullName = UserName;
            SetNameUi(); 
        }

        public void SetNameUi()
        {
            lblInsructorFullName.Text = FullName;
        }
    }
}

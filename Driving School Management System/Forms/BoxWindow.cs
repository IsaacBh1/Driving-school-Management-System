using Driving_School_Management_System.UserControls;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class BoxWindow : Form
    {
        public BoxWindow()
        {
            InitializeComponent();
            InetializeIncomeBox(); 
        }


        private void InetializeIncomeBox()
        {
            flowLayoutBox.Controls.Add(new BoxBankInos(182, 20000, 400, 200, 200)); 
        }


    }
}

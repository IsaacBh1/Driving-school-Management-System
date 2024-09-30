using System.Windows.Forms;

namespace Driving_School_Management_System.UserControls
{
    public partial class BoxBankInos : UserControl
    {
        public BoxBankInos()
        {
            InitializeComponent();
        }

        public BoxBankInos(bool parameters)
        {
            InitializeComponent();
            parameters = false; 
        }


    }
}

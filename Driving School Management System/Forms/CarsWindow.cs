using Driving_school_BusinessLayer;
using Driving_School_Management_System.UserControls;
using System;
using System.Data;
using System.Windows.Forms;

namespace Driving_School_Management_System.Forms
{
    public partial class CarsWindow : Form
    {
        public CarsWindow()
        {
            InitializeComponent();
            AddAllVehicluesToUI(); 
        }


        private  DataTable GetAllVehicules()
        {
            return clsVehicle.GetAllVehicles();
        }


        private void AddAllVehicluesToUI()
        {
            flowLayoutPanelVehicles.Controls.Clear();
            DataTable vehiclesDataTable = GetAllVehicules();
            foreach (DataRow row in vehiclesDataTable.Rows)
            {
                    flowLayoutPanelVehicles.Controls.Add(new lblCarInformations(   (int)row["VehicleID"],
                                                                                        row["RegestrationNumber"].ToString(), 
                                   clsDrivingLicenseType.GetDrivingLicenseNameByID((int)row["DrivingLicenseTypeID"]), 
                                                                                        row["Mark"].ToString(), 
                                                                                        row["Type"].ToString() , 
                                                                                        row["DateOfUsage"].ToString() ,
                                                   clsFuelType.GetFuelTypeNameByID((int)row["FuelType"]) ,
                                                                                        row["ImagePath"].ToString())); 
            }
        }


        private void guna2Button1_Click(object sender, EventArgs e)
        {
            AddCarForm carForm = new AddCarForm();
            carForm.OnCarAddedEventHundler += RefreshCarWindo; 
            carForm.ShowDialog(); 
        }

        private void RefreshCarWindo()
        {
            AddAllVehicluesToUI(); 
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
            AddAllVehicluesToUI();
        }
    }
}

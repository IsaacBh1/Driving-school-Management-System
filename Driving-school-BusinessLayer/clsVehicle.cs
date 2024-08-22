using DrivingSchool_DataAccessLayer;
using System;
using System.Data;

namespace Driving_school_BusinessLayer
{
    public class clsVehicle
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int VehicleID { get; set; }
        public string Name { get; set; }
        public string RegistrationNumber { get; set; }
        public string Mark { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string ImagePath { get; set; }
        public DateTime? DateOfUsage { get; set; }
        public string AdditionalNotes { get; set; }
        public int FuelType { get; set; }
        public int DrivingLicenseTypeID { get; set; }

        // Constructor for creating a new vehicle (AddNew mode)
        public clsVehicle()
        {
            VehicleID = -1;
            Name = string.Empty;
            RegistrationNumber = string.Empty;
            Mark = string.Empty;
            Type = string.Empty;
            Model = string.Empty;
            Color = string.Empty;
            ImagePath = string.Empty;
            DateOfUsage = null;
            AdditionalNotes = string.Empty;
            FuelType = -1;
            DrivingLicenseTypeID = -1;
            Mode = enMode.AddNew;
        }

        private clsVehicle(int vehicleID, string name, string registrationNumber, string mark,
                            string type, string model, string color, string imagePath,
                            DateTime? dateOfUsage, string additionalNotes, int fuelType, int drivingLicenseTypeID)
        {
            VehicleID = vehicleID;
            Name = name;
            RegistrationNumber = registrationNumber;
            Mark = mark;
            Type = type;
            Model = model;
            Color = color;
            ImagePath = imagePath;
            DateOfUsage = dateOfUsage;
            AdditionalNotes = additionalNotes;
            FuelType = fuelType;
            DrivingLicenseTypeID = drivingLicenseTypeID;
            Mode = enMode.Update;
        }

        private bool _AddNewVehicle()
        {
            VehicleID = clsVehicleDataAccess.AddNewVehicle(Name, RegistrationNumber, Mark, Type, Model, Color,
                                                           ImagePath, DateOfUsage, AdditionalNotes, FuelType,
                                                           DrivingLicenseTypeID);
            return VehicleID != -1;
        }

        private bool _UpdateVehicle()
        {
            return clsVehicleDataAccess.UpdateVehicle(VehicleID, Name, RegistrationNumber, Mark, Type, Model, Color,
                                                      ImagePath, DateOfUsage, AdditionalNotes, FuelType,
                                                      DrivingLicenseTypeID);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewVehicle())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateVehicle();
            }
            return false;
        }

        public static clsVehicle Find(int ID)
        {
            string _Name = string.Empty;
            string _RegistrationNumber = string.Empty;
            string _Mark = string.Empty;
            string _Type = string.Empty;
            string _Model = string.Empty;
            string _Color = string.Empty;
            string _ImagePath = string.Empty;
            DateTime? _DateOfUsage = null;
            string _AdditionalNotes = string.Empty;
            int _FuelType = -1;
            int _DrivingLicenseTypeID = -1;

            if (clsVehicleDataAccess.GetVehicleInfoByID(ID, ref _Name, ref _RegistrationNumber, ref _Mark, ref _Type,
                                                        ref _Model, ref _Color, ref _ImagePath, ref _DateOfUsage,
                                                        ref _AdditionalNotes, ref _FuelType, ref _DrivingLicenseTypeID))
            {
                return new clsVehicle(ID, _Name, _RegistrationNumber, _Mark, _Type, _Model, _Color, _ImagePath,
                                      _DateOfUsage, _AdditionalNotes, _FuelType, _DrivingLicenseTypeID);
            }
            return null;
        }
   
        public static DataTable GetAllVehiclesNames()
        {
            return clsVehicleDataAccess.GetAllVehiclesNames(); 
        }
        public static int GetVehicleIDByVehicleName(string Name)
        {
            return clsVehicleDataAccess.GetVehicleIDByVehicleName(Name); 
        }
        
    }
}

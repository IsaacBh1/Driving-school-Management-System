using DrivingSchool_DataAccessLayer;
using Microsoft.SqlServer.Server;
using System.Data;

namespace Driving_school_BusinessLayer
{
    public class clsGroup
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int GroupID { get; set; }
        public string Name { get; set; }
        public int NumberOfMembers { get; set; }
        public int DrivingLicenseTypesID { get; set; }

        public clsGroup()
        {
            GroupID = -1;
            Name = "";
            NumberOfMembers = 0;
            DrivingLicenseTypesID = -1;
            Mode = enMode.AddNew;
        }

        private clsGroup(int groupID, string name, int numberOfMembers, int drivingLicenseTypesID)
        {
            GroupID = groupID;
            Name = name;
            NumberOfMembers = numberOfMembers;
            DrivingLicenseTypesID = drivingLicenseTypesID;
            Mode = enMode.Update;
        }

        private bool _AddNewGroup()
        {
            GroupID = clsGroupDataAccess.AddNewGroup(Name, NumberOfMembers, DrivingLicenseTypesID);
            return GroupID != -1;
        }

        private bool _UpdateGroup()
        {
            return clsGroupDataAccess.UpdateGroup(GroupID, Name, NumberOfMembers, DrivingLicenseTypesID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewGroup())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateGroup();
            }
            return false;
        }

        public static clsGroup Find(int ID)
        {
            string _Name = "";
            int _NumberOfMembers = 0;
            int _DrivingLicenseTypesID = -1;

            if (clsGroupDataAccess.GetGroupInfoByID(ID, ref _Name, ref _NumberOfMembers, ref _DrivingLicenseTypesID))
            {
                return new clsGroup(ID, _Name, _NumberOfMembers, _DrivingLicenseTypesID);
            }
            return null;
        }
        public static DataTable GetAllGroupsNames()
        {
            return clsGroupDataAccess.GetAllNamesGroups(); 
        }
        public static int GetGroupIDbyName(string name)
        {
            return clsGroupDataAccess.GetGroupIDbyName(name);
        }
        public static string GetGroupNameByID(int ID)
        {
            return clsGroupDataAccess.GetGroupNameByID(ID);
        }
    }
}

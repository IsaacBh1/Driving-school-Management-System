using DrivingSchool_DataAccessLayer;
using System;

namespace Driving_school_BusinessLayer
{
    public class clsCondidateFile
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;

        public int CandidateFileID { get; set; }
        public int StudentID { get; set; }
        public int DrivingLicenseTypeID { get; set; }
        public string AdditionalNotes { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatingFileDate { get; set; }
        public bool IsArchived { get; set; }
        public int GroupID { get; set; }
        public int PaymentID { get; set; }
        public int TheoreticalInstructorID { get; set; }
        public int ApplicationInstructorID { get; set; }

        public clsCondidateFile()
        {
            CandidateFileID = -1;
            StudentID = -1;
            DrivingLicenseTypeID = -1;
            AdditionalNotes = string.Empty;
            IsActive = false;
            CreatingFileDate = DateTime.MinValue;
            IsArchived = false;
            GroupID = -1;
            PaymentID = -1;
            TheoreticalInstructorID = -1;
            ApplicationInstructorID = -1;
            Mode = enMode.AddNew;
        }

        private clsCondidateFile(int candidateFileID, int studentID, int drivingLicenseTypeID, string additionalNotes, bool isActive, DateTime creatingFileDate, bool isArchived, int groupID, int paymentID, int theoreticalInstructorID, int applicationInstructorID)
        {
            CandidateFileID = candidateFileID;
            StudentID = studentID;
            DrivingLicenseTypeID = drivingLicenseTypeID;
            AdditionalNotes = additionalNotes;
            IsActive = isActive;
            CreatingFileDate = creatingFileDate;
            IsArchived = isArchived;
            GroupID = groupID;
            PaymentID = paymentID;
            TheoreticalInstructorID = theoreticalInstructorID;
            ApplicationInstructorID = applicationInstructorID;
            Mode = enMode.Update;
        }

        private bool _AddNewCandidateFile()
        {
            CandidateFileID = clsCondidateFileDataAccess.AddNewCondidateFile(StudentID, DrivingLicenseTypeID, AdditionalNotes, IsActive, CreatingFileDate, IsArchived, GroupID, PaymentID, TheoreticalInstructorID, ApplicationInstructorID);
            return CandidateFileID != -1;
        }

        private bool _UpdateCandidateFile()
        {
            return clsCondidateFileDataAccess.UpdateCondidateFile(CandidateFileID, StudentID, DrivingLicenseTypeID, AdditionalNotes, IsActive, CreatingFileDate, IsArchived, GroupID, PaymentID, TheoreticalInstructorID, ApplicationInstructorID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCandidateFile())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateCandidateFile();
            }
            return false;
        }

        public static clsCondidateFile Find(int ID)
        {
            int _StudentID = -1;
            int _DrivingLicenseTypeID = -1;
            string _AdditionalNotes = string.Empty;
            bool _IsActive = false;
            DateTime _CreatingFileDate = DateTime.MinValue;
            bool _IsArchived = false;
            int _GroupID = -1;
            int _PaymentID = -1;
            int _TheoreticalInstructorID = -1;
            int _ApplicationInstructorID = -1;

            if (clsCondidateFileDataAccess.GetCondidateFileInfoByID(ID ,ref _DrivingLicenseTypeID ,ref _AdditionalNotes ,ref _IsActive ,ref _CreatingFileDate ,ref _IsArchived ,ref _GroupID ,ref _PaymentID , ref _TheoreticalInstructorID , ref _ApplicationInstructorID))
            {
                return new clsCondidateFile(ID, _StudentID, _DrivingLicenseTypeID, _AdditionalNotes, _IsActive, _CreatingFileDate, _IsArchived, _GroupID, _PaymentID, _TheoreticalInstructorID, _ApplicationInstructorID);
            }
            return null;
        }
    }
}

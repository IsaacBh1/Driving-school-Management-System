using DrivingSchool_DataAccessLayer;
using System;
using System.Data;

namespace Driving_school_BusinessLayer
{
    public class clsCondidateFile
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode Mode = enMode.AddNew;
        public int CandidateFileID { get; set; }
        public int StudentID { get; set; }
        public clsStudent Student {  get; set; }
        public int DrivingLicenseTypeID { get; set; }
        public clsDrivingLicenseType drivingLicenseType { get; set; }
        public string AdditionalNotes { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatingFileDate { get; set; }
        public bool IsArchived { get; set; }
        public int GroupID { get; set; }
        public clsGroup Group {  get; set; }
        public int PaymentID { get; set; }
        public clsPayment Payment { get; set; }
        public int TheoreticalInstructorID { get; set; }
        public int ApplicationInstructorID { get; set; }
        public clsInstructor TheoreticalInstructor {get ; set;}
        public clsInstructor ApplicationInstructor { get; set;}
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
            Student = clsStudent.Find(StudentID); 
            DrivingLicenseTypeID = drivingLicenseTypeID;
            drivingLicenseType = clsDrivingLicenseType.Find(DrivingLicenseTypeID); 
            AdditionalNotes = additionalNotes;
            IsActive = isActive;
            CreatingFileDate = creatingFileDate;
            IsArchived = isArchived;
            GroupID = groupID;
            Group = clsGroup.Find(GroupID); 
            PaymentID = paymentID;
            Payment = clsPayment.Find(PaymentID);
            TheoreticalInstructorID = theoreticalInstructorID;
            ApplicationInstructorID = applicationInstructorID;
            TheoreticalInstructor = clsInstructor.Find(TheoreticalInstructorID); 
            ApplicationInstructor = clsInstructor.Find(ApplicationInstructorID);
            Mode = enMode.Update;
        }


        public string GetActivation()
        {
            if (IsActive) return "نعم";
            return "لا"; 
        }


        public string GetArchived()
        {
            if (IsArchived) return "مؤرشف";
            return "غير مؤرشف";
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

            if (clsCondidateFileDataAccess.GetCondidateFileInfoByID(ID,
                                                                    ref _DrivingLicenseTypeID,
                                                                    ref _AdditionalNotes,
                                                                    ref _IsActive,
                                                                    ref _CreatingFileDate,
                                                                    ref _IsArchived,
                                                                    ref _GroupID,
                                                                    ref _PaymentID,
                                                                    ref _TheoreticalInstructorID,
                                                                    ref _ApplicationInstructorID,
                                                                    ref _StudentID
                                                                    ))
            {
                return new clsCondidateFile(ID, _StudentID, _DrivingLicenseTypeID, _AdditionalNotes, _IsActive, _CreatingFileDate, _IsArchived, _GroupID, _PaymentID, _TheoreticalInstructorID, _ApplicationInstructorID);
            }
            return null;
        }
        public static DataTable GetAllCondidateFileInformations()
            =>clsCondidateFileDataAccess.GetAllCondidateFileInformations(); 
        
        public static DataTable SearchCondidtesFilesByDrivingLisence(string Name)
            =>clsCondidateFileDataAccess.SearchCondidtesFilesByDrivingLisence(Name); 
        
        public static DataTable SearchArchivedStudentsFiles(bool isArchived)
            =>clsCondidateFileDataAccess.SearchArchivedStudentsFiles(isArchived); 
       
        public static DataTable SearchActiveStudentsFiles(bool isActive) 
            => clsCondidateFileDataAccess.SearchActiveStudentsFiles(isActive);
        public static DataTable SearchCondidatesFileInfoLastName_Arabic(string Name)
            => clsCondidateFileDataAccess.SearchCondidatesFileInfoLastName_Arabic(Name);

        public static DataTable SearchCondidatesFileInfoFirstName_Arabic(string Name)
            => clsCondidateFileDataAccess.SearchCondidtesFileInfoFirstName_Arabic(Name);
        public static DataTable SearchCondidateFileInfoByID(string Id)
            => clsCondidateFileDataAccess.SearchCondidateFileInfoByID(Id);
        public static DataTable SearchByAll(int CondidateFileID, string FirstName_Arabic, string LastName_Arabic, string DrivingLisenceType, bool isArchived, bool isActive)
            => clsCondidateFileDataAccess.SearchByAll(CondidateFileID, FirstName_Arabic, LastName_Arabic, DrivingLisenceType, isArchived, isActive); 
    
        public static bool IsCondidateFileExists(int id)
        {
            return clsCondidateFileDataAccess.IsCondidateFileExist(id);
        }

        public static bool DeleteCondidateFile(int id)
        {
            return clsCondidateFileDataAccess.DeleteCondidateFile(id); 
        }

        public static bool DeleteCondidateFilesByStudentID(int StudentID)
        {
            return clsCondidateFileDataAccess.DeleteCondidateFilesByStudentID(StudentID); 
        }

    }


}

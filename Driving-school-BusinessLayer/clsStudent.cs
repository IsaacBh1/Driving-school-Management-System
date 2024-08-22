using DrivingSchool_BusinesseLayer;
using DrivingSchool_DataAccessLayer;
using System;
using System.Data;

namespace Driving_school_BusinessLayer
{
    public class clsStudent
    {
        enum enMode { AddNew = 0, Update = 1 };
        enMode Mode = enMode.AddNew;

        private clsStudent(int studentID, int personID, DateTime birthDate, string birthPlace, bool gender, int nationalCardID)
        {
            StudentID = studentID;
            PersonID = personID;
            BirthDate = birthDate;
            BirthPlace = birthPlace;
            Gender = gender;
            NationalCardID = nationalCardID;
            Person = clsPerson.Find(PersonID);
            NationalCard = clsNationalCard.Find(NationalCardID);
            UserName = NationalCard.CardNumber;
            Mode = enMode.Update;
        }
        public clsStudent()
        {
            StudentID = -1;
            PersonID = -1;
            BirthDate = DateTime.Now;
            BirthPlace = string.Empty;
            NationalCardID = -1;
            Mode = enMode.AddNew;
        }

        public int StudentID { get; set; }
        public int PersonID { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public bool Gender { get; set; }
        public int NationalCardID { get; set; }
        public string UserName { get; set; }//the identity card 
        public clsPerson Person { get; set; }
        public clsNationalCard NationalCard { get; set; }



        private bool _AddNewStudent()
        {
            StudentID = clsStudentDataAccess.AddNewStudent(PersonID, UserName, BirthDate, BirthPlace, Gender, NationalCardID);
            return (StudentID != -1);
        }
        private bool _UpdateStudent()
        {
            //this is the code of Updating user 
            return clsStudentDataAccess.UpdateStudent(StudentID, PersonID, UserName, BirthDate, BirthPlace, Gender, NationalCardID);


        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewStudent())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateStudent();
            }
            return false;
        }
        public static clsStudent Find(int ID)
        {
            int personID = -1;
            DateTime birthDate = DateTime.Now;
            string birthPlace = string.Empty;
            bool gender = true;
            int nationalCardID = -1;
            string UserName = string.Empty;

            if (clsStudentDataAccess.GetStudentInfoByID(ID, ref personID, ref UserName, ref birthDate, ref birthPlace, ref gender, ref nationalCardID))
            {
                return new clsStudent(ID, personID, birthDate, birthPlace, gender, nationalCardID);
            }
            return null;

        }


        public static bool IsStudentExists(int ID)
        {
            return clsStudentDataAccess.IsStudentExists(ID);
        }

        public static bool DeleteStudent(int ID)
        {
            return clsStudentDataAccess.DeleteStudent(ID);
        }


        public static DataTable GetAllStudentsInfo()
        {
            return clsStudentDataAccess.GetAllStudentsInformations();
        }

        public static DataTable SearchStudentInfoByID(int id)
        {
            return clsStudentDataAccess.SearchStudentInfoByID(id); 
        }


        public static DataTable SearchStudentInfoByFirstName_Arabic(string Name)
        {
            return clsStudentDataAccess.SearchStudentInfoFirstName_Arabic(Name);
        }



        public static DataTable SearchStudentInfoLastName_Arabic(string LastName)
        {
            return clsStudentDataAccess.SearchStudentInfoLastName_Arabic(LastName);
        }

        public static DataTable SearchStudentInfoByIdentityNumber(string Number)
        {
            return clsStudentDataAccess.SearchStudentInfoByIdentityNumber(Number);
        }

        public static DataTable SearchByAll(int id, string FirstName, string LastName, string IdentityNumber)
        {
           return clsStudentDataAccess.SearchStudentByAll(id, FirstName, LastName, IdentityNumber); 
        }

        public static int GetStudentIDByIdentityNumber(string IdentityNumber)
        {
            return clsStudentDataAccess.GetStudentIDByIdentityNumber(IdentityNumber);
        }
        //GetStudentIdentityNumberByID
        public static string GetStudentIdentityNumberByID(int ID)
        {
            return clsStudentDataAccess.GetStudentIdentityNumberByID(ID);
        }
    }
}


    
using Driving_school_BusinessLayer;
using DrivingSchool_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool_BusinesseLayer
{


    public partial class clsPerson
    {
        public enum enMode { AddNew = 0, Update = 1 }

        private enMode Mode = enMode.AddNew;
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstName_Arabic { get; set; }
        public string LastName_Arabic { get; set; }
        public int ContactID { get; set; }
        //this is decomposition 
        public clsContact Contact { get; set; }
        public int AddressID { get; set; }
        public clsAddress Address { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }

        }
        public string FullName_Arabic
        {
            get { return FirstName_Arabic + " " + LastName_Arabic; }
        }

        public clsPerson()
        {
            PersonID = -1;
            ContactID = -1;
            AddressID = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
            FirstName_Arabic = string.Empty;
            LastName_Arabic = string.Empty;
            Mode = enMode.AddNew;
        }

        private clsPerson(int PersonID, string FirstName, string LastName, string FirstName_Arabic, string LastName_Arabic, int ContactID, int AddressID)
        {
            this.PersonID = PersonID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.FirstName_Arabic = FirstName_Arabic;
            this.LastName_Arabic = LastName_Arabic;
            this.AddressID = AddressID;
            this.ContactID = ContactID;
            Contact = clsContact.Find(ContactID);
            Address = clsAddress.Find(AddressID);
            Mode = enMode.Update;

        }


        private bool _AddNewPerson()
        {
            PersonID = clsPersonDataAccess.AddNewPerson(FirstName, LastName, FirstName_Arabic, LastName_Arabic, ContactID, AddressID);
            return (PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            //this is the code of Updating user 
            return clsPersonDataAccess.UpdatePerson(PersonID, FirstName, LastName, FirstName_Arabic, LastName_Arabic, ContactID, AddressID);

        }
        public static DataTable GetAllPersons()
        {
            //get all persons 
            return clsPersonDataAccess.GetAllPersons();
        }

        public static bool DeletePerson(int ID)
        {
            return clsPersonDataAccess.DeletePerson(ID);
        }

        public bool IsPersonExiste(int ID)
        {
            //this is the code to ckeck the user if exist or not
            return clsPersonDataAccess.IsPersonExists(ID);
        }
        public static clsPerson Find(int UserID)
        {
            //this is the code of Finding a user by ID
            string _FirstName = "";
            string _LastName = "";
            string _FirstName_Arabic = "";
            string _LastName_Arabic = "";
            int _ContactID = -1;
            int _AddressID = -1;

            bool IsFound = clsPersonDataAccess.GetPersonInfoByID(UserID, ref _FirstName, ref _LastName, ref _FirstName_Arabic, ref _LastName_Arabic, ref _ContactID, ref _AddressID);
            if (IsFound)
            {
                return new clsPerson(UserID, _FirstName, _LastName, _FirstName_Arabic, _LastName_Arabic, _ContactID, _AddressID);
            }
            return null;
        }
        public bool Save()
        {
            //this is the code of Saving A user in db 

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else { return false; };
                case enMode.Update:
                    return _UpdatePerson();


            }
            return false;
        }

    };
};














using DrivingSchool_DataAccessLayer;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.CompilerServices;



namespace DrivingSchool_BusinesseLayer
{
    public class clsContact
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode Mode = enMode.AddNew;
        public int contactID { get; set; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string AdditionalContact { get; set; }

        private clsContact(int contactID, string Phone, string Email, string AdditionalContact)
        {
            this.contactID = contactID;
            this.AdditionalContact = AdditionalContact;
            this.Phone = Phone;
            this.Email = Email;
            Mode = enMode.Update;
        }

        public clsContact()
        {
            contactID = -1;
            Phone = "";
            Email = "";
            AdditionalContact = "";
            Mode = enMode.AddNew;
        }

        //the code of Adding a new Contact 

        public bool _AddNewContact()
        {
            this.contactID = clsContactDataAccess.AddNewContact(Phone, Email, AdditionalContact);
            return (this.contactID != -1);
        }


        //the code of delete the contact
        public static bool DeleteContact(int ID)
        {
            return clsContactDataAccess.DeleteContact(ID);
        }

        //the code of saving the contact 
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else return false;

                case enMode.Update: return _UpdateContact();
            }
            return false;
        }


        //the code of updating a contact 
        public bool _UpdateContact()
        {
            return clsContactDataAccess.UpdateContact(contactID, Phone, Email, AdditionalContact);
        }


        public static clsContact Find(int ContactID)
        {


            string _Phone = "";
            string _Email = "";
            string _AdditionalContact = "";

            bool IsFound = clsContactDataAccess.GetContactInfoByID(ContactID, ref _Phone, ref _Email, ref _AdditionalContact);
            if (IsFound)
            {
                return new clsContact(ContactID, _Phone, _Email, _AdditionalContact);
            }
            else
            {
                return null;
            }


        }

        //get all contacts 
        public static DataTable GetAllContacts()
        {
            return clsContactDataAccess.GetAllContacts();
        }


        public static int Find(string Email, string Phone, string AdditionalInfo)
        {
            return clsContactDataAccess.GetCountactIDByInfo(Phone, Email, AdditionalInfo);
        }


    };
}

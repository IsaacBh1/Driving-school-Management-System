using DrivingSchool_BusinesseLayer;
using DrivingSchool_DataAccessLayer;
using System;
using System.Security.Policy;

namespace Driving_school_BusinessLayer
{
    public class clsUser
    {
        enum enMode {AddNew = 0, Update = 1}; 
        private enMode Mode = enMode.AddNew;
        private clsUser(int userID, int personID, string password, int permission, string userName)
        {
            UserID = userID;
            PersonID = personID;
            Person = clsPerson.Find(personID); 
            Password = password;
            Permission = permission;
            UserName = userName;
            Mode = enMode.Update;
        
        }

        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            Password = string.Empty;
            Permission = -1;
            UserName = string.Empty;
            Mode = enMode.AddNew; 
        }

        public int UserID {  get; set; }
        public int PersonID { get; set; }
        public clsPerson Person { get; set; }
        public string Password {  get; set; }
        public int Permission {  get; set; }
        public string UserName {  get; set; }



        private  bool _AddNewUser()
        {
            this.PersonID = clsUserDataAccess.AddNewUser(Password , Permission , UserName  , PersonID);
            return (PersonID != -1);  
        }

        private bool _UpdateUser()
        {
            return clsUserDataAccess.UpdateUser(UserID , Password , Permission , UserName , PersonID);
        }
        

        public static bool DeleteUser(int ID)
        {
            return clsUserDataAccess.DeleteUser(ID); 
        }


        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        Mode = enMode.Update; 
                        return true;
                    }
                    return false;
                case enMode.Update:
                    return _UpdateUser();
            }
            return false; 
        }
        

        public static clsUser Find(int ID)
        {
            int _PersonID = -1 ; 
            string _Password = string.Empty ; 
            int _Permission = -1 ; 
            string _UserName = string.Empty; 
            if(clsUserDataAccess.GetUserInfoByID(ID ,ref _Password ,ref _Permission ,ref _UserName , ref _PersonID))
            {
                return new clsUser(ID , _PersonID , _Password , _Permission , _UserName) ;
            }
            else
            {
                return null;
            }
        }

        public static bool IsPersonExists(int ID)
        {
            return clsUserDataAccess.IsUserExists(ID);
        }
    }
}
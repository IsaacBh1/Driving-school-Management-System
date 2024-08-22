using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsStudentDataAccess
    {
        private static string ConnectionString = clsConnectionStr.ConnectionStr;

        public static DataTable GetAllStudents()
        {
            DataTable Students = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Students;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Students.Load(reader);
                }
                reader.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return Students;
        }

        public static bool GetStudentInfoByID(int studentID, ref int PersonID, ref string UserName, ref DateTime BirthDate, ref string BirthCountry, ref bool Gender, ref int NationalCardID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from Students where StudentID = @studentID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@studentID", studentID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserName = reader["UserName"] != DBNull.Value ? (string)reader["UserName"] : null;
                    BirthDate = (DateTime)reader["BirthDate"];
                    BirthCountry = reader["BirthCountry"] != DBNull.Value ? (string)reader["BirthCountry"] : null;
                    Gender = (bool)reader["Gender"];
                    NationalCardID = (int)reader["NationalCardID"];
                }
                reader.Close();
                return IsFound;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static int AddNewStudent(int PersonID, string UserName, DateTime BirthDate, string BirthCountry, bool Gender, int NationalCardID)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            int gender = (Gender == true) ? 1 : 0; 
            string query = @"insert into Students (PersonID, UserName, BirthDate, BirthCountry, Gender, NationalCardID) values (@PersonID, @UserName, @BirthDate, @BirthCountry , @gender , @NationalCardID);
                    select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@BirthCountry", BirthCountry);
            command.Parameters.AddWithValue("@gender", gender);
            command.Parameters.AddWithValue("@NationalCardID", NationalCardID);
            try
            {
                sqlConnection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    Id = ID;
                }
                return Id; 
            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static int GetStudentIDByIdentityNumber(string IdentityNumber)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);          
            string query = @"select StudentID from Students 
                            inner join NationalCards on NationalCards.NationalCardID = Students.NationalCardID 
                            where CardNumber = @IdentityNumber;";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@IdentityNumber", IdentityNumber);
           
            try
            {
                sqlConnection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    Id = ID;
                }
                return Id;
            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public static string GetStudentIdentityNumberByID(int ID )
        {
            string IdentityNumber = string.Empty;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"select CardNumber from Students 
                            inner join NationalCards on NationalCards.NationalCardID = Students.NationalCardID 
                            where StudentID = @ID;";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@ID", ID);

            try
            {
                sqlConnection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    IdentityNumber= result.ToString();
                }
                return IdentityNumber;
            }
            catch
            {
                return "";
            }
            finally
            {
                sqlConnection.Close();
            }
        }




        public static bool UpdateStudent(int studentID, int PersonID, string UserName, DateTime BirthDate, string BirthCountry, bool Gender, int NationalCardID)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[Students] SET " +
                "PersonID = @PersonID, " +
                "UserName = @UserName, " +
                "BirthDate = @BirthDate, " +
                "BirthCountry = @BirthCountry, " +
                "Gender = @Gender, " +
                "NationalCardID = @NationalCardID " +
                "WHERE StudentID = @studentID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@studentID", studentID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@BirthCountry", BirthCountry);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@NationalCardID", NationalCardID);
            try
            {
                sqlConnection.Open();
                AffectedRows = command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return (AffectedRows != 0);
        }

        public static bool DeleteStudent(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM Students WHERE StudentID = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            try
            {
                int AffectedRows = 0;
                connection.Open();
                AffectedRows = command.ExecuteNonQuery();
                if (AffectedRows > 0) result = true;
            }
            catch
            {
                result = false;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public static bool IsStudentExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Found = 1 from Students where StudentID = @Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            try
            {
                connection.Open();
                SqlDataReader sqlDataReader = command.ExecuteReader();
                result = sqlDataReader.HasRows;
                sqlDataReader.Close();
            }
            catch
            {
                result = false;
            }
            finally
            {
                connection.Close();
            }
            return result;
        }

        public static int GetStudentIDByInfo(int PersonID, string UserName, DateTime BirthDate, string BirthCountry, bool Gender, int NationalCardID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select StudentID from Students where " +
                "PersonID = @PersonID and " +
                "UserName = @UserName and " +
                "BirthDate = @BirthDate and " +
                "BirthCountry = @BirthCountry and " +
                "Gender = @Gender and " +
                "NationalCardID = @NationalCardID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@BirthDate", BirthDate);
            command.Parameters.AddWithValue("@BirthCountry", BirthCountry);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@NationalCardID", NationalCardID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["StudentID"];
                    }
                }
                reader.Close();
            }
            catch
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return ID;
        }

        public static bool IsStudentExists(int PersonID, string UserName, DateTime BirthDate, string BirthCountry, bool Gender, int NationalCardID)
        {
            return (GetStudentIDByInfo(PersonID, UserName, BirthDate, BirthCountry, Gender, NationalCardID) != -1);
        }
        public static DataTable GetAllStudentsInformations()
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select top 50 * from StudentInformations order by StudentID desc;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
                }
                reader.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return StudentsInfo;
        }
        public static DataTable SearchStudentInfoByID(int id)
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from StudentInformations where StudentID = @Id ; ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id); 
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
                }
                reader.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return StudentsInfo;
        }
        

        public static DataTable SearchStudentInfoFirstName_Arabic(string Name)
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from StudentInformations where FirstName_Arabic like '%"+Name+"%'; ";
            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Name", Name);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
                }
                reader.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return StudentsInfo;
        }


        public static DataTable SearchStudentInfoLastName_Arabic(string LastName)
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from StudentInformations where LastName_Arabic like '%"+ LastName + "%';";
            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Name", LastName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
                }
                reader.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return StudentsInfo;
        }

        public static DataTable SearchStudentInfoByIdentityNumber(string Number)
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from StudentInformations where CardNumber like '"+Number+"%' ; ";
            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Number", Number);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
                }
                reader.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return StudentsInfo;
        }

        public static DataTable SearchStudentByAll(int id , string FirstName , string LastName , string IdentityNumber )
        {
            DataTable StudentsInfo = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from StudentInformations where StudentID like '%"+id+"%' " +
                           " and  FirstName_Arabic like '%"+FirstName+"%' " +
                           " and  LastName_Arabic like '%"+LastName+"%' " +
                           " and CardNumber like '%"+IdentityNumber+"%';";
            SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.AddWithValue("@Number", Number);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    StudentsInfo.Load(reader);
                }
                reader.Close();
            }
            catch
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return StudentsInfo;
        }
    }
}


//select * from StudentInformations where FirstName_Arabic like '%haq%'
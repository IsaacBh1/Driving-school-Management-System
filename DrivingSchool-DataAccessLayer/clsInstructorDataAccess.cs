using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsInstructorDataAccess
    {
        private static string ConnectionString = clsConnectionStr.ConnectionStr;

        public static DataTable GetAllInstructors()
        {
            DataTable Instructors = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Instructors;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Instructors.Load(reader);
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
            return Instructors;
        }


        public static DataTable GetAllInstructorsUserNames()
        {
            DataTable Instructors = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select UserName from Instructors;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Instructors.Load(reader);
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
            return Instructors;
        }




        public static bool GetInstructorInfoByID(int instructorID, ref int PersonID, ref string UserName, ref bool Gender, ref int DrivingLicenseID, ref int NationalCardID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from Instructors where InstructorID = @instructorID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@instructorID", instructorID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Gender = (bool)reader["Gender"];
                    DrivingLicenseID = (int)reader["DrivingLicenseID"];
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

        public static int AddNewInstructor(int PersonID, string UserName, bool Gender, int DrivingLicenseID, int NationalCardID)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into Instructors (PersonID, UserName, Gender, DrivingLicenseID, NationalCardID) values (@PersonID, @UserName, @Gender, @DrivingLicenseID, @NationalCardID);" +
                "select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@DrivingLicenseID", DrivingLicenseID);
            command.Parameters.AddWithValue("@NationalCardID", NationalCardID);
            try
            {
                sqlConnection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    Id = ID;
                }
            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlConnection.Close();
            }
            return Id;
        }

        public static bool UpdateInstructor(int instructorID, int PersonID, string UserName, bool Gender, int DrivingLicenseID, int NationalCardID)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[Instructors] SET " +
                "PersonID = @PersonID, " +
                "UserName = @UserName, " +
                "Gender = @Gender, " +
                "DrivingLicenseID = @DrivingLicenseID, " +
                "NationalCardID = @NationalCardID " +
                "WHERE InstructorID = @instructorID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@instructorID", instructorID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@DrivingLicenseID", DrivingLicenseID);
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

        public static bool DeleteInstructor(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM Instructors WHERE InstructorID = @Id";
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

        public static bool IsInstructorExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Found = 1 from Instructors where InstructorID = @Id";
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

        public static int GetInstructorIDByInfo(int PersonID, string UserName, bool Gender, int DrivingLicenseID, int NationalCardID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select InstructorID from Instructors where " +
                "PersonID = @PersonID and " +
                "UserName = @UserName and " +
                "Gender = @Gender and " +
                "DrivingLicenseID = @DrivingLicenseID and " +
                "NationalCardID = @NationalCardID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@DrivingLicenseID", DrivingLicenseID);
            command.Parameters.AddWithValue("@NationalCardID", NationalCardID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["InstructorID"];
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

        public static bool IsInstructorExists(int PersonID, string UserName, bool Gender, int DrivingLicenseID, int NationalCardID) =>
            (GetInstructorIDByInfo(PersonID, UserName, Gender, DrivingLicenseID, NationalCardID) != -1);

        public static int GetInstructorIDByUserName(string UserName)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select InstructorID from Instructors where UserName = @UserName ; "; 

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["InstructorID"];
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

        public static string GetInstructorUserNameByID(int instructorID)
        {
            string userName = null;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select UserName from Instructors where InstructorID = @InstructorID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InstructorID", instructorID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        userName = reader["UserName"].ToString();
                    }
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
            return userName;
        }






    }
}

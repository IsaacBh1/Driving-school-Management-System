using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsPersonDataAccess
    {
        private static string ConnectionString = "Server=. ; Database=DrivingSchoolDB ; User Id=sa ; Password=sa123456 ; Integrated security=true ; TrustServerCertificate=True;";

        public static DataTable GetAllPersons()
        {
            DataTable persons = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Persons;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    persons.Load(reader);
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
            return persons;
        }

        public static bool GetPersonInfoByID(int personID, ref string FirstName, ref string LastName, ref string FirstName_Arabic, ref string LastName_Arabic, ref int ContactID, ref int AddressID)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from Persons where PersonID = @personID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@personID", personID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    FirstName_Arabic = (string)reader["FirstName_Arabic"];
                    LastName_Arabic = (string)reader["LastName_Arabic"];
                    ContactID = (int)reader["ContactID"];
                    AddressID = (int)reader["AddressID"];
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

        public static int AddNewPerson(string FirstName, string LastName, string FirstName_Arabic, string LastName_Arabic, int ContactID, int AddressID)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into Persons (FirstName, LastName, FirstName_Arabic, LastName_Arabic, ContactID, AddressID) values (@FirstName, @LastName, @FirstName_Arabic, @LastName_Arabic, @ContactID, @AddressID);" +
                " select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@FirstName_Arabic", FirstName_Arabic);
            command.Parameters.AddWithValue("@LastName_Arabic", LastName_Arabic);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            command.Parameters.AddWithValue("@AddressID", AddressID);
            try
            {
                  sqlConnection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    Id = ID;
                    return Id;
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
            return -1; 
        }

        public static bool UpdatePerson(int personID, string FirstName, string LastName, string FirstName_Arabic, string LastName_Arabic, int ContactID, int AddressID)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[Persons] SET " +
                "FirstName = @FirstName, " +
                "LastName = @LastName, " +
                "FirstName_Arabic = @FirstName_Arabic, " +
                "LastName_Arabic = @LastName_Arabic, " +
                "ContactID = @ContactID, " +
                "AddressID = @AddressID " +
                "WHERE PersonID = @personID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@personID", personID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@FirstName_Arabic", FirstName_Arabic);
            command.Parameters.AddWithValue("@LastName_Arabic", LastName_Arabic);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            command.Parameters.AddWithValue("@AddressID", AddressID);
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

        public static bool DeletePerson(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM Persons WHERE PersonID = @Id";
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

        public static bool IsPersonExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Found = 1 from Persons where PersonID = @Id";
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

        public static int GetPersonIDByInfo(string FirstName, string LastName, string FirstName_Arabic, string LastName_Arabic, int ContactID, int AddressID)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select PersonID from Persons where " +
                "FirstName = @FirstName and " +
                "LastName = @LastName and " +
                "FirstName_Arabic = @FirstName_Arabic and " +
                "LastName_Arabic = @LastName_Arabic and " +
                "ContactID = @ContactID and " +
                "AddressID = @AddressID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@FirstName_Arabic", FirstName_Arabic);
            command.Parameters.AddWithValue("@LastName_Arabic", LastName_Arabic);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            command.Parameters.AddWithValue("@AddressID", AddressID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["PersonID"];
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

        public static bool IsPersonExists(string FirstName, string LastName, string FirstName_Arabic, string LastName_Arabic, int ContactID, int AddressID)
        {
            return (GetPersonIDByInfo(FirstName, LastName, FirstName_Arabic, LastName_Arabic, ContactID, AddressID) != -1);
        }
    }
}

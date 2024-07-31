using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{

    public sealed class clsPersonDataAccess
    {
        private static string ConnectionString = "Server=. ; Database=DrivingSchoolDB ; User Id=sa ; Password=sa123456 ;Integrated security=true ; TrustServerCertificate=True; ";
        public static DataTable GetAllPersons()
        {
            DataTable Addresses = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Persons ; ";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Addresses.Load(reader);
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

            return Addresses;


        }
        public static bool GetUserInfoByID(int PersonID,ref string FirstName,ref string LastName, ref string FirstName_Arabic, ref string LastName_Arabic,ref int ContactID, ref int AddressID)
        {

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from Persons where PersonID = @PersonID";
            SqlCommand commanad = new SqlCommand(query, sqlConnection);
            commanad.Parameters.AddWithValue("@PersonID", PersonID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = commanad.ExecuteReader();
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
        public static int AddNewUser(string FirstName,  string LastName, string FirstName_Arabic, string LastName_Arabic, int ContactID, int AddressID)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "INSERT INTO Persons " + 
            "([FirstName], [LastName], [FirstName_Arabic], [LastName_Arabic], [ContactID], [AddressID])" + 
            "VALUES (@FirstName,@LastName , @FirstName_Arabic, @LastName_Arabic , @ContactID , @AddressID);" +
            "select SCOPE_IDENTITY(); ";

            SqlCommand commanad = new SqlCommand(query, sqlConnection);
            commanad.Parameters.AddWithValue("@FirstName", FirstName);
            commanad.Parameters.AddWithValue("@LastName", LastName);
            commanad.Parameters.AddWithValue("@FirstName_Arabic", FirstName_Arabic);
            commanad.Parameters.AddWithValue("@LastName_Arabic", LastName_Arabic);
            commanad.Parameters.AddWithValue("@ContactID", ContactID);
            commanad.Parameters.AddWithValue("@AddressID", AddressID);
            try
            {
                sqlConnection.Open();
                object result = commanad.ExecuteScalar();
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
        public static bool UpdateUser(int PersonID , string FirstName, string LastName, string FirstName_Arabic, string LastName_Arabic, int ContactID, int AddressID)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[Persons] " +
                "SET FirstName = @FirstName, LastName = @LastName, FirstName_Arabic = @FirstName_Arabic, LastName_Arabic = @LastName_Arabic, ContactID = @ContactID, AddressID = @AddressID " +
                "WHERE PersonID = @PersonID;";

            SqlCommand commanad = new SqlCommand(query, sqlConnection);
            commanad.Parameters.AddWithValue("@PersonID", PersonID);
            commanad.Parameters.AddWithValue("@FirstName", FirstName);
            commanad.Parameters.AddWithValue("@LastName", LastName);
            commanad.Parameters.AddWithValue("@FirstName_Arabic", FirstName_Arabic);
            commanad.Parameters.AddWithValue("@LastName_Arabic", LastName_Arabic);
            commanad.Parameters.AddWithValue("@ContactID", ContactID);
            commanad.Parameters.AddWithValue("@AddressID", AddressID);
          
            try
            {
                sqlConnection.Open();
                AffectedRows = commanad.ExecuteNonQuery();

            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return AffectedRows != 0;
        }
        public static bool DeletePerson(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM [dbo].[Persons] WHERE PersonID = @Id";
            SqlCommand command = new SqlCommand(@query, connection);
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
            catch { result = false; }
            finally { connection.Close(); };
            return result;
        }


    }
}




/*        public static int AddNewUser(string FirstName, string LastName, string FirstName_Arabic, string LastName_Arabic, int ContactID, int AddressID)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into Persons Values (@FirstName, @LastName , @FirstName_Arabic , @LastName_Arabic , @ContactID @AddressID);" +
                "select SCOPE_IDENTITY();";

            SqlCommand commanad = new SqlCommand(query, sqlConnection);
            commanad.Parameters.AddWithValue("@FirstName", FirstName);
            commanad.Parameters.AddWithValue("@LastName", LastName);
            commanad.Parameters.AddWithValue("@FirstName_Arabic", FirstName_Arabic);
            commanad.Parameters.AddWithValue("@LastName_Arabic", LastName_Arabic);
            commanad.Parameters.AddWithValue("@ContactID", ContactID);
            commanad.Parameters.AddWithValue("@AddressID", AddressID);
            try
            {
                sqlConnection.Open();
                object result = commanad.ExecuteScalar();
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
*/
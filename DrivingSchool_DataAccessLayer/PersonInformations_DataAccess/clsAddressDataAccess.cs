using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsAddressDataAccess 
    {
        private static string ConnectionString = "Server=. ; Database=DrivingSchoolDB ; User Id=sa ; Password=sa123456 ;Integrated security=true ; TrustServerCertificate=True; "; 
        public static DataTable GetAllAddresses()
        {
            DataTable Addresses = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Addresses ; "; 
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) { 
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
        public static bool GetAddressInfoByID(int AddressID, ref string Country,ref string State,ref string LocalAddress)
        {

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from Addresses where AddressID = @AddressID"; 
            SqlCommand commanad  = new SqlCommand(query, sqlConnection);
            commanad.Parameters.AddWithValue("@AddressID", AddressID);
            bool IsFound = false; 
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = commanad.ExecuteReader(); 
                while(reader.Read())
                {
                    IsFound = true; 
                    Country = (string)reader["Country"];
                    State = (string)reader["State"];
                    LocalAddress = (string)reader["Localaddress"]; 
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
        public static int AddNewAddress(string Country, string State, string LocalAddress)
        {
            int Id = -1; 
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into Addresses Values (@Country, @State, @LocalAddress);" +
                "select SCOPE_IDENTITY();";

            SqlCommand commanad = new SqlCommand(query, sqlConnection);
            commanad.Parameters.AddWithValue("@Country", Country);
            commanad.Parameters.AddWithValue("@State", State);
            commanad.Parameters.AddWithValue("@LocalAddress", LocalAddress);
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
            }finally
            {
                sqlConnection.Close(); 
            }
            return Id; 
        }
        public static bool UpdateAddress(int AddressID  , string Country, string State, string LocalAddress)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "update Addresses set " +
                "Country = @Country," +
                "State = @State," +
                "Localaddress = @LocalAddress " +
                "where AddressID = @AddressID";

            SqlCommand commanad = new SqlCommand(query, sqlConnection);
            commanad.Parameters.AddWithValue("@Country", Country);
            commanad.Parameters.AddWithValue("@State", State);
            commanad.Parameters.AddWithValue("@LocalAddress", LocalAddress);
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
        public static bool DeleteAddress(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM [dbo].[Addresses] WHERE AddressID = @Id";
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
        public static bool IsAddressExiste(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Found = 1 from Addresses where AddressID = @Id";
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

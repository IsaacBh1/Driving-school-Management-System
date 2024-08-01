using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsAddressDataAccess
    {
        private static string ConnectionString = "Server=. ; Database=DrivingSchoolDB ; User Id=sa ; Password=sa123456 ; Integrated security=true ; TrustServerCertificate=True;";

        public static DataTable GetAllAddresses()
        {
            DataTable Addresses = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Addresses;";
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

        public static bool GetAddressInfoByID(int addressID, ref string Country, ref string State, ref string Localaddress)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from Addresses where AddressID = @addressID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@addressID", addressID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    Country = (string)reader["Country"];
                    State = (string)reader["State"];
                    Localaddress = reader["Localaddress"] as string;
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

        public static int AddNewAddress(string Country, string State, string Localaddress)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into Addresses (Country, State, Localaddress) values (@Country, @State, @Localaddress);" +
                "select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Country", Country);
            command.Parameters.AddWithValue("@State", State);
            command.Parameters.AddWithValue("@Localaddress", string.IsNullOrEmpty(Localaddress) ? DBNull.Value : (object)Localaddress);
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

        public static bool UpdateAddress(int addressID, string Country, string State, string Localaddress)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[Addresses] SET " +
                "Country = @Country, " +
                "State = @State, " +
                "Localaddress = @Localaddress " +
                "WHERE AddressID = @addressID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@addressID", addressID);
            command.Parameters.AddWithValue("@Country", Country);
            command.Parameters.AddWithValue("@State", State);
            command.Parameters.AddWithValue("@Localaddress", string.IsNullOrEmpty(Localaddress) ? DBNull.Value : (object)Localaddress);
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

        public static bool DeleteAddress(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM Addresses WHERE AddressID = @Id";
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

        public static bool IsAddressExists(int Id)
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

        public static int GetAddressIDByInfo(string Country, string State, string Localaddress)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select AddressID from Addresses where " +
                "Country = @Country and " +
                "State = @State and " +
                "Localaddress = @Localaddress";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Country", Country);
            command.Parameters.AddWithValue("@State", State);
            command.Parameters.AddWithValue("@Localaddress", string.IsNullOrEmpty(Localaddress) ? DBNull.Value : (object)Localaddress);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["AddressID"];
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

        public static bool IsAddressExists(string Country, string State, string Localaddress)
        {
            return (GetAddressIDByInfo(Country, State, Localaddress) != -1);
        }
    }
}

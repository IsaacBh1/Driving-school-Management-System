using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsExpenceTypeDataAccess
    {
        private static string ConnectionString = clsConnectionStr.ConnectionStr;

        public static DataTable GetAllExpenceTypes()
        {
            DataTable ExpenceTypes = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM ExpenceTypes;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    ExpenceTypes.Load(reader);
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
            return ExpenceTypes;
        }

        public static bool GetExpenceTypeInfoByID(int expenceTypeID, ref string Name, ref string Description)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM ExpenceTypes WHERE ExpenceTypeID = @expenceTypeID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@expenceTypeID", expenceTypeID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    Name = (string)reader["Name"];
                    Description = reader["Description"] as string;
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

        public static int AddNewExpenceType(string Name, string Description)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"INSERT INTO ExpenceTypes (Name, Description) 
                             VALUES (@Name, @Description);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Description", (object)Description ?? DBNull.Value);

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

        public static bool UpdateExpenceType(int expenceTypeID, string Name, string Description)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"UPDATE ExpenceTypes SET 
                             Name = @Name, 
                             Description = @Description 
                             WHERE ExpenceTypeID = @expenceTypeID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@expenceTypeID", expenceTypeID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Description", (object)Description ?? DBNull.Value);

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

        public static bool DeleteExpenceType(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM ExpenceTypes WHERE ExpenceTypeID = @Id";
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

        public static bool IsExpenceTypeExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM ExpenceTypes WHERE ExpenceTypeID = @Id) THEN 1 ELSE 0 END";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", Id);
            try
            {
                connection.Open();
                result = (int)command.ExecuteScalar() == 1;
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

        public static int GetExpenceTypeIDByName(string Name)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT ExpenceTypeID FROM ExpenceTypes WHERE Name = @Name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Name", Name);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int expenceTypeID))
                {
                    ID = expenceTypeID;
                }
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

        public static string GetExpenceTypeNameByID(int ID)
        {
            string Name = string.Empty;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Name from ExpenceTypes where ExpenceTypeID  = @ID ;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                Name = (string)result;
            }
            catch
            {
                return "";
            }
            finally
            {
                connection.Close();
            }
            return Name;
        }







        public static bool IsExpenceTypeExists(string Name)
        {
            return (GetExpenceTypeIDByName(Name) != -1);
        }
    }
}
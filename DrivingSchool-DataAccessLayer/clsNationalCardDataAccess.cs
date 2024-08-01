using System;
using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsNationalCardDataAccess
    {
        private static string ConnectionString = "Server=. ; Database=DrivingSchoolDB ; User Id=sa ; Password=sa123456 ; Integrated security=true ; TrustServerCertificate=True;";

        public static DataTable GetAllNationalCards()
        {
            DataTable NationalCards = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from NationalCards;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    NationalCards.Load(reader);
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
            return NationalCards;
        }

        public static bool GetNationalCardInfoByID(int nationalCardID, ref string NationalCardType, ref string CardNumber, ref DateTime EndDate)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from NationalCards where NationalCardID = @nationalCardID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@nationalCardID", nationalCardID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    NationalCardType = reader["NationalCardType"] != DBNull.Value ? (string)reader["NationalCardType"] : null;
                    CardNumber = (string)reader["CardNumber"];
                    EndDate = (DateTime)reader["EndDate"];
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

        public static int AddNewNationalCard(string NationalCardType, string CardNumber, DateTime EndDate)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into NationalCards (NationalCardType, CardNumber, EndDate) values (@NationalCardType, @CardNumber, @EndDate);" +
                "select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@NationalCardType", NationalCardType);
            command.Parameters.AddWithValue("@CardNumber", CardNumber);
            command.Parameters.AddWithValue("@EndDate", EndDate);
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

        public static bool UpdateNationalCard(int nationalCardID, string NationalCardType, string CardNumber, DateTime EndDate)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[NationalCards] SET " +
                "NationalCardType = @NationalCardType, " +
                "CardNumber = @CardNumber, " +
                "EndDate = @EndDate " +
                "WHERE NationalCardID = @nationalCardID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@nationalCardID", nationalCardID);
            command.Parameters.AddWithValue("@NationalCardType", NationalCardType);
            command.Parameters.AddWithValue("@CardNumber", CardNumber);
            command.Parameters.AddWithValue("@EndDate", EndDate);
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

        public static bool DeleteNationalCard(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM NationalCards WHERE NationalCardID = @Id";
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

        public static bool IsNationalCardExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Found = 1 from NationalCards where NationalCardID = @Id";
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

        public static int GetNationalCardIDByInfo(string NationalCardType, string CardNumber, DateTime EndDate)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select NationalCardID from NationalCards where " +
                "NationalCardType = @NationalCardType and " +
                "CardNumber = @CardNumber and " +
                "EndDate = @EndDate";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalCardType", NationalCardType);
            command.Parameters.AddWithValue("@CardNumber", CardNumber);
            command.Parameters.AddWithValue("@EndDate", EndDate);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID = (int)reader["NationalCardID"];
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

        public static bool IsNationalCardExists(string NationalCardType, string CardNumber, DateTime EndDate)
        {
            return (GetNationalCardIDByInfo(NationalCardType, CardNumber, EndDate) != -1);
        }
    }
}

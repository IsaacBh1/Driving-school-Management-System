﻿using System.Data;
using System.Data.SqlClient;

namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsMoneyBankDataAccess
    {
        private static string ConnectionString = clsConnectionStr.ConnectionStr;

        public static DataTable GetAllMoneyBanks()
        {
            DataTable MoneyBanks = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM MoneyBanks order by MoneyBankID desc;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    MoneyBanks.Load(reader);
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
            return MoneyBanks;
        }

        public static bool GetMoneyBankInfoByID(int moneyBankID, ref decimal InitialAmount, ref decimal Expences, ref decimal InternalAmount, ref bool IsClosed)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM MoneyBanks WHERE MoneyBankID = @moneyBankID";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@moneyBankID", moneyBankID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    InitialAmount = (decimal)reader["InitialAmount"];
                    Expences = (decimal)reader["Expences"];
                    InternalAmount = (decimal)reader["InternalAmount"];
                    IsClosed = (bool)reader["IsClosed"];
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

        public static int AddNewMoneyBank(decimal InitialAmount, decimal Expences, decimal InternalAmount, bool IsClosed)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"INSERT INTO MoneyBanks (InitialAmount, Expences, InternalAmount, IsClosed) 
                             VALUES (@InitialAmount, @Expences, @InternalAmount, @IsClosed);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@InitialAmount", InitialAmount);
            command.Parameters.AddWithValue("@Expences", Expences);
            command.Parameters.AddWithValue("@InternalAmount", InternalAmount);
            command.Parameters.AddWithValue("@IsClosed", IsClosed);

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

        public static bool UpdateMoneyBank(int moneyBankID, decimal InitialAmount, decimal Expences, decimal InternalAmount, bool IsClosed)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"UPDATE MoneyBanks SET 
                             InitialAmount = @InitialAmount, 
                             Expences = @Expences, 
                             InternalAmount = @InternalAmount, 
                             IsClosed = @IsClosed 
                             WHERE MoneyBankID = @moneyBankID";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.Parameters.AddWithValue("@moneyBankID", moneyBankID);
            command.Parameters.AddWithValue("@InitialAmount", InitialAmount);
            command.Parameters.AddWithValue("@Expences", Expences);
            command.Parameters.AddWithValue("@InternalAmount", InternalAmount);
            command.Parameters.AddWithValue("@IsClosed", IsClosed);

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

        public static bool DeleteMoneyBank(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM MoneyBanks WHERE MoneyBankID = @Id";
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

        public static bool IsMoneyBankExists(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT CASE WHEN EXISTS (SELECT 1 FROM MoneyBanks WHERE MoneyBankID = @Id) THEN 1 ELSE 0 END";
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

        public static int GetMoneyBankIDByInfo(decimal InitialAmount, decimal AllAmount, decimal InternalAmount, decimal NetProfit, bool IsClosed)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"SELECT MoneyBankID FROM MoneyBanks 
                             WHERE InitialAmount = @InitialAmount 
                             AND AllAmount = @AllAmount 
                             AND InternalAmount = @InternalAmount 
                             AND NetProfit = @NetProfit 
                             AND IsClosed = @IsClosed";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InitialAmount", InitialAmount);
            command.Parameters.AddWithValue("@AllAmount", AllAmount);
            command.Parameters.AddWithValue("@InternalAmount", InternalAmount);
            command.Parameters.AddWithValue("@NetProfit", NetProfit);
            command.Parameters.AddWithValue("@IsClosed", IsClosed);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int moneyBankID))
                {
                    ID = moneyBankID;
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

        public static int GetCurrentMoneyBank()
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = @"select MoneyBankID from MoneyBanks where IsClosed = 0;";
            SqlCommand command = new SqlCommand(query, connection);
      
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int moneyBankID))
                {
                    ID = moneyBankID;
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


        public static bool CloseCurrentMonneyBank()
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = @"update MoneyBanks set IsClosed = 1 where IsClosed = 0 ;";

            SqlCommand command = new SqlCommand(query, sqlConnection);
          

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
    }
}
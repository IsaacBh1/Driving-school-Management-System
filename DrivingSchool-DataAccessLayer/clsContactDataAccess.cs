﻿using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;


namespace DrivingSchool_DataAccessLayer
{
    public sealed class clsContactDataAccess
    {
        private static string ConnectionString = clsConnectionStr.ConnectionStr;
        public static DataTable GetAllContacts()
        {
            DataTable Addresses = new DataTable();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select * from Contacts; ";
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
        public static bool GetContactInfoByID(int contactID, ref string Phone, ref string Email, ref string AdditionalContact)
        {

            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "select * from Contacts where ContactID = @contactID";
            SqlCommand commanad = new SqlCommand(query, sqlConnection);
            commanad.Parameters.AddWithValue("@contactID", contactID);
            bool IsFound = false;
            try
            {
                sqlConnection.Open();
                SqlDataReader reader = commanad.ExecuteReader();
                while (reader.Read())
                {
                    IsFound = true;
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    AdditionalContact = (string)reader["AdditionalContact"];
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
        public static int AddNewContact(string Phone, string Email, string AdditionalContact)
        {
            int Id = -1;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "insert into Contacts Values (@Email, @Phone, @AdditionalContact);" +
                "select SCOPE_IDENTITY();";

            SqlCommand commanad = new SqlCommand(query, sqlConnection);
            commanad.Parameters.AddWithValue("@Email", Email);
            commanad.Parameters.AddWithValue("@Phone", Phone);
            commanad.Parameters.AddWithValue("@AdditionalContact", AdditionalContact);
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
        public static bool UpdateContact(int contactID, string Phone, string Email, string AdditionalContact)
        {
            int AffectedRows = 0;
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            string query = "UPDATE [dbo].[Contacts] SET " +
                "Email =  @Email," +
                "Phone =  @Phone, " +
                "AdditionalContact = @AdditionalContact" +
                " Where ContactID = @contactID";

            SqlCommand commanad = new SqlCommand(query, sqlConnection);
            commanad.Parameters.AddWithValue("@contactID", contactID);
            commanad.Parameters.AddWithValue("@Email", Email);
            commanad.Parameters.AddWithValue("@Phone", Phone);
            commanad.Parameters.AddWithValue("@AdditionalContact", AdditionalContact);
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
            return (AffectedRows != 0);
        }
        public static bool DeleteContact(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "DELETE FROM Contacts WHERE ContactID = @Id";
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
        public static bool IsContactExiste(int Id)
        {
            bool result = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select Found = 1 from Contacts where ContactID = @Id";
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
        public static int GetCountactIDByInfo(string Phone, string Email, string AdditionalContact)
        {
            int ID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "select ContactID from Contacts where " +
                        "CONVERT(VARCHAR, Phone) = @Phone and " +
                        "CONVERT(VARCHAR, Email) = @Email ; "; 

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Phone", string.IsNullOrEmpty(Phone) ? DBNull.Value : (object)Phone);
            command.Parameters.AddWithValue("@Email",string.IsNullOrEmpty(Email) ? DBNull.Value : (object)Email);
           // command.Parameters.AddWithValue("@AdditionalContact", string.IsNullOrEmpty(AdditionalContact) ? DBNull.Value : (object)AdditionalContact);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                        {
                            ID = (int)reader["ContactID"];
                        }
                }
                reader.Close();
                return ID; 
            }
            catch
            {
                return -1;
            }
            finally
            {

                connection.Close();
            }
        }
        public static bool IsContactExiste(string Phone, string Email, string AdditionalContact)
        {
            return (GetCountactIDByInfo(Phone, Email, AdditionalContact) != -1);
        }

    }
}
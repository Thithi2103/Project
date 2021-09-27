using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAL
{
    
    public class DBHelper
    {
        //create connection
        protected static MySqlConnection connection;
        
        public static void CloseConnection()
        {
            if (connection != null) connection.Close();
        }

        public static void ExecuteSqlStatment(string statment)
        {
            MySqlCommand cmd = GetSqlCommand(statment);
            cmd.ExecuteNonQuery();
        }
        public static MySqlDataReader GetDataReaderExeQuery(string query)
        {
            MySqlCommand cmd = GetSqlCommand(query);
            return cmd.ExecuteReader();
        }
        public static MySqlCommand GetSqlCommand(string query)
        {
            if (connection == null) return null;
            return new MySqlCommand(query, connection);
        }
        public static MySqlCommand GetSqlCommand()
        {
            if (connection == null) return null;
            return connection.CreateCommand();
        }   //lấy command từ connection ( khác với tạo command bằng query thực thi trên connection nào đó)
        public static bool ExecuteTransaction(List<string> queries)
        {
            bool result = true;
            if (connection == null) return false;

            //create Cmd
            MySqlCommand cmd = GetSqlCommand();

            //start transaction
            MySqlTransaction trans = connection.BeginTransaction();

            cmd.Connection = connection;
            cmd.Transaction = trans;

            try
            {
                foreach(string query in queries)
                {
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                result = true;
            }
            catch
            {
                result = false;
                try
                {
                    trans.Rollback();
                }
                catch { }
            }
            finally { CloseConnection(); }

            return result;
        }       
    }
}
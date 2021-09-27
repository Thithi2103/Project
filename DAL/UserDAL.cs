using System;
using System.Collections.Generic;
using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class UserDAL
    {
       static public bool CheckUserAndPass(string user, string pass)
       {
            string query = $"select * from user where user_name = '{user}' and password = '{pass}';";
            bool result = false;

            using(MySqlConnection connection = DbConfiguration.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        result = true;
                    }
                }
            }
           return result;
       }
       static public User GetUserById(int ID)
       {
           string query = $"select * from user where user_id = {ID};";
            User result = null;
            using(MySqlConnection connection = DbConfiguration.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                        result = GetUser(reader);
                }
            }

            return result;
       }    
       static public User GetUserByUsername(string username)
       {
            string query = $"select * from user where user_name = '{username}';";
            User result = null;
            using(MySqlConnection connection = DbConfiguration.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                        result = GetUser(reader);
                }
            }

            return result;
       } 
       static protected User GetUser(MySqlDataReader reader)
       {
            User result = new User();

            result.User_ID = reader.GetInt32("user_id");
            result.Name = reader.GetString("name");
            result.PhoneNumber = reader.GetString("phoneNumber");
            result.UserName = reader.GetString("user_name");

            return result;
       }
       
    }
}
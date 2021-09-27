using System;
using System.Collections.Generic;
using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class ApplicationDAL
    {
        static public List<Application> GetApplicationByName(string nameApp = "")
        {
            List<Application> result = null;

            string query;
            if(nameApp == "")
            {
                query = "select * from application;";
            }
            else
                query = $"select * from application where name like '{nameApp}%';";
            using(MySqlConnection connection = DbConfiguration.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {           
                    result = new List<Application>();
                    while(reader.Read())
                    {
                        result.Add(GetApplication(reader));
                    }                 
                }
            }
            return result;
        }
        static public Application GetApplicationById(int appId)
        {
            string query = $"select * from application where app_id = {appId};";

            Application result = null;
            using(MySqlConnection connection = DbConfiguration.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        result = new Application();
                        result = GetApplication(reader);
                    }
                }
            }
            return result;
        }

        static public List<Application> GetApplicationBoughtByUserID(int UserID)
        {
            List<Application> listApp = new List<Application>();
            string query = $"select app_id from appbougth where user_id = {UserID};";
            using(MySqlConnection connection = DbConfiguration.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using(MySqlDataReader reader =  cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        int app_id = reader.GetInt32("app_id");
                        listApp.Add(GetApplicationById(app_id));
                    }
                }
            }
            return listApp;
        }

        static protected Application GetApplication(MySqlDataReader reader)
        {
            Application app = new Application();
            app.App_ID = reader.GetInt32("app_id");
            app.Name = reader.GetString("name");
            app.Kind = reader.GetString("kind");
            app.Price = reader.GetDouble("price");
            app.Description = reader.GetString("description");
            app.Publisher = reader.GetString("publisher");                        
            app.DatePublisher = reader.GetDateTime("datepublish");
            app.Size = reader.GetDouble("size");
            app.Rating = reader.GetString("ratings");
            return app;
        }
    }
}

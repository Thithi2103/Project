using System;
using System.Collections.Generic;
using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class BillDAL
    {
        static public List<Bill> GetListBillByUserId(int userID)
        {
            string query = $"select * from Bill where User_ID = {userID};";

            List<Bill> result = new List<Bill>();
            using(MySqlConnection connection = DbConfiguration.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Bill p = GetBill(reader);
                        result.Add(p);
                    }
                }
            }

            return result;
        }
        static public bool CreateBill(Bill bill)
        {
            bool result = false;
            if(bill.App == null)return false;
            if(bill.User == null)return false;

            using(MySqlConnection connection = DbConfiguration.OpenConnection())
            {
                if(connection == null)return result = false;

                MySqlCommand cmd = connection.CreateCommand();
                MySqlTransaction trans = connection.BeginTransaction();

                cmd.Connection = connection;
                cmd.Transaction = trans;

                try
                {
                    string query = $@"insert into bill(app_id, user_id, payment_id, Unitprice)
                                     values({bill.App.App_ID}, {bill.User.User_ID}, {bill.Payment.ID},{bill.UnitPrice});";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    result = true;
                }
                catch
                {
                    result = false;
                    try
                    {
                        trans.Rollback();
                    }catch{}
                }
            }

            return result;
        }
        static protected Bill GetBill(MySqlDataReader reader)
        {
            Bill result = new Bill();
            int AppID, UserID, PaymentID;
            result.Bill_ID = reader.GetInt16("bill_Id");
            AppID = reader.GetInt32("App_ID");
            Application app = ApplicationDAL.GetApplicationById(AppID);
            result.App = app;
            UserID = reader.GetInt32("User_ID");
            User user = UserDAL.GetUserById(UserID);
            result.User = user;
            PaymentID = reader.GetInt32("payment_id");
            result.Payment = PaymentDAL.GetPaymentById(PaymentID);
            result.UnitPrice = reader.GetDouble("UnitPrice");
            result.DateCreate = reader.GetDateTime("DataCreate");

            return result;
        }
    }
}
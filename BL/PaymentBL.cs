using Persistence;
using DAL;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace BL
{
    public class PaymentBL
    {
        public List<Payment> GetPayments(int userid)
        {
            return PaymentDAL.GetPaymentByUserId(userid);
        }
        public bool CheckPayment(Payment payment, double money)
        {
            return PaymentDAL.CheckPayment(payment, money);
        }
    }
}
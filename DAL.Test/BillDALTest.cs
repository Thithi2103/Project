using System;
using Xunit;
using MySql.Data.MySqlClient;
using Persistence;

namespace DAL.Test
{
    public class BillDALTest : BillDAL
    {
        [Fact]
        public void GetListBillByUserId_Test()
        {
            //Pass
            Assert.True(GetListBillByUserId(1).Count > 0);

            //Fail
            Assert.False(GetListBillByUserId(-1).Count > 0);
            Assert.False(GetListBillByUserId(100000).Count > 0);
        }
        [Fact]
        public void CreateBill_Test()
        {
            //Pass
            Bill bill = new Bill()
            {
                App = ApplicationDAL.GetApplicationById(3),
                User = UserDAL.GetUserById(2),
                Payment = PaymentDAL.GetPaymentById(2),
                UnitPrice = ApplicationDAL.GetApplicationById(3).Price
            };
            //Fail
            //mua không hợp lệ và trả lại ứng dụng
            bill = new Bill()
            {
                App = ApplicationDAL.GetApplicationById(1),
                User = UserDAL.GetUserById(1),
                UnitPrice = ApplicationDAL.GetApplicationById(1).Price * 0.5,
            };
            Assert.False(CreateBill(bill));
            
            //mua một ứng dụng chưa được đăng bán
            bill = new Bill()
            {
                App = ApplicationDAL.GetApplicationById(1000),
                User = UserDAL.GetUserById(1),
                UnitPrice = ApplicationDAL.GetApplicationById(1).Price * 0.5,
            };
            Assert.False(CreateBill(bill));

            //mua ứng dụng khi chưa đăng ký
            bill = new Bill()
            {
                App = ApplicationDAL.GetApplicationById(7),
                User = UserDAL.GetUserById(100),
                UnitPrice = ApplicationDAL.GetApplicationById(1).Price * 0.5,
            };
            Assert.False(CreateBill(bill));

        }
        [Theory]
        [InlineData("select * from Bill order by bill_id limit 1;")]
        [InlineData("select * from Bill order by bill_id desc limit 1;")]
        [InlineData("select * from Bill order by rand() limit 1;")]
        public void GetBill_Test(string query)
        {
            using(MySqlConnection connection = DbConfiguration.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                        Assert.NotNull(GetBill(reader));
                }
            }        
        }
    }
}
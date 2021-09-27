using Xunit;
using MySql.Data.MySqlClient;
using DAL;

namespace DAL.Test
{
    public class PaymentDALTest
    {
        [Fact]
        void GetPaymentByUserId_Test()
        {
            //Pass
            Assert.NotEmpty(PaymentDAL.GetPaymentByUserId(1));

            //Fail
            Assert.Empty(PaymentDAL.GetPaymentByUserId(1000000));
            Assert.Empty(PaymentDAL.GetPaymentByUserId(-5));
        } 
        [Fact]
        void GetPaymentById()
        {
            //pass
            Assert.NotNull(PaymentDAL.GetPaymentById(1));
            Assert.NotNull(PaymentDAL.GetPaymentById(3));

            //fail
            Assert.Null(PaymentDAL.GetPaymentById(-1));
            Assert.Null(PaymentDAL.GetPaymentById(3000));

        }
    }
}
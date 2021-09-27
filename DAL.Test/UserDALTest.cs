using System;
using Xunit;

namespace DAL.Test
{
    public class UserDALTest : UserDAL
    {
        [Theory]
        [InlineData("hoangthi", "123456")]
        public void CheckUserAndPass_Test_True(string user, string pass)
        {
            Assert.True(CheckUserAndPass(user, pass));
        }

        [Theory]
        [InlineData("hoangthi", "1234567")]
        [InlineData("hoangthi", "1234")]
        [InlineData("hoangthi1234", "12")]
        public void CheckUserAndPass_Test_False(string user, string pass)
        {
            Assert.False(CheckUserAndPass(user, pass));
        }

        [Fact]
        public void GetUserByUsername_Test()
        {
            //check True
            string username = "hoangthi";
            Assert.NotNull(GetUserByUsername(username));
            //check false
            username = "hoangthi123";
            Assert.Null(GetUserByUsername(username));
        }
        
    }
}
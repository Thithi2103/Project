using System;
using System.Collections.Generic;
using Persistence;
using Xunit;
using MySql.Data.MySqlClient;

namespace DAL.Test
{
    public class ApplicationDALTest : ApplicationDAL
    {
        // [Theory]
        // [InlineData("flapy")]
        // [InlineData("")]
        // // void GetApplicationByName_Test_True(string nameApp)
        // // {
        // //     List<Application> result = ApplicationDAL.GetApplicationByName(nameApp);
        // //     Assert.True(result.Count > 0);
        // // }

        // [Theory]
        // [InlineData("flapy")]
        // [InlineData("facebook")]
        // void GetApplicationByName_Test_True2(string nameApp)
        // {
        //     List<Application> result = ApplicationDAL.GetApplicationByName(nameApp);
        //     Assert.True(result.Count > 0);
        // }

        [Fact]
        void GetApplication_TestFDM()
        {
            List<Application> listApp = ApplicationDAL.GetApplicationByName();
            Assert.NotNull(listApp);

            string query = "select * from application order by app_id limit 1;";
            Assert.Equal(GetApplication_Test(query).GetHashCode(), listApp[0].GetHashCode());

            query = "select * from application order by app_id desc limit 1;";
            Assert.Equal(GetApplication_Test(query).GetHashCode(), listApp[listApp.Count - 1].GetHashCode());

            query = "select * from application order by rand() limit 1;";
            Assert.Contains(GetApplication_Test(query), listApp);
        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        void GetApplicationById_Test_True(int id)
        {
            Assert.NotNull(GetApplicationById(id));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1000000)]
        void GetApplicationById_Test_False(int id)
        {
            Assert.Null(GetApplicationById(id));
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(1000000)]
        void GetApplicationBoughtByUserID_Test_Fail(int id)
        {
            Assert.Empty(GetApplicationBoughtByUserID(id));
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1000000)]
        void GetApplicationBoughtByUserID_Test_Fail2(int id)
        {
            Assert.Empty(GetApplicationBoughtByUserID(id));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1000000)]
        void GetApplicationBoughtByUserID_Test_Fail3(int id)
        {
            Assert.Empty(GetApplicationBoughtByUserID(id));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(1000000)]
        void GetApplicationBoughtByUserID_Test_Fail4(int id)
        {
            Assert.Empty(GetApplicationBoughtByUserID(id));
        }


        Application GetApplication_Test(string query)
        {
            Application result = null;
            using(MySqlConnection connection = DbConfiguration.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {     
                    if (reader.Read())
                    {
                        result = GetApplication(reader);
                    }                     
                }
            }
            return result;
        }
    }
}
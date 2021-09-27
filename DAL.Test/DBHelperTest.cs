using System;
using System.Collections.Generic;
using Xunit;
using DAL;
using MySql.Data.MySqlClient;

namespace DAL.Test
{
    public class DBHelperTest : DbConfiguration
    {
        [Fact]
        void OpenDefaultConnection_Test()
        {
            Assert.NotNull(OpenDefaultConnection());
        }
        [Theory]
        [InlineData("server=localhost;userid=root;password=21032002;port=3306;database=marketapp;sslmode=none;")]
        [InlineData("server=localhost;userid=root;password=21032002;port=3306;database=marketapps;sslmode=non;")]
        [InlineData("server=localhost;userid=root;password=21032002;port=3307;database=marketapps;sslmode=none;")]
        [InlineData("server=localhost;userid=root;password=2135;port=3306;database=marketapps;sslmode=none;")]
        [InlineData("server=localhost;userid=roo;password=21032002;port=3306;database=marketapps;sslmode=none;")]
        void OpenConnection_Test(string link)
        {
            Assert.Null(OpenConnection(link));
        }
        [Fact]
        void OpenConnectionByText_Test()
        {
            Assert.NotNull(OpenConnection());
        }
    }
}
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Models;
using NUnit.Framework;

namespace FTeam.Orm.DataBase.Test.Extentions
{
    public class ExtentionsTest
    {
        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public void ConnectionInfoExtentionsTest()
        {
            DbConnectionInfo connectionInfo = new("LocalHost", "Test_DB", Authentication.SqlServerAuthentication, "Sa", "ASDWweadf@#@#$");

            string connectionString = connectionInfo.GetConnectionString();

            Assert.Pass(connectionString);

        }
    }
}

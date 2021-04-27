using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Models;
using NUnit.Framework;

namespace FTeam.Orm.DataBase.Test.Extentions
{
    public class ExtentionsTest
    {
        private readonly DbConnectionInfo connectionInfo = new(".", "MCoin2_db", Authentication.WindowsAuthentication);

        [SetUp]
        public void Setup()
        {

        }


        [Test]
        public void ConnectionInfoExtentionsTest()
        {
            //DbConnectionInfo connectionInfo = new(".", "MCoin2_db", Authentication.WindowsAuthentication);

            string connectionString = connectionInfo.GetConnectionString();

            Assert.Pass(connectionString);

        }

      
    }
}

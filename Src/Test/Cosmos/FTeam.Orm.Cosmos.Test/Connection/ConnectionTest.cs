using FTeam.Orm.Cosmos.ConnectionBase;
using NUnit.Framework;

namespace FTeam.Orm.Cosmos.Test.Connection
{
    public class ConnectionTest
    {
        private readonly IConnectionBase _connectionBase;

        public ConnectionTest()
        {
            _connectionBase = new ConnectionBase.ConnectionBase();
        }

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestConnection()
        {

            var connectionResult = _connectionBase.OpenConnectionAsync("Server=185.83.208.175;Database=Charity_DB2;User Id=motilogin;Password=Motahar@347;MultipleActiveResultSets=true").Result;

            switch (connectionResult)
            {
                case Results.Connection.OpenConnectionResult.Success:
                    Assert.Pass("Success");
                    break;
                case Results.Connection.OpenConnectionResult.Exception:
                    Assert.Fail("Exception");
                    break;
                case Results.Connection.OpenConnectionResult.InvalidOperationException:
                    Assert.Fail("InvalidOperationException");
                    break;
                case Results.Connection.OpenConnectionResult.SqlException:
                    Assert.Fail("SqlException");
                    break;
                default:
                    Assert.Fail("Default");
                    break;
            }
        }
    }
}

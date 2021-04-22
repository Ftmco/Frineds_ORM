using FTeam.Orm.Cosmos.ConnectionBase;
using FTeam.Orm.Results.Connection;
using NUnit.Framework;

namespace FTeam.Orm.Cosmos.Test.Connection
{
    public class ConnectionTest
    {
        private readonly string connectionString = "Server=185.83.208.175;Database=Charity_DB2;User Id = motilogin; Password=Motahar@347;MultipleActiveResultSets=true";

        private IConnectionBase _connectionBase;

        [SetUp]
        public void Setup()
        {
            _connectionBase = new ConnectionBase.ConnectionBase();
        }

        [Test]
        public void TestOpenConnection()
        {

            OpenConnectionResult connectionResult = _connectionBase.OpenConnectionAsync(connectionString).Result;

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

        [Test]
        public void TestCloseConnection()
        {
            CloseConnectionResult closeResult = _connectionBase.CloseConnectionAsync(connectionString).Result;

            switch (closeResult)
            {
                case CloseConnectionResult.Success:
                    Assert.Pass("Success");
                    break;
                case CloseConnectionResult.Exception:
                    Assert.Fail("Exception");
                    break;
                case CloseConnectionResult.SqlException:
                    Assert.Fail("SqlException");
                    break;
                default:
                    Assert.Fail("Default");
                    break;
            }
        }
    }
}

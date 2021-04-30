using FTeam.Orm.Cosmos.ConnectionBase;
using FTeam.Orm.Models;
using NUnit.Framework;

namespace FTeam.Orm.Cosmos.Test.Connection
{
    public class ConnectionTest
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=MCoin2_db;Integrated Security=True";

        private IConnectionBase _connectionBase;

        [SetUp]
        public void Setup()
        {
            _connectionBase = new ConnectionBase.ConnectionBase();
        }

        [Test]
        public void TestOpenConnection()
        {

            OpenConnectionResult connectionResult = _connectionBase.TryOpenConnectionAsync(connectionString).Result;

            switch (connectionResult.ConnectionStatus)
            {
                case OpenConnectionStatus.Success:
                    Assert.Pass("Success");
                    break;
                case OpenConnectionStatus.Exception:
                    Assert.Fail("Exception");
                    break;
                case OpenConnectionStatus.InvalidOperationException:
                    Assert.Fail("InvalidOperationException");
                    break;
                case OpenConnectionStatus.SqlException:
                    Assert.Fail("SqlException");
                    break;
                default:
                    Assert.Fail("Default");
                    break;
            }
            _ = _connectionBase.TryCloseConnectionAsync(connectionString).Result;
        }

        [Test]
        public void TestCloseConnection()
        {
            CloseConnectionResult closeResult = _connectionBase.TryCloseConnectionAsync(connectionString).Result;

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

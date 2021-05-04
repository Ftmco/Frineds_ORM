using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Domains.Connection.PgSql;
using FTeam.Orm.PgSql.Cosmos.ConnectionBase;
using NUnit.Framework;

namespace FTeam.Orm.PgSqlOrmTest.Connection
{
    public class ConnectionBase
    {
        IPgSqlConnectionBase _connection;

        PgSqlDbConnectionInfo _connectionInfo = new("localhost", "new_db", "postger", "1G14ijWA");

        [SetUp]
        public void Setup()
        {
            _connection = new PgSqlConnectionBase();
        }

        [Test]
        public void ConnectionTest()
        {
            var result = _connection.OpenConnection(_connectionInfo.GetConnectionString());

            switch (result.ConnectionStatus)
            {
                case Models.Connection.Shared.OpenConnectionStatus.Success:
                    Assert.Pass("Suucess");
                    break;
                case Models.Connection.Shared.OpenConnectionStatus.Exception:
                    Assert.Fail("Exception");
                    break;
                case Models.Connection.Shared.OpenConnectionStatus.InvalidOperationException:
                    Assert.Fail("InvalidOperationException");
                    break;
                case Models.Connection.Shared.OpenConnectionStatus.SqlException:
                    Assert.Fail("SqlException");
                    break;
                default:
                    Assert.Fail("Exception");
                    break;
            }
        }
    }
}

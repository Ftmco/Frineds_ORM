using FTeam.Orm.DataBase.Tables;
using FTeam.Orm.Models;
using NUnit.Framework;

namespace FTeam.Orm.DataBase.Test.Tables
{
    public class TestTableServices
    {
        private ITableGetRules _tableRules;

        DbConnectionInfo _dbConnectionInfo = new(".", "MCoin2_db", Authentication.WindowsAuthentication);


        [SetUp]
        public void Setup()
        {
            _tableRules = new TableGetServices();
        }

        [Test]
        public void TestTableInfo()
        {
            var result = _tableRules.GetTableInfo(_dbConnectionInfo, "Users");

            switch (result.Status)
            {
                case Results.QueryBase.QueryStatus.Success:
                    Assert.Pass(result.TableInfo.PrimaryKey.Column + "" + result.TableInfo.PrimaryKey.Type);
                    break;
                case Results.QueryBase.QueryStatus.Exception:
                    Assert.Fail("Exception");
                    break;
                case Results.QueryBase.QueryStatus.InvalidOperationException:
                    Assert.Fail("InvalidOperationException");
                    break;
                case Results.QueryBase.QueryStatus.SqlException:
                    Assert.Fail("SqlException");
                    break;
                case Results.QueryBase.QueryStatus.DbException:
                    Assert.Fail("DbException");
                    break;
                default:
                    Assert.Fail("Exception");
                    break;
            }
        }
    }
}

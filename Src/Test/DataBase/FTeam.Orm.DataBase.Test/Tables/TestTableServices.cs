using FTeam.Orm.DataBase.Tables;
using FTeam.Orm.DataBase.Tables.Services;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using NUnit.Framework;

namespace FTeam.Orm.DataBase.Test.Tables
{
    public class TestTableServices
    {
        private ITableInfoRules _tableRules;

        DbConnectionInfo _dbConnectionInfo = new(".", "MCoin2_db", Authentication.WindowsAuthentication);


        [SetUp]
        public void Setup()
        {
            _tableRules = new TableInfoServices();
        }

        [Test]
        public void TestTableInfo()
        {
            var result = _tableRules.TryGetTableInfo(_dbConnectionInfo, "Users");

            switch (result.Status)
            {
                case QueryStatus.Success:
                    Assert.Pass(result.TableInfo.PrimaryKey.Column + "" + result.TableInfo.PrimaryKey.Type);
                    break;
                case QueryStatus.Exception:
                    Assert.Fail("Exception");
                    break;
                case QueryStatus.InvalidOperationException:
                    Assert.Fail("InvalidOperationException");
                    break;
                case QueryStatus.SqlException:
                    Assert.Fail("SqlException");
                    break;
                case QueryStatus.DbException:
                    Assert.Fail("DbException");
                    break;
                default:
                    Assert.Fail("Exception");
                    break;
            }
        }
    }
}

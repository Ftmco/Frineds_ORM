using FTeam.Orm.Extentions;
using FTeam.Orm.Models;
using NUnit.Framework;

namespace FTeam.Orm.OrmTest.Extentions
{
    public class OrmExtentionTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestExtentions()
        {
            DbConnectionInfo _dbConnectionInfo = new(".", "test_rb", Authentication.SqlServerAuthentication, "sa", "1H15asdj@3");

            TableInfoResult tableInfo = _dbConnectionInfo.Table("Users");

            switch (tableInfo.Status)
            {
                case Results.QueryBase.QueryStatus.Success:
                    {
                        if (tableInfo.TableInfo != null)
                        {
                            Assert.Pass(tableInfo.TableInfo.ToString());
                        }
                        else
                        {
                            Assert.Fail("Null Refrence");
                        }
                        break;
                    }
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

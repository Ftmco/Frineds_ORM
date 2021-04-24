using FTeam.Orm.Extentions;
using FTeam.Orm.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DbConnectionInfo connectionInfo = new("LocalHost", "Test_DB", Authentication.SqlServerAuthentication, "Sa", "ASDWweadf@#@#$");

            TableInfoResult tableInfo = connectionInfo.Table("Users");

            switch (tableInfo.Status)
            {
                case Results.QueryBase.QueryStatus.Success:
                    {
                        TableInfo bestResult = new() { Catalog = "Test_DB", Schema = "dbo", TableName = "Users" };
                        if (tableInfo.TableInfo != null)
                        {
                            if (tableInfo.TableInfo == bestResult)
                            {
                                Assert.Pass(tableInfo.TableInfo.ToString());
                            }
                            else
                            {
                                Assert.Fail(tableInfo.TableInfo.ToString());
                            }
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

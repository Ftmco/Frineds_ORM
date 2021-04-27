using FTeam.Orm.Extentions;
using FTeam.Orm.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;

namespace FTeam.Orm.OrmTest.Extentions
{
    public class OrmExtentionTest
    {
        private readonly DbConnectionInfo _dbConnectionInfo = new(".", "MCoin2_db", Authentication.WindowsAuthentication);

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestExtentions()
        {


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

        [Test]
        public void GetOnjectTest()
        {
            IEnumerable<Users> users = _dbConnectionInfo.Table("Users").GetAll<Users>("Users.[PhoneNumber] = '09012421080'");
                      
            if (users != null)
            {
                Assert.Pass(users.FirstOrDefault().UserName);
            }
            else
            {
                Assert.Fail("Null Refrence");
            }
        }
    }
}

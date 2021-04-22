using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.Results.QueryBase;
using NUnit.Framework;

namespace FTeam.Orm.Cosmos.Test.Query
{
    public class QueryBaseTest
    {
        private readonly string connectionString = "";

        private IQueryBase _queryBase;

        [SetUp]
        public void Setup()
        {
            _queryBase = new QueryBase.QueryBase();
        }

        [Test]
        public void QueryTest()
        {
            VoidQueryStatus result = _queryBase.RunVoidQueryAsync(connectionString,"Select * from Users").Result;

            switch (result)
            {
                case VoidQueryStatus.Success:
                    Assert.Pass("Success");
                    break;
                case VoidQueryStatus.Exception:
                    Assert.Fail("Excetpion");
                    break;
                case VoidQueryStatus.InvalidOperationException:
                    Assert.Fail("InvalidOperationException");
                    break;
                case VoidQueryStatus.SqlException:
                    Assert.Fail("SqlException");
                    break;
                case VoidQueryStatus.DbException:
                    Assert.Fail("DbException");
                    break;
                default:
                    Assert.Fail("Excetpion");
                    break;
            }
        }
    }
}

using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.Results.QueryBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.Cosmos.Test.Query
{
    public class QueryBaseTest
    {
        private readonly string connectionString = "Server=185.83.208.175;Database=Mcoin2_db;User Id = motilogin; Password=Motahar@347;MultipleActiveResultSets=true";

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

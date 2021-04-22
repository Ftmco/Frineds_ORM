﻿using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.Results.QueryBase;
using NUnit.Framework;
using System.Diagnostics;

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
        public void VoidQueryTest()
        {
            QueryStatus result = _queryBase.RunVoidQueryAsync(connectionString, "Select * from Users").Result;

            switch (result)
            {
                case QueryStatus.Success:
                    Assert.Pass("Success");
                    break;
                case QueryStatus.Exception:
                    Assert.Fail("Excetpion");
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
                    Assert.Fail("Excetpion");
                    break;
            }
        }

        [Test]
        public void NoneVoidQueryTest()
        {
            RunQueryResult result = _queryBase.RunQueryAsync(connectionString, "SELECT * FROM USERS").Result;

            switch (result.QueryStatus)
            {
                case QueryStatus.Success:
                    Assert.Pass($"Success {result.DataTable.Rows.Count}");
                    break;
                case QueryStatus.Exception:
                    Assert.Fail("Excetpion");
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
                    Assert.Fail("Excetpion");
                    break;
            }
        }
    }
}

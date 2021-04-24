﻿using FTeam.Orm.Cosmos.ConnectionBase;
using FTeam.Orm.Models;
using NUnit.Framework;

namespace FTeam.Orm.Cosmos.Test.Connection
{
    public class ConnectionTest
    {
        private readonly string connectionString = "";

        private IConnectionBase _connectionBase;

        [SetUp]
        public void Setup()
        {
            _connectionBase = new ConnectionBase.ConnectionBase();
        }

        [Test]
        public void TestOpenConnection()
        {

            OpenConnectionResult connectionResult = _connectionBase.OpenConnectionAsync(connectionString).Result;

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
        }

        [Test]
        public void TestCloseConnection()
        {
            CloseConnectionResult closeResult = _connectionBase.CloseConnectionAsync(connectionString).Result;

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

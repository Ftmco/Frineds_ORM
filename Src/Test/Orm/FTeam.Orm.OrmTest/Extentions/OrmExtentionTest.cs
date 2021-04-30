﻿using FTeam.Orm.Extentions;
using FTeam.Orm.Models;
using FTeam.Orm.Models.QueryBase;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
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
            TableInfoResult tableInfo = _dbConnectionInfo.TryTable("Users");

            switch (tableInfo.Status)
            {
                case QueryStatus.Success:
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

        [Test]
        public void GetObjectTest()
        {
            IEnumerable<Users> users = _dbConnectionInfo.TryTable("Users").TryGetAll<Users>("Users.[PhoneNumber] = '09012523240'");

            if (users != null)
            {
                Assert.Pass(users.FirstOrDefault().UserName);
            }
            else
            {
                Assert.Fail("Null Refrence");
            }
        }

        [Test]
        public void GetSingleObjectTest()
        {
            Users users = _dbConnectionInfo.TryTable("Users").TryGet<Users>("Users.[PhoneNumber] = '09012421080'");

            if (users != null)
            {
                Assert.Pass($"User Name = {users.UserName};Phone Number = {users.PhoneNumber};User Id = {users.UserId};Password = {users.Password}");
            }
            else
            {
                Assert.Fail("Null Refrence");
            }
        }

        [Test]
        public void InsertRow()
        {
            QueryStatus insertStatus = _dbConnectionInfo.TryTable("Users").TryInsertAsync<Users>(new()
            {
                ActiveCode = "234562",
                ActiveDate = DateTime.Now,
                Age = "0",
                Bio = "Null",
                CitizenCode = "12345",
                Email = "Gmail",
                FirstName = "Test",
                LastName = "Test",
                ImageName = "Null.jpg",
                IsActive = true,
                Password = "Password",
                PhoneNumber = "09012523240",
                RequestDescription = "Request Description",
                UserId = Guid.NewGuid(),
                UserName = "USer Name",
                UserType = 1

            }).Result;

            switch (insertStatus)
            {
                case QueryStatus.Success:
                    Assert.Pass("Success");
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

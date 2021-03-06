﻿using FTeam.Orm.Cosmos.QueryBase;
using FTeam.Orm.DataBase.Extentions;
using FTeam.Orm.Extentions;
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
        public void TestQuery()
        {
            IQueryBase _query = new QueryBase();

            RunQueryResult result = _query.RunQueryAsync(_dbConnectionInfo.GetConnectionString(), "SELECT * FROM USERS").Result;

            switch (result.QueryStatus)
            {
                case QueryStatus.Success:
                    Assert.Pass("Suucess");
                    break;
                case QueryStatus.Exception:
                    break;
                case QueryStatus.InvalidOperationException:
                    break;
                case QueryStatus.SqlException:
                    break;
                case QueryStatus.DbException:
                    break;
                default:
                    break;
            }
        }

        [Test]
        public void TestExtentions()
        {
            TableInfoResult tableInfo = _dbConnectionInfo.TryTable("Users", typeof(Users));

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
            IEnumerable<Users> users = _dbConnectionInfo.TryTableAsync("Users", typeof(Users)).Result.TryGetAllAsync<Users>().Result;

            if (users != null)
            {
                Assert.Pass(users.Count().ToString());
            }
            else
            {
                Assert.Fail("Null Refrence");
            }
        }

        [Test]
        public void GetSingleObjectTest()
        {
            IEnumerable<Entity> users = _dbConnectionInfo.TryTable("Entity", typeof(Entity)).TryGetAll<Entity>();

            if (users != null)
            {
                Assert.Pass($"{users.First().Name}");
            }
            else
            {
                Assert.Fail("Null Refrence");
            }
        }

        [Test]
        public void InsertRow()
        {
            QueryStatus insertStatus = _dbConnectionInfo.TryTable("Entity", typeof(Entity)).TryInsertAsync<Entity>(new Entity()
            {
                Age = 10,
                Family = "nullasd",
                Id = Guid.NewGuid(),
                Name = "asdasdasd"

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

        [Test]
        public void DeleteTest()
        {
            QueryStatus result = _dbConnectionInfo.TryTable("Users", typeof(Users)).TryDelete<Users>(new Users()
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
                UserId = Guid.Parse("C8D97D75-9C0F-4EB8-F906-08D8DEF73C82"),
                UserName = "USer Name",
                UserType = 1
            });

            switch (result)
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

        [Test]
        public void UpdateTest()
        {
            QueryStatus result = _dbConnectionInfo.TryTable("Users", typeof(Users)).TryUpdate<Users>(new Users()
            {
                ActiveCode = "234562",
                ActiveDate = DateTime.Now,
                Age = "0",
                Bio = "Null",
                CitizenCode = "12345",
                Email = "Gmail",
                FirstName = "Update TEst",
                LastName = "Test",
                ImageName = "Null.jpg",
                IsActive = true,
                Password = "Password",
                PhoneNumber = "09012523240",
                RequestDescription = "Request Description",
                UserId = Guid.Parse("EA4C415D-9C0D-457F-5618-08D8E09AE3A8"),
                UserName = "USer Name",
                UserType = 1
            });

            switch (result)
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

public record Entity
{
    public Entity()
    {

    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Family { get; set; }

    public int Age { get; set; }
}
using FTeam.Orm.DataBase.Commands;
using FTeam.Orm.Domains.Connection.PgSql;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.PgSqlOrmTest.DataBase
{
    public class DataBaseTest
    {
        private readonly PgSqlDbConnectionInfo _connectionInfo = new("localhost", "new_db", "postger", "1G14ijWA");

       
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void TestGenerateQueryInsert()
        {
          
        }
    }

    public record Table
    {
        public Table()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}

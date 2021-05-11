using FTeam.Orm.DataBase.StoreProcedures;
using FTeam.Orm.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.OrmTest.StoreProcedure
{
    public class StoreProcedureTest
    {
        private IStoreProcedureInfoRules _spInfo;

        private static DbConnectionInfo _dbInfo = new(".", "master",Authentication.WindowsAuthentication);

        [SetUp]
        public void Setup()
        {
            _spInfo = new StoreProcedureInfoServices();
        }

        [Test]
        public void GetSpInfo()
        {
            var spInfo = _spInfo.GetProcedureInfoAsync("test", _dbInfo).Result;

            Assert.Pass(spInfo.Name);
        }
    }
}

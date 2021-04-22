using FTeam.Orm.Results.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.DataBase.Models
{
    public record TableInfo
    {
        string _tableName;

        public TableInfo(string tableName)
        {
            _tableName = tableName;
        }

        public string TableName { get => _tableName; init => _tableName = value; }

        public OpenConnectionResult Status { get; set; }
    }
}

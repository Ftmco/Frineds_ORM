using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.Results.QueryBase
{
    public enum VoidQueryStatus
    {
        Success,
        Exception,
        InvalidOperationException,
        SqlException,
        DbException
    }
}

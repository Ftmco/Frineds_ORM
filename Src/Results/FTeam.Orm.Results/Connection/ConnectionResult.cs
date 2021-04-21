using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTeam.Orm.Results.Connection
{
    public enum OpenConnectionResult
    {
        Success,
        Exception,
        InvalidOperationException,
        SqlException
    }

    public enum CloseConnectionResult
    {
        Success,
        Exception,
        SqlException
    }
}

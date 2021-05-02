using System;
using System.Globalization;

namespace FTeam.Orm.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class FKey : Attribute
    {

    }
}

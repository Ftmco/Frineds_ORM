using System;

namespace FTeam.Orm.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class FKey : Attribute
    {

    }
}

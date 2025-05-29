using System;
using System.Collections.Generic;
using System.Text;

namespace ISL.Firefly.DataTypes.Common.Attributes
{
    /// <summary>
    /// Indicates the entity property is unique within the solution
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class UniqueAttribute : Attribute
    {
    }
}

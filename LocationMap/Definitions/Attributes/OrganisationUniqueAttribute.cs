using System;
using System.Collections.Generic;
using System.Text;

namespace LocationMap.Definitions.Attributes
{
    /// <summary>
    /// Indicates entity property is unique within the organisation
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class OrganisationUniqueAttribute : Attribute
    {
    }
}

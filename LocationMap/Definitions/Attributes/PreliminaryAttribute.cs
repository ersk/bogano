using System;

namespace LocationMap.Definitions.Attributes
{
    /// <summary>
    /// Indicated the class, method, property, etc. is under development and it's signature is liable to be changed in breaking ways without warning.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class PreliminaryAttribute : Attribute
    {
    }
}
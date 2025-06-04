using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LocationMap.Definitions.Attributes
{
    internal static class FailureKey
    {
     
                    /// <summary>
                    /// Used to make the failure reason key unique so it does not conflict if a failure happens against the same property.
                    /// The key is made using the following format "({ancestorPropertyNames}).{propInfo.Name}.{attributeName}". 
                    /// </summary>
                    /// <param name="attributeName">e.g. MinLength, MaxLength, Required.</param>
                    /// <param name="propInfo"></param>
                    /// <param name="ancestorPropertyNames">Optional. Should be provided further up if the object being validated has recursed down to validate references properties. e.g. "ServicePoint.Label"</param>
                    /// <returns></returns>
        public static string Create(string attributeName, PropertyInfo propInfo, string ancestorPropertyNames)
        {
            string key = propInfo.Name + "." + attributeName;

            if (string.IsNullOrWhiteSpace(ancestorPropertyNames) == false)
            {
                key = ancestorPropertyNames + "." + key;
            }
            return key;
        }
    }
}

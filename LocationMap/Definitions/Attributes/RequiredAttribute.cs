using ISL.Firefly.DataTypes.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ISL.Firefly.DataTypes.Common.Attributes
{
    /// <summary>
    /// Attribute indicates the property is required for an instance of this class to be valid
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RequiredAttribute : Attribute
    {
        const string AttributeName = "Required";

        /// <summary>
        /// Check code from https://pisquare.osisoft.com/thread/2164
        /// Checks all properties in the instance that have the RequiredAttribute for nulls
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="validationFailureReasons"></param>
        [Obsolete("Replaced by calling IsPropertyValid at a higher level")]
        public static void Check(object instance, ref IDictionary<string, string> validationFailureReasons)
        {
            if (validationFailureReasons == null)
            {
                validationFailureReasons = new Dictionary<string, string>();
            }

            var type = instance.GetType();

            foreach (PropertyInfo prop in type.GetProperties())
            {
                CheckProperty(prop, instance, ref validationFailureReasons);
            }
        }

        [Obsolete("Replaced by call to IsPropertyValid")]
        public static void CheckProperty(PropertyInfo prop, object instance, ref IDictionary<string, string> validationFailureReasons)
        {
            if (prop.GetCustomAttributes(typeof(RequiredAttribute), true).Any())
            {
                // Validate value
                object value = prop.GetValue(instance, null);
                if (value == null)
                {
                    string entityUniqueGuid = string.Empty;
                    if (instance is BaseType baseInstance)
                    {
                        entityUniqueGuid = baseInstance.UniqueGuid != null ? baseInstance.UniqueGuid.ToString() : "Unknown";
                    }
                    validationFailureReasons.Add(BaseType.FailureKey(AttributeName, prop, null), $"Value of property {prop.Name} on class {instance.GetType().FullName} with instance hashcode : {instance.GetHashCode()} and uniqueGuid: {entityUniqueGuid} is not set (null)");
                }
                else if (value is ReferenceBaseType refBaseInstance)
                {
                    if (refBaseInstance.UniqueGuid == Guid.Empty)
                    {
                        validationFailureReasons.Add(BaseType.FailureKey(AttributeName, prop, null), $"UniqueGuid of property {prop.Name} on class {instance.GetType().FullName} with instance hashcode : {instance.GetHashCode()} is not set (Empty Guid)");
                    }
                }
                else if (value is ReferenceReplaceableType || value is ReferenceModifiableType)
                {
                    BaseType refBaseTypeInstance = (BaseType)value;
                    if (refBaseTypeInstance.UniqueGuid == Guid.Empty)
                    {
                        validationFailureReasons.Add(BaseType.FailureKey(AttributeName, prop, null), $"UniqueGuid of property {prop.Name} on class {instance.GetType().FullName} with instance hashcode : {instance.GetHashCode()} is not set (Empty Guid)");
                    }
                }
            }
        }


        /// <summary>
        /// Check if the property has the [Required] attribute, and if so is the value of the property valid.
        /// </summary>
        /// <param name="prop"></param>
        /// <param name="instance"></param>
        /// <param name="validationFailureReasons"></param>
        /// <param name="ancestorPropertyNames">Optional. Adds extra detail to the key in the dictionary upon validation failure. Each property going down the tree should be separated with a period. e.g. "ServicePoint.Label"</param>
        /// <returns></returns>
        public static bool IsPropertyValid(PropertyInfo prop, object instance, ref IDictionary<string, string> validationFailureReasons, string ancestorPropertyNames = null)
        {
            object requiredAttrObj = prop.GetCustomAttributes(typeof(RequiredAttribute), true).FirstOrDefault();

            // Start by checking if the property has the attribute we are interested in [Required]
            if (requiredAttrObj == null)
            {
                // This property does not have the required attribute, so say it's valid.
                return true;
            }
            
            object value = prop.GetValue(instance, null);
            if (value == null)
            {
                string entityUniqueGuid = string.Empty;
                if (instance is BaseType baseInstance)
                {
                    entityUniqueGuid = baseInstance.UniqueGuid != null ? baseInstance.UniqueGuid.ToString() : "Unknown";
                }
                validationFailureReasons.Add(
                    BaseType.FailureKey(AttributeName, prop, ancestorPropertyNames),
                    $"Value of property {prop.Name} on class {instance.GetType().FullName}"
                    + $"with instance hashcode '{instance.GetHashCode()}'"
                    + $" and uniqueGuid '{entityUniqueGuid}' is not set (null)");

                return false;
            }

            if (value is ReferenceBaseType refBaseInstance)
            {
                if (refBaseInstance.UniqueGuid == Guid.Empty)
                {
                    validationFailureReasons.Add(BaseType.FailureKey(AttributeName, prop, ancestorPropertyNames), 
                        $"UniqueGuid of property {prop.Name} on class {instance.GetType().FullName} with instance hashcode : {instance.GetHashCode()} is not set (Empty Guid)");
                    return false;
                }
            }
            else if (value is ReferenceReplaceableType || value is ReferenceModifiableType)
            {
                BaseType refBaseTypeInstance = (BaseType)value;
                if (refBaseTypeInstance.UniqueGuid == Guid.Empty)
                {
                    validationFailureReasons.Add(BaseType.FailureKey(AttributeName, prop, ancestorPropertyNames), 
                        $"UniqueGuid of property {prop.Name} on class {instance.GetType().FullName} with instance hashcode : {instance.GetHashCode()} is not set (Empty Guid)");
                    return false;
                }
            }

            return true;
        }

    }
}

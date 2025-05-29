using ISL.Firefly.DataTypes.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ISL.Firefly.DataTypes.Common.Attributes
{
    /// <summary>
    /// Attribute can be added to datatypes specified in the SupportedTypesEnum.
    /// Is checked when IsValid is called and will return false if the value is not equal to or greater than the length set by the attribute.
    /// Note: This attribute does not check to see if the item is not null. Use the [Required] attribute.
    /// 
    /// Supports: Number types, any other type will return True in IsValid
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MinValueAttribute : Attribute
    {
        const string AttributeName = "MinValue";

        /// <summary>
        /// The minimum value that the property can be set to, which is considered valid.
        /// valid = propertyValue >= MinimumValue
        /// </summary>
        public double MinimumValue { get; private set; }

        public MinValueAttribute(double minimumValue)
        {
            MinimumValue = minimumValue;
        }

        /// <summary>
        /// Check if the attribute is present for the given property.
        /// If the attribute is NOT present, true is returned.
        /// If the attribute IS present, then the value of the property instance is validated 
        /// against the minimum value specified in the attribute constructor.
        /// Where the value of the explicitly cast property value is >= MinimumValue return true.
        /// If validation fails, the key used in the dictionary will be in the format of {ancestory}.{prop_name}.Minvalue;
        /// where '{ancestory}' is optional and may contain a list of properties separated by periods (.) 
        /// going down the chain from the parent object property being validated down the chain to the current object property.
        /// </summary>
        /// <param name="prop">The property to be validated.</param>
        /// <param name="instance">The instance of the object which contains the property to be validated.</param>
        /// <param name="validationFailureReasons">The dictionary of validation failure reasons which will be added to in the case of any discovered failures.</param>
        /// <param name="ancestorPropertyNames">Optional. Adds extra detail to the key in the dictionary upon validation failure. Each property going down the tree should be separated with a period. e.g. "ServicePoint.Label"</param>
        /// <returns>False if length is less than min length, else false.</returns>
        public static bool IsPropertyValid(
            PropertyInfo prop, object instance,ref IDictionary<string, string> validationFailureReasons, string ancestorPropertyNames = null)
        {
            object attrObj = prop.GetCustomAttributes(typeof(MinValueAttribute), true).FirstOrDefault();

            if (attrObj == null)
            {
                return true;
            }

            // Validate value
            object value = prop.GetValue(instance, null);
            if (value == null)
            {
                // Null can't be validated agsinst MinLength
                return true;
            }

            return IsAttributeValid(
                prop, 
                instance,
                prop.GetValue(instance, null), 
                (MinValueAttribute)attrObj,
                ref validationFailureReasons, 
                ancestorPropertyNames);
        }

        private static bool IsAttributeValid(
            PropertyInfo prop,
            object instance,
            object attrInstanceValue,
            MinValueAttribute minValueAttr,
            ref IDictionary<string, string> validationFailureReasons,
            string ancestorPropertyNames)
        {
            bool valid;
            string type = attrInstanceValue.GetType().Name;

            switch(type)
            {
                case "nint":
                case "nuint":
                case "byte":
                case "Byte":
                case "SByte":
                case "short":
                case "ushort":
                case "int":
                case "uint":
                case "long":
                case "Single":
                case "Int16":
                case "UInt16":
                case "Int32":
                case "UInt32":
                case "Int64":
                case "UInt64":
                case "float":
                case "double":
                case "NFloat":
                case "Double":
                case "Decimal":
                    // Check if the value is a struct that implements the IConvertible interface i.e.  System.Byte
                    if(attrInstanceValue is IConvertible iConvertibleValue)
                    {
                        valid = (iConvertibleValue.ToDouble(null) >= minValueAttr.MinimumValue);
                    }
                    else
                    {
                        // Castible instead?
                        valid = ((double)attrInstanceValue >= minValueAttr.MinimumValue);
                    }
                    break;
                default:
                    // If we can't validate (for MinLength) the type then just return true (valid)
                    valid = true;
                    break;
            }

            if (!valid)
            {
                string msg = $"Property {prop.Name} on class {instance.GetType().FullName}"
            + $" with instance hashcode '{instance.GetHashCode()}'"
            + $" has a value of {attrInstanceValue}."
            + $" Expected greater than or equal to {minValueAttr.MinimumValue}.";

                validationFailureReasons.Add(BaseType.FailureKey(AttributeName, prop, ancestorPropertyNames), msg);
            }

            return valid;
        }

    }

}

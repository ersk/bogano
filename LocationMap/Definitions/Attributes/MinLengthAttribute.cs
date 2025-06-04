using ISL.Firefly.DataTypes.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace LocationMap.Definitions.Attributes
{
    /// <summary>
    /// Attribute can be added to datatypes specified in the SupportedTypesEnum.
    /// Is checked when IsValid is called and will return false if the length of the value is not equal to or greater than the length set by the attribute.
    /// Note: This attribute does not check to see if the item is not null. Use the [Required] attribute.
    /// 
    /// Supports: String and IEnumerable type objects, any other type will return True in IsValid
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MinLengthAttribute : Attribute
    {
        const string AttributeName = "MinLength";

        /// <summary>
        /// Configuration of how the validation is to be carried out.
        /// </summary>
        public enum ValidationOption
        {
            /// <summary>
            /// No options, use the full string or all elements in count.
            /// </summary>
            None = 0,

            /// <summary>
            /// When comparing count of value against the min length, set this option if the empty element should not be counted towards the min length.
            /// For strings this is whitespace, for others this is a null.
            /// </summary>
            IgnoreEmptyElements = 1,

            /// <summary>
            /// Do not include whitespace at beginning and end of string in length
            /// </summary>
            IgnoreEmptyElementsAtStartAndEnd = 2,
        }

        /// <summary>
        /// The minimum items to be in the IEnumerable for the value to be considered valid.
        /// The value is inclusive. If Length is 2, then any IEnumerable of length 2 or greater will be considered valid.
        /// </summary>
        public uint Length { get; private set; }
        public ValidationOption Options { get; private set; }

        public MinLengthAttribute(uint length, ValidationOption options = ValidationOption.None)
        {
            if (length == 0)
            {
                throw new ArgumentException("Argument 'length' cannot be 0.", nameof(length));
            }

            Length = length;
            Options = options;
        }

        /// <summary>
        /// Check if the min length attribute is present for the given property.
        /// If the attribute is NOT present, true is returned.
        /// If the attribute IS present, then the value of the property instance is validated 
        /// against the minimum length specified in the attribute constructor.
        /// If the value's length is less than the minimum length specified, then the a faulure message is added to the dictionary 
        /// and the function will return false.
        /// If the value's length is vald, the function will return true.
        /// If validation fails, the key used in the dictionary will be in the format of {ancestory}.{prop_name}.MinLength;
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
            object minLengthAttrObj = prop.GetCustomAttributes(typeof(MinLengthAttribute), true).FirstOrDefault();

            if (minLengthAttrObj == null)
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
                (MinLengthAttribute)minLengthAttrObj,
                ref validationFailureReasons, 
                ancestorPropertyNames);
        }

        private static bool IsAttributeValid(
            PropertyInfo prop,
            object instance,
            object attrInstanceValue,
            MinLengthAttribute minLengthAttr,
            ref IDictionary<string, string> validationFailureReasons,
            string ancestorPropertyNames)
        {
            if (attrInstanceValue is string attrInstanceValueStr)
            {
                return IsStringValid(prop, instance, attrInstanceValueStr, minLengthAttr, ref validationFailureReasons, ancestorPropertyNames);
            }
            else if (typeof(IEnumerable).IsAssignableFrom(attrInstanceValue.GetType()))
            {
                return IsIEnumerableValid(prop, instance, (IEnumerable)attrInstanceValue, minLengthAttr, ref validationFailureReasons, ancestorPropertyNames);
            }

            // If we can't validate (for MinLength) the type then just return true (valid)
            return true;
        }


        private static bool IsStringValid(
            PropertyInfo prop,
            object instance,
            string attrInstanceValue,
            MinLengthAttribute minLengthAttr,
            ref IDictionary<string, string> validationFailureReasons,
            string ancestorPropertyNames)
        {      
            if (minLengthAttr.Options.HasFlag(ValidationOption.IgnoreEmptyElements))
            {
                attrInstanceValue = String.Concat(attrInstanceValue.Where(c => !Char.IsWhiteSpace(c)));
            }
            else if (minLengthAttr.Options.HasFlag(ValidationOption.IgnoreEmptyElementsAtStartAndEnd))
            {
                attrInstanceValue = attrInstanceValue.Trim();
            }

            if (attrInstanceValue.Length < minLengthAttr.Length)
            {
                string msg = $"Property {prop.Name} on class {instance.GetType().FullName}"
                        + $" with instance hashcode '{instance.GetHashCode()}'"
                        + $" has a length of {attrInstanceValue.Length}."
                        + $" Expected no less than {minLengthAttr.Length}.";

                if (minLengthAttr.Options.HasFlag(ValidationOption.IgnoreEmptyElements))
                {
                    msg += " No whitspace characters are counted towards the minimum length.";
                }
                else if (minLengthAttr.Options.HasFlag(ValidationOption.IgnoreEmptyElementsAtStartAndEnd))
                {
                    msg += " No leading or trailing whitespace characters are counted towards the minimum length.";
                }

                validationFailureReasons.Add(FailureKey.Create(AttributeName, prop, ancestorPropertyNames), msg);
                return false;
            }

            

            return true;
        }

        private static bool IsIEnumerableValid(
          PropertyInfo prop,
          object instance,
          IEnumerable attrInstanceValue,
          MinLengthAttribute minLengthAttr,
          ref IDictionary<string, string> validationFailureReasons,
          string ancestorPropertyNames)
        {
            List<object> list = attrInstanceValue.Cast<object>().ToList();

            if (minLengthAttr.Options.HasFlag(ValidationOption.IgnoreEmptyElements))
            {
                list = list.Where(obj => obj != null).ToList();
            }
            else if (minLengthAttr.Options.HasFlag(ValidationOption.IgnoreEmptyElementsAtStartAndEnd))
            {
                list = RemoveLeadingAndTrailingNulls(list);
            }

            int count = list.Count;

            if (count < minLengthAttr.Length)
            {
                validationFailureReasons.Add(
                    FailureKey.Create(AttributeName, prop, ancestorPropertyNames),
                    $"Property {prop.Name} on class {instance.GetType().FullName}"
                        + $" with instance hashcode '{instance.GetHashCode()}'"
                        + $" has a length of {count}."
                        + $" Expected no less than {minLengthAttr.Length}.");
                return false;
            }
            return true;
        }
        private static List<object> RemoveLeadingAndTrailingNulls(List<object> list)
        {
            // Strip out leading null elements
            bool matchingNulls = true; ;
            List<object> tempList = new List<object>();
            for (int i = 0; i < list.Count; i++)
            {
                if (matchingNulls)
                {
                    if (list[i] == null)
                    {
                        // value is equal so don't add it to the temp list
                        continue;
                    }
                    else
                    {
                        matchingNulls = false;
                    }
                }
                tempList.Add(list[i]);
            }

            // Strip out trailing null elements (iterate backards)
            matchingNulls = true;
            List<object> tempList2 = new List<object>();
            for (int i = tempList.Count - 1; i >= 0; i--)
            {
                if (matchingNulls)
                {
                    if (tempList[i] == null)
                    {
                        // value is equal so don't add it to the temp list
                        continue;
                    }
                    else
                    {
                        matchingNulls = false;
                    }
                }
                tempList2.Add(list[i]);
            }

            return tempList2;
        }


    }

}

using LocationMap.Definitions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ISL.Firefly.DataTypes.Abstract
{

    public abstract class Validatable
    {

        public class InvalidException : Exception
        {
            public static new string Message => "The object was invalid. See 'validationFailureReasons' property for reasons.";
            public IDictionary<string, string> validationFailureReasons { get; }
            public InvalidException(IDictionary<string, string> validationFailureReasons)
                :base(Message)
            {
                this.validationFailureReasons = validationFailureReasons;
            }
            public override string ToString()
            {
                StringBuilder sb = new(Message);
                foreach(var validationFailureReason in validationFailureReasons)
                {
                    sb.Append($"\r\n{validationFailureReason.Key} => {validationFailureReason.Value}");
                }
                return sb.ToString();
            }
        }
        public enum IsValidOptions
        {
            None,
            ThrowException
        }
        public virtual bool IsValid(
            ref IDictionary<string, string> validationFailureReasons, IsValidOptions options = IsValidOptions.None, string? ancestorPropertyNames = null)
        {
            // return true by default
            bool isValid = true;

            foreach (PropertyInfo prop in GetType().GetProperties())
            {
                bool isPropertyValid = IsPropertyValid(prop, ref validationFailureReasons, ancestorPropertyNames);

                if (isPropertyValid == false) isValid = false;
            }

            if (options.HasFlag(IsValidOptions.ThrowException) && !isValid)
            {
                throw new InvalidException(validationFailureReasons);
            }

            return isValid;
        }


        private bool IsPropertyValid(PropertyInfo prop, ref IDictionary<string, string> validationFailureReasons, string? ancestorPropertyNames)
        {
            // return true by default
            bool isValid = true;

            bool requiredIsValid = IsPropertyRequiredValid(prop, ref validationFailureReasons, ancestorPropertyNames);
            if (requiredIsValid == false) isValid = false;

            // dont test max length if
            //  - the basic validation for null or empty failed
            if (requiredIsValid)
            {
                bool minLengthIsValid = IsPropertyMinLengthValid(prop, ref validationFailureReasons, ancestorPropertyNames);
                if (minLengthIsValid == false) isValid = false;

                // do not bother testing maxLength if minLength is not valid
                if (minLengthIsValid)
                {
                    bool maxLengthIsValid = IsPropertyMaxLengthValid(prop, ref validationFailureReasons, ancestorPropertyNames);
                    if (maxLengthIsValid == false) isValid = false;
                }

                bool minValueIsValid = IsPropertyMinValueValid(prop, ref validationFailureReasons, ancestorPropertyNames);
                if (minValueIsValid == false) isValid = false;

                // do not bother testing maxLength if minLength is not valid
                if (minValueIsValid)
                {
                    bool maxValueIsValid = IsPropertyMaxValueValid(prop, ref validationFailureReasons, ancestorPropertyNames);
                    if (maxValueIsValid == false) isValid = false;
                }
            }

            return isValid;
        }

        private bool IsPropertyRequiredValid(PropertyInfo prop, ref IDictionary<string, string> validationFailureReasons, string? ancestorPropertyNames)
        {
            // return true by default
            bool requiredIsValid = true;

            if (prop.GetCustomAttributes(typeof(RequiredAttribute), true).Any())
            {
                requiredIsValid = RequiredAttribute.IsPropertyValid(prop, this, ref validationFailureReasons, ancestorPropertyNames);
            }
            else
            {
                // Property does not contain a 'Required' attribute so continue execution.
            }

            return requiredIsValid;
        }

        private bool IsPropertyMaxLengthValid(PropertyInfo prop, ref IDictionary<string, string> validationFailureReasons, string? ancestorPropertyNames)
        {
            // return true by default
            bool maxLengthIsValid = true;

            if (prop.GetCustomAttributes(typeof(MaxLengthAttribute), true).Any())
            {
                maxLengthIsValid = MaxLengthAttribute.IsPropertyValid(prop, this, ref validationFailureReasons, ancestorPropertyNames);
            }

            return maxLengthIsValid;
        }

        private bool IsPropertyMinLengthValid(PropertyInfo prop, ref IDictionary<string, string> validationFailureReasons, string? ancestorPropertyNames)
        {
            // return true by default
            bool minLengthIsValid = true;

            if (prop.GetCustomAttributes(typeof(MinLengthAttribute), true).Any())
            {
                minLengthIsValid = MinLengthAttribute.IsPropertyValid(prop, this, ref validationFailureReasons, ancestorPropertyNames);
            }

            return minLengthIsValid;
        }

        private bool IsPropertyMinValueValid(PropertyInfo prop, ref IDictionary<string, string> validationFailureReasons, string? ancestorPropertyNames)
        {
            // return true by default
            bool minLengthIsValid = true;

            if (prop.GetCustomAttributes(typeof(MinValueAttribute), true).Any())
            {
                minLengthIsValid = MinValueAttribute.IsPropertyValid(prop, this, ref validationFailureReasons, ancestorPropertyNames);
            }

            return minLengthIsValid;
        }

        private bool IsPropertyMaxValueValid(PropertyInfo prop, ref IDictionary<string, string> validationFailureReasons, string? ancestorPropertyNames)
        {
            // return true by default
            bool maxLengthIsValid = true;

            if (prop.GetCustomAttributes(typeof(MaxValueAttribute), true).Any())
            {
                maxLengthIsValid = MaxValueAttribute.IsPropertyValid(prop, this, ref validationFailureReasons, ancestorPropertyNames);
            }

            return maxLengthIsValid;
        }


        /// <summary>
        /// Used to make the failure reason key unique so it does not conflict if a failure happens agaionst the same property.
        /// The key is made using the following format "({ancestorPropertyNames}).{propInfo.Name}.{attributeName}". 
        /// </summary>
        /// <param name="attributeName">e.g. MinLength, MaxLength, Required.</param>
        /// <param name="propInfo"></param>
        /// <param name="ancestorPropertyNames">Optional. Should be provided further up if the object being validated has recursed down to validate references properties. e.g. "ServicePoint.Label"</param>
        /// <returns></returns>
        protected static string FailureKey(string attributeName, PropertyInfo propInfo, string? ancestorPropertyNames)
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

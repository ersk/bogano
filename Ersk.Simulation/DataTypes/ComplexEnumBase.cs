using Ersk_Simulation.CustomExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ersk.Simulation.DataTypes
{
    [JsonConverter(typeof(DictionaryTKeyEnumTValueConverter))]
    public abstract class ComplexEnumBase<T>
    {
        //protected readonly int index;
        protected readonly string identity;
        protected readonly string name;

        public string Identity => identity;
        public string Name => name;

        //private static int indexInitializer = 0;


        protected static Dictionary<string, ComplexEnumBase<T>> enumDictionary = new();
        public static IReadOnlyDictionary<string, ComplexEnumBase<T>> EnumDictionary => enumDictionary;

        //public static ComplexEnumBase<T> Air = new(indexInitializer++, "Air");
        //public static ComplexEnumBase<T> Water = new(indexInitializer++, "Water");
        //public static ComplexEnumBase<T> Food = new(indexInitializer++, "Food");
        //public static ComplexEnumBase<T> Temperature = new(indexInitializer++, "Temperature");
        //public static ComplexEnumBase<T> Excretion = new(indexInitializer++, "Excretion");
        //public static ComplexEnumBase<T> Recreation = new(indexInitializer++, "Recreation");

        protected ComplexEnumBase(string identity, string name)
        {
            identity.ThrowIfNullOrWhiteSpace(nameof(identity));
            name.ThrowIfNullOrWhiteSpace(nameof(name));

            //this.index = indexInitializer;
            //indexInitializer++;

            this.identity = identity;

            this.name = name;

            enumDictionary.Add(this.identity, this);
            //indexInitializer++;
        }

        public static explicit operator ComplexEnumBase<T>(string needsString)
        {
            bool canCast = enumDictionary.ContainsKey(needsString);

            if (!canCast)
            {
                throw new InvalidCastException($"Could not cast string '{needsString}' to Needs static enum class instance.");
            }

            return enumDictionary[needsString];
        }

        public static ComplexEnumBase<T> Convert(string needsString)
        {
            return (ComplexEnumBase<T>)needsString;
        }

        public static bool TryConvert(string needsString, out ComplexEnumBase<T>? need)
        {
            bool canCast = enumDictionary.ContainsKey(needsString);

            if (!canCast)
            {
                need = null;
                return false;
            }

            need = enumDictionary[needsString];
            return true;
        }
    }

}

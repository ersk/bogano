using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;



namespace Ersk.Simulation.DataTypes
{

    public class DictionaryTKeyEnumTValueConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            //if (!typeToConvert.IsGenericType)
            //{
            //    return false;
            //}

            //if (typeToConvert.GetGenericTypeDefinition() != typeof(ComplexEnumBase<>))
            //{
            //    return false;
            //}

           // Type t1 = v1.GetType().GetProperty("Value").PropertyType;
            var shellPropertyType = typeof(ComplexEnumBase<>);
            var specificShellPropertyType = shellPropertyType.MakeGenericType(typeToConvert);
            //dynamic v2 = specificShellPropertyType.GetProperty("Value").GetValue(v1, null);

            if (typeToConvert.IsSubclassOf(specificShellPropertyType) == false)
            {
                return false;
            }

            //return typeToConvert.GetGenericArguments()[0].IsEnum;
            return true;
        }

        public override JsonConverter CreateConverter(
            Type type,
            JsonSerializerOptions options)
        {
            //Type[] typeArguments = type.GetGenericArguments();
            //Type derivedType = typeArguments[0];

            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(DictionaryEnumConverterInner<>).MakeGenericType(type),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: [options],
                culture: null)!;



            return converter;
        }



        private class DictionaryEnumConverterInner<TDerived> :
            JsonConverter<ComplexEnumBase<TDerived>>
        {
            //private readonly JsonConverter _valueConverter;
            private readonly Type _keyType;
            //private readonly Type _valueType;

            public DictionaryEnumConverterInner(JsonSerializerOptions options)
            {
                // For performance, use the existing converter.
                //_valueConverter = (JsonConverter)options
                //    .GetConverter(typeof(TValue));

                // Cache the key and value types.
                _keyType = typeof(TDerived);
                //_valueType = typeof(TValue);
            }

            public override ComplexEnumBase<TDerived> Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options)
            {
                string? readString = reader.GetString();

                if (string.IsNullOrWhiteSpace(readString))
                {
                    throw new JsonException("Failed to deserialize CompllexEnumBase. Value was null or white-space.");
                }

                return ComplexEnumBase<TDerived>.Convert(readString);
            }

            public override void Write(
                Utf8JsonWriter writer,
                ComplexEnumBase<TDerived> dictionary,
                JsonSerializerOptions options)
            {
                writer.WriteStringValue(dictionary.Identity);
            }
        }
    }
}
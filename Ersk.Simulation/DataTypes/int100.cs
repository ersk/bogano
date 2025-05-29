using System.Globalization;
using System.Security.Principal;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Ersk.Simulation.DataTypes
{
    [JsonConverter(typeof(int100JsonConverter))]
    public struct int100
    {
        private const int minValue = 0;
        private const int maxValue = 100;

        private int value;

        public int100(int value)
        {
            this.value = Math.Clamp(value, minValue, maxValue);
        }

        public static int100 operator ++(int100 int100)
        {
            int100.value = Math.Clamp(int100.value + 1, minValue, maxValue);
            return int100;
        }
        public static int100 operator --(int100 int100)
        {
            int100.value = Math.Clamp(int100.value - 1, minValue, maxValue);
            return int100;
        }

        public static implicit operator int(int100 int100)
        {
            return int100.value;
        }
        public static implicit operator int100(int intValue)
        {
            return new int100(intValue);
        }

        public static explicit operator string(int100 int100)
        {
            return int100.value.ToString();
        }
        public static explicit operator int100(string intValue)
        {
            int parsedString = Convert.ToInt32(intValue);
            return new int100(parsedString);
        }


        public override string ToString()
        {
            return value.ToString();
        }
    }

    public class int100JsonConverter : JsonConverter<int100>
    {
        public override int100 Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {

            int readValue;
            try
            {
                readValue = reader.GetInt32()!;
            }
            catch(Exception ex)
            {
                throw new JsonException("Failed to read int100 value as a number.", ex);
            }
            

            return new int100(readValue);
        }
                

        public override void Write(
            Utf8JsonWriter writer,
            int100 int100,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(int100.ToString());
        }
             
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employee.Core.BundleEmployee.Validator
{
    public class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        private readonly string _dateFormat;

        public JsonDateTimeConverter(string dateFormat)
        {
            _dateFormat = dateFormat;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String && DateTime.TryParseExact(reader.GetString(), _dateFormat, null, System.Globalization.DateTimeStyles.None, out var date))
            {
                return date;
            }
            throw new JsonException($"Invalid date format. Expected format: {_dateFormat}");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_dateFormat));
        }
    }
}

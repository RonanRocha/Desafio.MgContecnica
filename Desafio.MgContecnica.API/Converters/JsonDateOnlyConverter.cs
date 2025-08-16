namespace Desafio.MgContecnica.API.Converters
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class JsonDateOnlyConverter : JsonConverter<DateOnly>
    {
        private readonly string _format = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var str = reader.GetString()!;
            return DateOnly.ParseExact(str, _format);
        }

        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }
    }

}

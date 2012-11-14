using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TelAPI
{
    public class DateTimeConverter : DateTimeConverterBase
    {
        private const string Format = "ddd, d MMM yyyy HH:mm:ss K";
        private const string FormatAlt = "ddd, d MMM yyyy HH:mm:ss 0";

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DateTime dateTime;

            if (reader.TokenType != JsonToken.String)
            {
                return null;
            }

            if(reader.Value.ToString() == string.Empty)
            {
                return null;
            }
                        
            var rawDate = reader.Value.ToString();
            
            // try with format #1
            try
            {
                dateTime = DateTime.ParseExact(rawDate, Format, CultureInfo.InvariantCulture);
                return dateTime;
            }
            catch (FormatException)
            {
                // now try with second format
            }

            try
            {
                dateTime = DateTime.ParseExact(rawDate, FormatAlt, CultureInfo.InvariantCulture);
                return dateTime;
            }
            catch (FormatException)
            {
                // not valid date time format, return null and ignore it
            }

            return null;
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new System.NotImplementedException();
        }
    }
}

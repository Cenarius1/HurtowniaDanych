using DWH.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DWH.ETL.Extract {
    public class DetailsConverter : JsonConverter {
        private List<string> deserializationErrors = new List<string>();
        public override bool CanConvert(Type objectType) {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            serializer.Error += delegate (object sender, ErrorEventArgs args) {
                deserializationErrors.Add(args.ErrorContext.Error.Message);
                args.ErrorContext.Handled = true;
            };
            serializer.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
            serializer.MissingMemberHandling = MissingMemberHandling.Error;

            if (reader.TokenType == JsonToken.StartObject) {
                // All json objects into key/value pairs
                JObject items = JObject.Load(reader);

                foreach (var item in items) {
                    JToken value = item.Value;
                    if (value.Type == JTokenType.Array) {
                        if (item.Key != "features") {
                            // Take first item from array
                            var firstValue = value.First;
                            // Replace array with first item value
                            item.Value.Replace(firstValue);
                        }
                    }
                }
                return items.ToObject<ExtractCarDetail>();
            } else {
                JArray array = JArray.Load(reader);
                var users = array.ToObject<ExtractCarDetail>();
                return users;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}

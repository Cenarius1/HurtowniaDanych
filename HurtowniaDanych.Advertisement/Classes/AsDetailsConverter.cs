using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HurtowniaDanych.Advertisement.Classes
{
    class AsDetailsConverter : JsonConverter
    {
        private List<string> deserializationErrors = new List<string>();
        private readonly bool isDebug = true;
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            serializer.Error += delegate (object sender, ErrorEventArgs args)
            {
                deserializationErrors.Add(args.ErrorContext.Error.Message);
                args.ErrorContext.Handled = true;
            };
            serializer.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
            serializer.MissingMemberHandling = MissingMemberHandling.Error;

            if (reader.TokenType == JsonToken.StartObject)
            {
                // All json objects into key/value pairs
                JObject items = JObject.Load(reader);

                foreach(var item in items)
                {
                    JToken value = item.Value;                    
                    if(value.Type == JTokenType.Array) 
                    {
                        if (item.Key != "features")
                        {
                            // Take first item from array
                            var vvv = value.First;
                            // Replace array with first item value
                            item.Value.Replace(vvv);
                        }
                        else {
                            var convertedFeatures = new Features();
                            var json = JObject.FromObject(convertedFeatures);
                            foreach (JProperty property in json.Properties())
                            {
                                bool has = value.ToObject<List<string>>().Any(y => y == property.Name);
                                if (has)
                                    property.Value = true;                                
                            }

                            if (isDebug) Console.WriteLine("JObject: " + json.ToString());
                            item.Value.Replace(json);
                        }
                            
                    }
                }
                if (isDebug) Console.WriteLine("Deserialization errors: " + string.Join(",", deserializationErrors.ToArray()));
                return items.ToObject<Details>();
            }
            else
            {
                JArray array = JArray.Load(reader);
                var users = array.ToObject<Details>();
                if (isDebug) Console.WriteLine("Deserialization errors: " + string.Join(",", deserializationErrors.ToArray()));
                return users;                
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }


}

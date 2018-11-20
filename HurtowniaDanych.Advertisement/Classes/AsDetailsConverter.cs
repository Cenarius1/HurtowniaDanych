using HurtowniaDanych.Advertisement.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace HurtowniaDanych.Advertisement.Classes
{
    class AsDetailsConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            //throw new NotImplementedException();
            //return objectType == typeof(Details);
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject item = JObject.Load(reader);

                if (item["body_type"] != null)
                {
                    //var users = item["make"].ToObject<IList<Details>>(serializer);
                    //int length = item["length"].Value<int>();


                    //return new PagedList<User>(users, new PagingInformation(start, limit, length, total));

                    var make = item["body_type"];
                    Console.WriteLine(make);
                    Console.WriteLine(item["body_type"].ToString());

                    if (make.HasValues)
                    {
                        Console.WriteLine(make.First);
                    }

                    item["body_type"].Replace("asd");

                    //return serializer.Deserialize<Details>(reader);
                    
                }
            
            }
            else
            {
                JArray array = JArray.Load(reader);

                var users = array.ToObject<Details>();
                Console.WriteLine("end");
                //return users;               

                return serializer.Deserialize<Details>(reader);


            }
            return null;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

    class FixConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            serializer.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
            serializer.MissingMemberHandling = MissingMemberHandling.Error;

            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject item = JObject.Load(reader);

                foreach(var x in item)
                {
                    JToken value = x.Value;                    
                    if((value.Type == JTokenType.Array) && (x.Key != "features"))
                    {
                        // Take first item from array
                        var vvv = value.First;
                        // Replace array with first item value
                        x.Value.Replace(vvv);
                    }
                }
                
                return item.ToObject<Details>();
            }
            else
            {
                JArray array = JArray.Load(reader);
                var users = array.ToObject<Details>();
                return users;                
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }


}

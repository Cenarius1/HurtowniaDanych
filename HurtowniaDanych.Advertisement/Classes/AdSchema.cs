using System.Text;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using HurtowniaDanych.Advertisement.Interfaces;
using HurtowniaDanych.Advertisement.Models;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace HurtowniaDanych.Advertisement.Classes
{
    /// <summary>
    /// Not in use at the moment - work in progress
    /// </summary>
    public class AdSchema : IAd<Schema>
    {
        private Schema schema;
        private List<string> deserializationErrors = new List<string>();
        private readonly bool isDebug = false;

        public void ProcessUrl(string url)
        {
            HtmlWeb web = new HtmlWeb
            {
                OverrideEncoding = Encoding.UTF8
            };
            var doc = web.Load(url);

            string contextJson = doc.DocumentNode.SelectSingleNode("//script[@type='application/ld+json']").InnerHtml;
            if (isDebug) Console.WriteLine(contextJson);
            try
            {
                schema = JsonConvert.DeserializeObject<Schema>(contextJson, new JsonSerializerSettings
                {
                    Error = delegate (object sender, ErrorEventArgs args) {
                        deserializationErrors.Add(args.ErrorContext.Error.Message);
                        args.ErrorContext.Handled = true;
                    },
                    DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate,
                    MissingMemberHandling = MissingMemberHandling.Error
                });
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (isDebug) Console.WriteLine("Deserialization errors: " + string.Join(",", deserializationErrors.ToArray()));
        }

        public Schema RetrieveAd()
        {
            return schema;
        }
    }
}

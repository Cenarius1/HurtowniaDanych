using System.Text;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using HurtowniaDanych.Advertisement.Interfaces;
using HurtowniaDanych.Advertisement.Models;

namespace HurtowniaDanych.Advertisement.Classes
{
    /// <summary>
    /// Not in use at the moment - work in progress
    /// </summary>
    public class AdSchema : IAd<Schema>
    {
        private Schema schema;
        public void ProcessUrl(string url)
        {
            HtmlWeb web = new HtmlWeb
            {
                OverrideEncoding = Encoding.UTF8
            };
            var doc = web.Load(url);

            string contextJson = doc.DocumentNode.SelectSingleNode("//script[@type='application/ld+json']").InnerHtml;
            try
            {
                schema = JsonConvert.DeserializeObject<Schema>(contextJson, new JsonSerializerSettings
                {
                    MissingMemberHandling = MissingMemberHandling.Error
                });
            }
            catch (JsonSerializationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Schema RetrieveAd()
        {
            return schema;
        }
    }
}

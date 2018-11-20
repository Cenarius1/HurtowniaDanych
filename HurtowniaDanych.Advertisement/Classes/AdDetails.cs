using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using HurtowniaDanych.Advertisement.Interfaces;
using HurtowniaDanych.Advertisement.Models;

namespace HurtowniaDanych.Advertisement.Classes
{
    public class AdDetails : IAd<Details>
    {
        private Details ad;
        private List<string> deserializationErrors = new List<string>();
        private readonly bool isDebug = true;

        public void ProcessUrl(string url)
        {
            HtmlWeb web = new HtmlWeb
            {
                OverrideEncoding = Encoding.UTF8
            };
            var doc = web.Load(url);

            var scriptNodes = doc.DocumentNode.SelectNodes("//script[@type='text/javascript']");

            foreach (var x in scriptNodes)
            {
                var InnerHtml = x.InnerHtml;

                string pattern = @"(?<targeting>GPT\.targeting\s=\s)(?<details>{.*?})";
                var match = Regex.Match(InnerHtml, pattern);
                if (match.Success)
                {
                    if (isDebug) Console.WriteLine(match.Groups["details"].ToString());
                    try
                    {
                        ad = JsonConvert.DeserializeObject<Details>(match.Groups["details"].ToString(), new FixConverter());

                    }
                    catch (JsonSerializationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }

            if(isDebug) Console.WriteLine("Deserialization errors: " + string.Join(",", deserializationErrors.ToArray()));
        }

        public Details RetrieveAd()
        {
            return ad;
        }

    }
}

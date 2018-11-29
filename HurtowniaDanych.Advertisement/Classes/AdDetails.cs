using System;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using HurtowniaDanych.Advertisement.Interfaces;
using Newtonsoft.Json;

namespace HurtowniaDanych.Advertisement.Classes
{
    public class AdDetails : IAd<Details>
    {
        private Details ad;
        private readonly bool isDebug = false;

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
                        ad = JsonConvert.DeserializeObject<Details>(match.Groups["details"].ToString(), new AsDetailsConverter());

                    }
                    catch (JsonSerializationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }            
        }

        public Details RetrieveAd()
        {
            return ad;
        }
    }
}

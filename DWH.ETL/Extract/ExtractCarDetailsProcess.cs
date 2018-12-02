using DWH.Domain;
using DWH.ETL.Interfaces;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace DWH.ETL.Extract {
    public class ExtractCarDetailsProcess : IETLProcess<string, ExtractCarDetail> {
        public ExtractCarDetail Process(string url) {
            HtmlWeb web = new HtmlWeb {
                OverrideEncoding = Encoding.UTF8
            };
            var doc = web.Load(url);

            var scriptNodes = doc.DocumentNode.SelectNodes("//script[@type='text/javascript']");

            var carDetails = new ExtractCarDetail();

            foreach (var x in scriptNodes) {
                var InnerHtml = x.InnerHtml;
                string pattern = @"(?<targeting>GPT\.targeting\s=\s)(?<details>{.*?})";
                var match = Regex.Match(InnerHtml, pattern);
                if (match.Success) {
                    try {
                        carDetails = JsonConvert.DeserializeObject<ExtractCarDetail>(match.Groups["details"].ToString(), new DetailsConverter());
                    } catch (JsonSerializationException ex) {
                        Console.WriteLine(ex.Message);
                    }
                }

            }

            return carDetails;
        }
    }
}

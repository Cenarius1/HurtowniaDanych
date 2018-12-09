using DWH.ETL.Interfaces;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DWH.ETL.Extract {
    public class ExtractCarDetailsProcess : IETLProcess<string, string> {
        public string Process(string url) {
            HtmlWeb web = new HtmlWeb {
                OverrideEncoding = Encoding.UTF8
            };

            var doc = Run(2, () => web.Load(url));

            var scriptNodes = doc.DocumentNode.SelectNodes("//script[@type='text/javascript']");

            var carDetails = string.Empty;

            foreach (var x in scriptNodes) {
                var InnerHtml = x.InnerHtml;
                string pattern = @"(?<targeting>GPT\.targeting\s=\s)(?<details>{.*?})";
                var match = Regex.Match(InnerHtml, pattern);
                if (match.Success) {
                    try {
                        carDetails = match.Groups["details"].ToString();
                    } catch (JsonSerializationException ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return carDetails;
        }

        public static T Run<T>(int retryCount, Func<T> doThis) {
            for (int i = 0; i < retryCount; i++) {
                try {
                    if (i > 0)
                        Task.Delay(50);

                    return doThis();
                } catch (Exception ex) {
                    if (i == retryCount - 1)
                        throw;
                }
            }

            return default(T);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace HurtowniaDanych
{
    public class SearchCarLinkHandler
    {
        public const string BaseLinkPath = "https://www.otomoto.pl/osobowe/?search%5Bfilter_float_year%3Ato%5D=2018&search%5Bnew_used%5D=on";

        public List<string> GetLinks()
        {
            var rawData = GetHtml();
            //jak skonczy sie stronnicowanie to link do nastepnego page czy cus
            return GetFiltredLinksFromRawHtml(rawData);
        }

        private List<string> GetFiltredLinksFromRawHtml(string rawData)
        {
            List<string> linkList = new List<string>();
            int offerIndex, hrefIndex, beginingOfLink ,titleIndex ,endOfLink ,linkLength;
            string linkPath;
            string cutterdData = rawData;
            while (rawData.Contains("offer-title__link"))
            {
                offerIndex = rawData.IndexOf("offer-title__link");
                hrefIndex = rawData.IndexOf("href", offerIndex);
                beginingOfLink = hrefIndex + 6;
                titleIndex = rawData.IndexOf("title", beginingOfLink);
                endOfLink = titleIndex - 2;
                linkLength = endOfLink - beginingOfLink;
                linkPath = rawData.Substring(beginingOfLink, linkLength);
                linkList.Add(linkPath);
                rawData = rawData.Substring(endOfLink);
            }

            return linkList;
        }

        private string GetHtml()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BaseLinkPath);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                    readStream = new StreamReader(receiveStream);
                else
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                string data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return data;
            }
            throw new Exception("Website error");
        }
    }
}

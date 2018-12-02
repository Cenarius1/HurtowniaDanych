using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DWH.ETL.Extract
{
    public class SearchCarLinkHandler
    {
        public string BaseLinkPath = "https://www.otomoto.pl/osobowe/?search[filter_float_year%3Ato]=2018&page=";

        public SearchCarLinkHandler(string baseLinkPath = null) {
            if (baseLinkPath != null)
                BaseLinkPath = baseLinkPath;
        }

        public List<string> GetLinksFromEachPage()
        {
            List<string> linksFromEachPage = new List<string>();
            int lastPageNumber =  GetPagesCount();
            /*
             *  Lepiej ustawić sztuczną ilość stron, a nie brać z maksymalnej ze strony
             *  1) Jest tego ogrom ~7685, a na każdej stronie 16 aut, czas pobierania tego bedzie duzy
             *  2) Maksymalna ilosc stron zmienia się. A sprawdzanie za każdym razem jest mnożeniem zapytań.
             */
            lastPageNumber = 10;
            for (int i = 0; i < lastPageNumber; i++)
            {
                string linkToPage = BaseLinkPath + (i+1).ToString();
                linksFromEachPage.AddRange(GetLinks(linkToPage));
            }

            return linksFromEachPage;
        }

        private List<string> GetLinks(string pageLink)
        {
            var rawData = GetHtml(pageLink);
            return GetFiltredLinksFromRawHtml(rawData);
        }

        private int GetPagesCount()
        {
            var rawData = GetHtml(BaseLinkPath+"1");
            string patternTripleDots = "<span class=\"page\">...</span>";
            var indexOfPagingTripleDots = rawData.IndexOf(patternTripleDots);
            int rangeAfterTrimpleDots = 30;
            int rangeBeforeTrimpleDots = 296;
            var textWithTripleDots = rawData.Substring(indexOfPagingTripleDots+ rangeBeforeTrimpleDots, rangeAfterTrimpleDots);
            var indexOfEndOfLastPageNumber = textWithTripleDots.IndexOf("</span>");
            var textLastPageNumber = textWithTripleDots.Substring(0, indexOfEndOfLastPageNumber);
            int result = -1;
            int.TryParse(textLastPageNumber, out result);
            return result;
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

        private string GetHtml(string pageLink)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(pageLink);
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

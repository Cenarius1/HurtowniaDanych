using DWH.ETL.Interfaces;
using System.Collections.Generic;

namespace DWH.ETL.Extract {
    public class ExtractCarDetailUrlsProcess : IETLProcess<string, List<string>> {
        public List<string> Process(string baseUrl) {
            var urlSearchHandler = new SearchCarLinkHandler(baseUrl);
            var links = urlSearchHandler.GetLinksFromEachPage();

            return links;
        }
    }
}

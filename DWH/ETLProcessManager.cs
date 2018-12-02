using DWH.Domain;
using DWH.ETL.Extract;
using DWH.ETL.Load;
using DWH.ETL.Transform;
using System;
using System.Collections.Generic;

namespace DWH {
    public class ETLProcessManager {
        private readonly ExtractCarDetailUrlsProcess extractCarDetailUrlsProcess;
        private readonly ExtractCarDetailsProcess extractProcess;
        private readonly TransformProcess transformProcess;
        private readonly LoadProcess loadProcess;

        public ETLProcessManager() {
            extractCarDetailUrlsProcess = new ExtractCarDetailUrlsProcess();
            extractProcess = new ExtractCarDetailsProcess();
            transformProcess = new TransformProcess();
            loadProcess = new LoadProcess();
        }

        public void Launch() {
            string baseUrl = null;

            Console.WriteLine("Obtaining links from: {0}", baseUrl);

            var urls = extractCarDetailUrlsProcess.Process(baseUrl);

            Console.WriteLine("Starting extracting details from links...");
            var extractCarDetails = new List<ExtractCarDetail>();
            foreach (var url in urls) {
                Console.WriteLine("Extracting details from link: {0}", url);
                var extractCarDetail = extractProcess.Process(url);
                extractCarDetails.Add(extractCarDetail);
            }

            Console.WriteLine("Starting transform process...");
            var loadCarDetails = new List<LoadCarDetail>();
            foreach (var extractCarDetail in extractCarDetails) {
                var loadCarDetail = transformProcess.Process(extractCarDetail);
                loadCarDetails.Add(loadCarDetail);
            }

            Console.WriteLine("Starting load process...");
            var success = loadProcess.Process(loadCarDetails);

            if (success) {
                Console.WriteLine("ETL Process finished succesfully");
            } else {
                Console.WriteLine("ETL Process occured problems during work, check console logs for details.");
            }
        }
    }
}

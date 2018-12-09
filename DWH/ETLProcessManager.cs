using DWH.Domain;
using DWH.ETL.Extract;
using DWH.ETL.Load;
using DWH.ETL.Transform;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DWH {
    public class ETLProcessManager {
        private readonly ExtractCarDetailUrlsProcess extractCarDetailUrlsProcess;
        private readonly ExtractCarDetailsProcess extractProcess;
        private readonly TransformProcess transformProcess;
        private readonly LoadProcess loadProcess;

        private const string extractFile = "extract.txt";
        private const string transformFile = "transform.txt";

        public ETLProcessManager() {
            extractCarDetailUrlsProcess = new ExtractCarDetailUrlsProcess();
            extractProcess = new ExtractCarDetailsProcess();
            transformProcess = new TransformProcess();
            loadProcess = new LoadProcess();
        }

        public void LaunchAll(string baseUrl) {
            LaunchExtract(baseUrl);
            LaunchTransform();
            LaunchLoad();
        }

        public void LaunchExtract(string baseUrl) {
            var urls = ExtractUrls(baseUrl);
            ExtractCarDetails(urls, extractFile);
        }

        public void LaunchTransform() {
            TransformCarDetails(extractFile, transformFile);
        }

        public void LaunchLoad() {
            LoadCarDetails(transformFile);
        }

        private List<string> ExtractUrls(string baseUrl) {
            Console.WriteLine("Obtaining links from: {0}", baseUrl);
            var urls = extractCarDetailUrlsProcess.Process(baseUrl);
            return urls;
        }

        private void LoadCarDetails(string sourceFile) {
            Console.WriteLine("Starting load process...");
            var loadCarDetailsJson = File.ReadAllLines(sourceFile);

            var loadCarDertails = new List<LoadCarDetail>();
            foreach (var json in loadCarDetailsJson) {
                loadCarDertails.Add(JsonConvert.DeserializeObject<LoadCarDetail>(json));
            }

            var success = loadProcess.Process(loadCarDertails);

            if (success) {
                Console.WriteLine("ETL Process finished succesfully");
                File.WriteAllText(sourceFile, string.Empty); //Clear source file
            } else {
                Console.WriteLine("ETL Process occured problems during work, check console logs for details.");
            }
        }

        private void TransformCarDetails(string inputFile, string outputFile) {
            Console.WriteLine("Starting transform process...");

            var rawData = File.ReadAllLines(inputFile).ToList();

            var loadCarDetails = new List<string>();

            foreach (var data in rawData) {
                var loadCarDetail = transformProcess.Process(data);
                loadCarDetails.Add(JsonConvert.SerializeObject(loadCarDetail));
            }

            File.AppendAllLines(outputFile, loadCarDetails);
            File.WriteAllText(inputFile, string.Empty); //Clear source file
        }

        private void ExtractCarDetails(List<string> urls, string targetFile) {
            Console.WriteLine("Starting extracting details from links...");
            var extractCarDetails = new List<string>();

            Parallel.ForEach(urls, (url) => {
                Console.WriteLine("Extracting details from link: {0}", url);
                var extractCarDetail = extractProcess.Process(url);
                extractCarDetails.Add(extractCarDetail);
            });

            File.AppendAllLines(targetFile, extractCarDetails);
        }
    }
}

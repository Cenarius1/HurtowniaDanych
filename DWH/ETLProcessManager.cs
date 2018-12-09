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
        //private ETLProcessManager _ETLProcessManagers { get; set; }
        //List<ExtractCarDetail> _listExtractCarDetail;
        //private List<LoadCarDetail> _loadCarDetailsList;

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

        //public void Launch() {
        //    //do wywalenia ponizej, dla pokazania czegos na grid
        //    _loadCarDetailsList = new List<LoadCarDetail>()
        //    {
        //        new LoadCarDetail()
        //        {
        //            Id = 1,
        //            Title = "title1",
        //            Price = "100",
        //            Year = "1000",
        //            OfferSeek = "1",
        //            PrivateBusiness = "1",
        //            Category = "1",
        //            Region = "1",
        //            Subregion = "1",
        //            UserId = "1",
        //            City = "1",
        //            Make = "1",
        //            Model = "1",
        //            EngineCode = "1"
        //        },
        //        new LoadCarDetail()
        //        {
        //            Id = 2,
        //            Title = "title12",
        //            Price = "222",
        //            Year = "2222",
        //            OfferSeek = "2",
        //            PrivateBusiness = "2",
        //            Category = "2",
        //            Region = "2",
        //            Subregion = "2",
        //            UserId = "2",
        //            City = "2",
        //            Make = "2",
        //            Model = "2",
        //            EngineCode = "2"
        //        },
        //        new LoadCarDetail()
        //        {
        //            Id = 3,
        //            Title = "title123",
        //            Price = "3333",
        //            Year = "3333",
        //            OfferSeek = "3",
        //            PrivateBusiness = "3",
        //            Category = "3",
        //            Region = "3",
        //            Subregion = "3",
        //            UserId = "3",
        //            City = "3",
        //            Make = "3",
        //            Model = "3",
        //            EngineCode = "3"
        //        },
        //    };
        //    return;
        //    //do usuniecia powyzej
        //}
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

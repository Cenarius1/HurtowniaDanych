using DWH.Domain;
using DWH.ETL.Extract;
using DWH.ETL.Load;
using DWH.ETL.Transform;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DWH
{
    public class ETLProcessManager
    {
        private readonly string _baseUrl = "https://www.otomoto.pl/osobowe/bmw/?search[filter_float_year%3Ato]=2018&page=";
        private readonly ExtractCarDetailUrlsProcess extractCarDetailUrlsProcess;
        private readonly ExtractCarDetailsProcess extractProcess;
        private readonly TransformProcess transformProcess;
        private readonly LoadProcess loadProcess;
        private ETLProcessManager _ETLProcessManagers { get; set; }
        List<ExtractCarDetail> _listExtractCarDetail;
        private List<LoadCarDetail> _loadCarDetailsList;



        public ETLProcessManager()
        {
            extractCarDetailUrlsProcess = new ExtractCarDetailUrlsProcess();
            extractProcess = new ExtractCarDetailsProcess();
            transformProcess = new TransformProcess();
            loadProcess = new LoadProcess();
        }

        public void Launch()
        {
            //do wywalenia ponizej, dla pokazania czegos na grid
            _loadCarDetailsList = new List<LoadCarDetail>()
            {
                new LoadCarDetail()
                {
                    Id = 1,
                    Title = "title1",
                    Price = "100",
                    Year = "1000",
                    OfferSeek = "1",
                    PrivateBusiness = "1",
                    Category = "1",
                    Region = "1",
                    Subregion = "1",
                    UserId = "1",
                    City = "1",
                    Make = "1",
                    Model = "1",
                    EngineCode = "1"
                },
                new LoadCarDetail()
                {
                    Id = 2,
                    Title = "title12",
                    Price = "222",
                    Year = "2222",
                    OfferSeek = "2",
                    PrivateBusiness = "2",
                    Category = "2",
                    Region = "2",
                    Subregion = "2",
                    UserId = "2",
                    City = "2",
                    Make = "2",
                    Model = "2",
                    EngineCode = "2"
                },
                new LoadCarDetail()
                {
                    Id = 3,
                    Title = "title123",
                    Price = "3333",
                    Year = "3333",
                    OfferSeek = "3",
                    PrivateBusiness = "3",
                    Category = "3",
                    Region = "3",
                    Subregion = "3",
                    UserId = "3",
                    City = "3",
                    Make = "3",
                    Model = "3",
                    EngineCode = "3"
                },
            };
            return;
            //do usuniecia powyzej

            Extract();
            Transform();
            Load();
        }

        public void Extract()
        {
            var urls = ExtractUrls(_baseUrl);
            _listExtractCarDetail = ExtractCarDetails(urls);
        }

        public void Transform()
        {
            if (_listExtractCarDetail == null)
                return;

            _loadCarDetailsList = TransformCarDetails(_listExtractCarDetail);
        }

        public void Load()
        {
            LoadCarDetails(_loadCarDetailsList);
        }

        public List<LoadCarDetail> GetLoadedCarDetail()
        {
            return _loadCarDetailsList;
        }

        private List<string> ExtractUrls(string baseUrl)
        {
            Console.WriteLine("Obtaining links from: {0}", baseUrl);
            var urls = extractCarDetailUrlsProcess.Process(baseUrl);
            return urls;
        }

        private void LoadCarDetails(List<LoadCarDetail> loadCarDetails)
        {
            Console.WriteLine("Starting load process...");
            var success = loadProcess.Process(loadCarDetails);

            if (success)
            {
                Console.WriteLine("ETL Process finished succesfully");
            }
            else
            {
                Console.WriteLine("ETL Process occured problems during work, check console logs for details.");
            }
        }

        private List<LoadCarDetail> TransformCarDetails(List<ExtractCarDetail> extractCarDetails)
        {
            Console.WriteLine("Starting transform process...");
            var loadCarDetails = new List<LoadCarDetail>();
            foreach (var extractCarDetail in extractCarDetails)
            {
                var loadCarDetail = transformProcess.Process(extractCarDetail);
                loadCarDetails.Add(loadCarDetail);
            }

            return loadCarDetails;
        }

        private List<ExtractCarDetail> ExtractCarDetails(List<string> urls)
        {
            Console.WriteLine("Starting extracting details from links...");
            var extractCarDetails = new List<ExtractCarDetail>();

            Parallel.ForEach(urls, (url) =>
            {
                Console.WriteLine("Extracting details from link: {0}", url);
                var extractCarDetail = extractProcess.Process(url);
                extractCarDetails.Add(extractCarDetail);
            });

            return extractCarDetails;
        }
    }
}

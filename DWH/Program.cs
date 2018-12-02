using DWH.Domain;
using DWH.ETL.Extract;
using DWH.ETL.Load;
using DWH.ETL.Transform;
using System;
using System.Collections.Generic;

namespace DWH {
    class Program {
        static void Main(string[] args) {
            var etlManager = new ETLProcessManager();

            etlManager.Launch();

            //var extractProcess = new ExtractCarDetailsProcess();
            //var transformProcess = new TransformProcess();
            //var loadProcess = new LoadProcess();

            //var carDetails = extractProcess.Process("https://www.otomoto.pl/oferta/bmw-x5-3-0d-235km-x-drive-serwisowany-w-aso-bezwypadkowy-ID6ByeWn.html#2bd424144f");
            //var loadCarDetails = transformProcess.Process(carDetails);
            //var loadResult = loadProcess.Process(new List<LoadCarDetail>() {
            //    loadCarDetails
            //});

            Console.ReadKey();
        }
    }
}

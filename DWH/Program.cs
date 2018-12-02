using System;

namespace DWH {
    class Program {
        static void Main(string[] args) {
            //TODO: Parametrize ETLProcessManager
            if (args.Length > 0) {
                var manufacturer = args[0];
            }

            var etlManager = new ETLProcessManager();

            etlManager.Launch();

            Console.ReadKey();
        }
    }
}

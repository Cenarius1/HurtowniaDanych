using System;

namespace DWH {
    class Program {
        static void Main(string[] args) {
            var etlManager = new ETLProcessManager();

            etlManager.Launch();

            Console.ReadKey();
        }
    }
}

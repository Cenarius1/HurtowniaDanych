using System;

namespace DWH {
    class Program {
        static void Main(string[] args) {
            var etlManager = new ETLProcessManager();

            if (args.Length > 0) {
                switch (args[0]) {
                    case "extract":
                        if (args.Length != 2) {
                            Console.WriteLine("Unable to launch extract process, parameters missmatch, use: etl.exe extract <manufacturer>, example: etl.exe extract BMW");
                        } else {
                            if (string.IsNullOrEmpty(args[1])) {
                                Console.WriteLine("Unable to launch extract process with null or empty manufacturer, aboring.");
                            } else {
                                Console.WriteLine($"Launching extract process with \"{args[1]}\" manufacturer");

                                var baseUrl = $"https://www.otomoto.pl/osobowe/{args[1]}/?search[filter_float_year%3Ato]=2018&page=";
                                etlManager.LaunchExtract(baseUrl);
                            }
                        }
                        break;
                    case "transform":
                        Console.WriteLine($"Launching transform process");
                        etlManager.LaunchTransform();
                        break;
                    case "load":
                        Console.WriteLine($"Launching load process");
                        etlManager.LaunchLoad();
                        break;
                    case "all":
                        if (args.Length != 2) {
                            Console.WriteLine("Unable to launch extract process, parameters missmatch, use: etl.exe extract <manufacturer>, example: etl.exe extract BMW");
                        } else {
                            if (string.IsNullOrEmpty(args[1])) {
                                Console.WriteLine("Unable to launch extract process with null or empty manufacturer, aboring.");
                            } else {
                                Console.WriteLine($"Launching extract, transofrm, load at once process with \"{args[1]}\" manufacturer");

                                var baseUrl = $"https://www.otomoto.pl/osobowe/{args[1]}/?search[filter_float_year%3Ato]=2018&page=";
                                etlManager.LaunchAll(baseUrl);
                            }
                        }
                        
                        break;
                    default:
                        Console.WriteLine($"Unknown process step \"{args[0]}\", aborting...");
                        break;
                }
            } else {
                Console.WriteLine("Unable to launch ETL process, no parameters detected, use: etl.exe <etl_step> [<manufacturer>], example: etl.exe extract BMW\r\n available elt_steps: extract, transform, load, all");
            }

            Console.WriteLine("Process done, press any key to close.");
            Console.ReadKey();
        }
    }
}

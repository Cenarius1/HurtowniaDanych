using System;

namespace HurtowniaDanych
{
    class Program
    {
        static void Main(string[] args)
        {
            DataWarehouseManager dataWarehouseManager = new DataWarehouseManager();
            dataWarehouseManager.Launch();

            Console.Read();
        }
    }
}

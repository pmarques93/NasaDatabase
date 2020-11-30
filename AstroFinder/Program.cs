using System;
using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Manager manager = new Manager();
            // manager.Run();
            CSVFileDataReader fileDataReader = new CSVFileDataReader("planets.csv");

            IGetCollectionFromData get = new ExoplanetsListFromCSVData(new string[] { "pl_name", "hostname" });

            var v = get.GetCollection(fileDataReader.FileData);

            foreach (string[] p in v)
            {
                System.Console.WriteLine(p[0]);
            }

        }
    }
}

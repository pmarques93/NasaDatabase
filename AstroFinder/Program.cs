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
            string[] headers = new string[] { "pl_name", "hostname" };
            const string filePath = "planets.csv";


            CSVFileDataReader fileDataReader = new CSVFileDataReader(filePath);

            ExoplanetsListFromCSVData get = new ExoplanetsListFromCSVData(headers);

            Exoplanet planet = new Exoplanet(name: "pudim", hostName: "hey");

            var v = get.GetCollection(fileDataReader.FileData);

            foreach (Exoplanet p in v)
            {
                System.Console.WriteLine(p);
            }

        }
    }
}

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
            string[] headers = new string[] { "pl_name", "hostname", "discoverymethod" };
            ExoplanetsListFromCSVData get = new ExoplanetsListFromCSVData(headers);
            const string filePath = "planets.csv";

            CSVFileDataReader fileDataReader = new CSVFileDataReader(filePath);



            List<Exoplanet> v = get.GetCollection(fileDataReader.FileData) as List<Exoplanet>;

            string planetName = null;
            string hostName = null;
            string discoverymethod = "Imaging";

            IEnumerable<Exoplanet> planetas = v.
                                        Where( // Checks for planet name
                                                p => p.PlanetName == planetName
                                                || planetName == null
                                                // Checks for host name
                                                && p.HostName == hostName
                                                || hostName == null
                                                // checks for discovery method
                                                && p.DiscoveryMethod == discoverymethod
                                                || discoverymethod == null).
                                        Select(p => p);

            foreach (Exoplanet planet in planetas)
            {
                Console.WriteLine(planet);
            }


            // foreach (Exoplanet p in v)
            // {
            //     System.Console.WriteLine(p);
            // }

        }
    }
}

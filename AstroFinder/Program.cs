using System;
using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    /// <summary>
    /// Class that contains Main() method
    /// </summary>
    class Program
    {
        /// <summary>
        /// A static reference to a IUserInterface
        /// </summary>
        public static IUserInterface UI { get; private set; }

        /// <summary>
        /// Application starts from this method
        /// </summary>
        /// <param name="args">Command-Line options</param>
        static void Main(string[] args)
        {
            UI = new ConsoleUserInterface();
            /*
            Manager manager = new Manager();
            manager.Run();*/

            string[] headers = new string[] { "pl_name", "hostname", "discoverymethod",
            "disc_year", "pl_orbper", "pl_rade", "pl_bmasse", "pl_eqt",
            "st_teff", "st_rad", "st_mass", "st_age", "st_vsin", "st_rotp", "sy_dist"};
            ExoplanetsListFromCSVData get = new ExoplanetsListFromCSVData(headers);
            const string filePath = "planets.csv";

            CSVFileDataReader fileDataReader = new CSVFileDataReader(filePath);



            List<Exoplanet> v = get.GetCollection(fileDataReader.FileData) as List<Exoplanet>;

            string planetName = null;
            string hostName = null;
            string discoverymethod = null;

            IEnumerable<Exoplanet> planetas = v.
                                        Where( // Checks for planet name
                                                p => p.Name == planetName
                                                || planetName == null
                                                // Checks for host name
                                                && p.ParentStar.Name == hostName
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

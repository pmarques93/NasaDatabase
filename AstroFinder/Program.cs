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


            const string filePath = "planets.csv";
            CSVFileDataReader fileDataReader = new CSVFileDataReader(filePath);

            string[] starHeaders = new string[] { "hostname", "st_teff", "st_rad",
                "st_mass", "st_age", "st_vsin", "st_rotp", "sy_dist"};
            StarsListFromCSVData getStars = new StarsListFromCSVData(starHeaders);
            List<Star> stars = getStars.GetCollection(fileDataReader.FileData) as List<Star>;

            string[] planetHeaders = new string[] { "pl_name", "hostname",
                "discoverymethod", "disc_year", "pl_orbper", "pl_rade", "pl_bmasse", "pl_eqt"};
            ExoplanetsListFromCSVData getPlanets = new ExoplanetsListFromCSVData(planetHeaders);
            List<Exoplanet> planets = getPlanets.GetCollection(fileDataReader.FileData) as List<Exoplanet>;


            // temp info
            string planetName = "11 Com B";
            string hostName = null;
            string discoverymethod = null;
            ushort? discoveryYear = null;


            // n apagar
            byte numResultsToShow = 2; // RESULTADOS PARA MOSTRAR
            byte numTimesShown = 0;   // QUANDO UTILIZADOR CARREGA NUM BOTAO, INCREMENTA numberOfTimes++ ;
            // n apagar

            IEnumerable<IPlanet> filteredPlanets = planets.
                                        Where( // Checks for planet name
                                                p => p.Name == planetName
                                                || planetName == null
                                                // Checks for host name
                                                && p.ParentStar.Name == hostName
                                                || hostName == null
                                                // checks for discovery method
                                                && p.DiscoveryMethod == discoverymethod
                                                || discoverymethod == null
                                                && p.DiscoveryYear == discoveryYear
                                                || discoveryYear == null).
                                        Select(p => p).
                                            Skip(numResultsToShow * numTimesShown).Take(numResultsToShow);




            foreach (var v in filteredPlanets)
            {
                Console.WriteLine(v);
            }

        }
    }
}

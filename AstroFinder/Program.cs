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

            // STAR STUFF
            string[] starHeaders = new string[] { "hostname", "st_teff", "st_rad",
                "st_mass", "st_age", "st_vsin", "st_rotp", "sy_dist"};
            StarsListFromCSVData getStars = new StarsListFromCSVData(starHeaders);
            List<Star> allStars = getStars.GetCollection(fileDataReader.FileData) as List<Star>;
            // List with non repeated stars
            List<Star> nonRepeatedStars = new List<Star>();
            foreach(Star star in allStars)
            {
                if (nonRepeatedStars.Contains(star) == false)
                    nonRepeatedStars.Add(star);
            }

            // PLANET STUFF
            string[] planetHeaders = new string[] { "pl_name", "hostname",
                "discoverymethod", "disc_year", "pl_orbper", "pl_rade", "pl_bmasse", "pl_eqt"};
            ExoplanetsListFromCSVData getPlanets = new ExoplanetsListFromCSVData(planetHeaders);
            List<Exoplanet> allPlanets = getPlanets.GetCollection(fileDataReader.FileData) as List<Exoplanet>;



            // TESTES /////////////////////////////////////////////////////////////////////////////////////
            // temp info
            string planetName = null;
            string hostName = "55 cnc";
            string discoverymethod = null;
            ushort? discoveryYear = null;

            // n apagar
            const byte numResultsToShow = 2; // RESULTADOS PARA MOSTRAR
            byte numTimesShown = 0;   // QUANDO UTILIZADOR CARREGA NUM BOTAO, INCREMENTA numberOfTimes++ ;
            // n apagar

            IEnumerable<IPlanet> filteredPlanets = 
                (from planet in allPlanets
                 where planet.Name.ToLower() == planetName || planetName == null
                 where planet.ParentStar.Name.ToLower() == hostName || hostName == null
                 where planet.DiscoveryMethod.ToLower() == discoverymethod || discoverymethod == null
                 where planet.DiscoveryYear == discoveryYear || discoveryYear == null
                 select planet).Skip(numResultsToShow * numTimesShown).Take(numResultsToShow);

            /* STARS + CHILD PLANETS
            foreach (Star star in nonRepeatedStars)
            {
                foreach (IPlanet planet in star.ChildPlanets)
                {
                    Console.WriteLine(star.Name + ": " + planet.Name);
                }
            }*/
        }
    }
}

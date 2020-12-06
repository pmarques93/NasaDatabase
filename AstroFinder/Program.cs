using System;
using System.Collections.Generic;
using System.Linq;
using AstroFinder.FileReader.Exception;

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
            
            Manager manager = new Manager();
            manager.Run();

            // const string filePath = "planets.csv";
            // CSVFileDataReader fileDataReader = new CSVFileDataReader(filePath);

            // // STAR STUFF
            // string[] starHeaders = new string[] { "hostname", "st_teff", "st_rad",
            //     "st_mass", "st_age", "st_vsin", "st_rotp", "sy_dist"};
            // StarsListFromCSVData getStars = new StarsListFromCSVData(starHeaders);

            // // PLANET STUFF
            // string[] planetHeaders = new string[] { "pl_name", "hostname",
            //     "discoverymethod", "disc_year", "pl_orbper", "pl_rade", "pl_bmasse", "pl_eqt"};
            // ExoplanetsListFromCSVData getPlanets = new ExoplanetsListFromCSVData(planetHeaders);



            // // STARS CREATION
            // List<Star> allStars = getStars.GetCollection(fileDataReader.FileData) as List<Star>;

            // // List with non repeated stars
            // List<Star> nonRepeatedStars = new List<Star>();
            // foreach (Star star in allStars)
            // {
            //     if (nonRepeatedStars.Contains(star) == false)
            //     {
            //         nonRepeatedStars.Add(star);
            //     }
            // }

            // // PLANET DECLARATION
            // List<Exoplanet> allPlanets = getPlanets.GetCollection(fileDataReader.FileData) as List<Exoplanet>;
            

            // foreach (Exoplanet planet in allPlanets)
            // {
            //     foreach (Star star in nonRepeatedStars)
            //     {
            //         if (planet.ParentStar.Name == star.Name)
            //         {
            //             star.ChildPlanets.Add(planet);
            //             planet.ParentStar = star;
            //         }
            //     }
            // }


            // // TESTES /////////////////////////////////////////////////////////////////////////////////////
            // // temp info
            // string planetName = null;
            // string hostName = "ngc";
            // string discoverymethod = null;
            // ushort? discoveryYear = null;

            // // n apagar
            // const byte numResultsToShow = 5; // RESULTADOS PARA MOSTRAR
            // byte numTimesShown = 0;   // QUANDO UTILIZADOR CARREGA NUM BOTAO, INCREMENTA numberOfTimes++ ;
            // // n apagar

            // IEnumerable<IPlanet> filteredPlanets =
            //     (from planet in allPlanets
            //      where planet.Name.ToLower().Contains(planetName ?? "any") || planetName == null || planetName == "any"
            //      where planet.ParentStar.Name.ToLower().Contains(hostName ?? "any") || hostName == null || hostName == "any"
            //      where planet.DiscoveryMethod.ToLower().Contains(discoverymethod ?? "any") || discoverymethod == null || discoverymethod == "any"
            //      where planet.DiscoveryYear == discoveryYear || discoveryYear == null
            //      select planet).Skip(numResultsToShow * numTimesShown).Take(numResultsToShow);


            //foreach (var v in filteredPlanets)
            //    Console.WriteLine(v.ParentStar.Name+ ": " + v.Name);


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

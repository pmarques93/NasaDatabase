using System;
using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    /// <summary>
    /// Class responsible for running the application
    /// </summary>
    public class Manager
    {
        ////////////////////// PARA TAR NOUTRA CLASSE ////////////////////////////////////////////////////////////
        string[] planetHeaders;
        ExoplanetsListFromCSVData getPlanets;
        string[] starHeaders;
        StarsListFromCSVData getStars;
        //////////////////////////// TEMPORARIO //////////////////////////////////////////////////////////

        /// <summary>
        /// Variable responsible for reading a file
        /// </summary>
        private CSVFileDataReader fileReader;

        /// <summary>
        /// Number of results to show on query
        /// </summary>
        private const byte numResultsToShow = 10;

        private IEnumerable<IStar> allStars;
        private IEnumerable<IPlanet> allPlanets;
        private ICollection<IStar> nonRepeatedStars;

        public Manager()
        {
            //////////////////////////// TEMPORARIO //////////////////////////////////////////////////////////
            planetHeaders = new string[] { "pl_name", "hostname",
                "discoverymethod", "disc_year", "pl_orbper", "pl_rade", "pl_bmasse", "pl_eqt"};
            getPlanets = new ExoplanetsListFromCSVData(planetHeaders);
            starHeaders = new string[] { "hostname", "st_teff", "st_rad",
                "st_mass", "st_age", "st_vsin", "st_rotp", "sy_dist"};
            getStars = new StarsListFromCSVData(starHeaders);
            //////////////////////////// TEMPORARIO //////////////////////////////////////////////////////////

            allStars = new List<IStar>();
            allPlanets = new List<IPlanet>();
            nonRepeatedStars = new List<IStar>(); ;
        }

        /// <summary>
        /// Method responsible for starting the main loop
        /// </summary>
        public void Run()
        {
            string input;
            do
            {
                Program.UI.ChooseAnOptionNoFile();
                switch (input = Program.UI.GetInput())
                {
                    case "new file":
                        // Gets file path and reads the file
                        ReadFile(input);
                        // If it read a file, asks for information
                        if (fileReader != null)
                            ChooseAnOption(input);
                        break;

                    case "quit":
                        break;
                    default:
                        Program.UI.NotValid("Not a valid option");
                        break;
                } 
                
            }while (input != "quit");
            Program.UI.Goodbye();
        }

        /// <summary>
        /// Method that asks the user for an option to run the application
        /// </summary>
        /// <param name="input">Receives string from user input</param>
        private void ChooseAnOption(string input)
        {
            // Creates IPlanet IEnumerable, Creates a list with nonRepeatedStars
            CreateStarsAndPlanets();
            // Search field and list with all planets creation
            AstronomicalObjectCriteria criteria =
                new AstronomicalObjectCriteria();

            do
            {
                // Player chooses an option
                Program.UI.ChooseAnOption();
                switch (input = Program.UI.GetInput())
                {
                    case "planet":
                        SearchPlanet(input, criteria);
                        break;
                    case "star":
                        SearchStar(input, criteria);
                        break;
                    case "back":     
                        // Turns file back to null
                        fileReader = null;  
                        break;
                    default:
                        Program.UI.NotValid("Not a valid option");
                        break;
                }
            } while (input != "back");
        }

        /// <summary>
        /// Method responsible for searching planets in a list
        /// </summary>
        /// <param name="input">Receives string from user input</param>
        private void SearchPlanet(string input,
            AstronomicalObjectCriteria criteria)
        {
            do
            {
                // Number of times the query was shown;
                byte numTimesShown = 0;

                // Shows information and asks for input
                Program.UI.PossibleCriteria(criteria);

                input = Program.UI.GetInput();

                // If user types search, it will search for the criteria
                if (input == "search")
                {
                    do
                    {
                        // Filters planets to show the user input data
                        // Shows 'numResultsToShow' elements at a time
                        IEnumerable<IPlanet> filteredPlanets =
                        (from planet in allPlanets
                         where planet.Name.ToLower().Contains(criteria.PlanetName ?? "any") ||
                                criteria.PlanetName == null || criteria.PlanetName == "any"
                         where planet.ParentStar.Name.ToLower().Contains(criteria.StarName ?? "any") 
                                || criteria.StarName == null || criteria.StarName == "any"
                         where planet.DiscoveryMethod.ToLower().Contains(criteria.DiscoveryMethod ?? "any") 
                                || criteria.DiscoveryMethod == null || criteria.DiscoveryMethod == "any"
                         where planet.DiscoveryYear < criteria.DiscoveryYearMax &&
                                planet.DiscoveryYear > criteria.DiscoveryYearMin
                         select planet).Skip(numResultsToShow * numTimesShown).Take(numResultsToShow);

                        Program.UI.PrintCriteria(filteredPlanets);

                        numTimesShown++;

                        Program.UI.OptionsOnSearchCriteria();
                        input = Program.UI.GetInput();
                    } while (input != "change");
                }

                else if (input == "reset")
                    criteria.ResetFields();

                // If input is in searchable criteria enum
                else if (Enum.TryParse(input.Split(": ")[0].Trim(),
                        out SearchFieldInputs inputEnum))
                {
                    try
                    {
                        // Sets value after the name
                        string userValue = input.Split(": ")[1].Trim();
                        criteria.AddCriteria(inputEnum, userValue);
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Program.UI.NotValid("Invalid criteria");
                    }
                }
                else if (input != "back")
                {
                    Program.UI.NotValid("Invalid criteria");
                }

            } while (input != "back");
        }

        /// <summary>
        /// Method responsible for searching stars in a list
        /// </summary>
        /// <param name="input">Receives string from user input</param>
        private void SearchStar(string input, 
            AstronomicalObjectCriteria criteria)
        {
            
        }

        /// <summary>
        /// Creates IPlanet IEnumerable, Creates a list with nonRepeatedStars
        /// Adds planets to star's child planets
        /// Adds a star as a planet's star parent
        /// </summary>
        private void CreateStarsAndPlanets()
        {
            allStars = getStars.GetCollection(fileReader.FileData)
                as List<Star>;
            allPlanets = getPlanets.GetCollection(fileReader.FileData)
                as List<Exoplanet>;
            nonRepeatedStars = new List<IStar>();
            foreach (IStar star in allStars)
            {
                if (nonRepeatedStars.Contains(star) == false)
                {
                    nonRepeatedStars.Add(star);
                }
            }

            foreach (Exoplanet planet in allPlanets)
            {
                foreach (Star star in nonRepeatedStars)
                {
                    // If the planet has a start with its name
                    // The planet gets added to star's childPlanets
                    // The star gets added as the planet's parent
                    if (planet.ParentStar.Name == star.Name)
                    {
                        star.ChildPlanets.Add(planet);
                        planet.ParentStar = star;
                    }
                }
            }
        }

        /// <summary>
        /// Method responsible for reading a file
        /// </summary>
        /// <param name="input">Receives string from user input</param>
        private void ReadFile(string input)
        {
            do
            {
                // Shows information and asks for input
                Program.UI.AskForAFilePath();
                input = Program.UI.GetInput();

                try
                {
                    fileReader = new CSVFileDataReader(input);
                    Program.UI.FileOpened();
                    break;
                }
                catch (Exception)
                {
                    if (input != "back")
                        Program.UI.InvalidPath();
                }    
            } while (input != "back");
        }
    }
}
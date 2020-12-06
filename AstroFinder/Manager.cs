using System;
using System.Collections.Generic;
using System.Linq;
using AstroFinder.FileReader.Exception;

namespace AstroFinder
{
    /// <summary>
    /// Class responsible for running the application
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// Variable responsible for reading a file
        /// </summary>
        private CSVFileDataReader fileReader;

        /// <summary>
        /// Number of results to show on query
        /// </summary>
        public const byte numResultsToShow = 20;

        /// <summary>
        /// IEnumerable for allplanets
        /// </summary>
        private IEnumerable<IPlanet> allPlanets;

        /// <summary>
        /// IEnumerable for allstars
        /// </summary>
        /// 
        private IEnumerable<IStar> allStars;
        /// <summary>
        /// ICollection for all non repeated stars
        /// </summary>
        private ICollection<IStar> nonRepeatedStars;

        /// <summary>
        /// Constructor for Manager
        /// </summary>
        public Manager()
        {
            allPlanets = new List<IPlanet>();
            allStars = new List<IStar>();
            nonRepeatedStars = new List<IStar>();
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
                        Program.UI.Message("Not a valid option");
                        break;
                }

            } while (input != "quit");
            Program.UI.Goodbye();
        }

        /// <summary>
        /// Method that asks the user for an option to run the application
        /// </summary>
        /// <param name="input">Receives string from user input</param>
        private void ChooseAnOption(string input)
        {
            // Creates new Planets and Stars ///////////////////////////////////
            // Creates headers of interess for the file
            string[] planetHeaders = new string[8] { "pl_name", "hostname",
                "discoverymethod", "disc_year", "pl_orbper", "pl_rade",
                "pl_bmasse", "pl_eqt"};
            string[] starHeaders = new string[8] { "hostname", "st_teff",
                "st_rad", "st_mass", "st_age", "st_vsin", "st_rotp", "sy_dist"};

            // Creates new planets and stars with the headers
            IGetCollectionFromData<string[], List<Star>> getStars =
                new StarsListFromCSVData(starHeaders);
            IGetCollectionFromData<string[], List<Exoplanet>> getPlanets =
                new ExoplanetsListFromCSVData(planetHeaders);
            // /////////////////////////////////////////////////////////////////

            // Searchfield with all searchable criteria
            AstronomicalObjectCriteria criteria =
                new AstronomicalObjectCriteria();


            // Creates IPlanet IEnumerable, Creates a list with nonRepeatedStars
            // Sets star child planets and planet parent stars
            StarPlanetRelation(getPlanets, getStars);

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
                        Program.UI.Message("Not a valid option");
                        break;
                }
            } while (input != "back");
        }

        /// <summary>
        /// Method responsible for searching planets in a list
        /// </summary>
        /// <param name="input">Receives string from user input</param>
        /// <param name="criteria">Receives criteria for search fields</param>
        private void SearchPlanet(string input,
            AstronomicalObjectCriteria criteria)
        {
            IQuery<IPlanet> query = new PlanetQuery(allPlanets);

            // List order
            string order = "defaultorder";
            do
            {
                // Number of times the query was shown;
                ushort numTimesShown = 0;

                // Shows information and asks for input
                Program.UI.PossibleCriteria(criteria, order);

                input = Program.UI.GetInput();

                // If user types search, it will search for the criteria
                if (input == "search")
                {
                    Enum.TryParse(order, out ListOrder listOrder);
                    do
                    {
                        // Prints criteria and options
                        Program.UI.PrintCriteria(query.Order(listOrder,
                                                criteria, numTimesShown));

                        // Prints possible options while inside the criteria
                        // loop.
                        Program.UI.OptionsOnSearchCriteria(numTimesShown, order);

                        numTimesShown++;

                        input = Program.UI.GetInput();

                        // If input == information shows detailed information
                        if (input == "information")
                        {
                            byte counter = 0;
                            do
                            {
                                if (counter > 0)
                                {
                                    input = Program.UI.GetInput();

                                    // Gets the planet the user chose
                                    List<IPlanet> detailedPlanet =
                                        (from body in query.Filter(criteria)
                                         where body.Name.ToLower() == input
                                         select body).ToList();

                                    Program.UI.
                                        PrintDetailedCriteria(detailedPlanet);
                                }
                                Program.UI.OptionsOnDetailedInformation();
                                counter++;

                            } while (input != "list");

                            // The list stays the same
                            numTimesShown--;
                        }

                        // Goes back to previous results
                        else if (numTimesShown > 1)
                        {
                            if (input == "back")
                                numTimesShown -= 2;
                        }

                        // Goes back to user values
                    } while (input != "change");
                }

                // Sets list order
                else if (input == "order")
                {
                    // Prints every field of an enum
                    Program.UI.PrintEnumValues(ListOrder.defaultorder);
                    order = Program.UI.GetInput();
                }

                // Resets every field
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
                        Program.UI.Message("Invalid criteria");
                    }
                }
                else if (input != "back")
                {
                    Program.UI.Message("Invalid criteria");
                }

            } while (input != "back");
        }

        /// <summary>
        /// Method responsible for searching stars in a list
        /// </summary>
        /// <param name="input">Receives string from user input</param>
        /// <param name="criteria">Receives criteria for search fields</param>
        private void SearchStar(string input,
            AstronomicalObjectCriteria criteria)
        {
            IQuery<IStar> query = new StarQuery(allPlanets, nonRepeatedStars);

            string order = "defaultorder";
            do
            {
                // Number of times the query was shown;
                ushort numTimesShown = 0;
                // Shows information and asks for input
                Program.UI.PossibleCriteria(criteria, order);

                input = Program.UI.GetInput();

                // If user types search, it will search for the criteria
                if (input == "search")
                {
                    // 
                    Enum.TryParse(order, out ListOrder listOrder);
                    do
                    {
                        // Prints criteria and options
                        Program.UI.PrintCriteria(query.Order(listOrder,
                                                criteria, numTimesShown));

                        // Prints possible options while inside the criteria
                        // loop.
                        Program.UI.OptionsOnSearchCriteria(numTimesShown, order);

                        numTimesShown++;

                        input = Program.UI.GetInput();

                        // If input == information shows detailed information
                        if (input == "information")
                        {
                            byte counter = 0;
                            do
                            {
                                if (counter > 0)
                                {
                                    input = Program.UI.GetInput();

                                    // Gets the planet the user chose
                                    List<IStar> detailedStar =
                                        (from star in query.Filter(criteria)
                                         where star.Name.ToLower() == input
                                         select star).ToList();

                                    Program.UI.
                                        PrintDetailedCriteria(detailedStar);
                                }
                                Program.UI.OptionsOnDetailedInformation();
                                counter++;

                            } while (input != "list");
                            // The list stays the same
                            numTimesShown--;
                        }

                        // Goes back to previous results
                        else if (numTimesShown > 1)
                        {
                            if (input == "back")
                                numTimesShown -= 2;
                        }

                        // Goes back to user values
                    } while (input != "change");
                }

                // Sets list order
                else if (input == "order")
                {
                    // Prints every field of an enum
                    Program.UI.PrintEnumValues(ListOrder.defaultorder);
                    order = Program.UI.GetInput();
                }

                // Resets every field
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
                        Program.UI.Message("Invalid criteria");
                    }
                }
                else if (input != "back")
                {
                    Program.UI.Message("Invalid criteria");
                }

            } while (input != "back");
        }

        /// <summary>
        /// Creates allplanets and allstars
        /// Adds planets to star's child planets
        /// Adds a star as a planet's star parent
        /// </summary>
        /// <param name="getPlanets">Collection with all planets</param>
        /// <param name="getStars">Collection with all stars</param>
        private void StarPlanetRelation(
            IGetCollectionFromData<string[], List<Exoplanet>> getPlanets,
            IGetCollectionFromData<string[], List<Star>> getStars
            )
        {
            allPlanets = getPlanets.GetCollection(fileReader.FileData)
                    as List<Exoplanet>;

            allStars = getStars.GetCollection(fileReader.FileData)
                    as List<Star>;

            // Creates a list with all non repeated stars
            nonRepeatedStars = new List<IStar>();
            foreach (IStar star in allStars)
            {
                if (nonRepeatedStars.Contains(star) == false)
                {
                    nonRepeatedStars.Add(star);
                }
            }

            // Adds planets to star's child planets
            // Adds a star as a planet's star parent
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

            string[] mandatoryHeaders = new string[2] { "pl_name", "hostname" };
            do
            {
                // Shows information and asks for input
                Program.UI.AskForAFilePath();
                input = Program.UI.GetInput();

                try
                {
                    fileReader = new CSVFileDataReader(input, mandatoryHeaders);
                    Program.UI.FileOpened();
                    break;
                }
                catch (MissingHeaderOnCSVFileException)
                {
                    if (input != "back")
                    {
                        System.Console.Clear();
                        System.Console.WriteLine("Falta header!");
                    }
                }
                catch (FileEmptyException)
                {
                    if (input != "back")
                        System.Console.WriteLine("Ficheiro tá vazio!");
                }
                catch (System.IO.FileNotFoundException)
                {
                    if (input != "back")
                        System.Console.WriteLine("Ficheiro não existe!");
                }
                // catch (Exception)
                // {
                //     if (input != "back")
                        // Program.UI.InvalidPath();
                // }
            } while (input != "back");
        }
    }
}
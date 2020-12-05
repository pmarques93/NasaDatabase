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
        /// <summary>
        /// Variable responsible for reading a file
        /// </summary>
        private CSVFileDataReader fileReader;

        /// <summary>
        /// Number of results to show on query
        /// </summary>
        const byte numResultsToShow = 10;

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
            string[] planetHeaders = new string[] { "pl_name", "hostname",
                "discoverymethod", "disc_year", "pl_orbper", "pl_rade",
                "pl_bmasse", "pl_eqt"};
            string []starHeaders = new string[] { "hostname", "st_teff", 
                "st_rad", "st_mass", "st_age", "st_vsin", "st_rotp", "sy_dist"};

            // Creates new planets and stars with the headers
            IGetCollectionFromData<string[], List<Star>> getStars = 
                new StarsListFromCSVData(starHeaders);
            IGetCollectionFromData<string[], List<Exoplanet>> getPlanets =
                new ExoplanetsListFromCSVData(planetHeaders);
            ////////////////////////////////////////////////////////////////////

            // Searchfield with all searchable criteria
            AstronomicalObjectCriteria criteria =
                new AstronomicalObjectCriteria();

            // Creates 3 empty lists
            IEnumerable<IPlanet> allPlanets = new List<IPlanet>();
            IEnumerable<IStar> allStars = new List<IStar>();
            ICollection<IStar> nonRepeatedStars = new List<IStar>();

            // Creates IPlanet IEnumerable, Creates a list with nonRepeatedStars
            // Sets star child planets and planet parent stars
            StarPlanetRelation(getPlanets, getStars, allPlanets, allStars,
                                nonRepeatedStars);

            Console.WriteLine(allPlanets.Count());
            do
            {
                // Player chooses an option
                Program.UI.ChooseAnOption();
                switch (input = Program.UI.GetInput())
                {
                    case "planet":
                        SearchPlanet(input, criteria, allPlanets);
                        break;
                    case "star":
                        SearchStar(input, criteria, allPlanets, 
                                    nonRepeatedStars);
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
        /// <param name="allPlanets">All planets to filter on query</param>
        private void SearchPlanet(string input,
            AstronomicalObjectCriteria criteria,
            IEnumerable<IPlanet> allPlanets)
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
                    IEnumerable<IPlanet> orderedPlanets =
                            new List<IPlanet>();
                    Enum.TryParse(order, out ListOrder listOrder);
                    do
                    {
                        // Switch with Ordererd planets
                        switch (listOrder)
                        {
                            case ListOrder.ascendingname:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                orderby planet.Name ascending
                                 select planet).
                                ThenBy(p => p.DiscoveryYear).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingname:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.Name descending
                                 select planet).
                                ThenBy(p => p.DiscoveryYear).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstarname:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.Name ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstarname:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.Name descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingdiscoverymethod:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.DiscoveryMethod ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingdiscoverymethod:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.DiscoveryMethod descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingdiscoveryyear:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.DiscoveryYear ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingdiscoveryyear:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.DiscoveryYear descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingorbitalperiod:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.OrbitalPeriod ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingorbitalperiod:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.OrbitalPeriod descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingplanetradius:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.PlanetRadius ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingplanetradius:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.PlanetRadius descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingplanetmass:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.PlanetMass ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingplanetmass:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.PlanetMass descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingplanettemperature:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.PlanetTemperature ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingplanettemperature:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.PlanetTemperature descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellartemperature:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.StellarTemperature
                                 ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellartemperature:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.StellarTemperature
                                 descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarradius:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.StellarRadius
                                 ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarradius:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.StellarRadius
                                 descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarmass:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.StellarMass
                                 ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarmass:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.StellarMass
                                 descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarage:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.StellarAge
                                 ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarage:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.StellarAge
                                 descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarrotationvelocity:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.
                                        StellarRotationVelocity ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarrotationvelocity:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.
                                        StellarRotationVelocity descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarrotationperiod:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.
                                        StellarRotationPeriod ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarrotationperiod:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.
                                        StellarRotationPeriod descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingdistance:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.Distance ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingdistance:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.Distance descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingchildplanets:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.ChildPlanets
                                 ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingchildplanets:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 orderby planet.ParentStar.ChildPlanets
                                 descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            default:
                                orderedPlanets =
                                (from planet in query.Filter(criteria)
                                 select planet).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                        }

                        // Prints criteria and options
                        Program.UI.PrintCriteria(orderedPlanets);
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
                                        (from planet in query.Filter(criteria)
                                         where planet.Name.ToLower() == input
                                         select planet).ToList();

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
        /// <param name="allPlanets">Receives IEnumerable with all planets</param>
        private void SearchStar(string input,
            AstronomicalObjectCriteria criteria,
            IEnumerable<IPlanet> allPlanets,
            ICollection<IStar> nonRepeatedStars)
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
                    IEnumerable<IStar> orderedStars =
                            new List<IStar>();
                    Enum.TryParse(order, out ListOrder listOrder);
                    do
                    {
                        // Switch with Ordererd planets
                        switch (listOrder)
                        {
                            case ListOrder.ascendingname:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.Name ascending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingname:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.Name descending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstarname:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.ParentStar.Name ascending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstarname:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.ParentStar.Name descending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingdiscoverymethod:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.DiscoveryMethod ascending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingdiscoverymethod:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.DiscoveryMethod descending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingdiscoveryyear:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.DiscoveryYear ascending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingdiscoveryyear:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.DiscoveryYear descending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingorbitalperiod:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.OrbitalPeriod ascending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingorbitalperiod:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.OrbitalPeriod descending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingplanetradius:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.PlanetRadius ascending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingplanetradius:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.PlanetRadius descending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingplanetmass:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.PlanetMass ascending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingplanetmass:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.PlanetMass descending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingplanettemperature:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.PlanetTemperature ascending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingplanettemperature:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 join planet in allPlanets
                                 on star.Name equals planet.ParentStar.Name
                                 orderby planet.PlanetTemperature descending
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellartemperature:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.StellarTemperature
                                 ascending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellartemperature:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.StellarTemperature
                                 descending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarradius:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.StellarRadius
                                 ascending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarradius:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.StellarRadius
                                 descending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarmass:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.StellarMass
                                 ascending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarmass:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.StellarMass
                                 descending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarage:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.StellarAge
                                 ascending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarage:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.StellarAge
                                 descending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarrotationvelocity:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.
                                        StellarRotationVelocity ascending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarrotationvelocity:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.
                                        StellarRotationVelocity descending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarrotationperiod:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.
                                        StellarRotationPeriod ascending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarrotationperiod:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.
                                        StellarRotationPeriod descending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingdistance:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.Distance ascending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingdistance:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.Distance descending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingchildplanets:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.ChildPlanets
                                 ascending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingchildplanets:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 orderby star.ChildPlanets
                                 descending
                                 select star).
                                 ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            default:
                                orderedStars =
                                (from star in query.Filter(criteria)
                                 select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                        }

                        // Prints criteria and options
                        Program.UI.PrintCriteria(orderedStars);
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
        /// Creates IPlanet IEnumerable, Creates a list with nonRepeatedStars
        /// Adds planets to star's child planets
        /// Adds a star as a planet's star parent
        /// </summary>
        private void StarPlanetRelation(
            IGetCollectionFromData<string[], List<Exoplanet>> getPlanets,
            IGetCollectionFromData<string[], List<Star>> getStars,
            IEnumerable<IPlanet> allPlanets,
            IEnumerable<IStar> allStars,
            ICollection<IStar> nonRepeatedStars
            )
        {
            allPlanets = getPlanets.GetCollection(fileReader.FileData)
                    as List<Exoplanet>;
            Console.WriteLine(allPlanets.Count());
            allStars = getStars.GetCollection(fileReader.FileData)
                    as List<Star>;
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
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
                        Program.UI.Message("Not a valid option");
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
            // List order
            string order = null;
            do
            {
                // Number of times the query was shown;
                ushort numTimesShown = 0;

                // Shows information and asks for input
                Program.UI.PossibleCriteria(criteria);

                input = Program.UI.GetInput();


                #region filteredPlanets
                // Filters planets to show the user input data only
                // Shows 'numResultsToShow' elements at a time
                IEnumerable<IPlanet> filteredPlanets =
                from planet in allPlanets
                where planet.Name.ToLower().Contains(
                   criteria.PlanetName ?? "any") ||
                   criteria.PlanetName == null ||
                   criteria.PlanetName == "any"
                where planet.ParentStar.Name.ToLower().Contains(
                    criteria.StarName ?? "any") ||
                    criteria.StarName == null ||
                    criteria.StarName == "any"
                where planet.DiscoveryMethod.ToLower().Contains(
                    criteria.DiscoveryMethod ?? "any") ||
                    criteria.DiscoveryMethod == null ||
                    criteria.DiscoveryMethod == "any"
                where planet.DiscoveryYear <=
                       criteria.DiscoveryYearMax &&
                       planet.DiscoveryYear >=
                       criteria.DiscoveryYearMin ||
                       planet.DiscoveryYear == null
                where planet.OrbitalPeriod <=
                       criteria.OrbitalPeriodMax &&
                       planet.OrbitalPeriod >=
                       criteria.OrbitalPeriodMin ||
                       planet.OrbitalPeriod == null
                where planet.PlanetRadius <=
                       criteria.PlanetRadiusMax &&
                       planet.PlanetRadius >=
                       criteria.PlanetRadiusMin ||
                       planet.PlanetRadius == null
                where planet.PlanetMass <=
                       criteria.PlanetMassMax &&
                       planet.PlanetMass >=
                       criteria.PlanetMassMin ||
                       planet.PlanetMass == null
                where planet.PlanetTemperature <=
                       criteria.PlanetTemperatureMax &&
                       planet.PlanetTemperature >=
                       criteria.PlanetTemperatureMin ||
                       planet.PlanetTemperature == null
                where planet.ParentStar.StellarTemperature <=
                       criteria.StellarTemperatureMax &&
                       planet.ParentStar.StellarTemperature >=
                       criteria.StellarTemperatureMin ||
                       planet.ParentStar.StellarTemperature == null
                where planet.ParentStar.StellarRadius <=
                       criteria.StellarRadiusMax &&
                       planet.ParentStar.StellarRadius >=
                       criteria.StellarRadiusMin ||
                       planet.ParentStar.StellarRadius == null
                where planet.ParentStar.StellarMass <=
                       criteria.StellarMassMax &&
                       planet.ParentStar.StellarMass >=
                       criteria.StellarMassMin ||
                       planet.ParentStar.StellarMass == null
                where planet.ParentStar.StellarAge <=
                       criteria.StellarAgeMax &&
                       planet.ParentStar.StellarAge >=
                       criteria.StellarAgeMin ||
                       planet.ParentStar.StellarAge == null
                where planet.ParentStar.StellarRotationVelocity <=
                       criteria.StellarRotationVelocityMax &&
                       planet.ParentStar.StellarRotationVelocity >=
                       criteria.StellarRotationVelocityMin ||
                       planet.ParentStar.StellarRotationVelocity == null
                where planet.ParentStar.StellarRotationPeriod <=
                       criteria.StellarRotationPeriodMax &&
                       planet.ParentStar.StellarRotationPeriod >=
                       criteria.StellarRotationPeriodMin ||
                       planet.ParentStar.StellarRotationPeriod == null
                where planet.ParentStar.Distance <=
                       criteria.DistanceMax &&
                       planet.ParentStar.Distance >=
                       criteria.DistanceMin ||
                       planet.ParentStar.Distance == null
                where planet.ParentStar.ChildPlanets.Count <=
                       criteria.ChildPlanetsMax &&
                       planet.ParentStar.ChildPlanets.Count >=
                       criteria.ChildPlanetsMin
                select planet;
                #endregion

                // If user types search, it will search for the criteria
                if (input == "search")
                {
                    IEnumerable<IPlanet> orderedPlanets =
                            new List<IPlanet>();
                    Enum.TryParse(order, out ListOrder listOrder);
                    do
                    {
                        #region SwitchWithListOrder
                        // Ordererd planets
                        switch (listOrder)
                        {
                            case ListOrder.ascendingname:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.Name ascending
                                 select planet).
                                ThenBy(p => p.DiscoveryYear).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingname:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.Name descending
                                 select planet).
                                ThenBy(p => p.DiscoveryYear).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstarname:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.Name ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstarname:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.Name descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingdiscoverymethod:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.DiscoveryMethod ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingdiscoverymethod:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.DiscoveryMethod descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingdiscoveryyear:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.DiscoveryYear ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingdiscoveryyear:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.DiscoveryYear descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingorbitalperiod:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.OrbitalPeriod ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingorbitalperiod:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.OrbitalPeriod descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingplanetradius:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.PlanetRadius ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingplanetradius:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.PlanetRadius descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingplanetmass:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.PlanetMass ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingplanetmass:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.PlanetMass descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingplanettemperature:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.PlanetTemperature ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingplanettemperature:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.PlanetTemperature descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellartemperature:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.StellarTemperature 
                                 ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellartemperature:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.StellarTemperature 
                                 descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarradius:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.StellarRadius
                                 ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarradius:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.StellarRadius
                                 descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarmass:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.StellarMass
                                 ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarmass:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.StellarMass
                                 descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarage:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.StellarAge
                                 ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarage:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.StellarAge
                                 descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarrotationvelocity:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.
                                        StellarRotationVelocity ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarrotationvelocity:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.
                                        StellarRotationVelocity descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingstellarrotationperiod:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.
                                        StellarRotationPeriod ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingstellarrotationperiod:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.
                                        StellarRotationPeriod descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingdistance:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.Distance ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingdistance:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar. Distance descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.ascendingchildplanets:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.ChildPlanets 
                                 ascending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            case ListOrder.descendingchildplanets:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 orderby planet.ParentStar.ChildPlanets 
                                 descending
                                 select planet).
                                ThenBy(p => p.Name).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                            default:
                                orderedPlanets =
                                (from planet in filteredPlanets
                                 select planet).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);
                                break;
                        }
                        #endregion

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
                                        (from planet in filteredPlanets
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
        private void SearchStar(string input, 
            AstronomicalObjectCriteria criteria)
        {
            string order = null;
            do
            {
                // Number of times the query was shown;
                ushort numTimesShown = 0;

                // Shows information and asks for input
                Program.UI.PossibleCriteria(criteria);

                input = Program.UI.GetInput();

                // If user types search, it will search for the criteria
                if (input == "search")
                {
                    do
                    {
                        // Filters planets to show the user input data only
                        // Shows 'numResultsToShow' elements at a time
                        IEnumerable<IStar> filteredStars =
                        (from star in nonRepeatedStars
                         where star.Name.ToLower().Contains(
                            criteria.StarName ?? "any") ||
                            criteria.StarName == null ||
                            criteria.StarName == "any"

                         where star.StellarTemperature <=
                                criteria.StellarTemperatureMax &&
                                star.StellarTemperature >=
                                criteria.StellarTemperatureMin ||
                                star.StellarTemperature == null
                         where star.StellarRadius <=
                                criteria.StellarRadiusMax &&
                                star.StellarRadius >=
                                criteria.StellarRadiusMin ||
                                star.StellarRadius == null
                         where star.StellarMass <=
                                criteria.StellarMassMax &&
                                star.StellarMass >=
                                criteria.StellarMassMin ||
                                star.StellarMass == null
                         where star.StellarAge <=
                                criteria.StellarAgeMax &&
                                star.StellarAge >=
                                criteria.StellarAgeMin ||
                                star.StellarAge == null
                         where star.StellarRotationVelocity <=
                                criteria.StellarRotationVelocityMax &&
                                star.StellarRotationVelocity >=
                                criteria.StellarRotationVelocityMin ||
                                star.StellarRotationVelocity == null
                         where star.StellarRotationPeriod <=
                                criteria.StellarRotationPeriodMax &&
                                star.StellarRotationPeriod >=
                                criteria.StellarRotationPeriodMin ||
                                star.StellarRotationPeriod == null
                         where star.Distance <=
                                criteria.DistanceMax &&
                                star.Distance >=
                                criteria.DistanceMin ||
                                star.Distance == null
                         where star.ChildPlanets.Count <=
                                criteria.ChildPlanetsMax &&
                                star.ChildPlanets.Count >=
                                criteria.ChildPlanetsMin
                         select star).
                                Skip(numResultsToShow * numTimesShown).
                                Take(numResultsToShow);

                        // Prints criteria and options
                        Program.UI.PrintCriteria(filteredStars);
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
                                        (from star in filteredStars
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
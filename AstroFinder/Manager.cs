using System;
using System.IO;
using System.Collections.Generic;

namespace AstroFinder
{
    public class Manager
    {
        private UserInterface UI;

        private FileReader fileReader;
        
        private SearchCriteria searchCriteria;

        public Manager()
        {
            UI = new UserInterface();
        }

        public void Run()
        {
            string input = null;

            while (input != "quit" && ReadFile(input) != "quit")
            {
                fileReader = null;

                // Gets file path and reads the file
                ReadFile(input);

                // If it read a file, asks for information
                if (fileReader != null)
                {
                    while (input != "quit" && input != "new file")
                    {
                        UI.ChooseAnOption();

                        // Chooses an option
                        switch (input = UI.GetInput())
                        {
                            case "planet":
                                SearchPlanet(input);
                                break;
                            case "star":

                                break;
                            case "new file":
                                break;
                            case "quit":       
                                break;
                            default:
                                UI.NotValid();
                                break;
                        }
                    } 
                }
            } 
        }

        // Planet data to search
        private void SearchPlanet(string input)
        {
            List<Exoplanet> exoplanets = fileReader.CSVtoList();
            searchCriteria = new SearchCriteria();
            do
            {
                // Asks for input
                UI.PossibleCriteria(searchCriteria);
                input = UI.GetInput();

                // If user types search, it will search for the criteria
                if (input == "search")
                {

                    // Gabriel magic //
                    ///////////////////
                }
                // If input is in inputs enum
                else if (Inputs.TryParse(input.Split(": ")[0].Trim(), 
                        out Inputs temp))
                {
                    string trimmedInput = input.Split(": ")[0].Trim();
                    try
                    {
                        switch (trimmedInput)
                        {
                            case "pl_name":
                                searchCriteria.PlanetName = Convert.
                                        ToString(input.Split(": ")[1]).Trim();

                                break;
                            case "hostname":
                                searchCriteria.HostName = Convert.
                                        ToString(input.Split(": ")[1]).Trim();

                                break;
                            case "discoverymethod":
                                searchCriteria.Discoverymethod = Convert.
                                        ToString(input.Split(": ")[1]).Trim();

                                break;
                            case "disc_year":
                                try{
                                    if (input.Substring(
                                        input.IndexOf("min"), 3) == "min")
                                    {
                                        searchCriteria.DiscoveryYearMin = 
                                        Convert.ToUInt16(input.Split(" ")[2]);
                                    }
                                }catch{
                                    try{
                                        if (input.Substring(
                                            input.IndexOf("max"), 3) == "max")
                                        {
                                            searchCriteria.DiscoveryYearMax = 
                                            Convert. ToUInt16(
                                            input.Split(" ")[2]);
                                        }
                                    }catch{}
                                }
                                break;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        UI.InvalidCriteria();
                    }
                    catch (ArgumentException)
                    {
                        UI.InvalidCriteria();
                    }
                    catch (FormatException)
                    {
                        UI.InvalidCriteria();
                    }
                    catch (StackOverflowException)
                    {
                        Console.WriteLine("Insert a positive number");
                    }
                    finally
                    {
                        UI.CurrentlySearchingFor(searchCriteria);
                    }
                }
                else if (input != "back")
                {
                    UI.InvalidCriteria();
                }

            } while (input != "back");
        }


        // Reads player input and adds a file's path
        private string ReadFile(string input)
        {
            do
            {
                UI.InitialInformation();
                input = UI.GetInput();

                try
                {
                    fileReader = new FileReader(input);
                    UI.FileOpened();
                    break;
                }
                catch (FileNotFoundException)
                {
                    if (input != "quit")
                        UI.InvalidPath();
                }    
            } while (input != "quit");

            if (input == "quit")
                UI.Goodbye();

            return input;
        }
    }
}
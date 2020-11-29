using System;
using System.IO;
using System.Collections.Generic;

namespace AstroFinder
{
    public class Manager
    {
        private UserInterface UI;
        private FileReader fileReader;

        private List<Exoplanet> exoplanets;
        public Dictionary<string, string> SearchCriteria { get; private set; }
        public Manager()
        {
            UI = new UserInterface();
            SearchCriteria = new Dictionary<string, string>();
        }

        public void Run()
        {
            string input = null;

            // Gets file path and reads the file
            ReadFile();

            // If it read a file, asks for information
            if (fileReader != null)
            {
                do
                {
                    UI.ChooseAnOption();
                    ChooseAnOption(input = UI.GetInput());
                } while (input != "quit");
            }
        }

        // Chooses an option to search
        public void ChooseAnOption(string input)
        {
            switch (input)
            {
                case "planet":
                    exoplanets = fileReader.CSVtoList();
                    SearchPlanet();
                    break;
                case "star":

                    break;
                case "quit":
                    UI.Goodbye();
                    break;
                default:
                    UI.NotValid();
                    break;
            }
        }

        // Planet data to search
        private void SearchPlanet()
        {
            string input = null;
            do
            {
                // Asks for input
                UI.ChoosePlanet();
                input = UI.GetInput();

                // If user types search, it will search for the criteria
                if (input == "search")
                {

                    // Gabriel magic //
                    ///////////////////

                    UI.PrintDictionary(SearchCriteria);
                }
                // If input is in inputs enum
                else if (Inputs.TryParse(input.Split(':')[0].Trim(), 
                        out Inputs temp))
                {
                    try
                    {
                        // If input value is a string
                        if (Inputs.Strings.HasFlag(temp))
                        {
                            // Adds first input as key and the rest as value
                            SearchCriteria[input.Split(':')[0].Trim()] = 
                            input.Split(": ")[1];
                        }
                        else
                        {
                            Console.WriteLine("teste");
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
                    finally
                    {
                        UI.PrintDictionary(SearchCriteria);
                    }
                }
                else if (input != "back")
                {
                    UI.InvalidCriteria();
                }

            } while (input != "back");
        }


        // Reads player input and adds a file's path
        private void ReadFile()
        {
            string input;
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
        }
    }
}
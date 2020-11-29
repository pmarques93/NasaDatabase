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
        

        private string pl_name, hostname, discoverymethod;
        int disc_year;
        public object[] SearchCriteria {get;}


        public Manager()
        {
            UI = new UserInterface();
            
            SearchCriteria = new object[]
            {
                pl_name, hostname, discoverymethod, disc_year
            };
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
                    string trimmedInput = input.Split(':')[0].Trim();
                    try
                    {
                        switch (trimmedInput)
                        {
                            case "pl_name":
                                pl_name = Convert.ToString(input.Split(": ")[1]);
                                break;
                            case "hostname":
                                hostname = Convert.ToString(input.Split(": ")[1]);
                            break;
                            case "discoverymethod":
                                discoverymethod = Convert.ToString(input.Split(": ")[1]);
                            break;
                            case "disc_year":
                                disc_year = Convert.ToInt32(input.Split(": ")[1]);
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
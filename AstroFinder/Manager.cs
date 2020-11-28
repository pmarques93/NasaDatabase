using System.Collections.Generic;
using System;
using System.IO;

namespace AstroFinder
{
    public class Manager
    {
        private UserInterface UI;
        private FileReader fileReader;

        private List<Exoplanet> exoplanets;
        public Dictionary<string, string> SearchCriteria {get; private set;}
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

            if (File.Exists(fileReader.path))
            {
                // Asks for information
                do
                {
                    UI.ChooseAnOption();
                    input = UI.GetInput();
                    ChooseAnOption(input);
                } while(input.ToLower() != "quit");
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
                UI.ChoosePlanet(input);
                input = UI.GetInput();

                // If user types search, it will search for the criteria
                if (input == "search")
                {
                    
                    // print with criteria

                    UI.PrintDictionary(SearchCriteria);
                }
                // If input is in inputs enum
                else if (Inputs.TryParse(input.Split()[0], out Inputs temp))
                {
                    try
                    {
                        // Adds input to search critera
                        SearchCriteria[input.Split()[0]] = input.Split()[1];
                    }catch (IndexOutOfRangeException)
                    {
                        UI.InvalidCriteria();
                    }catch (ArgumentException)
                    {
                        UI.InvalidCriteria();
                    }finally
                    {
                        UI.PrintDictionary(SearchCriteria);
                    }
                }
                else if (input != "back")
                {
                    UI.InvalidCriteria();
                }            

            } while(input != "back"); 
        }


        // Reads player input and adds a file's path
        private void ReadFile()
        {
            string input;
            do
            {
                UI.InitialInformation();
                input = UI.GetInput();

                UI.Print(this);
                fileReader = new FileReader(input);
                if (File.Exists(fileReader.path))
                {
                    UI.FileOpened();
                }
                else
                {
                    if (input != "quit")
                        UI.InvalidPath();
                }
                    
            } while(File.Exists(fileReader.path) == false &&
                    input != "quit");

            if (input == "quit")
                UI.Goodbye();
        }
    }
}
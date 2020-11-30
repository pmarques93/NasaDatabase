using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace AstroFinder
{
    public class Manager
    {
        private UserInterface UI;

        private FileReader fileReader;
        
        public Manager()
        {
            UI = new UserInterface();
        }

        public void Run()
        {
            string input = null;
            
            do
            {
                UI.ChooseAnOptionNoFile();
                switch (input = UI.GetInput())
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
                        UI.NotValid();
                        break;
                } 
                
            }while (input != "quit");
            UI.Goodbye();
        }

        private void ChooseAnOption(string input)
        {
            // Chooses an option
            do
            {
                UI.ChooseAnOption();
                switch (input = UI.GetInput())
                {
                    case "planet":
                        SearchPlanet(input);
                        break;
                    case "star":

                        break;
                    case "back":     
                        fileReader = null;  
                        break;
                    default:
                        UI.NotValid();
                        break;
                }
            } while (input != "back");
        }

        // Planet data to search
        private void SearchPlanet(string input)
        {
            List<Exoplanet> exoplanets = fileReader.CSVtoList();
            SearchCriteria searchCriteria = new SearchCriteria();
            do
            {
                // Asks for input
                UI.PossibleCriteria(searchCriteria);
                input = UI.GetInput();

                // If user types search, it will search for the criteria
                if (input == "search")
                {

                    // SEARCH
                    
                }
                // If input is in inputs enum
                else if (Inputs.TryParse(input.Split(": ")[0].Trim(), 
                        out Inputs outInputEnum))
                {
                    // Sets value after the name
                    string userValue = input.Split(": ")[1].Trim();
                    searchCriteria.AddCriteria(outInputEnum, userValue);  
                }
                else if (input != "back")
                {
                    UI.InvalidCriteria();
                }

            } while (input != "back");
        }


        // Reads player input and adds a file's path
        private void ReadFile(string input)
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
                    if (input != "back")
                        UI.InvalidPath();
                }    
            } while (input != "back");
        }
    }
}
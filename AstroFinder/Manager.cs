using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace AstroFinder
{
    /// <summary>
    /// Class responsible for running the application
    /// </summary>
    public class Manager
    {
        // FILE VARIABLE //////////////////////////////////
        //private FileReader fileReader;
   

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
                        //if (fileReader != null)
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
            do
            {
                // Player chooses an option
                Program.UI.ChooseAnOption();
                switch (input = Program.UI.GetInput())
                {
                    case "planet":
                        SearchPlanet(input);
                        break;
                    case "star":
                        SearchStar(input);
                        break;
                    case "back":     
                        // FILE VARIABLE //////////////////
                        //fileReader = null;  
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
        private void SearchPlanet(string input)
        {
            ISearchField exoplanetCriteria = new AstronomicalObjectCriteria();
            do
            {
                // Shows information and asks for input
                Program.UI.PossibleCriteria(exoplanetCriteria);
                input = Program.UI.GetInput();

                // If user types search, it will search for the criteria
                if (input == "search")
                {

                    // SEARCH
                    
                }
                // If input is in inputs enum
                else if (Enum.TryParse(input.Split(": ")[0].Trim(), 
                        out SearchFieldInputs inputEnum))
                {
                    try
                    {
                        // Sets value after the name
                        string userValue = input.Split(": ")[1].Trim();
                        exoplanetCriteria.AddCriteria(inputEnum, userValue);
                    } catch (IndexOutOfRangeException)
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
        private void SearchStar(string input)
        {
            ISearchField starCriteria = new AstronomicalObjectCriteria();
            do
            {
                // Shows information and asks for input
                Program.UI.PossibleCriteria(starCriteria);
                input = Program.UI.GetInput();

                // If user types search, it will search for the criteria
                if (input == "search")
                {

                    // SEARCH

                }
                // If input is in inputs enum
                else if (Enum.TryParse(input.Split(": ")[0].Trim(),
                        out SearchFieldInputs inputEnum))
                {
                    try
                    {
                        // Sets value after the name
                        string userValue = input.Split(": ")[1].Trim();
                        starCriteria.AddCriteria(inputEnum, userValue);
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
                    // FILE READER VARIABLE ////////////////////////
                    //fileReader = new FileReader(input);
                    Program.UI.FileOpened();
                    break;
                }
                catch (FileNotFoundException)
                {
                    if (input != "back")
                        Program.UI.InvalidPath();
                }    
            } while (input != "back");
        }
    }
}
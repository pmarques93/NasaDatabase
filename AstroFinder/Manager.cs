using System.Collections.Generic;
using System;

namespace AstroFinder
{
    public class Manager
    {
        private UserInterface UI;

        public List<string> SearchCriteria {get; private set;}
        public Manager()
        {
            UI = new UserInterface();
            SearchCriteria = new List<String>();
        }

        public void Run()
        {
            string input = null;

            // Gets file path and reads the file
            ReadFile();

            // Asks for information
            do
            {
                UI.ChooseAnOption();
                input = UI.GetInput();
                ChooseAnOption(input);
            } while(input.ToLower() != "quit");
        }

        // Chooses an option to search
        public void ChooseAnOption(string input)
        {
            switch (input)
            {
                case "planet":
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
            string input;
            do
            {
                UI.ChoosePlanet();
                input = UI.GetInput();

                // If input is in inputs enum
                if (Inputs.TryParse(input, out Inputs temp))
                {
                    // Adds input to search critera
                    SearchCriteria.Add(input);
                }
            
                

            } while(input.ToLower() != "back");
        }


        // Reads player input and adds a file's path
        private void ReadFile()
        {
            string input;
            do
            {
                UI.InitialInformation();
                input = UI.GetInput();
                FileReader.filePath = input;
            } while(input == null);

            UI.FileOpened();
        }
    }
}
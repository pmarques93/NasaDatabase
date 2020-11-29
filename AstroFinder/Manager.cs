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
                        break;
                    default:
                        UI.NotValid();
                        break;
                }
            } while (input != "file" && input != "back");
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
                    try
                    {
                        switch (temp)
                        {
                            case Inputs.planetname:
                                searchCriteria.PlanetName = Convert.
                                        ToString(input.Split(": ")[1]).Trim();
                                break;

                            case Inputs.hostname:
                                searchCriteria.HostName = Convert.
                                        ToString(input.Split(": ")[1]).Trim();
                                break;

                            case Inputs.discoverymethod:
                                searchCriteria.Discoverymethod = Convert.
                                        ToString(input.Split(": ")[1]).Trim();
                                break;

                            case Inputs.discoveryyearmin:
                                try{
                                    searchCriteria.DiscoveryYearMin = 
                                    Convert.ToUInt16
                                    (input.Split(": ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;

                            case Inputs.discoveryyearmax:
                                try{
                                searchCriteria.DiscoveryYearMax = 
                                    Convert.ToUInt16
                                    (input.Split(": ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;

                            case Inputs.orbitalperiodmin:
                                try{
                                searchCriteria.OrbitalPeriodMin = 
                                    Convert.ToUInt32
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;

                            case Inputs.orbitalperiodmax:
                                try{
                                searchCriteria.OrbitalPeriodMax = 
                                    Convert.ToUInt32
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;

                            case Inputs.planetradiusmin:
                                try{
                                searchCriteria.PlanetRadiusMin = 
                                    Convert.ToByte
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            
                            case Inputs.planetradiusmax:
                                try{
                                searchCriteria.PlanetRadiusMax = 
                                    Convert.ToByte
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            case Inputs.planetmassmin:
                                try{
                                searchCriteria.PlanetMassMin = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            
                            case Inputs.planetmassmax:
                                try{
                                searchCriteria.PlanetMassMax = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            case Inputs.planettemperaturemin:
                                try{
                                searchCriteria.PlanetTemperatureMin = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            
                            case Inputs.planettemperaturemax:
                                try{
                                searchCriteria.PlanetTemperatureMax = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            case Inputs.stellartemperaturemin:
                                try{
                                searchCriteria.StellarTemperatureMin = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            
                            case Inputs.stellartemperaturemax:
                                try{
                                searchCriteria.StellarTemperatureMax = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            case Inputs.stellarradiusmin:
                                try{
                                searchCriteria.StellarRadiusMin = 
                                    Convert.ToByte
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            
                            case Inputs.stellarradiusmax:
                                try{
                                searchCriteria.StellarRadiusMax = 
                                    Convert.ToByte
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            case Inputs.stellarmassmin:
                                try{
                                searchCriteria.StellarMassMin = 
                                    Convert.ToByte
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            
                            case Inputs.stellarmassmax:
                                try{
                                searchCriteria.StellarMassMax = 
                                    Convert.ToByte
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;

                            case Inputs.stellaragemin:
                                try{
                                searchCriteria.StellarAgeMin = 
                                    Convert.ToByte
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            
                            case Inputs.stellaragemax:
                                try{
                                searchCriteria.StellarAgeMax = 
                                    Convert.ToByte
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;

                            case Inputs.stellarrotationvelocitymin:
                                try{
                                searchCriteria.StellarRotationVelocityMin = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            
                            case Inputs.stellarrotationvelocitymax:
                                try{
                                searchCriteria.StellarRotationVelocityMax = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            
                            case Inputs.stellarrotationperiodmin:
                                try{
                                searchCriteria.StellarRotationPeriodMin = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            
                            case Inputs.stellarrotationperiodmax:
                                try{
                                searchCriteria.StellarRotationPeriodMax = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;

                            case Inputs.distancemin:
                                try{
                                searchCriteria.DistanceMin = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                            
                            case Inputs.distancemax:
                                try{
                                searchCriteria.DistanceMax = 
                                    Convert.ToUInt16
                                    (input.Split(" ")[1].Trim());
                                }catch{ UI.InvalidCriteria(); }
                                break;
                        }
                    }

                    catch (StackOverflowException)
                    {
                        UI.InvalidCriteria();
                    }
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
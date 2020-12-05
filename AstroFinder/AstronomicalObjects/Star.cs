using System.Collections.Generic;
using System.Globalization;

namespace AstroFinder
{
    /// <summary>
    /// Class that implements IStar
    /// </summary>
    public class Star: IStar
    {
        /// <summary>
        /// Star's name property
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Star's temperature property
        /// </summary>
        public float? StellarTemperature { get; }

        /// <summary>
        /// Star's radius property
        /// </summary>
        public float? StellarRadius { get; }

        /// <summary>
        /// Star's mass property
        /// </summary>
        public float? StellarMass { get; }

        /// <summary>
        /// Star's age property
        /// </summary>
        public float? StellarAge { get; }

        /// <summary>
        /// Star's rotation velocity property
        /// </summary>
        public float? StellarRotationVelocity { get; }

        /// <summary>
        /// Star's rotation period property
        /// </summary>
        public float? StellarRotationPeriod { get; }

        /// <summary>
        /// Star's distance from the sun property
        /// </summary>
        public float? Distance { get; }

        /// <summary>
        /// Star's ICollection with child planets property
        /// </summary>
        public ICollection<IPlanet> ChildPlanets { get; }

        /// <summary>
        /// Star constructor
        /// </summary>
        /// <param name="starName">Star's name</param>
        /// <param name="stellarTemperature">Star's temperature</param>
        /// <param name="stellarRadius">Star's radius</param>
        /// <param name="stellarMass">Star's mass</param>
        /// <param name="stellarAge">Star's age</param>
        /// <param name="stellarRotationVelocity">Star's rotation velocity</param>
        /// <param name="stellarRotationPeriod">Star's rotation period</param>
        /// <param name="distance">Star's distance from the sun</param>
        public Star(string starName, string stellarTemperature,
            string stellarRadius, string stellarMass, string stellarAge,
            string stellarRotationVelocity, string stellarRotationPeriod,
            string distance)
        {
            Name = starName;
            StellarTemperature = float.TryParse(stellarTemperature, 
                NumberStyles.Any, CultureInfo.InvariantCulture, 
                out float sTemp) ? sTemp : null;
            StellarRadius = float.TryParse(stellarRadius, NumberStyles.Any, 
                CultureInfo.InvariantCulture, out float sRad) ? sRad : null;
            StellarMass = float.TryParse(stellarMass, NumberStyles.Any, 
                CultureInfo.InvariantCulture, out float sMass) ? sMass : null;
            StellarAge = float.TryParse(stellarAge, NumberStyles.Any, 
                CultureInfo.InvariantCulture, out float sAge) ? sAge : null;
            StellarRotationVelocity = float.TryParse(stellarRotationVelocity, 
                NumberStyles.Any, CultureInfo.InvariantCulture, 
                out float srotvel) ? srotvel : null;
            StellarRotationPeriod = float.TryParse(stellarRotationPeriod, 
                NumberStyles.Any, CultureInfo.InvariantCulture, 
                out float srotper) ? srotper : null;
            Distance = float.TryParse(distance, NumberStyles.Any, 
                CultureInfo.InvariantCulture, out float dist) ? dist : null;
            ChildPlanets = new List<IPlanet>();
        }

        public Star(string name) { Name = name; }

        /// <summary>
        /// Prints information with this IAstronomicalObject fields
        /// </summary>
        /// <returns>Returns a string with information</returns>
        public string Information()
        {
            const string nonAvailable = "N/A";
            return
                (Name == null ?
                $"{nonAvailable,-30}|" :
                $"{Name,-30}|") +

                (StellarTemperature == null ?
                $"{nonAvailable,-15}|" :
                $"{StellarTemperature,-15}|") +

                (StellarRadius == null ?
                $"{nonAvailable,-15}|" :
                $"{StellarRadius,-15}|") +

                (StellarMass == null ?
                $"{nonAvailable,-7}|" :
                $"{StellarMass,-7}|") +

                (StellarAge == null ?
                $"{nonAvailable,-8}|" :
                $"{StellarAge,-8}|") +

                (StellarRotationVelocity == null ?
                $"{nonAvailable,-8}|" :
                $"{StellarRotationVelocity,-8}|") +

                (StellarRotationPeriod == null ?
                $"{nonAvailable,-8}|" :
                $"{StellarRotationPeriod,-8}|") +

                (Distance == null ?
                $"{nonAvailable,-10}|" :
                $"{Distance,-10}|") +                

                (ChildPlanets == null ?
                $"{nonAvailable,-13}|" :
                $"{ChildPlanets.Count,-13}|");
        }

        /// <summary>
        /// Prints detailed information with this IAstronomicalObject fields
        /// </summary>
        /// <returns>Returns a string with information</returns>
        public string DetailedInformation()
        {

            const string nonAvailable = "N/A";
            const string kmPerSec = "km/s";
            const string kelvin = "K";
            const string days = "days";
            const string compToSun = "compared to Sun";
            const string bilYears = "billion years";
            const string parsec = "pc";

            const sbyte y = -25;
            return
                "\n--------------------------------------------------------" +
                "-------\n" +
                $"{"\n--Star Information--",y}\n" +

                $"{"StellarName",y}: " + (Name == null ?
                                                $"{nonAvailable}\n" :
                                                $"{Name}\n") +

                $"{"StellarTemperature",y}: " +
                                 (StellarTemperature == null ?
                                        $"{nonAvailable}\n" :
                                        $"{StellarTemperature} {kelvin}\n") +

                $"{"StellarRadius",y}: " + 
                                (StellarRadius == null ?
                                    $"{nonAvailable}\n" :
                                    $"{StellarRadius} {compToSun}\n") +

                $"{"StellarMass",y}: " + 
                                (StellarMass == null ?
                                    $"{nonAvailable}\n" :
                                    $"{StellarMass} {compToSun}\n") +

                $"{"StellarAge",y}: " + (StellarAge == null ?
                                                $"{nonAvailable}\n" :
                                                $"{StellarAge} {bilYears}\n") +

                $"{"StellarRotationVelocity",y}: " + (
                                StellarRotationVelocity == null ?
                                    $"{nonAvailable}\n" :
                                    $"{StellarRotationVelocity} {kmPerSec}\n") +

                $"{"StellarRotationPeriod",y}: " + 
                                    (StellarRotationPeriod == null ?
                                        $"{nonAvailable}\n" :
                                        $"{StellarRotationPeriod} {days}\n") +

                $"{"Distance",y}: " + (Distance == null ?
                                                $"{nonAvailable}\n" :
                                                $"{Distance} {parsec}\n") +

                $"{"\n\tChildPlanets"}: \n" +
                ExtractChildPlanetName() +
                "\n----------------------------------------------------------" +
                "-------\n" +
                "Fields with '0' mean it's an empty field with " +
                "unknown information";
        }

        /// <summary>
        /// Creates a string with every child planet name
        /// </summary>
        /// <returns>Returns a string with child planets names</returns>
        private string ExtractChildPlanetName()
        {
            string str = "\t";
            int counter = ChildPlanets.Count;
            foreach (IPlanet planet in  ChildPlanets)
            {
                if (counter <= 1)
                    str += $"{planet.Name}";
                else
                    str += $"{planet.Name}, ";
                counter--;
            }
            return str;
        }

        /// <summary>
        /// Override equals to return true if the name is the same
        /// </summary>
        /// <param name="obj">Other object to compare</param>
        /// <returns>Returns true if the name is equal</returns>
        public override bool Equals(object obj)
        {
            return (obj as Star)?.Name == Name;
        }

        /// <summary>
        /// Throws new System.NotImplementedException();
        /// </summary>
        /// <returns>Returns a int</returns>
        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}

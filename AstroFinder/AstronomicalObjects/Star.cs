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
            return
                $"{Name,-30}|{StellarTemperature ?? 0,-15}|" +
                $"{StellarRadius ?? 0,-15}|" +
                $"{StellarMass ?? 0,-7}|{StellarAge ?? 0,-8}|" +
                $"{StellarRotationVelocity ?? 0,-8}|" +
                $"{StellarRotationPeriod ?? 0,-8}|" +
                $"{Distance ?? 0,-10}|{ChildPlanets.Count,-13}";
        }

        /// <summary>
        /// Prints detailed information with this IAstronomicalObject fields
        /// </summary>
        /// <returns>Returns a string with information</returns>
        public string DetailedInformation()
        {
            const sbyte y = -25;
            return
                "\n--------------------------------------------------------" +
                "-------\n" +
                $"{"\n--Star Information--",y}\n" +
                $"{"StellarName",y}: {Name}\n" +
                $"{"StellarTemperature",y}: " +
                    $"{StellarTemperature ?? 0} kelvin\n" +
                $"{"StellarRadius",y}: {StellarRadius ?? 0}" +
                    $" compared to sun\n" +
                $"{"StellarMass",y}: {StellarMass ?? 0} " +
                    $"compared to sun\n" +
                $"{"StellarAge",y}: {StellarAge ?? 0} " +
                    $"billion years\n" +
                $"{"StellarRotationVelocity",y}: " +
                    $"{StellarRotationVelocity ?? 0} km/s\n" +
                $"{"StellarRotationPeriod",y}: " +
                    $"{StellarRotationPeriod ?? 0} days\n" +
                $"{"Distance",y}: {Distance ?? 0} parsec \n" +
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

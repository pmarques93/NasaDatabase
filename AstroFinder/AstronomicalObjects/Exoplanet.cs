using System;
using System.Globalization;

namespace AstroFinder
{
    /// <summary>
    /// Concrete representation of IPlanet objects.
    /// </summary>
    public class Exoplanet : IPlanet
    {
        /// <summary>
        /// Planet's name property.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Star that is the parent of the planet property.
        /// </summary>
        public IStar ParentStar { get; set; }
        /// <summary>
        /// Method of discovery of the planet property.
        /// </summary>
        public string DiscoveryMethod { get; }
        /// <summary>
        /// Year of discovery of the planet property.
        /// </summary>
        public ushort? DiscoveryYear { get; }
        /// <summary>
        /// Orbital period of the planet property.
        /// </summary>
        public float? OrbitalPeriod { get; }
        /// <summary>
        /// Radius of the planet property.
        /// </summary>
        public float? PlanetRadius { get; }
        /// <summary>
        /// Mass of the planet property.
        /// </summary>
        public float? PlanetMass { get; }
        /// <summary>
        /// Temperature of the planet property.
        /// </summary>
        public float? PlanetTemperature { get; }

        /// <summary>
        /// Constructor, that creates a new instance of Exoplanet and 
        /// initializes all its properties.
        /// </summary>
        /// <param name="name">Name of the planet.</param>
        /// <param name="hostName">Name of the host star of the planet.</param>
        /// <param name="discoveryMethod">Method of discovery of the
        ///  planet.</param>
        /// <param name="discoveryYear">Year of discovery of the planet.</param>
        /// <param name="orbitalPeriod">Orbital period of the planet.</param>
        /// <param name="planetRadius">Radius os the planet.</param>
        /// <param name="planetMass">Mass of the planet.</param>
        /// <param name="planetTemperature">Temperature of the planet.</param>
        public Exoplanet(string name, string hostName, string discoveryMethod,
            string discoveryYear, string orbitalPeriod, string planetRadius,
            string planetMass, string planetTemperature)
        {
            Name = name;
            DiscoveryMethod = discoveryMethod;
            DiscoveryYear = UInt16.TryParse(discoveryYear, NumberStyles.Any,
                CultureInfo.InvariantCulture, out UInt16 discyear) ?
                discyear : null;
            OrbitalPeriod = float.TryParse(orbitalPeriod, NumberStyles.Any,
                CultureInfo.InvariantCulture, out float operiod) ?
                operiod : null;
            PlanetRadius = float.TryParse(planetRadius, NumberStyles.Any,
                CultureInfo.InvariantCulture, out float pradius) ?
                pradius : null;
            PlanetMass = float.TryParse(planetMass, NumberStyles.Any,
                CultureInfo.InvariantCulture, out float pmass) ? pmass : null;
            PlanetTemperature = float.TryParse(planetTemperature,
                NumberStyles.Any, CultureInfo.InvariantCulture,
                out float ptemp) ? ptemp : null;
            ParentStar = new Star(hostName);
        }

        /// <summary>
        /// Prints information with this IAstronomicalObject fields.
        /// </summary>
        /// <returns>Returns a string with information.</returns>
        public string Information()
        {
            const string nonAvailable = "N/A";
            return
                $"{Name,-30}|" +
                $"{ParentStar.Name,-30}|" +

                (DiscoveryMethod == null ?
                $"{nonAvailable,-30}|" :
                $"{DiscoveryMethod,-30}|") +

                (DiscoveryYear == null ?
                $"{nonAvailable,-7}|" :
                $"{DiscoveryYear,-7}|") +

                (OrbitalPeriod == null ?
                $"{nonAvailable,-10}|" :
                $"{OrbitalPeriod,-10}|") +

                (PlanetRadius == null ?
                $"{nonAvailable,-10}|" :
                $"{PlanetRadius,-10}|") +

                (PlanetMass == null ?
                $"{nonAvailable,-10}|" :
                $"{PlanetMass,-10}|") +

                (PlanetTemperature == null ?
                $"{nonAvailable,-10}" :
                $"{PlanetTemperature,-10}");

        }
        
        /// <summary>
        /// Prints detailed information with this IAstronomicalObject fields
        /// </summary>
        /// <returns>Returns a string with information<</returns>
        public string DetailedInformation()
        {
            const sbyte x = -18;
            const sbyte y = -25;
            const string nonAvailable = "N/A";
            const string kmPerSec = "km/s";
            const string kelvin = "K";
            const string days = "days";
            const string compToEarth = "compared to Earth";
            const string compToSun = "compared to Sun";
            const string bilYears = "billion years";
            const string parsec = "pc";
            return
                "\n--------------------------------------------------------" +
                "-------\n" +
                $"{"--Planet Information--",x}\n" +
                $"{"Name",x}: {Name}\n" +
                $"{"DiscoveryMethod",x}: " + (DiscoveryMethod == null ?
                                                $"{nonAvailable}\n" :
                                                $"{DiscoveryMethod}\n") +
                $"{"DiscoveryYear",x}: " + (DiscoveryYear == null ?
                                            $"{nonAvailable}\n" :
                                            $"{DiscoveryYear}\n") +
                $"{"OrbitalPeriod",x}: " + (OrbitalPeriod == null ?
                                            $"{nonAvailable}\n" :
                                            $"{OrbitalPeriod} {days}\n") +
                $"{"PlanetRadius",x}: " + (PlanetRadius == null ?
                                            $"{nonAvailable}\n" :
                                            $"{PlanetRadius} {compToEarth}\n") +
                $"{"PlanetMass",x}: " + (PlanetMass == null ?
                                            $"{nonAvailable}\n" :
                                            $"{PlanetMass} {compToEarth}\n") +
                $"{"PlanetTemperature",x}: " + (PlanetTemperature == null ?
                                            $"{nonAvailable}\n" :
                                            $"{PlanetTemperature} {kelvin}\n") +
                $"{"\n\t--Star Information--",y}\n" +
                $"{"\tStellarName",y}: " + (ParentStar == null ||
                                                ParentStar.Name == null ?
                                                $"{nonAvailable}\n" :
                                                $"{ParentStar.Name}\n") +
                $"{"\tStellarTemperature",y}: " +
                            (ParentStar == null ||
                            ParentStar.StellarTemperature == null ?
                            $"{nonAvailable}\n" :
                            $"{ParentStar.StellarTemperature} {kelvin}\n") +

                $"{"\tStellarRadius",y}: " +
                            (ParentStar == null ||
                            ParentStar.StellarRadius == null ?
                            $"{nonAvailable}\n" :
                            $"{ParentStar.StellarRadius} {compToSun}\n") +

                $"{"\tStellarMass",y}: " +
                            (ParentStar == null ||
                            ParentStar.StellarMass == null ?
                            $"{nonAvailable}\n" :
                            $"{ParentStar.StellarMass} {compToSun}\n") +

                $"{"\tStellarAge",y}: " +
                            (ParentStar == null ||
                            ParentStar.StellarMass == null ?
                            $"{nonAvailable}\n" :
                            $"{ParentStar.StellarMass} {bilYears}\n") +

                $"{"\tStellarRotationVelocity",y}: " +
                            (ParentStar == null ||
                            ParentStar.StellarRotationVelocity == null ?
                            $"{nonAvailable}\n" :
                            $"{ParentStar.StellarRotationVelocity} {kmPerSec}\n") +


                $"{"\tStellarRotationPeriod",y}: " +
                            (ParentStar == null ||
                            ParentStar.StellarRotationPeriod == null ?
                            $"{nonAvailable}\n" :
                            $"{ParentStar.StellarRotationPeriod} {days}\n") +

                $"{"\tDistance",y}: " +
                            (ParentStar == null ||
                            ParentStar.Distance == null ?
                            $"{nonAvailable}\n" :
                            $"{ParentStar.Distance} {parsec}\n") +

                $"{"\tNumberOfChildPlanets",y}: " +
                            (ParentStar == null ||
                            ParentStar.ChildPlanets == null ?
                            $"{nonAvailable}\n" :
                            $"{ParentStar.ChildPlanets.Count}\n") +

                "----------------------------------------------------------" +
                "-------\n" +
                "Fields with N/A mean the field is empty " +
                "or its information is unkown";
        }
    }
}

using System;
using System.Globalization;

namespace AstroFinder
{
    public class Exoplanet : IPlanet
    {
        public string Name { get; }
        public IStar ParentStar { get; set; }
        public string DiscoveryMethod { get; }
        public ushort? DiscoveryYear { get; }
        public float? OrbitalPeriod { get; }
        public float? PlanetRadius { get; }
        public float? PlanetMass { get; }
        public float? PlanetTemperature { get; }


        public Exoplanet(string name, string hostName, string discoveryMethod,
            string discoveryYear, string orbitalPeriod, string planetRadius,
            string planetMass, string planetTemperature)
        {
            Name = name;
            DiscoveryMethod = discoveryMethod;
            DiscoveryYear = UInt16.TryParse(discoveryYear, NumberStyles.Any, CultureInfo.InvariantCulture, out UInt16 discyear) ? discyear : null;
            OrbitalPeriod = float.TryParse(orbitalPeriod, NumberStyles.Any, CultureInfo.InvariantCulture, out float operiod) ? operiod : null;
            PlanetRadius = float.TryParse(planetRadius, NumberStyles.Any, CultureInfo.InvariantCulture, out float pradius) ? pradius : null;
            PlanetMass = float.TryParse(planetMass, NumberStyles.Any, CultureInfo.InvariantCulture, out float pmass) ? pmass : null;
            PlanetTemperature = float.TryParse(planetTemperature, NumberStyles.Any, CultureInfo.InvariantCulture, out float ptemp) ? ptemp : null;
            ParentStar = new Star(hostName);
        }
    }
}
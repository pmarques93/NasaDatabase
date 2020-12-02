using System;
using System.Collections.Generic;
using System.Reflection;

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


        public Exoplanet(string name, string discoveryMethod,
            string discoveryYear, string orbitalPeriod, string planetRadius,
            string planetMass, string planetTemperature)
        {
            Name = name;
            DiscoveryMethod = discoveryMethod;
            DiscoveryYear = UInt16.TryParse(discoveryYear, out UInt16 discyear) ? discyear : null;
            OrbitalPeriod = float.TryParse(orbitalPeriod, out float operiod) ? operiod : null;
            PlanetRadius = float.TryParse(planetRadius, out float pradius) ? pradius : null;
            PlanetMass = float.TryParse(planetMass, out float pmass) ? pmass : null;
            PlanetTemperature = float.TryParse(planetTemperature, out float ptemp) ? ptemp : null;
            ParentStar = new Star();

            OnPlanetCreation();
        }
        private void OnPlanetCreation()
            => PlanetCreation?.Invoke(this);

        public static event Action<IPlanet> PlanetCreation;

        public override string ToString()
        {
            return $"Name:              {Name}\n" +
                    $"HostName:          {ParentStar.Name}\n" +
                    $"DiscoveryMethod :  {DiscoveryMethod}\n" +
                    "-------------------------------------------\n\n";
        }
    }
}
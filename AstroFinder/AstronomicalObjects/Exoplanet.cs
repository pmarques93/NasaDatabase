using System;
using System.Collections.Generic;
using System.Reflection;

namespace AstroFinder
{
    public struct Exoplanet : IPlanet
    {
        public string Name { get; }
        public IStar ParentStar { get; }
        public string DiscoveryMethod { get; }
        public ushort? DiscoveryYear { get; }
        public float? OrbitalPeriod { get; }
        public float? PlanetRadius { get; }
        public float? PlanetMass { get; }
        public float? PlanetTemperature { get; }

        /*
        public Exoplanet(string name, string TEMPHOSTNAME, string discoveryMethod)
        {
            List<IPlanet> TESTE = new List<IPlanet>();
            Name = name;
            ParentStar = new Star("sol", 10, 10, 10, 10, 10, 10, 10, TESTE);
            DiscoveryMethod = discoveryMethod;
            DiscoveryYear = default;
            OrbitalPeriod = default;
            PlanetRadius = default;
            PlanetMass = default;
            PlanetTemperature = default;
        }

        public Exoplanet(string name, IStar hostName, string discoveryMethod)
        {
            Name = name;
            ParentStar = hostName;
            DiscoveryMethod = discoveryMethod;
            DiscoveryYear = default;
            OrbitalPeriod = default;
            PlanetRadius = default;
            PlanetMass = default;
            PlanetTemperature = default;
        }*/

        public Exoplanet(string name, string hostName, string discoveryMethod,
            string discoveryYear, string orbitalPeriod, string planetRadius,
            string planetMass, string planetTemperature, string starTemperature,
            string StarRadius, string starMass, string starAge, string starRotVel,
            string starRotPer, string distance)
        {
            Name = name;
            DiscoveryMethod = discoveryMethod;
            DiscoveryYear = UInt16.TryParse(discoveryYear, out UInt16 discyear) ? discyear : null;
            OrbitalPeriod = float.TryParse(orbitalPeriod, out float operiod) ? operiod : null;
            PlanetRadius = float.TryParse(planetRadius, out float pradius) ? pradius : null;
            PlanetMass = float.TryParse(planetMass, out float pmass) ? pmass : null;
            PlanetTemperature = float.TryParse(planetTemperature, out float ptemp) ? ptemp : null;

            float.TryParse(starTemperature, out float sTemp);
            float.TryParse(StarRadius, out float sRad);
            float.TryParse(starMass, out float sMass);
            float.TryParse(starAge, out float sAge);
            float.TryParse(starRotVel, out float srotvel);
            float.TryParse(starRotPer, out float srotper);
            float.TryParse(distance, out float dist);
            ParentStar = new Star(hostName, sTemp, sRad, sMass, sAge, srotvel, srotper, dist,
                                    new List<IPlanet>());
        }

        public override string ToString()
        {
            return $"Name:              {Name}\n" +
                        $"HostName:          {ParentStar.Name}\n" +
                        $"DiscoveryMethod :  {DiscoveryMethod}\n" +
                    "-------------------------------------------\n\n";
        }
    }
}
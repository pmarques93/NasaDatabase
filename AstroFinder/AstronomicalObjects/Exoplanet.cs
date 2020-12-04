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

        public string Information()
        {
            const sbyte x = -18;
            return
                "\n--------------------------------------------------------" +
                "-------\n" +
                $"{"Planet Information:",x}\n" +
                $"{"Name",x}: {Name}\n" +
                $"{"StellarName",x}: {ParentStar.Name}\n" +
                $"{"DiscoveryMethod",x}: {DiscoveryMethod}\n" +
                $"{"DiscoveryYear",x}: {DiscoveryYear}\n" +
                $"{"OrbitalPeriod",x}: {OrbitalPeriod ?? 0} days\n" +
                $"{"PlanetRadius",x}: " +
                    $"{PlanetRadius ?? 0} compared to earth\n" +
                $"{"PlanetMass",x}: {PlanetMass ?? 0} compared to earth\n" +
                $"{"PlanetTemperature",x}: {PlanetTemperature ?? 0} kelvin\n" +
                "----------------------------------------------------------" +
                "-------\n" +
                "Fields with '0' mean it's an empty field with " +
                "unknown information";
        }

        public string DetailedInformation()
        {
            const sbyte x = -18;
            const sbyte y = -25;
            return
                "\n--------------------------------------------------------" +
                "-------\n" +
                $"{"--Planet Information--",x}\n" +
                $"{"Name",x}: {Name}\n" +
                $"{"DiscoveryMethod",x}: {DiscoveryMethod}\n" +
                $"{"DiscoveryYear",x}: {DiscoveryYear}\n" +
                $"{"OrbitalPeriod",x}: {OrbitalPeriod ?? 0} days\n" +
                $"{"PlanetRadius",x}: " +
                    $"{PlanetRadius ?? 0} compared to earth\n" +
                $"{"PlanetMass",x}: {PlanetMass ?? 0} compared to earth\n" +
                $"{"PlanetTemperature",x}: {PlanetTemperature ?? 0} kelvin\n" +
                $"{"\n\t--Star Information--",y}\n" +
                $"{"\tStellarName",y}: {ParentStar.Name}\n" +
                $"{"\tStellarTemperature",y}: " +
                    $"{ParentStar.StellarTemperature ?? 0} kelvin\n" +
                $"{"\tStellarRadius",y}: {ParentStar.StellarRadius ?? 0}" +
                    $" compared to sun\n" +
                $"{"\tStellarMass",y}: {ParentStar.StellarMass ?? 0} " +
                    $"compared to sun\n" +
                $"{"\tStellarAge",y}: {ParentStar.StellarAge ?? 0} " +
                    $"billion years\n" +
                $"{"\tStellarRotationVelocity",y}: " +
                    $"{ParentStar.StellarRotationVelocity ?? 0} km/s\n" +
                $"{"\tStellarRotationPeriod",y}: " +
                    $"{ParentStar.StellarRotationPeriod ?? 0} days\n" +
                $"{"\tDistance",y}: {ParentStar.Distance ?? 0} parsec \n" +
                $"{"\tNumberOfChildPlanets",y}: " +
                    $"{ParentStar.ChildPlanets.Count}\n" +
                "----------------------------------------------------------" +
                "-------\n" +
                "Fields with '0' mean it's an empty field with " +
                "unknown information";
        }
    }
}
                                                                                
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

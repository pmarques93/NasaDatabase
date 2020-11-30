namespace AstroFinder
{
    public struct Exoplanet
    {
        public string PlanetName { get; }
        public string HostName { get; }
        public string DiscoveryMethod { get; }
        public ushort DiscoveryYear { get; }
        public float OrbitalPeriod { get; }
        public float PlanetRadius { get; }
        public float PlanetMass { get; }
        public float PlanetTemperature { get; }
        public float StellarTemperature { get; }
        public float StellarRadius { get; }
        public float StellarMass { get; }
        public float StellarAge { get; }
        public float StellarRotationVelocity { get; }
        public float StellarRotationPeriod { get; }
        public float Distance { get; }

        public Exoplanet(string name, string hostName, string discoveryMethod,
            ushort discoveryYear, float orbitalPeriod, float planetRadius,
            float planetMass, float planetTemperature, float stellarTemperature,
            float stellarRadius, float stellarMass, float stellarAge,
            float stellarRotationVelocity, float stellarRotationPeriod,
            float distance)
        {
            PlanetName = name;
            HostName = hostName;
            DiscoveryMethod = discoveryMethod;
            DiscoveryYear = discoveryYear;
            OrbitalPeriod = orbitalPeriod;
            PlanetRadius = planetRadius;
            PlanetMass = planetMass;
            PlanetTemperature = planetTemperature;
            StellarTemperature = stellarTemperature;
            StellarRadius = stellarRadius;
            StellarMass = stellarMass;
            StellarAge = stellarAge;
            StellarRotationVelocity = stellarRotationVelocity;
            StellarRotationPeriod = stellarRotationPeriod;
            Distance = distance;
        }
    }
}   
namespace AstroFinder
{
    public class SearchCriteria
    {
        private const byte MINVALUE = 0;
        private const ushort CURRENTYEAR = 2020;
        private const int IMAXVALUE = 100000000;
        private const ushort SMAXVALUE = 50000;
        private const byte BMAXVALUE = 255;

        public string PlanetName {get; set;}
        public string HostName {get; set;}
        public string Discoverymethod {get; set;}
        private ushort discoveryYearMin;
        private ushort discoveryYearMax;
        private uint orbitalPeriodMin;
        private uint orbitalPeriodMax;
        private byte planetRadiusMin;
        private byte planetRadiusMax;
        private ushort planetMassMin;
        private ushort planetMassMax;
        private ushort planettemperaturemin;
        private ushort planettemperaturemax;
        private ushort stellartemperaturemin;
        private ushort stellartemperaturemax;
        private byte stellarRadiusMin;
        private byte stellarRadiusMax;
        private byte stellarMassMin;
        private byte stellarMassMax;
        private byte stellarAgeMin;
        private byte stellarAgeMax;
        private ushort stellarRotationVelocityMin;
        private ushort stellarRotationVelocityMax;
        private ushort stellarRotationPeriodMin;
        private ushort stellarRotationPeriodMax;
        private ushort distanceMin;
        private ushort distanceMax;

        public ushort DiscoveryYearMin 
        {
            get => discoveryYearMin;
            set
            {
                discoveryYearMin = value;
                if(value < MINVALUE) discoveryYearMin = MINVALUE;
                if(discoveryYearMin > discoveryYearMax) 
                    discoveryYearMin = discoveryYearMax;
            }
        }
        public ushort DiscoveryYearMax 
        {
            get => discoveryYearMax;
            set
            {
                discoveryYearMax = value;
                if(value > CURRENTYEAR) discoveryYearMax = CURRENTYEAR;
                if(discoveryYearMax < discoveryYearMin) 
                    discoveryYearMax = discoveryYearMin;
            }
        }
        public uint OrbitalPeriodMin
        {
            get => orbitalPeriodMin;
            set
            {
                orbitalPeriodMin = value;
                if (value < MINVALUE) orbitalPeriodMin = MINVALUE;
                if (orbitalPeriodMin > orbitalPeriodMax)
                    orbitalPeriodMin = orbitalPeriodMax;
            }
        }
        public uint OrbitalPeriodMax
        {
            get => orbitalPeriodMax;
            set
            {
                orbitalPeriodMax = value;
                if (value > IMAXVALUE) orbitalPeriodMax = IMAXVALUE;
                if (orbitalPeriodMax < orbitalPeriodMin)
                    orbitalPeriodMax = orbitalPeriodMin;
            }
        }
        public byte PlanetRadiusMin
        {
            get => planetRadiusMin;
            set
            {
                planetRadiusMin = value;
                if (value < MINVALUE) planetRadiusMin = MINVALUE;
                if (planetRadiusMin > planetRadiusMax)
                    planetRadiusMin = planetRadiusMax;
            }
        }
        public byte PlanetRadiusMax
        {
            get => planetRadiusMax;
            set
            {
                planetRadiusMax = value;
                if (value > BMAXVALUE) planetRadiusMax = BMAXVALUE;
                if (planetRadiusMax < planetRadiusMin)
                    planetRadiusMax = planetRadiusMin;
            }
        }
        public ushort PlanetMassMin
        {
            get => planetMassMin;
            set
            {
                planetMassMin = value;
                if (value < MINVALUE) planetMassMin = MINVALUE;
                if (planetMassMin > planetMassMax)
                    planetMassMin = planetMassMax;
            }
        }
        public ushort PlanetMassMax
        {
            get => planetMassMax;
            set
            {
                planetMassMax = value;
                if (value > SMAXVALUE) planetMassMax = SMAXVALUE;
                if (planetMassMax < planetMassMin)
                    planetMassMax = planetMassMin;
            }
        }
        public ushort PlanetTemperatureMin
        {
            get => planettemperaturemin;
            set
            {
                planettemperaturemin = value;
                if (value < MINVALUE) planettemperaturemin = MINVALUE;
                if (planettemperaturemin > planettemperaturemax)
                    planettemperaturemin = planettemperaturemax;
            }
        }
        public ushort PlanetTemperatureMax
        {
            get => planettemperaturemax;
            set
            {
                planettemperaturemax = value;
                if (value > SMAXVALUE) planettemperaturemax = SMAXVALUE;
                if (planettemperaturemax < planettemperaturemin)
                    planettemperaturemax = planettemperaturemin;
            }
        }
        public ushort StellarTemperatureMin
        {
            get => stellartemperaturemin;
            set
            {
                stellartemperaturemin = value;
                if (value < MINVALUE) stellartemperaturemin = MINVALUE;
                if (stellartemperaturemin > stellartemperaturemax)
                    stellartemperaturemin = stellartemperaturemax;
            }
        }
        public ushort StellarTemperatureMax
        {
            get => stellartemperaturemax;
            set
            {
                stellartemperaturemax = value;
                if (value > SMAXVALUE) stellartemperaturemax = SMAXVALUE;
                if (stellartemperaturemax < stellartemperaturemin)
                    stellartemperaturemax = stellartemperaturemin;
            }
        }
        public byte StellarRadiusMin
        {
            get => stellarRadiusMin;
            set
            {
                stellarRadiusMin = value;
                if (value < MINVALUE) stellarRadiusMin = MINVALUE;
                if (stellarRadiusMin > stellarRadiusMax)
                    stellarRadiusMin = stellarRadiusMax;
            }
        }
        public byte StellarRadiusMax
        {
            get => stellarRadiusMax;
            set
            {
                stellarRadiusMax = value;
                if (value > BMAXVALUE) stellarRadiusMax = BMAXVALUE;
                if (stellarRadiusMax < stellarRadiusMin)
                    stellarRadiusMax = stellarRadiusMin;
            }
        }
        public byte StellarMassMin
        {
            get => stellarMassMin;
            set
            {
                stellarMassMin = value;
                if (value < MINVALUE) stellarMassMin = MINVALUE;
                if (stellarMassMin > stellarMassMax)
                    stellarMassMin = stellarMassMax;
            }
        }
        public byte StellarMassMax
        {
            get => stellarMassMax;
            set
            {
                stellarMassMax = value;
                if (value > BMAXVALUE) stellarMassMax = BMAXVALUE;
                if (stellarMassMax < stellarMassMin)
                    stellarMassMax = stellarMassMin;
            }
        }
        public byte StellarAgeMin
        {
            get => stellarAgeMin;
            set
            {
                stellarAgeMin = value;
                if (value < MINVALUE) stellarAgeMin = MINVALUE;
                if (stellarAgeMin > stellarAgeMax)
                    stellarAgeMin = stellarAgeMax;
            }
        }
        public byte StellarAgeMax
        {
            get => stellarAgeMax;
            set
            {
                stellarAgeMax = value;
                if (value > BMAXVALUE) stellarAgeMax = BMAXVALUE;
                if (stellarAgeMax < stellarAgeMin)
                    stellarAgeMax = stellarAgeMin;
            }
        }
        public ushort StellarRotationVelocityMin
        {
            get => stellarRotationVelocityMin;
            set
            {
                stellarRotationVelocityMin = value;
                if (value < MINVALUE) stellarRotationVelocityMin = MINVALUE;
                if (stellarRotationVelocityMin > stellarRotationVelocityMax)
                    stellarRotationVelocityMin = stellarRotationVelocityMax;
            }
        }
        public ushort StellarRotationVelocityMax
        {
            get => stellarRotationVelocityMax;
            set
            {
                stellarRotationVelocityMax = value;
                if (value > SMAXVALUE) stellarRotationVelocityMax = SMAXVALUE;
                if (stellarRotationVelocityMax < stellarRotationVelocityMin)
                    stellarRotationVelocityMax = stellarRotationVelocityMin;
            }
        }
        public ushort StellarRotationPeriodMin
        {
            get => stellarRotationPeriodMin;
            set
            {
                stellarRotationPeriodMin = value;
                if (value < MINVALUE) stellarRotationPeriodMin = MINVALUE;
                if (stellarRotationPeriodMin > stellarRotationPeriodMax)
                    stellarRotationPeriodMin = stellarRotationPeriodMax;
            }
        }
        public ushort StellarRotationPeriodMax
        {
            get => stellarRotationPeriodMax;
            set
            {
                stellarRotationPeriodMax = value;
                if (value > SMAXVALUE) stellarRotationPeriodMax = SMAXVALUE;
                if (stellarRotationPeriodMax < stellarRotationPeriodMin)
                    stellarRotationPeriodMax = stellarRotationPeriodMin;
            }
        }
        public ushort DistanceMin
        {
            get => distanceMin;
            set
            {
                distanceMin = value;
                if (value < MINVALUE) distanceMin = MINVALUE;
                if (distanceMin > distanceMax)
                    distanceMin = distanceMax;
            }
        }
        public ushort DistanceMax
        {
            get => distanceMax;
            set
            {
                distanceMax = value;
                if (value > SMAXVALUE) distanceMax = SMAXVALUE;
                if (distanceMax < distanceMin)
                    distanceMax = distanceMin;
            }
        }

        public SearchCriteria()
        {
            PlanetName = "everything";
            HostName = "everything";
            Discoverymethod = "everything";
            DiscoveryYearMax = CURRENTYEAR;
            DiscoveryYearMin = MINVALUE;
            OrbitalPeriodMax = IMAXVALUE;
            OrbitalPeriodMin = MINVALUE;
            PlanetRadiusMax = BMAXVALUE;
            PlanetRadiusMin = MINVALUE;
            PlanetMassMax = SMAXVALUE;
            PlanetMassMin = MINVALUE;
            PlanetTemperatureMax = SMAXVALUE;
            PlanetTemperatureMin = MINVALUE;
            StellarTemperatureMax = SMAXVALUE;
            StellarTemperatureMin = MINVALUE;
            StellarRadiusMax = BMAXVALUE;
            StellarRadiusMin = MINVALUE;
            StellarMassMax = BMAXVALUE;
            StellarMassMin = MINVALUE;
            StellarAgeMax = BMAXVALUE;
            StellarAgeMin = MINVALUE;
            StellarRotationVelocityMax = SMAXVALUE;
            StellarRotationVelocityMin = MINVALUE;
            StellarRotationPeriodMax = SMAXVALUE;
            StellarRotationPeriodMin = MINVALUE;
            DistanceMax = SMAXVALUE;
            DistanceMin = MINVALUE;
        }
    }
}
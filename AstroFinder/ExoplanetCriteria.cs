using System.Globalization;
using System;

namespace AstroFinder
{
    public class ExoplanetCriteria: SearchField
    {
        private const byte MINVALUE = 0;
        private const ushort CURRENTYEAR = 2020;
        private const float FMAXVALUE = 100000000.0f;

        public string PlanetName {get; set;}
        public string HostName {get; set;}
        public string DiscoveryMethod {get; set;}
        private ushort discoveryYearMin;
        private ushort discoveryYearMax;
        private float orbitalPeriodMin;
        private float orbitalPeriodMax;
        private float planetRadiusMin;
        private float planetRadiusMax;
        private float planetMassMin;
        private float planetMassMax;
        private float planetTemperatureMin;
        private float planetTemperatureMax;
        private float stellarTemperatureMin;
        private float stellarTemperatureMax;
        private float stellarRadiusMin;
        private float stellarRadiusMax;
        private float stellarMassMin;
        private float stellarMassMax;
        private float stellarAgeMin;
        private float stellarAgeMax;
        private float stellarRotationVelocityMin;
        private float stellarRotationVelocityMax;
        private float stellarRotationPeriodMin;
        private float stellarRotationPeriodMax;
        private float distanceMin;
        private float distanceMax;

        #region Properties
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
        public float OrbitalPeriodMin
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
        public float OrbitalPeriodMax
        {
            get => orbitalPeriodMax;
            set
            {
                orbitalPeriodMax = value;
                if (value > FMAXVALUE) orbitalPeriodMax = FMAXVALUE;
                if (orbitalPeriodMax < orbitalPeriodMin)
                    orbitalPeriodMax = orbitalPeriodMin;
            }
        }
        public float PlanetRadiusMin
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
        public float PlanetRadiusMax
        {
            get => planetRadiusMax;
            set
            {
                planetRadiusMax = value;
                if (value > FMAXVALUE) planetRadiusMax = FMAXVALUE;
                if (planetRadiusMax < planetRadiusMin)
                    planetRadiusMax = planetRadiusMin;
            }
        }
        public float PlanetMassMin
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
        public float PlanetMassMax
        {
            get => planetMassMax;
            set
            {
                planetMassMax = value;
                if (value > FMAXVALUE) planetMassMax = FMAXVALUE;
                if (planetMassMax < planetMassMin)
                    planetMassMax = planetMassMin;
            }
        }
        public float PlanetTemperatureMin
        {
            get => planetTemperatureMin;
            set
            {
                planetTemperatureMin = value;
                if (value < MINVALUE) planetTemperatureMin = MINVALUE;
                if (planetTemperatureMin > planetTemperatureMax)
                    planetTemperatureMin = planetTemperatureMax;
            }
        }
        public float PlanetTemperatureMax
        {
            get => planetTemperatureMax;
            set
            {
                planetTemperatureMax = value;
                if (value > FMAXVALUE) planetTemperatureMax = FMAXVALUE;
                if (planetTemperatureMax < planetTemperatureMin)
                    planetTemperatureMax = planetTemperatureMin;
            }
        }
        public float StellarTemperatureMin
        {
            get => stellarTemperatureMin;
            set
            {
                stellarTemperatureMin = value;
                if (value < MINVALUE) stellarTemperatureMin = MINVALUE;
                if (stellarTemperatureMin > stellarTemperatureMax)
                    stellarTemperatureMin = stellarTemperatureMax;
            }
        }
        public float StellarTemperatureMax
        {
            get => stellarTemperatureMax;
            set
            {
                stellarTemperatureMax = value;
                if (value > FMAXVALUE) stellarTemperatureMax = FMAXVALUE;
                if (stellarTemperatureMax < stellarTemperatureMin)
                    stellarTemperatureMax = stellarTemperatureMin;
            }
        }
        public float StellarRadiusMin
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
        public float StellarRadiusMax
        {
            get => stellarRadiusMax;
            set
            {
                stellarRadiusMax = value;
                if (value > FMAXVALUE) stellarRadiusMax = FMAXVALUE;
                if (stellarRadiusMax < stellarRadiusMin)
                    stellarRadiusMax = stellarRadiusMin;
            }
        }
        public float StellarMassMin
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
        public float StellarMassMax
        {
            get => stellarMassMax;
            set
            {
                stellarMassMax = value;
                if (value > FMAXVALUE) stellarMassMax = FMAXVALUE;
                if (stellarMassMax < stellarMassMin)
                    stellarMassMax = stellarMassMin;
            }
        }
        public float StellarAgeMin
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
        public float StellarAgeMax
        {
            get => stellarAgeMax;
            set
            {
                stellarAgeMax = value;
                if (value > FMAXVALUE) stellarAgeMax = FMAXVALUE;
                if (stellarAgeMax < stellarAgeMin)
                    stellarAgeMax = stellarAgeMin;
            }
        }
        public float StellarRotationVelocityMin
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
        public float StellarRotationVelocityMax
        {
            get => stellarRotationVelocityMax;
            set
            {
                stellarRotationVelocityMax = value;
                if (value > FMAXVALUE) stellarRotationVelocityMax = FMAXVALUE;
                if (stellarRotationVelocityMax < stellarRotationVelocityMin)
                    stellarRotationVelocityMax = stellarRotationVelocityMin;
            }
        }
        public float StellarRotationPeriodMin
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
        public float StellarRotationPeriodMax
        {
            get => stellarRotationPeriodMax;
            set
            {
                stellarRotationPeriodMax = value;
                if (value > FMAXVALUE) stellarRotationPeriodMax = FMAXVALUE;
                if (stellarRotationPeriodMax < stellarRotationPeriodMin)
                    stellarRotationPeriodMax = stellarRotationPeriodMin;
            }
        }
        public float DistanceMin
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
        public float DistanceMax
        {
            get => distanceMax;
            set
            {
                distanceMax = value;
                if (value > FMAXVALUE) distanceMax = FMAXVALUE;
                if (distanceMax < distanceMin)
                    distanceMax = distanceMin;
            }
        }
        #endregion

        public ExoplanetCriteria()
        {
            PlanetName = "everything";
            HostName = "everything";
            DiscoveryMethod = "everything";
            DiscoveryYearMax = CURRENTYEAR;
            DiscoveryYearMin = MINVALUE;
            OrbitalPeriodMax = FMAXVALUE;
            OrbitalPeriodMin = MINVALUE;
            PlanetRadiusMax = FMAXVALUE;
            PlanetRadiusMin = MINVALUE;
            PlanetMassMax = FMAXVALUE;
            PlanetMassMin = MINVALUE;
            PlanetTemperatureMax = FMAXVALUE;
            PlanetTemperatureMin = MINVALUE;
            StellarTemperatureMax = FMAXVALUE;
            StellarTemperatureMin = MINVALUE;
            StellarRadiusMax = FMAXVALUE;
            StellarRadiusMin = MINVALUE;
            StellarMassMax = FMAXVALUE;
            StellarMassMin = MINVALUE;
            StellarAgeMax = FMAXVALUE;
            StellarAgeMin = MINVALUE;
            StellarRotationVelocityMax = FMAXVALUE;
            StellarRotationVelocityMin = MINVALUE;
            StellarRotationPeriodMax = FMAXVALUE;
            StellarRotationPeriodMin = MINVALUE;
            DistanceMax = FMAXVALUE;
            DistanceMin = MINVALUE;
        }

        public override void AddCriteria(Enum inputName, string inputValue)
        {
            UserInterface UI = new UserInterface();
            ushort svalue;
            float fvalue;
            
            switch (inputName)
            {
                case ExoplanetInputs.planetname:
                    PlanetName = inputValue;
                    break;

                case ExoplanetInputs.hostname:
                    HostName = inputValue;
                    break;

                case ExoplanetInputs.discoverymethod:
                    DiscoveryMethod = inputValue;
                    break;

                case ExoplanetInputs.discoveryyearmin:
                    if (UInt16.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out svalue))
                        DiscoveryYearMin = svalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.discoveryyearmax:
                    
                    if (UInt16.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out svalue))
                        DiscoveryYearMax = svalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.orbitalperiodmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        OrbitalPeriodMin = fvalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.orbitalperiodmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        OrbitalPeriodMax = fvalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.planetradiusmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetRadiusMin = fvalue;
                    else UI.InvalidCriteria();
                    break;
                
                case ExoplanetInputs.planetradiusmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetRadiusMax = fvalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.planetmassmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetMassMin = fvalue;
                    else UI.InvalidCriteria();
                    break;
                
                case ExoplanetInputs.planetmassmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetMassMax = fvalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.planettemperaturemin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetTemperatureMin = fvalue;
                    else UI.InvalidCriteria();
                    break;
                
                case ExoplanetInputs.planettemperaturemax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetTemperatureMax = fvalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.stellartemperaturemin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarTemperatureMin = fvalue;
                    else UI.InvalidCriteria();
                    break;
                
                case ExoplanetInputs.stellartemperaturemax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarTemperatureMax = fvalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.stellarradiusmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRadiusMin = fvalue;
                    else UI.InvalidCriteria();
                    break;
                
                case ExoplanetInputs.stellarradiusmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRadiusMax = fvalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.stellarmassmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarMassMin = fvalue;
                    else UI.InvalidCriteria();
                    break;
                
                case ExoplanetInputs.stellarmassmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarMassMax = fvalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.stellaragemin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarAgeMin = fvalue;
                    else UI.InvalidCriteria();
                    break;
                
                case ExoplanetInputs.stellaragemax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarAgeMax = fvalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.stellarrotationvelocitymin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRotationVelocityMin = fvalue;
                    else UI.InvalidCriteria();
                    break;
                
                case ExoplanetInputs.stellarrotationvelocitymax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRotationVelocityMax = fvalue;
                    else UI.InvalidCriteria();
                    break;
                
                case ExoplanetInputs.stellarrotationperiodmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRotationPeriodMin = fvalue;
                    else UI.InvalidCriteria();
                    break;
                
                case ExoplanetInputs.stellarrotationperiodmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRotationPeriodMax = fvalue;
                    else UI.InvalidCriteria();
                    break;

                case ExoplanetInputs.distancemin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        DistanceMin = fvalue;
                    else UI.InvalidCriteria();
                    break;
                
                case ExoplanetInputs.distancemax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        DistanceMax = fvalue;
                    else UI.InvalidCriteria();
                    break;
            } 
        }
    }
}
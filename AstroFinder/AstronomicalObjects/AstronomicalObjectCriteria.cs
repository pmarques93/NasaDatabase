using System.Globalization;
using System;

namespace AstroFinder
{
    /// <summary>
    /// Class that inherits from SearchField
    /// This class has AstronomicalObjects searchable criteria
    /// </summary>
    public class AstronomicalObjectCriteria: SearchField
    {
        private const byte MINVALUE = 0;
        private const ushort CURRENTYEAR = 2020;
        private const float FMAXVALUE = 100000000.0f;

        private string planetName;
        private string starName;
        private string discoveryMethod;
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
        /// <summary>
        /// PlanetName property
        /// </summary>
        public string PlanetName
        {
            get => planetName;
            set
            {
                if (value == " ".Trim()) planetName = "any";
                else planetName = value;
            }
        }
        /// <summary>
        /// StarName property
        /// </summary>
        public string StarName
        {
            get => starName;
            set
            {
                if (value == " ".Trim()) starName = "any";
                else starName = value;
            }
        }
        /// <summary>
        /// DiscoveryMethod property
        /// </summary>
        public string DiscoveryMethod
        {
            get => discoveryMethod;
            set
            {
                if (value == " ".Trim()) discoveryMethod = "any";
                else discoveryMethod = value;
            }
        }
        /// <summary>
        /// DiscoveryYearMin property
        /// </summary>
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
        /// <summary>
        /// DiscoveryYearMax property
        /// </summary>
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
        /// <summary>
        /// OrbitalPeriodMin property
        /// </summary>
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
        /// <summary>
        /// Property
        /// </summary>
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
        /// <summary>
        /// PlanetRadiusMin property
        /// </summary>
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
        /// <summary>
        /// PlanetRadiusMax property
        /// </summary>
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
        /// <summary>
        /// PlanetMassMin property
        /// </summary>
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
        /// <summary>
        /// PlanetMassMax property
        /// </summary>
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
        /// <summary>
        /// PlanetTemperatureMin property
        /// </summary>
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
        /// <summary>
        /// PlanetTemperatureMax property
        /// </summary>
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
        /// <summary>
        /// StellarTemperatureMin property
        /// </summary>
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
        /// <summary>
        /// StellarTemperatureMax property
        /// </summary>
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
        /// <summary>
        /// StellarRadiusMin property
        /// </summary>
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
        /// <summary>
        /// StellarRadiusMax property
        /// </summary>
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
        /// <summary>
        /// StellarMassMin property
        /// </summary>
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
        /// <summary>
        /// StellarMassMax property
        /// </summary>
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
        /// <summary>
        /// StellarAgeMin property
        /// </summary>
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
        /// <summary>
        /// StellarAgeMax property
        /// </summary>
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
        /// <summary>
        /// StellarRotationVelocityMin property
        /// </summary>
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
        /// <summary>
        /// StellarRotationVelocityMax property
        /// </summary>
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
        /// <summary>
        /// StellarRotationPeriodMin property
        /// </summary>
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
        /// <summary>
        /// StellarRotationPeriodMax property
        /// </summary>
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
        /// <summary>
        /// DistanceMin property
        /// </summary>
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
        /// <summary>
        /// DistanceMax property
        /// </summary>
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

        /// <summary>
        /// AstronomicalObjectCriteria constructor
        /// Gives default values to the class variables
        /// </summary>
        public AstronomicalObjectCriteria()
        {
            ResetFields();
        }

        /// <summary>
        /// Adds/Converts received criteria
        /// </summary>
        /// <param name="inputName">Receives a kind of Enum</param>
        /// <param name="inputValue">Receives a string with the user's input</param>
        public override void AddCriteria(Enum inputName, string inputValue)
        {
            ushort svalue;
            float fvalue;
            // Converts inputValue and sets a property
            switch (inputName)
            {
                case SearchFieldInputs.planetname:
                    PlanetName = inputValue;
                    break;

                case SearchFieldInputs.starname:
                    StarName = inputValue;
                    break;

                case SearchFieldInputs.discoverymethod:
                    DiscoveryMethod = inputValue;
                    break;

                case SearchFieldInputs.discoveryyearmin:
                    if (UInt16.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out svalue))
                        DiscoveryYearMin = svalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.discoveryyearmax:
                    if (UInt16.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out svalue))
                        DiscoveryYearMax = svalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.orbitalperiodmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        OrbitalPeriodMin = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.orbitalperiodmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        OrbitalPeriodMax = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.planetradiusmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetRadiusMin = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
                
                case SearchFieldInputs.planetradiusmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetRadiusMax = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.planetmassmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetMassMin = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
                
                case SearchFieldInputs.planetmassmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetMassMax = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.planettemperaturemin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetTemperatureMin = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
                
                case SearchFieldInputs.planettemperaturemax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        PlanetTemperatureMax = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.stellartemperaturemin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarTemperatureMin = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
                
                case SearchFieldInputs.stellartemperaturemax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarTemperatureMax = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.stellarradiusmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRadiusMin = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
                
                case SearchFieldInputs.stellarradiusmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRadiusMax = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.stellarmassmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarMassMin = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
                
                case SearchFieldInputs.stellarmassmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarMassMax = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.stellaragemin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarAgeMin = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
                
                case SearchFieldInputs.stellaragemax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarAgeMax = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.stellarrotationvelocitymin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRotationVelocityMin = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
                
                case SearchFieldInputs.stellarrotationvelocitymax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRotationVelocityMax = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
                
                case SearchFieldInputs.stellarrotationperiodmin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRotationPeriodMin = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
                
                case SearchFieldInputs.stellarrotationperiodmax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        StellarRotationPeriodMax = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;

                case SearchFieldInputs.distancemin:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        DistanceMin = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
                
                case SearchFieldInputs.distancemax:
                    if (float.TryParse(inputValue, NumberStyles.Any,
                        CultureInfo.InvariantCulture, out fvalue))
                        DistanceMax = fvalue;
                    else Program.UI.NotValid("Invalid criteria");
                    break;
            } 
        }

        /// <summary>
        /// Sets default values
        /// </summary>
        public override void ResetFields()
        {
            PlanetName = "any";
            StarName = "any";
            DiscoveryMethod = "any";
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
    }
}
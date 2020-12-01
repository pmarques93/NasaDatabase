using System.Collections;
using System.Collections.Generic;
namespace AstroFinder
{
    public struct Star: IStar
    {
        public string Name { get; }
        public float? StellarTemperature { get; }
        public float? StellarRadius { get; }
        public float? StellarMass { get; }
        public float? StellarAge { get; }
        public float? StellarRotationVelocity { get; }
        public float? StellarRotationPeriod { get; }
        public float? Distance { get; }
        public IEnumerable<IPlanet> ChildPlanets { get; }

        public Star(string starName, float stellarTemperature,
            float stellarRadius, float stellarMass, float stellarAge,
            float stellarRotationVelocity, float stellarRotationPeriod,
            float distance, IEnumerable<IPlanet> exoplanets)
        {
            Name = starName;
            StellarTemperature = stellarTemperature;
            StellarRadius = stellarRadius;
            StellarMass = stellarMass;
            StellarAge = stellarAge;
            StellarRotationVelocity = stellarRotationVelocity;
            StellarRotationPeriod = stellarRotationPeriod;
            Distance = distance;
            ChildPlanets = exoplanets; 
        }
    }
}

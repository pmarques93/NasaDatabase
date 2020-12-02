using System.Collections.Generic;

namespace AstroFinder
{
    public class Star: IStar
    {
        public string Name { get; }
        public float? StellarTemperature { get; }
        public float? StellarRadius { get; }
        public float? StellarMass { get; }
        public float? StellarAge { get; }
        public float? StellarRotationVelocity { get; }
        public float? StellarRotationPeriod { get; }
        public float? Distance { get; }
        public ICollection<IPlanet> ChildPlanets { get; }

        public Star(string starName, string stellarTemperature,
            string stellarRadius, string stellarMass, string stellarAge,
            string stellarRotationVelocity, string stellarRotationPeriod,
            string distance)
        {
            Name = starName;
            StellarTemperature = float.TryParse(stellarTemperature, out float sTemp) ? sTemp : null;
            StellarRadius = float.TryParse(stellarRadius, out float sRad) ? sRad : null;
            StellarMass = float.TryParse(stellarMass, out float sMass) ? sMass : null;
            StellarAge = float.TryParse(stellarAge, out float sAge) ? sAge : null;
            StellarRotationVelocity = float.TryParse(stellarRotationVelocity, out float srotvel) ? srotvel : null;
            StellarRotationPeriod = float.TryParse(stellarRotationPeriod, out float srotper) ? srotper : null;
            Distance = float.TryParse(distance, out float dist) ? dist : null;
            ChildPlanets = new List<IPlanet>();

            Exoplanet.PlanetCreation += AddChildPlanet;
        }

        public Star(string name) { Name = name; }

        public void AddChildPlanet(IPlanet planetToTest)
        {
            if (planetToTest.ParentStar.Name == Name)
            {
                ChildPlanets.Add(planetToTest);
                planetToTest.ParentStar = this;
            }
        }

        ~Star()
        {
            Exoplanet.PlanetCreation -= AddChildPlanet;
        }

        public override bool Equals(object obj)
        {
            return (obj as Star)?.Name == Name;
        }
    }
}

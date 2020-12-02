using System.Collections.Generic;
using System.Globalization;

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
            StellarTemperature = float.TryParse(stellarTemperature, NumberStyles.Any, CultureInfo.InvariantCulture, out float sTemp) ? sTemp : null;
            StellarRadius = float.TryParse(stellarRadius, NumberStyles.Any, CultureInfo.InvariantCulture, out float sRad) ? sRad : null;
            StellarMass = float.TryParse(stellarMass, NumberStyles.Any, CultureInfo.InvariantCulture, out float sMass) ? sMass : null;
            StellarAge = float.TryParse(stellarAge, NumberStyles.Any, CultureInfo.InvariantCulture, out float sAge) ? sAge : null;
            StellarRotationVelocity = float.TryParse(stellarRotationVelocity, NumberStyles.Any, CultureInfo.InvariantCulture, out float srotvel) ? srotvel : null;
            StellarRotationPeriod = float.TryParse(stellarRotationPeriod, NumberStyles.Any, CultureInfo.InvariantCulture, out float srotper) ? srotper : null;
            Distance = float.TryParse(distance, NumberStyles.Any, CultureInfo.InvariantCulture, out float dist) ? dist : null;
            ChildPlanets = new List<IPlanet>();
        }

        public Star(string name) { Name = name; }

        public override bool Equals(object obj)
        {
            return (obj as Star)?.Name == Name;
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}

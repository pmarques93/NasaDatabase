using System.Collections.Generic;
namespace AstroFinder
{
    public interface IStar: IAstronomicalObject
    {
        float? StellarTemperature { get; }
        float? StellarRadius { get; }
        float? StellarMass { get; }
        float? StellarAge { get; }
        float? StellarRotationVelocity { get; }
        float? StellarRotationPeriod { get; }
        float? Distance { get; }
        ICollection<IPlanet> ChildPlanets { get; }
    }
}

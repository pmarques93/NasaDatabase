using System;
namespace AstroFinder
{
    public interface IPlanet: IAstronomicalObject
    {
        IStar ParentStar { get; set; }
        string DiscoveryMethod { get; }
        ushort? DiscoveryYear { get; }
        float? OrbitalPeriod { get; }
        float? PlanetRadius { get; }
        float? PlanetMass { get; }
        float? PlanetTemperature { get; }
        public string Information();
    }
}

namespace AstroFinder
{
    public interface IPlanet: IAstronomicalObject
    {
        IStar ParentStar { get; }
        string DiscoveryMethod { get; }
        ushort? DiscoveryYear { get; }
        float? OrbitalPeriod { get; }
        float? PlanetRadius { get; }
        float? PlanetMass { get; }
        float? PlanetTemperature { get; }
    }
}

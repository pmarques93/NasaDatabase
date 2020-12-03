using System;
namespace AstroFinder
{
    /// <summary>
    /// Interface for exoplanets. This interface implements IAstromicalObject
    /// </summary>
    public interface IPlanet: IAstronomicalObject
    {
        /// <summary>
        /// Planet's ParentStar property
        /// </summary>
        IStar ParentStar { get; set; }

        /// <summary>
        /// Planet's DiscoveryMethod property
        /// </summary>
        string DiscoveryMethod { get; }

        /// <summary>
        /// Planet's DiscoveryYear property
        /// </summary>
        ushort? DiscoveryYear { get; }

        /// <summary>
        /// Planet's OrbitalPeriod property
        /// </summary>
        float? OrbitalPeriod { get; }

        /// <summary>
        /// Planet's PlanetRadius property
        /// </summary>
        float? PlanetRadius { get; }

        /// <summary>
        /// Planet's PlanetMass property
        /// </summary>
        float? PlanetMass { get; }

        /// <summary>
        /// Planet's Temperature property
        /// </summary>
        float? PlanetTemperature { get; }
    }
}

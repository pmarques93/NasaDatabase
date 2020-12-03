using System.Collections.Generic;
namespace AstroFinder
{
    /// <summary>
    /// Interface for stars. This interface implements IAstromicalObject
    /// </summary>
    public interface IStar: IAstronomicalObject
    {
        /// <summary>
        /// Star's Temperature property
        /// </summary>
        float? StellarTemperature { get; }

        /// <summary>
        /// Star's Radius property
        /// </summary>
        float? StellarRadius { get; }

        /// <summary>
        /// Star's Mass property
        /// </summary>
        float? StellarMass { get; }

        /// <summary>
        /// Star's Age property
        /// </summary>
        float? StellarAge { get; }

        /// <summary>
        /// Star's rotation velocity property
        /// </summary>
        float? StellarRotationVelocity { get; }

        /// <summary>
        /// Star's rotation period property
        /// </summary>
        float? StellarRotationPeriod { get; }

        /// <summary>
        /// Star's distance from the sun property
        /// </summary>
        float? Distance { get; }

        /// <summary>
        /// Star's ICollection of child planets property
        /// </summary>
        ICollection<IPlanet> ChildPlanets { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    public class StarQuery : IQuery<IStar>
    {
        private readonly IEnumerable<IPlanet> allPlanets;
        private readonly ICollection<IStar> nonRepeatedStars;
        public StarQuery(IEnumerable<IPlanet> allPlanets,
                        ICollection<IStar> nonRepeatedStars)
        {
            this.allPlanets = allPlanets;
            this.nonRepeatedStars = nonRepeatedStars;
        }

        public IEnumerable<IStar> Filter(ISearchField temp)
        {
            AstronomicalObjectCriteria criteria =
                temp as AstronomicalObjectCriteria;

            // Filters planets to show the user input data only
            // Shows 'Query.numResultsToShow' elements at a time
            IEnumerable<IStar> filteredStars =
            from star in nonRepeatedStars
            where star.Name == null ||
                    star.Name.ToLower().Contains(
                    criteria.StarName ?? "any") ||
                    criteria.StarName == null ||
                    criteria.StarName == "any"
            where star.StellarTemperature == null ||
                    star.StellarTemperature <=
                        criteria.StellarTemperatureMax &&
                        star.StellarTemperature >=
                        criteria.StellarTemperatureMin ||
                        star.StellarTemperature == null
            where star.StellarRadius == null ||
                    star.StellarRadius <=
                        criteria.StellarRadiusMax &&
                        star.StellarRadius >=
                        criteria.StellarRadiusMin ||
                        star.StellarRadius == null
            where star.StellarMass == null ||
                    star.StellarMass <=
                        criteria.StellarMassMax &&
                        star.StellarMass >=
                        criteria.StellarMassMin ||
                   star.StellarMass == null
            where star.StellarAge == null ||
                   star.StellarAge <=
                   criteria.StellarAgeMax &&
                   star.StellarAge >=
                   criteria.StellarAgeMin ||
                   star.StellarAge == null
            where star.StellarRotationVelocity == null ||
                    star.StellarRotationVelocity <=
                        criteria.StellarRotationVelocityMax &&
                        star.StellarRotationVelocity >=
                        criteria.StellarRotationVelocityMin ||
                        star.StellarRotationVelocity == null
            where star.StellarRotationPeriod == null ||
                    star.StellarRotationPeriod <=
                        criteria.StellarRotationPeriodMax &&
                        star.StellarRotationPeriod >=
                        criteria.StellarRotationPeriodMin ||
                        star.StellarRotationPeriod == null
            where star.Distance == null ||
                    star.Distance <=
                        criteria.DistanceMax &&
                        star.Distance >=
                        criteria.DistanceMin ||
                        star.Distance == null
            where star.ChildPlanets == null ||
                    star.ChildPlanets.Count <=
                        criteria.ChildPlanetsMax &&
                        star.ChildPlanets.Count >=
                        criteria.ChildPlanetsMin
            join planet in allPlanets on star.Name
               equals planet.ParentStar.Name
            where planet.Name == null ||
                    planet.Name.ToLower().Contains(
                        criteria.PlanetName ?? "any") ||
                        criteria.PlanetName == null ||
                        criteria.PlanetName == "any"
            where planet.DiscoveryMethod == null ||
                    planet.DiscoveryMethod.ToLower().Contains(
                    criteria.DiscoveryMethod ?? "any") ||
                    criteria.DiscoveryMethod == null ||
                    criteria.DiscoveryMethod == "any"
            where planet.DiscoveryYear == null ||
                    planet.DiscoveryYear <=
                        criteria.DiscoveryYearMax &&
                        planet.DiscoveryYear >=
                        criteria.DiscoveryYearMin ||
                        planet.DiscoveryYear == null
            where planet.OrbitalPeriod == null ||
                    planet.OrbitalPeriod <=
                        criteria.OrbitalPeriodMax &&
                        planet.OrbitalPeriod >=
                        criteria.OrbitalPeriodMin ||
                        planet.OrbitalPeriod == null
            where planet.PlanetRadius == null ||
                    planet.PlanetRadius <=
                        criteria.PlanetRadiusMax &&
                        planet.PlanetRadius >=
                        criteria.PlanetRadiusMin ||
                        planet.PlanetRadius == null
            where planet.PlanetMass == null ||
                    planet.PlanetMass <=
                        criteria.PlanetMassMax &&
                        planet.PlanetMass >=
                        criteria.PlanetMassMin ||
                        planet.PlanetMass == null
            where planet.PlanetTemperature == null ||
                    planet.PlanetTemperature <=
                        criteria.PlanetTemperatureMax &&
                        planet.PlanetTemperature >=
                        criteria.PlanetTemperatureMin ||
                        planet.PlanetTemperature == null
            select star;

            return filteredStars;
        }
    }
}

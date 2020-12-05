using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    class PlanetQuery : IQuery<IPlanet>
    {
        private readonly IEnumerable<IPlanet> allPlanets;
        public PlanetQuery(IEnumerable<IPlanet> allPlanets)
        {
            allPlanets = new List<IPlanet>();
            this.allPlanets = allPlanets;
        }

        public IEnumerable<IPlanet> Filter(ISearchField temp)
        {
            AstronomicalObjectCriteria criteria = 
                temp as AstronomicalObjectCriteria;

            // Filters planets to show the user input data only
            // Shows 'Query.numResultsToShow' elements at a time
            IEnumerable<IPlanet> filteredPlanets =
            from planet in allPlanets
            where planet.Name == null ||
                    planet.Name.ToLower().Contains(
                    criteria.PlanetName ?? "any") ||
                    criteria.PlanetName == null ||
                    criteria.PlanetName == "any"
            where planet.ParentStar == null ||
                    planet.ParentStar.Name.ToLower().Contains(
                        criteria.StarName ?? "any") ||
                        criteria.StarName == null ||
                        criteria.StarName == "any"
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
            where planet.ParentStar == null ||
                    planet.ParentStar.StellarTemperature == null ||
                        planet.ParentStar.StellarTemperature <=
                        criteria.StellarTemperatureMax &&
                        planet.ParentStar.StellarTemperature >=
                        criteria.StellarTemperatureMin ||
                        planet.ParentStar.StellarTemperature == null
            where planet.ParentStar == null ||
                    planet.ParentStar.StellarRadius == null ||
                        planet.ParentStar.StellarRadius <=
                            criteria.StellarRadiusMax &&
                            planet.ParentStar.StellarRadius >=
                            criteria.StellarRadiusMin ||
                            planet.ParentStar.StellarRadius == null
            where planet.ParentStar == null ||
                     planet.ParentStar.StellarMass == null ||
                        planet.ParentStar.StellarMass <=
                            criteria.StellarMassMax &&
                            planet.ParentStar.StellarMass >=
                            criteria.StellarMassMin ||
                            planet.ParentStar.StellarMass == null
            where planet.ParentStar == null ||
                    planet.ParentStar.StellarAge == null ||
                        planet.ParentStar.StellarAge <=
                            criteria.StellarAgeMax &&
                            planet.ParentStar.StellarAge >=
                            criteria.StellarAgeMin ||
                            planet.ParentStar.StellarAge == null
            where planet.ParentStar == null ||
                    planet.ParentStar.StellarRotationVelocity == null ||
                        planet.ParentStar.StellarRotationVelocity <=
                        criteria.StellarRotationVelocityMax &&
                        planet.ParentStar.StellarRotationVelocity >=
                        criteria.StellarRotationVelocityMin ||
                        planet.ParentStar.StellarRotationVelocity == null
            where planet.ParentStar == null ||
                    planet.ParentStar.StellarRotationPeriod == null ||
                        planet.ParentStar.StellarRotationPeriod <=
                            criteria.StellarRotationPeriodMax &&
                            planet.ParentStar.StellarRotationPeriod >=
                            criteria.StellarRotationPeriodMin ||
                            planet.ParentStar.StellarRotationPeriod == null
            where planet.ParentStar == null ||
                    planet.ParentStar.Distance == null ||
                        planet.ParentStar.Distance <=
                            criteria.DistanceMax &&
                            planet.ParentStar.Distance >=
                            criteria.DistanceMin ||
                            planet.ParentStar.Distance == null
            where planet.ParentStar == null ||
                    planet.ParentStar.ChildPlanets == null ||
                        planet.ParentStar.ChildPlanets.Count <=
                            criteria.ChildPlanetsMax &&
                            planet.ParentStar.ChildPlanets.Count >=
                            criteria.ChildPlanetsMin
            select planet;

            return filteredPlanets;
        }
    }
}
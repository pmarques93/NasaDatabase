using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    /// <summary>
    /// Class for planet queries. Implements IQuery<T>
    /// </summary>
    class PlanetQuery : IQuery<IPlanet>
    {
        /// <summary>
        /// IEnumerable with all planets
        /// </summary>
        private readonly IEnumerable<IPlanet> allPlanets;

        /// <summary>
        /// Constructor for PlanetQuery
        /// </summary>
        /// <param name="allPlanets">Receives IEnumerable with allPlanets</param>
        public PlanetQuery(IEnumerable<IPlanet> allPlanets)
        {
            this.allPlanets = allPlanets;
        }

        /// <summary>
        /// Method to filter data through a query
        /// </summary>
        /// <param name="criteria">Search Criteria for seach filters</param>
        /// <returns>Returns a filtered IEnumerable of type T</returns>
        public IEnumerable<IPlanet> Filter(ISearchField temp)
        {
            AstronomicalObjectCriteria criteria = 
                temp as AstronomicalObjectCriteria;

            // Filters planets to show the user input data only
            IEnumerable<IPlanet> filteredPlanets =
            from planet in allPlanets

            where   planet.Name != null &&
                        criteria.PlanetName == "any" ||
                    planet.Name != null && planet.
                        Name.ToLower().Contains(criteria.PlanetName) ||

                    (planet?.Name?.ToLower().Contains(
                    criteria.PlanetName ?? "any") ?? false ||
                    (criteria.PlanetName == "any"))

            where   planet.ParentStar.Name != null &&
                        criteria.StarName == "any" ||
                    planet.ParentStar.Name != null && planet.
                        ParentStar.Name.ToLower().Contains(criteria.StarName) ||

                    (planet?.ParentStar?.Name?.ToLower().Contains(
                    criteria.StarName ?? "any") ?? false ||
                    (criteria.StarName == "any"))

            where   planet.DiscoveryMethod != null && 
                        criteria.DiscoveryMethod == "any" ||
                    planet.DiscoveryMethod != null && planet.
                        DiscoveryMethod.ToLower().Contains(
                        criteria.DiscoveryMethod) ||

                    (planet?.DiscoveryMethod?.ToLower().Contains(
                    criteria.DiscoveryMethod ?? "any") ?? false ||
                    (criteria.DiscoveryMethod == "any"))

            where   criteria.DiscoveryYearMin == 
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.DiscoveryYearMax ==
                    AstronomicalObjectCriteria.CURRENTYEAR &&
                    planet.DiscoveryYear == null ||

                    planet.DiscoveryYear <=
                    criteria.DiscoveryYearMax &&
                    planet.DiscoveryYear >=
                    criteria.DiscoveryYearMin
                    
            where   criteria.OrbitalPeriodMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.OrbitalPeriodMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    planet.OrbitalPeriod == null ||

                    planet.OrbitalPeriod <=
                    criteria.OrbitalPeriodMax &&
                    planet.OrbitalPeriod >=
                    criteria.OrbitalPeriodMin
                    
            where   criteria.PlanetRadiusMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.PlanetRadiusMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    planet.PlanetRadius == null ||

                    planet.PlanetRadius <=
                    criteria.PlanetRadiusMax &&
                    planet.PlanetRadius >=
                    criteria.PlanetRadiusMin

            where   criteria.PlanetMassMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.PlanetMassMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    planet.PlanetMass == null ||

                    planet.PlanetMass <=
                    criteria.PlanetMassMax &&
                    planet.PlanetMass >=
                    criteria.PlanetMassMin

            where   criteria.PlanetTemperatureMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.PlanetTemperatureMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    planet.PlanetTemperature == null ||

                    planet.PlanetTemperature <=
                    criteria.PlanetTemperatureMax &&
                    planet.PlanetTemperature >=
                    criteria.PlanetTemperatureMin

            where   criteria.StellarTemperatureMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarTemperatureMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    planet.ParentStar.StellarTemperature == null ||

                    planet.ParentStar.StellarTemperature <=
                    criteria.StellarTemperatureMax &&
                    planet.ParentStar.StellarTemperature >=
                    criteria.StellarTemperatureMin

            where   criteria.StellarRadiusMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarRadiusMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    planet.ParentStar.StellarRadius == null ||

                    planet.ParentStar.StellarRadius <=
                    criteria.StellarRadiusMax &&
                    planet.ParentStar.StellarRadius >=
                    criteria.StellarRadiusMin

            where   criteria.StellarMassMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarMassMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    planet.ParentStar.StellarMass == null ||

                    planet.ParentStar.StellarMass <=
                    criteria.StellarMassMax &&
                    planet.ParentStar.StellarMass >=
                    criteria.StellarMassMin

            where   criteria.StellarAgeMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarAgeMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    planet.ParentStar.StellarAge == null ||

                    planet.ParentStar.StellarAge <=
                    criteria.StellarAgeMax &&
                    planet.ParentStar.StellarAge >=
                    criteria.StellarAgeMin

            where   criteria.StellarRotationVelocityMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarRotationVelocityMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    planet.ParentStar.StellarRotationVelocity == null ||

                    planet.ParentStar.StellarRotationVelocity <=
                    criteria.StellarRotationVelocityMax &&
                    planet.ParentStar.StellarRotationVelocity >=
                    criteria.StellarRotationVelocityMin


            where   criteria.StellarRotationPeriodMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarRotationPeriodMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    planet.ParentStar.StellarRotationPeriod == null ||

                    planet.ParentStar.StellarRotationPeriod <=
                    criteria.StellarRotationPeriodMax &&
                    planet.ParentStar.StellarRotationPeriod >=
                    criteria.StellarRotationPeriodMin

            where   criteria.DistanceMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.DistanceMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    planet.ParentStar.StellarAge == null ||

                    planet.ParentStar.Distance <=
                    criteria.DistanceMax &&
                    planet.ParentStar.Distance >=
                    criteria.DistanceMin

            where   criteria.ChildPlanetsMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.ChildPlanetsMax ==
                    AstronomicalObjectCriteria.BMAXVALUE &&
                    planet.ParentStar.StellarAge == null ||

                    planet.ParentStar.ChildPlanets.Count <=
                    criteria.ChildPlanetsMax &&
                    planet.ParentStar.ChildPlanets.Count >=
                    criteria.ChildPlanetsMin

            select planet;

            return filteredPlanets;
        }

        /// <summary>
        /// Method to order filtered data
        /// </summary>
        /// <param name="listOrder">Enum to know the desired order</param>
        /// <param name="temp">Search Criteria for seach filters</param>
        /// <param name="numTimesShown">Number of times the result was 
        /// shown</param>
        /// <returns>Returns an IEnumerable with a certain order</returns>
        public IEnumerable<IPlanet> Order(ListOrder listOrder, 
            ISearchField temp, ushort numTimesShown)
        {
            AstronomicalObjectCriteria criteria =
                temp as AstronomicalObjectCriteria;

            IEnumerable<IPlanet> orderedPlanets =
                            new List<IPlanet>();

            // Switch with Ordererd planets
            switch (listOrder)
            {
                case ListOrder.ascendingname:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.Name ascending
                     select planet).
                    ThenBy(p => p.DiscoveryYear).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingname:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.Name descending
                     select planet).
                    ThenBy(p => p.DiscoveryYear).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstarname:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.Name ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstarname:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.Name descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingdiscoverymethod:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.DiscoveryMethod ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingdiscoverymethod:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.DiscoveryMethod descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingdiscoveryyear:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.DiscoveryYear ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingdiscoveryyear:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.DiscoveryYear descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingorbitalperiod:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.OrbitalPeriod ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingorbitalperiod:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.OrbitalPeriod descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingplanetradius:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.PlanetRadius ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingplanetradius:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.PlanetRadius descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingplanetmass:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.PlanetMass ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingplanetmass:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.PlanetMass descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingplanettemperature:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.PlanetTemperature ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingplanettemperature:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.PlanetTemperature descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellartemperature:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.StellarTemperature
                     ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellartemperature:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.StellarTemperature
                     descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellarradius:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.StellarRadius
                     ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellarradius:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.StellarRadius
                     descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellarmass:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.StellarMass
                     ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellarmass:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.StellarMass
                     descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellarage:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.StellarAge
                     ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellarage:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.StellarAge
                     descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellarrotationvelocity:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.
                            StellarRotationVelocity ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellarrotationvelocity:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.
                            StellarRotationVelocity descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellarrotationperiod:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.
                            StellarRotationPeriod ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellarrotationperiod:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.
                            StellarRotationPeriod descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingdistance:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.Distance ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingdistance:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.Distance descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingchildplanets:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.ChildPlanets
                     ascending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingchildplanets:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     orderby planet.ParentStar.ChildPlanets
                     descending
                     select planet).
                    ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                default:
                    orderedPlanets =
                    (from planet in Filter(criteria)
                     select planet).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
            }

            return orderedPlanets;
        }
    }
}
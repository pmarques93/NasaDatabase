using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    /// <summary>
    /// Class for star queries. Implements IQuery<T>
    /// </summary>
    public class StarQuery : IQuery<IStar>
    {
        /// <summary>
        /// IEnumerable with all planets
        /// </summary>
        private readonly IEnumerable<IPlanet> allPlanets;

        /// <summary>
        /// IEnumerable with all non repeated stars
        /// </summary>
        private readonly ICollection<IStar> nonRepeatedStars;

        /// <summary>
        /// Constructor for PlanetQuery
        /// </summary>
        /// <param name="allPlanets">Receives IEnumerable with allPlanets</param>
        /// <param name="nonRepeatedStars">Receives ICollection 
        /// with nonRepeatedStars</param>
        public StarQuery(IEnumerable<IPlanet> allPlanets,
                        ICollection<IStar> nonRepeatedStars)
        {
            this.allPlanets = allPlanets;
            this.nonRepeatedStars = nonRepeatedStars;
        }

        /// <summary>
        /// Method to filter data through a query
        /// </summary>
        /// <param name="criteria">Search Criteria for seach filters</param>
        /// <returns>Returns a filtered IEnumerable of type T</returns>
        public IEnumerable<IStar> Filter(ISearchField temp)
        {
            AstronomicalObjectCriteria criteria =
                temp as AstronomicalObjectCriteria;

            // Filters planets to show the user input data only
            IEnumerable<IStar> filteredStars =
            from star in nonRepeatedStars

            where   star.Name != null &&
                    criteria.StarName == "any" ||
                    star.Name != null && star.
                    Name.ToLower().Contains(criteria.StarName) ||

                    (star?.Name?.ToLower().Contains(
                    criteria.StarName ?? "any") ?? false ||
                    (criteria.StarName == "any"))

            where criteria.StellarTemperatureMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarTemperatureMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    star.StellarTemperature == null ||

                    star.StellarTemperature <=
                    criteria.StellarTemperatureMax &&
                    star.StellarTemperature >=
                    criteria.StellarTemperatureMin

            where criteria.StellarRadiusMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarRadiusMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    star.StellarRadius == null ||

                    star.StellarRadius <=
                    criteria.StellarRadiusMax &&
                    star.StellarRadius >=
                    criteria.StellarRadiusMin

            where criteria.StellarMassMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarMassMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    star.StellarMass == null ||

                    star.StellarMass <=
                    criteria.StellarMassMax &&
                    star.StellarMass >=
                    criteria.StellarMassMin

            where criteria.StellarAgeMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarAgeMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    star.StellarAge == null ||

                    star.StellarAge <=
                    criteria.StellarAgeMax &&
                    star.StellarAge >=
                    criteria.StellarAgeMin

            where criteria.StellarRotationVelocityMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarRotationVelocityMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    star.StellarRotationVelocity == null ||

                    star.StellarRotationVelocity <=
                    criteria.StellarRotationVelocityMax &&
                    star.StellarRotationVelocity >=
                    criteria.StellarRotationVelocityMin


            where criteria.StellarRotationPeriodMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.StellarRotationPeriodMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    star.StellarRotationPeriod == null ||

                    star.StellarRotationPeriod <=
                    criteria.StellarRotationPeriodMax &&
                    star.StellarRotationPeriod >=
                    criteria.StellarRotationPeriodMin

            where criteria.DistanceMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.DistanceMax ==
                    AstronomicalObjectCriteria.FMAXVALUE &&
                    star.Distance == null ||

                    star.Distance <=
                    criteria.DistanceMax &&
                    star.Distance >=
                    criteria.DistanceMin

            where criteria.ChildPlanetsMin ==
                    AstronomicalObjectCriteria.MINVALUE &&
                    criteria.ChildPlanetsMax ==
                    AstronomicalObjectCriteria.BMAXVALUE &&
                    star.ChildPlanets == null ||

                    star.ChildPlanets.Count <=
                    criteria.ChildPlanetsMax &&
                    star.ChildPlanets.Count >=
                    criteria.ChildPlanetsMin

            join planet in allPlanets on star.Name
               equals planet.ParentStar.Name

                where planet.Name != null &&
                        criteria.PlanetName == "any" ||
                        planet.Name != null && planet.
                        Name.ToLower().Contains(criteria.PlanetName) ||

                        (planet?.Name?.ToLower().Contains(
                        criteria.PlanetName ?? "any") ?? false ||
                        (criteria.PlanetName == "any"))

                where planet.DiscoveryMethod != null &&
                        criteria.DiscoveryMethod == "any" ||
                        planet.DiscoveryMethod != null && planet.
                        DiscoveryMethod.ToLower().Contains(
                        criteria.DiscoveryMethod) ||

                        (planet?.DiscoveryMethod?.ToLower().Contains(
                        criteria.DiscoveryMethod ?? "any") ?? false ||
                        (criteria.DiscoveryMethod == "any"))

                where criteria.DiscoveryYearMin ==
                        AstronomicalObjectCriteria.MINVALUE &&
                        criteria.DiscoveryYearMax ==
                        AstronomicalObjectCriteria.CURRENTYEAR &&
                        planet.DiscoveryYear == null ||

                        planet.DiscoveryYear <=
                        criteria.DiscoveryYearMax &&
                        planet.DiscoveryYear >=
                        criteria.DiscoveryYearMin

                where criteria.OrbitalPeriodMin ==
                        AstronomicalObjectCriteria.MINVALUE &&
                        criteria.OrbitalPeriodMax ==
                        AstronomicalObjectCriteria.FMAXVALUE &&
                        planet.OrbitalPeriod == null ||

                        planet.OrbitalPeriod <=
                        criteria.OrbitalPeriodMax &&
                        planet.OrbitalPeriod >=
                        criteria.OrbitalPeriodMin

                where criteria.PlanetRadiusMin ==
                        AstronomicalObjectCriteria.MINVALUE &&
                        criteria.PlanetRadiusMax ==
                        AstronomicalObjectCriteria.FMAXVALUE &&
                        planet.PlanetRadius == null ||

                        planet.PlanetRadius <=
                        criteria.PlanetRadiusMax &&
                        planet.PlanetRadius >=
                        criteria.PlanetRadiusMin

                where criteria.PlanetMassMin ==
                        AstronomicalObjectCriteria.MINVALUE &&
                        criteria.PlanetMassMax ==
                        AstronomicalObjectCriteria.FMAXVALUE &&
                        planet.PlanetMass == null ||

                        planet.PlanetMass <=
                        criteria.PlanetMassMax &&
                        planet.PlanetMass >=
                        criteria.PlanetMassMin

                where criteria.PlanetTemperatureMin ==
                        AstronomicalObjectCriteria.MINVALUE &&
                        criteria.PlanetTemperatureMax ==
                        AstronomicalObjectCriteria.FMAXVALUE &&
                        planet.PlanetTemperature == null ||

                        planet.PlanetTemperature <=
                        criteria.PlanetTemperatureMax &&
                        planet.PlanetTemperature >=
                        criteria.PlanetTemperatureMin

            select star;

            return filteredStars;
        }

        /// <summary>
        /// Method to order filtered data
        /// </summary>
        /// <param name="listOrder">Enum to know the desired order</param>
        /// <param name="temp">Search Criteria for seach filters</param>
        /// <param name="numTimesShown">Number of times the result was 
        /// shown</param>
        /// <returns>Returns an IEnumerable with a certain order</returns>
        public IEnumerable<IStar> Order(ListOrder listOrder,
            ISearchField temp, ushort numTimesShown)
        {
            AstronomicalObjectCriteria criteria =
                temp as AstronomicalObjectCriteria;

            IEnumerable<IStar> orderedStars =
                            new List<IStar>();

            // Switch with Ordererd planets
            switch (listOrder)
            {
                case ListOrder.ascendingname:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.Name ascending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingname:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.Name descending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstarname:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.ParentStar.Name ascending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstarname:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.ParentStar.Name descending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingdiscoverymethod:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.DiscoveryMethod ascending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingdiscoverymethod:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.DiscoveryMethod descending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingdiscoveryyear:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.DiscoveryYear ascending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingdiscoveryyear:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.DiscoveryYear descending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingorbitalperiod:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.OrbitalPeriod ascending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingorbitalperiod:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.OrbitalPeriod descending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingplanetradius:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.PlanetRadius ascending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingplanetradius:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.PlanetRadius descending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingplanetmass:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.PlanetMass ascending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingplanetmass:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.PlanetMass descending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingplanettemperature:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.PlanetTemperature ascending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingplanettemperature:
                    orderedStars =
                    (from star in Filter(criteria)
                     join planet in allPlanets
                     on star.Name equals planet.ParentStar.Name
                     orderby planet.PlanetTemperature descending
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellartemperature:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.StellarTemperature
                     ascending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellartemperature:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.StellarTemperature
                     descending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellarradius:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.StellarRadius
                     ascending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellarradius:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.StellarRadius
                     descending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellarmass:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.StellarMass
                     ascending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellarmass:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.StellarMass
                     descending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellarage:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.StellarAge
                     ascending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellarage:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.StellarAge
                     descending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellarrotationvelocity:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.
                            StellarRotationVelocity ascending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellarrotationvelocity:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.
                            StellarRotationVelocity descending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingstellarrotationperiod:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.
                            StellarRotationPeriod ascending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingstellarrotationperiod:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.
                            StellarRotationPeriod descending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingdistance:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.Distance ascending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingdistance:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.Distance descending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.ascendingchildplanets:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.ChildPlanets
                     ascending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                case ListOrder.descendingchildplanets:
                    orderedStars =
                    (from star in Filter(criteria)
                     orderby star.ChildPlanets
                     descending
                     select star).
                     ThenBy(p => p.Name).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
                default:
                    orderedStars =
                    (from star in Filter(criteria)
                     select star).
                    Skip(Manager.numResultsToShow * numTimesShown).
                    Take(Manager.numResultsToShow);
                    break;
            }
            return orderedStars;
        }
    }
}

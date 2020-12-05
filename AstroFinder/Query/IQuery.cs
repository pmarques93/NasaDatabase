using System.Collections.Generic;

namespace AstroFinder
{
    /// <summary>
    /// Interface for Queries
    /// </summary>
    /// <typeparam name="T">The type of object</typeparam>
    public interface IQuery<T>
    {
        /// <summary>
        /// Method to filter data through a query
        /// </summary>
        /// <param name="criteria">Search Criteria for seach filters</param>
        /// <returns>Returns a filtered IEnumerable of type T</returns>
        IEnumerable<T> Filter(ISearchField criteria);

        /// <summary>
        /// Method to order filtered data
        /// </summary>
        /// <param name="listOrder">Enum to know the desired order</param>
        /// <param name="temp">Search Criteria for seach filters</param>
        /// <param name="numTimesShown">Number of times the result was 
        /// shown</param>
        /// <returns>Returns an IEnumerable with a certain order</returns>
        IEnumerable<T> Order(ListOrder listOrder, ISearchField criteria, 
            ushort numTimesShown);
    }
}

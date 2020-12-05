using System.Collections.Generic;

namespace AstroFinder
{
    public interface IQuery<T>
    {
        /// <summary>
        /// Filters data with a query
        /// </summary>
        /// <param name="criteria">Search Criteria for seach filters</param>
        /// <returns>Returns an IEnumerable of type T</returns>
        IEnumerable<T> Filter(ISearchField criteria);
    }
}

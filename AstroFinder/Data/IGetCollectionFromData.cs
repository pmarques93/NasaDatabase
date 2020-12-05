using System.Collections;
using System.Collections.Generic;

namespace AstroFinder
{
    /// <summary>
    /// Defines a method that gets a collection of a given type from
    /// some data of a given type.
    /// </summary>
    /// <typeparam name="T">The type of the data from which the collection
    /// will come from.</typeparam>
    /// <typeparam name="U">The type of the collection that will
    /// returned.</typeparam>
    public interface IGetCollectionFromData<T, U> where T : IEnumerable
                                                    where U : ICollection
    {
        /// <summary>
        /// Gets a collection from a given data.
        /// </summary>
        /// <param name="data">Data from which the collection will come
        ///  from.</param>
        /// <returns></returns>
        U GetCollection(T data);
    }
}
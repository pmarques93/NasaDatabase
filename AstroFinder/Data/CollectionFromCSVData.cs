using System.Collections;
using System.Collections.Generic;

namespace AstroFinder
{
    /// <summary>
    /// Defines a method to get a collection from a given string array of data.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class CollectionFromCSVData<T> : 
                            IGetCollectionFromData<string[], T> 
                            where T : ICollection
    {
        /// <summary>
        /// Gets a collection of type T from the given data.
        /// </summary>
        /// <param name="data">Data from which tha collection will be 
        /// created.</param>
        /// <returns></returns>
        public abstract T GetCollection(string[] data);
    }
}
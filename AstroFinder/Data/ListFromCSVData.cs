using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    /// <summary>
    /// Responsible for getting a list of objects of type T.
    /// </summary>
    /// <typeparam name="T">Type of the objects that will be listed.</typeparam>
    public abstract class ListFromCSVData<T> : 
                            CollectionFromCSVData<List<T>> 
    {
        /// <summary>
        /// Headers that will be looked for on the data.
        /// </summary>
        protected virtual string[] HeadersOfInteress { get; }
        /// <summary>
        /// Constructor, that creates a new instance of ListFromCSVData and 
        /// initializes its properties.
        /// </summary>
        /// <param name="headersOfInteress"></param>
        public ListFromCSVData(string[] headersOfInteress)
        {
            HeadersOfInteress = headersOfInteress;
        }

        /// <summary>
        /// Gets a List of objects of type T.
        /// </summary>
        /// <param name="data">Data from which the collection will be 
        /// created.</param>
        /// <returns>List of T objects.</returns>
        public abstract override List<T> GetCollection(string[] data);
    }
}

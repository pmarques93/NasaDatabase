using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    public abstract class ListFromCSVData<T> : 
                            CollectionFromCSVData<List<T>> 
    {
        protected virtual string[] HeadersOfInteress { get; }
        public ListFromCSVData(string[] headers)
        {
            HeadersOfInteress = headers;
        }

        public abstract override List<T> GetCollection(string[] data);
    }
}

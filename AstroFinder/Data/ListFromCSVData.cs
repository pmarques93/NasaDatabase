using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    public abstract class ListFromCSVData : CollectionFromCSVData
    {
        protected virtual string[] HeadersOfInteress { get; }
        public ListFromCSVData(string[] headers)
        {
            HeadersOfInteress = headers;
        }

        public abstract override ICollection GetCollection(string[] data);
    }
}

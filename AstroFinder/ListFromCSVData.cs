using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    public class ListFromCSVData : CollectionFromCSVData
    {
        protected virtual string[] Headers { get; }
        public ListFromCSVData(string[] headers)
        {
            Headers = headers;
        }

        public override ICollection GetCollection(string[] data)
        {
            IEnumerable<string[]> refinedData =
                data.
                Where(p => p[0] != '#').
                Select(p => p.Split(","));

            return refinedData.ToArray();

        }
    }
}

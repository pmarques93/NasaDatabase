using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    public class ExoplanetsListFromCSVData : ListFromCSVData
    {
        public ExoplanetsListFromCSVData(string[] headers) : base(headers) { }

        public new ICollection GetCollection(string[] data)
        {
            // Retrieves the raw data from the CSV file
            ICollection rawData = base.GetCollection(data);

            // Converts the raw data into queryable Data
            // that makes it possible to make LINQ queries operations with it
            IEnumerable<string[]> queryableData = rawData.OfType<string[]>();

            // Dictionary that contain Column headers linked to their index
            // in the file
            // For instance: <pl_name, 0>
            // This implies that the column header named 'pl_name'
            // is the column of index 0 in the file
            Dictionary<string, int> headersDic = new Dictionary<string, int>();

            // Loops through the queryableData by columns
            for (int i = 0; i < queryableData.ElementAt(0).Count(); i++)
            {
                // Gets the element of index 'i' of the line 0
                // This means getting the column header of index 'i'
                string header = queryableData.ElementAt(0)[i];

                // Loops through all the headers of interess
                for (int j = 0; j < HeadersOfInteress.Length; j++)
                {
                    // Checks if a certain header of interess of index 'j'
                    // matches the header on the current column of the file
                    if (HeadersOfInteress[j] == header.Trim())
                    {
                        // If the column header matches a header of interess
                        // the header is added to the dictionary as a KEY
                        // its value will be the header column index on the file
                        headersDic.Add(HeadersOfInteress[j], i);
                    }
                }
            }


            // Returns a List of Exoplanets, skipping the first line
            // of the data file that corresponds to the column headers
            return
                queryableData.
                Skip(1).
                Select(p => new Exoplanet(
                                p?[headersDic[HeadersOfInteress[0]]].Trim(),
                                p?[headersDic[HeadersOfInteress[1]]].Trim(),
                                p?[headersDic[HeadersOfInteress[2]]].Trim(),
                                p?[headersDic[HeadersOfInteress[3]]].Trim(),
                                p?[headersDic[HeadersOfInteress[4]]].Trim(),
                                p?[headersDic[HeadersOfInteress[5]]].Trim(),
                                p?[headersDic[HeadersOfInteress[6]]].Trim(),
                                p?[headersDic[HeadersOfInteress[7]]].Trim())).
                                ToList();
        }
    }
}
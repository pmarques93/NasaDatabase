using System.Collections.Generic;
using System.Linq;

namespace AstroFinder.Data.FilterData
{
    /// <summary>
    /// Responsible for going through CSV data and filtering it by the given
    /// headers.
    /// </summary>
    public class FilterCSVDataByHeaders : FilterCSVData<IEnumerable<string[]>>
    {
        // Dictionary that will establish a relationship between e header and 
        // its column index on the data
        private Dictionary<string, int?> headersIndex;

        /// <summary>
        /// Constructor, that initializes and creates a new instance of 
        /// FilterCSVDataByHeaders.
        /// </summary>
        /// <param name="headers">Headers that will be looked for on the
        /// CSV data</param>
        /// <param name="headersIndex">Dictionary that establishes and
        /// relation between a header and its index on the data.</param>
        /// <returns></returns>
        public FilterCSVDataByHeaders(IEnumerable<string[]> data,
                                      string[] headers,
                                      Dictionary<string, int?> headersIndex) :
                                      base(data, headers)
        {
            this.headersIndex = headersIndex;
        }

        /// <summary>
        /// Responsible for filtering data.
        /// </summary>
        public override void Filter()
        {
            // Loops through the data by columns
            for (int i = 0; i < data.ElementAt(0).Count(); i++)
            {
                // Gets the element of index 'i' of the line 0
                // This means getting the column header of index 'i'
                string header = data.ElementAt(0)[i].Trim();

                // Loops through all the headers of interess
                for (int j = 0; j < headers.Length; j++)
                {
                    // Checks if a certain header of interess of index 'j'
                    // matches the header on the current column of the file
                    if (headers[j] == header)
                    {
                        // If the column header matches a header of interess
                        // the header is added to the dictionary as a KEY
                        // its value will be the header column index on the file
                        headersIndex.Add(headers[j], i);
                    }
                }
            }


            // Adds the missing headers to the headers dictionary
            for (int i = 0; i < headers.Length; i++)
            {
                if (!(headersIndex.ContainsKey(headers[i])))
                {
                    string missingHeader = headers[i];
                    headersIndex.Add(missingHeader, null);
                }
            }

        }
    }
}
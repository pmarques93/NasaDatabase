using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AstroFinder.Data.FilterData;

namespace AstroFinder
{
    /// <summary>
    /// Responsible for getting a List of Exoplanet objects.
    /// </summary>
    public class ExoplanetsListFromCSVData : ListFromCSVData<Exoplanet>
    {
        /// <summary>
        /// Constructor, that creates a new instance of 
        /// ExoplanetsListFromCSVData and initializes its base class members.
        /// </summary>
        /// <param name="headersOfInteress">Headers that will be looked
        /// for.</param>
        public ExoplanetsListFromCSVData(string[] headersOfInteress)
                                        : base(headersOfInteress) { }
        /// <summary>
        /// Gets a List of Exoplanet objects from the given data.
        /// </summary>
        /// <param name="data">Data from which the List will be 
        /// created</param>
        /// <returns>List of Exoplanet objects.</returns>
        public override List<Exoplanet> GetCollection(string[] data)
        {
            // Data splitted by ', ' and ignoring all line that start with '#'
            IEnumerable<string[]> refinedData =
                                    data.
                                    Where(p => p[0] != '#').
                                    Select(p => p.Split(","));

            //Dictionary that establishes a relation between a header and its 
            // index on the data.
            Dictionary<string, int?> headersDic = new Dictionary<string,int?>();

            IFilterData dataFilter = new FilterCSVDataByHeaders(refinedData,
                                                                HeadersOfInteress,
                                                                 headersDic);
            // Filters the data
            dataFilter.Filter();

            Dictionary<string, int?> hd = headersDic;
            string[] HoI = HeadersOfInteress;
            // Returns a List of Exoplanets, skipping the first line
            // of the data file that corresponds to the column headers
            return
                refinedData.
                Skip(1).
                Select(p => new Exoplanet(
                        hd[HoI[0]] != null ? p[(int)hd[HoI[0]]].Trim() : null,
                        hd[HoI[1]] != null ? p[(int)hd[HoI[1]]].Trim() : null,
                        hd[HoI[2]] != null ? p[(int)hd[HoI[2]]].Trim() : null,
                        hd[HoI[3]] != null ? p[(int)hd[HoI[3]]].Trim() : null,
                        hd[HoI[4]] != null ? p[(int)hd[HoI[4]]].Trim() : null,
                        hd[HoI[5]] != null ? p[(int)hd[HoI[5]]].Trim() : null,
                        hd[HoI[6]] != null ? p[(int)hd[HoI[6]]].Trim() : null,
                        hd[HoI[7]] != null ? p[(int)hd[HoI[7]]].Trim() : null)).
                        ToList();
        }
    }
}
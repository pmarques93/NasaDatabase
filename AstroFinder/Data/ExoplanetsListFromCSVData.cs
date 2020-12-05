using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AstroFinder.Data.FilterData;

namespace AstroFinder
{
    public class ExoplanetsListFromCSVData : ListFromCSVData<Exoplanet>
    {
        public ExoplanetsListFromCSVData(string[] headers) : base(headers) { }

        public override List<Exoplanet> GetCollection(string[] data)
        {
            IEnumerable<string[]> queryableData =
                                    data.
                                    Where(p => p[0] != '#').
                                    Select(p => p.Split(","));


            Dictionary<string, int?> headersDic = new Dictionary<string, int?>();

            IFilterData dataFilter = new FilterCSVDataByHeaders(queryableData,
                                                                HeadersOfInteress,
                                                                headersDic);
            dataFilter.Filter();

            Dictionary<string, int?> hd = headersDic;
            string[] HoI = HeadersOfInteress;
            // Returns a List of Exoplanets, skipping the first line
            // of the data file that corresponds to the column headers
            return
                queryableData.
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
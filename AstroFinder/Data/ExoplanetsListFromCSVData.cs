using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AstroFinder.Data;

namespace AstroFinder
{
    public class ExoplanetsListFromCSVData : ListFromCSVData
    {
        public ExoplanetsListFromCSVData(string[] headers) : base(headers) { }

        public override ICollection GetCollection(string[] data)
        {
            IGetDataTable<string[]> dataTableGetter 
                        = new GetDataTableFromCSVData(data, null,
                                                      HeadersOfInteress);

            DataTable dataTable = dataTableGetter.GetTableFromData();

            return
                dataTable.AsEnumerable().
                Select(p => new Exoplanet(
                            p[0].ToString() != "" ? p[0].ToString() : "N/A",
                            p[1].ToString() != "" ? p[1].ToString() : "N/A",
                            p[2].ToString() != "" ? p[2].ToString() : "N/A",
                            p[3].ToString() != "" ? p[3].ToString() : "N/A",
                            p[4].ToString() != "" ? p[4].ToString() : "N/A",
                            p[5].ToString() != "" ? p[5].ToString() : "N/A",
                            p[6].ToString() != "" ? p[6].ToString() : "N/A",
                            p[7].ToString() != "" ? p[7].ToString() : "N/A" )).
                            ToList();
        }
    }
}
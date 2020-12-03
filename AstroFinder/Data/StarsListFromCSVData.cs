using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AstroFinder.Data;

namespace AstroFinder
{
    public class StarsListFromCSVData : ListFromCSVData
    {
        public StarsListFromCSVData(string[] headers) : base(headers) { }

        public override ICollection GetCollection(string[] data)
        {            
            IGetDataTable<string[]> dataTableGetter 
                        = new GetDataTableFromCSVData(data, null,
                                                      HeadersOfInteress);

            DataTable dataTable = dataTableGetter.GetTableFromData();

            return
                dataTable.AsEnumerable().
                Select(p => new Star(
                            p[0].ToString() != "" ? p[0].ToString() : null,
                            p[1].ToString() != "" ? p[1].ToString() : null,
                            p[2].ToString() != "" ? p[2].ToString() : null,
                            p[3].ToString() != "" ? p[3].ToString() : null,
                            p[4].ToString() != "" ? p[4].ToString() : null,
                            p[5].ToString() != "" ? p[5].ToString() : null,
                            p[6].ToString() != "" ? p[6].ToString() : null,
                            p[7].ToString() != "" ? p[7].ToString() : null)).
                            ToList();
        }
    }
}
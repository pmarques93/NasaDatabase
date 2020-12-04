using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AstroFinder.Data;
using AstroFinder.Table;

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

            DataTable<string> dataTable = dataTableGetter.GetTableFromData();
            string[] HoI = HeadersOfInteress;
            return
                dataTable.
                Select(p => new Star(
                            p?[HoI[0]].ToString() != "" && p?[HoI[0]].ToString() != null ? p?[HoI[0]].ToString() : "N/A",
                            p?[HoI[1]].ToString() != "" && p?[HoI[1]].ToString() != null ? p?[HoI[1]].ToString() : "N/A",
                            p?[HoI[2]].ToString() != "" && p?[HoI[2]].ToString() != null ? p?[HoI[2]].ToString() : "N/A",
                            p?[HoI[3]].ToString() != "" && p?[HoI[3]].ToString() != null ? p?[HoI[3]].ToString() : "N/A",
                            p?[HoI[4]].ToString() != "" && p?[HoI[4]].ToString() != null ? p?[HoI[4]].ToString() : "N/A",
                            p?[HoI[5]].ToString() != "" && p?[HoI[5]].ToString() != null ? p?[HoI[5]].ToString() : "N/A",
                            p?[HoI[6]].ToString() != "" && p?[HoI[6]].ToString() != null ? p?[HoI[6]].ToString() : "N/A",
                            p?[HoI[7]].ToString() != "" && p?[HoI[7]].ToString() != null ? p?[HoI[7]].ToString() : "N/A")).
                            ToList();
        }
    }
}
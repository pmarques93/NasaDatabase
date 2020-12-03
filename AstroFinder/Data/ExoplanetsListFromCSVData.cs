using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            Dictionary<string, int?> headersDic = new Dictionary<string, int?>();

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

            DataTable dataTable = new DataTable();

            AddTableColumns(queryableData, dataTable);

            AddTableRows(queryableData, dataTable);

            RemoveNonInteressColumns(dataTable);

            AddMissingColumnsOfInteress(dataTable);

            SortColumnByInteress(dataTable);

            // System.Console.WriteLine(dataTable.Columns[2].ColumnName);

            List<Exoplanet> v =
                        dataTable.AsEnumerable().
                        Select(p => new Exoplanet(
                                        p[0].ToString() != "" ? p[0].ToString() : null,
                                        p[1].ToString() != "" ? p[1].ToString() : null,
                                        p[2].ToString() != "" ? p[2].ToString() : null,
                                        p[3].ToString() != "" ? p[3].ToString() : null,
                                        p[4].ToString() != "" ? p[4].ToString() : null,
                                        p[5].ToString() != "" ? p[5].ToString() : null,
                                        p[6].ToString() != "" ? p[6].ToString() : null,
                                        p[7].ToString() != "" ? p[7].ToString() : null
                        )).ToList();
            // foreach (Exoplanet planet in v)
            // {
            //     System.Console.WriteLine(planet);
            // }



            // Returns a List of Exoplanets, skipping the first line
            // of the data file that corresponds to the column headers
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
                                p[7].ToString() != "" ? p[7].ToString() : "N/A"
                )).ToList();
        }

        /// <summary>
        /// Sorts table columns accordingly to the HeaderOfInteresse array
        /// </summary>
        /// <param name="dataTable">Table in which the data is written</param>
        private void SortColumnByInteress(DataTable dataTable)
        {
            int colIndex = 0;
            foreach (string columnName in HeadersOfInteress)
            {
                dataTable.Columns?[columnName].SetOrdinal(colIndex);
                colIndex++;
            }
        }

        /// <summary>
        /// Adds to the table the columns that could not be found in the file
        /// but still correspond to one of the headers of interess
        /// </summary>
        /// <param name="dataTable">Table in which the data is written</param>
        private void AddMissingColumnsOfInteress(DataTable dataTable)
        {
            for (int i = 0; i < HeadersOfInteress.Length; i++)
            {
                if (!(dataTable.Columns.Contains(HeadersOfInteress[i])))
                {
                    DataColumn missingColumn = new DataColumn();
                    missingColumn.ColumnName = HeadersOfInteress[i];
                    dataTable.Columns.Add(missingColumn);
                }
            }
        }

        /// <summary>
        /// Removes the table the columns that do not correspond to one of the 
        /// headers of interess
        /// </summary>
        /// <param name="dataTable">Table in which the data is written</param>
        private void RemoveNonInteressColumns(DataTable dataTable)
        {
            List<DataColumn> allColumns = new List<DataColumn>();
            foreach (DataColumn column in dataTable.Columns)
            {
                allColumns.Add(column);
            }

            foreach (DataColumn column in allColumns)
            {
                if (!(HeadersOfInteress.Contains(column.ColumnName)))
                {
                    dataTable.Columns.Remove(column);
                }
            }
        }
        
        private void AddTableRows(IEnumerable<string[]> queryableData,
                                  DataTable dataTable)
        {
            for (int rowIndex = 1; rowIndex < queryableData.Count(); rowIndex++)
            {
                DataRow row = dataTable.NewRow();
                dataTable.Rows.Add(row);

                for (int columnIndex = 0; columnIndex
                    < dataTable.Columns.Count; columnIndex++)
                {
                    row[dataTable.
                        Columns[columnIndex].
                                 ColumnName] = 
                        queryableData.ElementAt(rowIndex)[columnIndex].Trim();
                }
            }
        }

        private void AddTableColumns(IEnumerable<string[]> queryableData, DataTable dataTable)
        {
            for (int columnIndex = 0; columnIndex < queryableData.ElementAt(0).Count(); columnIndex++)
            {
                DataColumn column = new DataColumn();
                column.ColumnName = queryableData.ElementAt(0)[columnIndex].Trim();
                dataTable.Columns.Add(column);
            }
        }
    }
}
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AstroFinder.Data;

namespace AstroFinder.Data
{
    public class GetDataTableFromCSVData : IGetDataTable<string[]>
    {
        public string[] MandatoryHeaders { get; }

        public string[] HeadersOfInteress { get; }

        public string[] Data { get; }
        int testNumber = 0;

        public GetDataTableFromCSVData(string[] data,
                                       string[] mandatoryHeaders,
                                       string[] headersOfInteress = null)
        {
            Data = data;
            MandatoryHeaders = mandatoryHeaders;
            HeadersOfInteress = headersOfInteress;
        }

        /// <summary>
        /// Gets a table based 
        /// </summary>
        /// <returns></returns>
        public DataTable GetTableFromData()
        {
            // Converts the raw data into queryable Data
            // that makes it possible to make LINQ queries operations with it
            IEnumerable<string[]> queryableData = Data.
                                                    Where(p => p[0] != '#').
                                                    Select(p => p.Split(","));
            DataTable dataTable = new DataTable();

            AddTableFields(queryableData, dataTable);

            if (HeadersOfInteress != null)
            {
                RemoveNonInteressColumns(dataTable);

                AddMissingColumnsOfInteress(dataTable);

                SortColumnByInteress(dataTable);
            }
            return dataTable;
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
            List<string> allColumnsNames = new List<string>(dataTable.Columns.Count);

            for (int i = 0; i < allColumnsNames.Count; i ++)
            {
                allColumnsNames.Add(dataTable.Columns[i].ColumnName);
            }

            for (int i = 0; i < allColumnsNames.Count; i++)
            {
                string columnName = dataTable.Columns[i].ColumnName;
                if (!(HeadersOfInteress.Contains(columnName)))
                {
                    dataTable.Columns.Remove(columnName);
                }
            }
        }

        /// <summary>
        /// Add columns and rows to the table
        /// </summary>
        /// <param name="queryableData">Data from which the row will be 
        /// read and added</param>
        /// <param name="dataTable">Table in which the data will be 
        /// written</param>
        private void AddTableFields(IEnumerable<string[]> queryableData,
                                     DataTable dataTable)
        {
            for (int rowIndex = 1; rowIndex < queryableData.Count(); rowIndex++)
            {
                DataRow row = dataTable.NewRow();
                dataTable.Rows.Add(row);

                for (int columnIndex = 0; columnIndex
                    < queryableData.ElementAt(0).Count(); columnIndex++)
                {
                    if (rowIndex == 1)
                    {
                        DataColumn column = new DataColumn();
                        column.ColumnName = queryableData.
                                            ElementAt(0)[columnIndex].Trim();

                        dataTable.Columns.Add(column);
                    }

                    row[dataTable.Columns[columnIndex].ColumnName] =
                        queryableData.ElementAt(rowIndex)[columnIndex].Trim();
                }
            }
        }
    }
}
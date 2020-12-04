using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AstroFinder.Data;
using AstroFinder.Table;

namespace AstroFinder.Data
{
    public class GetDataTableFromCSVData : IGetDataTable<string[]>
    {
        public string[] MandatoryHeaders { get; }

        public string[] HeadersOfInteress { get; }

        public Dictionary<string, int> HeadersOrder { get; }

        public string[] Data { get; }

        public GetDataTableFromCSVData(string[] data,
                                       string[] mandatoryHeaders,
                                       string[] headersOfInteress = null)
        {
            Data = data;
            MandatoryHeaders = mandatoryHeaders;
            HeadersOfInteress = headersOfInteress;
            HeadersOrder = new Dictionary<string, int>();
        }

        /// <summary>
        /// Gets a table based 
        /// </summary>
        /// <returns></returns>
        public DataTable<string> GetTableFromData()
        {
            // Converts the raw data into queryable Data
            // that makes it possible to make LINQ queries operations with it
            IEnumerable<string[]> queryableData = Data.
                                                    Where(p => p[0] != '#').
                                                    Select(p => p.Split(","));

            List<List<string>> tableTest = new List<List<string>>();
            DataTable<string> table = new DataTable<string>();

            AddTableFields(queryableData, tableTest, table);

            // if (HeadersOfInteress != null)
            // {
            //     // AddMissingColumnsOfInteress(tableTest, table);
            //     // SortColumnByInteress(tableTest, table);
            // }
            return table;
        }

        /// <summary>
        /// Sorts table columns accordingly to the HeaderOfInteresse array
        /// </summary>
        /// <param name="dataTable">Table in which the data is written</param>
        private void SortColumnByInteress(List<List<string>> tableTest,
                                            DataTable<string> dataTable)
        {
            // int colIndex = 0;

            // colIndex = 0;
            List<List<string>> tempList = new List<List<string>>();
            tempList.Add(new List<string>());

            for (int i = 0; i < tableTest[0].Count; i++)
            {
                tempList[0].Add((string)default);
            }
            for (int i = 1; i < tableTest.Count; i++)
            {
                tempList.Add(new List<string>());
            }

            Dictionary<int, string> dicHeaders = new Dictionary<int, string>();

            for (int i = 0; i < HeadersOfInteress.Length; i++)
            {
                dicHeaders.Add(i, HeadersOfInteress[i]);
            }

            // Loops through the columns
            for (int i = 0; i < tableTest[0].Count; i++)
            {
                // Loops through the headers of interess
                for (int j = 0; j < HeadersOfInteress.Length; j++)
                {
                    if (tableTest[0][i].Contains(dicHeaders[j]))
                    {
                        for (int k = 0; k < tableTest.Count; k++)
                        {
                            // tempList[k][j] = tableTest[k][i];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds to the table the columns that could not be found in the file
        /// but still correspond to one of the headers of interess
        /// </summary>
        /// <param name="dataTable">Table in which the data is written</param>
        private void AddMissingColumnsOfInteress(List<List<string>> tableTest,
                                                DataTable<string> dataTable,
                                                List<string> missingHeaders)
        {
            if (tableTest.Count == HeadersOfInteress.Length)
                return;

            // List of the headers that the table has
            List<string> tableHeaders = new List<string>();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                tableHeaders.Add(dataTable.Columns[i].ColumnName);
            }

            for (int i = 0; i < HeadersOfInteress.Length; i++)
            {
                string missingColumnName = "";
                if (!(tableHeaders.Contains(HeadersOfInteress[i])))
                {
                    missingColumnName = HeadersOfInteress[i];
                    TableColumn missingColumn = new TableColumn(missingColumnName);
                    dataTable.AddColumn(missingColumn);
                    missingHeaders.Add(missingColumnName);
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
                                     List<List<string>> tableTest,
                                     DataTable<string> dataTable)
        {
            Dictionary<string, int> headersDic = new Dictionary<string, int>();

            // Adds the columns that match the headers of interess
            for (int i = 0; i < queryableData.ElementAt(0).Count(); i++)
            {
                string headerName = queryableData.ElementAt(0)[i].Trim();
                if (!(HeadersOfInteress.Contains(headerName)))
                    continue;

                HeadersOrder.Add(headerName, i);
                TableColumn column = new TableColumn(headerName);
                dataTable.AddColumn(column);
            }

            List<string> missingHeaders = new List<string>();
            AddMissingColumnsOfInteress(tableTest, dataTable, missingHeaders);

            // Writes the rows on the table
            for (int rowIndex = 1; rowIndex < queryableData.Count(); rowIndex++)
            {
                TableRow<string> row = dataTable.NewRow();
                for (int columnIndex = 0; columnIndex < dataTable.Columns.Count; columnIndex++)
                {
                    string columnName = dataTable.
                                        Columns[columnIndex].ColumnName;

                    if (missingHeaders.Contains(columnName))
                    {
                        row[columnName] = "n/a";
                        if (!(HeadersOrder.ContainsKey(columnName)))
                            HeadersOrder.Add(columnName, columnIndex);
                    }
                    else
                    {
                        int dataColumnIndex = HeadersOrder[columnName];
                        row[columnName] = queryableData.
                                            ElementAt(rowIndex)[dataColumnIndex];
                    }
                }
                dataTable.AddRow(row);
            }

            foreach (var v in HeadersOrder)
            {
                Console.WriteLine($"Key: {v.Key}, Value: {v.Value} ");
            }

            // foreach (TableColumn v in dataTable.Columns)
            // {
            //     Console.WriteLine("--------------- HEADERS ----------------");
            //     Console.WriteLine($"{v.ColumnName}\n");
            //     foreach (TableRow<string> w in dataTable.Rows)
            //     {
            //         Console.WriteLine($"It is: {w[v.ColumnName]}");
            //     }
            // }

            // THIS IS ABOUT TO GO OUT /////////////////////////////////////////
            // Adds the first row to the table
            // This row corresponds to te headers row
            tableTest.Add(new List<string>());

            for (int columnIndex = 0; columnIndex
                < queryableData.ElementAt(0).Count(); columnIndex++)
            {
                string colName = queryableData.
                                    ElementAt(0)[columnIndex].Trim();

                if (!(HeadersOfInteress.Contains(colName)))
                    continue;
                tableTest[0].Add(colName);
            }

            for (int rowIndex = 1; rowIndex < queryableData.Count(); rowIndex++)
            {
                tableTest.Add(new List<string>());
                for (int columnIndex = 0; columnIndex < tableTest[0].Count; columnIndex++)
                {
                    tableTest[rowIndex].Add(queryableData.ElementAt(rowIndex)[columnIndex].Trim());
                }
            }
        }
    }
}
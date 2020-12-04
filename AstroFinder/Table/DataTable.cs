using System.Collections;
using System.Collections.Generic;

namespace AstroFinder.Table
{
    public class DataTable<T> : IEnumerable<TableRow<T>>
    {
        public TableRowCollection<T> Rows { get; }
        public TableColumnCollection Columns { get; }

        public DataTable()
        {
            Rows = new TableRowCollection<T>();
            Columns = new TableColumnCollection();
        }
        public void AddRow(TableRow<T> row)
        {
            Rows.Add(row);
        }

        public TableColumn this[int columnIndex] => Columns[columnIndex];

        public TableRow<T> NewRow()
        {
            TableRow<T> row =  new TableRow<T>();
            foreach (TableColumn column in Columns)
            {
                row.BindToColumn(column);
            }
            return row;
        }

        public void AddColumn(TableColumn column)
        {
            Columns.Add(column);
        }

        public IEnumerator<TableRow<T>> GetEnumerator()
        {
            return Rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
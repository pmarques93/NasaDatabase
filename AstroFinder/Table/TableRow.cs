using System.Collections.Generic;

namespace AstroFinder.Table
{
    public class TableRow<T>
    {
        private Dictionary<string, T> rowData;
        // private TableColumn associatedColumn;
        public T this[string colName]
        {
            get => rowData[colName];
            set => rowData[colName] = value;
        }

        public TableRow(TableColumn colum, T value)
        {
            rowData = new Dictionary<string, T>();
            rowData.Add(colum.ColumnName, value);
        }

        public TableRow()
        {
            rowData = new Dictionary<string, T>();
        }

        public void BindToColumn(TableColumn column)
        {
            rowData.Add(column.ColumnName, (T)default);
        }
    }
}
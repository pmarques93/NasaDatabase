namespace AstroFinder.Table
{
    public class TableColumn
    {
        public string ColumnName { get; set; }
        public TableColumn() { }
        public TableColumn(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;

namespace AstroFinder.Table
{
    public class TableColumnCollection : IEnumerable<TableColumn>
    {
        private Dictionary<int, TableColumn> columnCollection;

        private int index;

        public int Count => columnCollection.Count;

        public TableColumn this[int colIndex] => columnCollection[colIndex];


        public TableColumnCollection()
        {
            columnCollection = new Dictionary<int, TableColumn>(); 
            index = -1;  
        }

        public void Add(TableColumn columnToAdd)
        {
            int colindex = columnCollection.Count;
            columnCollection.Add(colindex, columnToAdd);
        }

        public IEnumerator<TableColumn> GetEnumerator()
        {
            return columnCollection.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
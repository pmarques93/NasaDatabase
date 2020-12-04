using System;
using System.Collections;
using System.Collections.Generic;

namespace AstroFinder.Table
{
    public class TableRowCollection<T> : IEnumerable<TableRow<T>>
    {
        private Dictionary<int, TableRow<T>> rowCollection;
        public TableRow<T> this [int rowIndex] => rowCollection[rowIndex];

        private int index;
        public object Current => rowCollection[index];

        public int Count => rowCollection.Count;


        public TableRowCollection()
        {   
            rowCollection = new Dictionary<int, TableRow<T>>();
            index = -1;
        }

        public void Add(TableRow<T> rowToAdd)
        {
            int colindex = rowCollection.Count;
            rowCollection.Add(colindex, rowToAdd);
        }

        public IEnumerator<TableRow<T>> GetEnumerator()
        {
            return rowCollection.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
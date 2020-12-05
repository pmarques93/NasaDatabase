using System.Collections;
using System.Collections.Generic;

namespace AstroFinder.Data.FilterData
{
    /// <summary>
    /// Defines methods and variables used on the process of filtering CSV Data.
    /// </summary>
    /// <typeparam name="T">The type of the data to be filtered.</typeparam>
    public abstract class FilterCSVData<T> : IFilterData where T : IEnumerable
    {
        protected T data;
        protected string[] headers;
        /// <summary>
        /// Constructor, that creates a new instance of FilterCSVData<T> and 
        /// initializes its variables.
        /// </summary>
        /// <param name="data">Data that will be filtered.</param>
        /// <param name="headers">Headers that will be looked for on the
        /// CSV data.</param>
        public FilterCSVData(T data,
                            string[] headers)
        {
            this.data = data;
            this.headers = headers;
        }
        
        /// <summary>
        /// Responsible for filtering data.
        /// </summary>
        public abstract void Filter();
    }
}
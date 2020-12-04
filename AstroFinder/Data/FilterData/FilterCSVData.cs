using System.Collections;
using System.Collections.Generic;

namespace AstroFinder.Data.FilterData
{
    public abstract class FilterCSVData<T> : IFilterData where T : IEnumerable
    {
        protected T data;
        protected string[] headers;
        public FilterCSVData(T data,
                            string[] headers)
        {
            this.data = data;
            this.headers = headers;
        }
        public abstract void Filter();
    }
}
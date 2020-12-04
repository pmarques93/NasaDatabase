using System.Collections;
using System.Collections.Generic;
using AstroFinder.Table;

namespace AstroFinder.Data
{
    public interface IGetDataTable<T> where T : IEnumerable
    {
        /// <summary>
        /// Headers that must be present on the given data for the generated 
        /// table be considered as valid
        /// </summary>
        /// <value></value>
        string[] MandatoryHeaders { get; }

        /// <summary>
        /// Headers that the table will contain
        /// </summary>
        /// <value></value>
        string[] HeadersOfInteress { get; }

        /// <summary>
        /// Data from which the table will be created
        /// </summary>
        /// <value></value>
        T Data { get; }

        /// <summary>
        /// Gets a DataTable from data keeping only the the columns with the
        /// given headers of interess if there is any</summary>
        /// <returns>Table filtered by the given paramaters</returns>
        DataTable<string> GetTableFromData();
    }
}
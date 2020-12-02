using System;

namespace AstroFinder
{
    /// <summary>
    /// Class that implements ISearchField
    /// This is an abstract base class for classes with
    /// searchable criteria
    /// </summary>
    public abstract class SearchField : ISearchField
    {
        /// <summary>
        /// Adds/Converts received criteria
        /// </summary>
        /// <param name="inputName">Receives a kind of Enum</param>
        /// <param name="inputValue">Receives a string with the user's input</param>
        public abstract void AddCriteria(Enum inputName, string inputValue);

        /// <summary>
        /// Sets default values
        /// </summary>
        public abstract void ResetFields();

    }
}

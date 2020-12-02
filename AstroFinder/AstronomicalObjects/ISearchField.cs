using System;
namespace AstroFinder
{
    /// <summary>
    /// Interface for searchable criteria
    /// </summary>
    public interface ISearchField
    {
        /// <summary>
        /// Adds/Converts received criteria
        /// </summary>
        /// <param name="inputName">Receives a kind of Enum</param>
        /// <param name="inputValue">Receives a string with the user's input</param>
        void AddCriteria(Enum inputName, string inputValue);

        /// <summary>
        /// Sets default values
        /// </summary>
        void ResetFields();
    }
}

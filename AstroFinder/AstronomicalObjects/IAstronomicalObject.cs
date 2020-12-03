namespace AstroFinder
{
    /// <summary>
    /// Interface for any Astronomical Object
    /// </summary>
    public interface IAstronomicalObject
    {
        /// <summary>
        /// Name of the Astronomical Object
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns information about the IAstronomicalObject
        /// </summary>
        /// <returns>Returns a string with the information</returns>
        string Information();

        /// <summary>
        /// Returns detailed information about the IAstronomicalObject
        /// </summary>
        /// <returns>Returns a string with the information</returns>
        string DetailedInformation();
    }
}

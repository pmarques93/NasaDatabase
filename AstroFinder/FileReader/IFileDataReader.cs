namespace AstroFinder
{
    /// <summary>
    /// Defines methods and properties to read data from a file.
    /// </summary>
    public interface IFileDataReader
    {
        /// <summary>
        /// Contains the data read from the file.
        /// </summary>
        string[] FileData { get; }

        /// <summary>
        /// Path of the file that will be read.
        /// </summary>
        string Path { get; }
        /// <summary>
        /// Gets the data from the given file.
        /// </summary>
        /// <param name="fileData">Object that will contain the data.</param>
        void GetDataFromFile(out string[] fileData);
    }
}
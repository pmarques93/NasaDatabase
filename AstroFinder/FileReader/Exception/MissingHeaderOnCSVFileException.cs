namespace AstroFinder.FileReader.Exception
{
    /// <summary>
    /// The exception that is thrown when a given CSV file misses a mandatory
    /// header.
    /// </summary>
    public class MissingHeaderOnCSVFileException : System.Exception
    {
        /// <summary>
        /// Constructor, that initializes a new instance of the
        /// MissingHeaderOnCSVFileException class with its deafult 
        /// error message.
        /// </summary>
        /// <param name="path">Path of the file with the missing 
        /// headers.</param>
        public MissingHeaderOnCSVFileException(string path) : 
            base($"There are headers missing on the file '{path}' ")
        {
            
        }
        /// <summary>
        /// Constructor, that initializes a new instance of the
        /// MissingHeaderOnCSVFileException class. 
        /// </summary>
        public MissingHeaderOnCSVFileException()
        {
            
        }
    }
}
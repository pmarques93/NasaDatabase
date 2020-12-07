namespace AstroFinder.FileReader.Exception
{
    /// <summary>
    /// The exception that is thrown when a given file is empty.
    /// </summary>
    public class FileEmptyException : System.Exception
    {   
        /// <summary>
        /// Constructor, that initializes a new instance of the
        /// FileEmptyException class with its default error message.
        /// </summary>
        /// <param name="path">Path of the empty file.</param>
        public FileEmptyException(string path) :
            base($"The file '{path}' is empty.")
        { }
        /// <summary>
        /// Constructor, that initializes a new instance of the
        /// FileEmptyException class.
        /// </summary>
        public FileEmptyException()
        { }
    }
}
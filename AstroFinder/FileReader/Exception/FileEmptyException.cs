namespace AstroFinder.FileReader.Exception
{
    public class FileEmptyException : System.Exception
    {
        public FileEmptyException(string path) :
            base($"The file '{path}' is empty.")
        { }
        public FileEmptyException()
        { }
    }
}
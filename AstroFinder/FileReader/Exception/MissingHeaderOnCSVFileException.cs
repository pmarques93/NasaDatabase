namespace AstroFinder.FileReader.Exception
{
    public class MissingHeaderOnCSVFileException : System.Exception
    {
        public MissingHeaderOnCSVFileException(string path) : 
            base($"There are headers missing on the file '{path}' ")
        {
            
        }
        public MissingHeaderOnCSVFileException()
        {
            
        }
    }
}
namespace AstroFinder
{
    public interface IFileDataReader
    {
        string[] FileData { get; set; }
        string Path { get; }
        bool TryGetDataFromFile();
        bool TryOpenFile(string _path, out string path);
    }
}
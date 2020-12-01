namespace AstroFinder
{
    public interface IFileDataReader
    {
        string[] FileData { get; }
        string Path { get; }
        bool TryGetDataFromFile(out string[] fileData);
    }
}
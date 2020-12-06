namespace AstroFinder
{
    public interface IFileDataReader
    {
        string[] FileData { get; }
        string Path { get; }
        void GetDataFromFile(out string[] fileData);
    }
}
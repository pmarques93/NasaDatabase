using System;
using System.IO;

namespace AstroFinder
{
    public class CSVFileDataReader : IFileDataReader
    {
        private readonly string[] fileData;
        public string[] FileData => fileData;
        public string Path { get; }
        private string[] mandatoryHeaders;

        public CSVFileDataReader(string path, string[] mandatoryHeaders = null)
        {
            this.mandatoryHeaders = mandatoryHeaders;
            Path = path;

            if (!File.Exists(Path) ||
                !TryGetDataFromFile(out fileData))
            {
                throw new Exception("File not found or empty");
            }
        }
        public bool TryGetDataFromFile(out string[] fileData)
        {
            fileData = File.ReadAllLines(Path);
            return fileData.Length > 0;
        }
    }
}
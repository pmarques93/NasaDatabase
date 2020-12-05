using System;
using System.IO;
using System.Linq;

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
            string[] tempData = File.ReadAllLines(Path).
                                Where(p => p.Length != 0).
                                Select(p => p).ToArray();
            fileData = tempData;
            return fileData.Length > 0;
        }
    }
}
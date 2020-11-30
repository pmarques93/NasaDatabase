using System;
using System.IO;

namespace AstroFinder
{
    public class CSVFileDataReader : IFileDataReader
    {
        public string[] FileData { get; set; }

        private readonly string _path;
        public string Path => _path;
        private string[] mandatoryHeaders;

        public CSVFileDataReader(string path, string[] mandatoryHeaders = null)
        {
            this.mandatoryHeaders = mandatoryHeaders;

            if (!TryOpenFile(path, out _path) || !TryGetDataFromFile())
            {
                throw new Exception("File not found or empty");
            }

        }

        public bool TryGetDataFromFile()
        {
            FileData = File.ReadAllLines(Path);
            return FileData.Length > 0;
        }

        public bool TryOpenFile(string _path, out string path)
        {
            path = _path;
            return File.Exists(path);
        }
    }
}
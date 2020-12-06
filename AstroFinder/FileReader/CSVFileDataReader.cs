using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AstroFinder.FileReader.Exception;

namespace AstroFinder
{
    public class CSVFileDataReader : IFileDataReader
    {
        private readonly string[] fileData;
        public string[] FileData => fileData;
        public CSVFileDataReader(string path)
        {
            this.Path = path;

        }
        public string Path { get; }
        private string[] mandatoryHeaders;

        public CSVFileDataReader(string path, string[] mandatoryHeaders = null)
        {
            this.mandatoryHeaders = mandatoryHeaders;
            Path = path;

            if (!File.Exists(Path))
            {
                throw new FileNotFoundException($"The file '{Path}' could no be found.");
            }
            GetDataFromFile(out fileData);
            ValidateHeaders(fileData);
        }
        public void GetDataFromFile(out string[] fileData)
        {
            string[] tempData = File.ReadAllLines(Path).
                                Where(p => p.Length != 0).
                                Select(p => p).ToArray();
            fileData = tempData;
            if (fileData.Length == 0)
            {
                throw new FileEmptyException(Path);
            }
        }
        public void ValidateHeaders(string[] fileData)
        {
            IEnumerable<string[]> queryableData =
                                    fileData.
                                    Where(p => p[0] != '#').
                                    Select(p => p.Split(","));

            string[] h = queryableData.ElementAt(0).
                            Where(p => mandatoryHeaders.Contains(p.Trim())).
                            Select(p => p).ToArray();

            if (h.Length < mandatoryHeaders.Length)
            {
                throw new MissingHeaderOnCSVFileException(Path);
            }

        }
    }
}
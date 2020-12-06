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

        /// <summary>
        /// Contains the data read from the file.
        /// </summary>
        public string[] FileData => fileData;

        /// <summary>
        /// Path of the file that will be read.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Headers that must be present on the file.
        /// </summary>
        private string[] mandatoryHeaders;

        /// <summary>
        /// Constructor that creates a new instance of CSVFileDataReader and
        /// initializes its Path property.
        /// </summary>
        /// <param name="path">Path of the file that will be read.</param>
        public CSVFileDataReader(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// Constructor that creates a new instance of CSVFileDataReader and
        /// initializes the Path and mandatoryHeaders members.
        /// </summary>
        /// <param name="path">Path of the file that will be read.</param>
        /// <param name="mandatoryHeaders">Headers that must be present on 
        /// the file.</param>
        public CSVFileDataReader(string path, string[] mandatoryHeaders = null)
        {
            this.mandatoryHeaders = mandatoryHeaders;
            Path = path;
            
            // Checks if the file exists
            if (!File.Exists(Path))
            {
                // In case the file does not exist, it throws an exception
                throw new FileNotFoundException();
            }
            GetDataFromFile(out fileData);
            ValidateHeaders(fileData);
        }

        /// <summary>
        /// Gets the data from the given file.
        /// </summary>
        /// <param name="fileData">Object that will contain the data.</param>
        public void GetDataFromFile(out string[] fileData)
        {
            string[] tempData = File.ReadAllLines(Path).
                                Where(p => p.Length != 0).
                                Select(p => p).ToArray();
            fileData = tempData;

            // Throws an exception if the file is empty
            if (fileData.Length == 0)
            {
                throw new FileEmptyException(Path);
            }
        }

        /// <summary>
        /// Checks if the data retrieved from the file as the mandatory headers.
        /// </summary>
        /// <param name="fileData">Data to be validated.</param>
        private void ValidateHeaders(string[] fileData)
        {
            // Splits the data
            IEnumerable<string[]> queryableFileData =
                                    fileData.
                                    Where(p => p[0] != '#').
                                    Select(p => p.Split(","));

            // Looks for the mandatory headers on the data and if they are found
            // stores them in an array.
            string[] headersOnData = queryableFileData.ElementAt(0).
                            Where(p => mandatoryHeaders.Contains(p.Trim())).
                            Select(p => p).ToArray();

            // Checks if the headers that were found match the amount of 
            // mandatory headers
            if (headersOnData.Length < mandatoryHeaders.Length)
            {
                throw new MissingHeaderOnCSVFileException(Path);
            }
        }
    }
}
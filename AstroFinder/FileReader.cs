using System;
using System.Collections.Generic;
using System.Linq;
namespace AstroFinder
{
    public class FileReader
    {
        public string Path { get; }
        public FileReader(string path)
        {
            Path = path;
        }

        public List<Exoplanet> CSVtoList()
        {
            // Dictionary that hold the headers and their column (index)
            // Example - {"pn_name", 0}
            // This mean the "pn_name" header is on column 0
            Dictionary<string, int> headers = new Dictionary<string, int>();

            // Valid table headers
            string[] tableHeaders = new string[]
            {
                "pl_name",
                "hostname"
            };

            // Writes all the lines from the file to a string[]
            string[] fileData = System.IO.File.ReadAllLines(Path);

            // Retrieves the data from the file and
            // Ignores lines starting with # - comments
            // Splits the lines in columns
            IEnumerable<string[]> planets =
                fileData.
                Where(p => p[0] != '#').
                Select(p => p.Split(","));


            for (int i = 0; i < tableHeaders.Length; i++)
            {
                string planet = planets.ElementAt(0)[i];
                if (planet.Contains(tableHeaders[i]))
                {
                    headers.Add(tableHeaders[i], i);
                }
            }
            return
                planets.
                Select(p => new Exoplanet(  p[headers["pl_name"]].Trim(' '),
                                            p[headers["hostname"]].Trim(' '))).
                                            ToList();
        }
    }
}
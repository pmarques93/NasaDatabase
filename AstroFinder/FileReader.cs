using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace AstroFinder
{
    public class FileReader
    {
        private readonly string path;

        private string[] file_data;

        public FileReader(string path)
        {
            this.path = path;
            TryOpenFile();
            GetDataFromFile();
        }
        private void TryOpenFile()
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
        }

        private void GetDataFromFile()
        {
            file_data = File.ReadAllLines(path);
        }

        public List<Exoplanet> CSVtoList()
        {
            // Dictionary that hold the headers and their column (index)
            // Example - {"pn_name", 0}
            // This mean the "pn_name" header is on column 0
            Dictionary<string, int> headers = new Dictionary<string, int>();

            string[] tableHeaders = Enum.GetNames(typeof(Inputs));
            string[] tempString = {"pl_name", "hostname"};

            // Writes all the lines from the file to a string[]
            // string[] fileData = System.IO.File.ReadAllLines(path);

            // Retrieves the data from the file and
            // Ignores lines starting with # - comments
            // Splits the lines in columns
            IEnumerable<string[]> planets =
                file_data.
                Where(p => p[0] != '#').
                Select(p => p.Split(","));


            for (int i = 0; i < tempString.Length; i++)
            {
                string planet = planets.ElementAt(0)[i];
                if (planet.Contains(tempString[i]))
                {
                    headers.Add(tempString[i], i);
                }
            }
            return
                planets.
                Select(p => new Exoplanet(p[headers["pl_name"]].Trim(' '),
                                            p[headers["hostname"]].Trim(' '),
                                            p[headers["discoverymethod "]].Trim())).
                                            ToList();
        }
    }
}
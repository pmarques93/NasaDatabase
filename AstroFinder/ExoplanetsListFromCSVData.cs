using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AstroFinder
{
    public class ExoplanetsListFromCSVData : ListFromCSVData
    {
        public ExoplanetsListFromCSVData(string[] headers) : base(headers)
        {

        }

        public new ICollection GetCollection(string[] data)
        {
            ICollection rawData = base.GetCollection(data);

            IEnumerable<string[]> queryableData = rawData.OfType<string[]>();

            Dictionary<string, int> headersDic = new Dictionary<string, int>();

            string[] orderedHeaders = new string[queryableData.ElementAt(0).Count()];

            for (int i = 0; i < queryableData.ElementAt(0).Count(); i++)
            {
                string header = queryableData.ElementAt(0)[i];

                for (int j = 0; j < Headers.Length; j++)
                {
                    if (Headers[j] == header.Trim())
                    {
                        headersDic.Add(Headers[j], i);
                    }
                    // System.Console.WriteLine("\n");
                }
            }

            List<string[]> listOfHeaders = new List<string[]>(Headers.Length);

            foreach (var v in queryableData)
            {
                listOfHeaders.Add(v);
            }

            // This is here to make some tests ///////////////////////////
            List<Exoplanet> planets1 = new List<Exoplanet>();
            for (int i = 0; i < listOfHeaders.Count; i++)
            {
                planets1.Add(new Exoplanet(listOfHeaders[i]));
            }
            foreach (Exoplanet planet in planets1)
            {
                System.Console.WriteLine(planet);
            }

            return
                queryableData.
                Skip(1).
                Select(p => new Exoplanet(p?[headersDic[Headers[0]]].Trim(),
                                            p?[headersDic[Headers[1]]].Trim(),
                                            p?[headersDic[Headers[2]]].Trim())).
                                            ToList();
        }
    }
}
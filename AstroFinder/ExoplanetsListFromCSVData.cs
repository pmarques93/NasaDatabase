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
                       System.Console.WriteLine($"Header[{j}] - {Headers[j]} is on Column {i}");
                       headersDic.Add(Headers[j],i);
                    }
                    // System.Console.WriteLine("\n");
                }
            }

            foreach (var v in headersDic)
            {
                System.Console.WriteLine($"Key: {v.Key}, Value: {v.Value}");
            }

            return
                queryableData.
                Skip(1).
                Select(p => new Exoplanet(p?[headersDic["pl_name"]].Trim(' '),
                                            p?[headersDic["hostname"]].Trim(' '))).
                                            ToList();
        }
    }
}
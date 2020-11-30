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

            IEnumerable<string[]> refinedData = base.GetCollection(data)
                                                    .OfType<string[]>();

            Dictionary<string, int> headersDic = new Dictionary<string, int>();

            for (int i = 0; i < Headers.Length; i++)
            {
                string planet = refinedData.ElementAt(0)[i];
                if (planet.Contains(Headers[i]))
                {
                    headersDic.Add(Headers[i], i);
                }
            }
            return
                refinedData.
                Select(p => new Exoplanet(p[headersDic["pl_name"]].Trim(' '),
                                            p[headersDic["hostname"]].Trim(' '))).
                                            ToList();
        }
    }
}
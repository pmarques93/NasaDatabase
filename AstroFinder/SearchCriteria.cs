using System;
namespace AstroFinder
{
    public class SearchCriteria
    {
        public string PlanetName {get; set;}
        public string HostName {get; set;}
        public string Discoverymethod {get; set;}
        private ushort discoveryYearMin;
        private ushort discoveryYearMax;
        public ushort DiscoveryYearMin 
        {
            get => discoveryYearMin;
            set
            {
                discoveryYearMin = value;
                if(value < 1989) discoveryYearMin = 1989;
                if(discoveryYearMin > discoveryYearMax) 
                    discoveryYearMin = discoveryYearMax;
            }
        }
        public ushort DiscoveryYearMax 
        {
            get => discoveryYearMax;
            set
            {
                discoveryYearMax = value;
                if(value > 2020) discoveryYearMax = 2020;
                if(discoveryYearMax < discoveryYearMin) 
                    discoveryYearMax = discoveryYearMin;
            }
        }

        public SearchCriteria()
        {
            PlanetName = "everything";
            HostName = "everything";
            Discoverymethod = "everything";
            DiscoveryYearMax = 2020;
            DiscoveryYearMin = 1989;
        }
    }
}
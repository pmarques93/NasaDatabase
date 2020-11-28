namespace AstroFinder
{
    public struct Exoplanet
    {
        public string Name { get; }
        public string HostName { get; }

        public Exoplanet(string name, string hostName)
        {
            Name = name;
            HostName = hostName;
        }

        public override string ToString()
        {
            return Name + HostName;
        }
    }
}   
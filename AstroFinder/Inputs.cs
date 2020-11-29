using System;

namespace AstroFinder
{
    [Flags]
    public enum Inputs
    {
        pl_name = 1 << 0,
        hostname = 1 << 1,
        discoverymethod = 1 << 2,
        disc_year = 1 << 3,
        Strings = pl_name | hostname | discoverymethod,
        Int = disc_year,
    }
}

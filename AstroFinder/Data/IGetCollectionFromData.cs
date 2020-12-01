using System.Collections;
using System.Collections.Generic;

namespace AstroFinder
{
    public interface IGetCollectionFromData
    {
        ICollection GetCollection(string[] data);
    }
}
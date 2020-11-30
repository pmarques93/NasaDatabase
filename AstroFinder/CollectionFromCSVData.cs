using System.Collections;
using System.Collections.Generic;

namespace AstroFinder
{
    public abstract class CollectionFromCSVData : IGetCollectionFromData
    {
        public abstract ICollection GetCollection(string[] data);
    }
}
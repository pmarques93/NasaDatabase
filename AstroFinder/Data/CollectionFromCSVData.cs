using System.Collections;
using System.Collections.Generic;
using AstroFinder.Data;

namespace AstroFinder
{
    public abstract class CollectionFromCSVData : IGetCollectionFromData<string[]>
    {
        public abstract ICollection GetCollection(string[] data);
    }
}
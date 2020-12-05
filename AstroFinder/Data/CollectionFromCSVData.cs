using System.Collections;
using System.Collections.Generic;

namespace AstroFinder
{
    public abstract class CollectionFromCSVData<T> : 
                            IGetCollectionFromData<string[], T> 
                            where T : ICollection
    {
        public abstract T GetCollection(string[] data);
    }
}
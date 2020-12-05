using System.Collections;
using System.Collections.Generic;

namespace AstroFinder
{
    public interface IGetCollectionFromData<T, U>   where T : IEnumerable
                                                    where U : ICollection
    {
        U GetCollection(T data);
    }
}
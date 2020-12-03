using System.Collections;
using System.Collections.Generic;

namespace AstroFinder
{
    public interface IGetCollectionFromData<T>
    {
        ICollection GetCollection(T data);
    }
}
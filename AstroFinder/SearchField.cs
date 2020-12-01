using System;

namespace AstroFinder
{
    public abstract class SearchField : ISearchField
    {
        public abstract void AddCriteria(Enum inputName, string inputValue);
    }
}

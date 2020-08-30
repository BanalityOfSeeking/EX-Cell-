using System.Collections.Generic;

namespace EXCell
{
    internal interface IGameRulesService<T, U>
    {
        T ApplyRule(T item);

        IEnumerable<T> GetItemsOfType(U itemType);
    }
}
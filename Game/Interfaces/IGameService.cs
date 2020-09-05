using System.Collections.Generic;

namespace EXCell
{
    internal interface IGameRulesService<T, U> where T : struct where U : System.Enum
    {
        T ApplyRule(T item);

        IEnumerable<T> GetItemsOfType(U itemType);
    }
}
using System.Collections.Generic;

namespace EXCell
{
    public interface IRulesManager<T, U>
    {
        IReadOnlyList<T> Rules { get; }

        IEnumerable<T> GetItemsOfType(U EnumType);

        T ApplyRule(T id);
    }
}
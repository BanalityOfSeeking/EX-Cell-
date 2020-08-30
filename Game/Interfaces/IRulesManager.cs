using System.Collections.Generic;

namespace EXCell
{
    public interface IRulesManager<T, U>
    {
        IReadOnlyList<T> Rules { get; }

        IEnumerable<T> GetItemsOfType(U EnumType);

        T ApplyRule(T id);
    }

    public abstract class AbstractRulesManager<T, U> : IRulesManager<T, U> where T : class where U : System.Enum
    {
        public IReadOnlyList<T> Rules { get; internal set; }

        public abstract IEnumerable<T> GetItemsOfType(U EnumType);

        public abstract T ApplyRule(T id);
    }
}
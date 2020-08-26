using System;

namespace EXCell.DataStructure
{
    public interface IGenericParam<T> where T : class
    {
        T Component { get; }
        Func<T, T> Configuration { get; }
        IParam Param { get; }
    }
}
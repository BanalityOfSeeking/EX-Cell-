using System.Collections.Generic;
using System.Data;

namespace Loader
{
    internal interface ILoader<T>
    {
        IList<T> Items { get; }

        IEnumerator<T> GetEnumerator();

        abstract DataSet Load(string filePath);
    }
}
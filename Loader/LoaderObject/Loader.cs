using System.Collections.Generic;
using System.Data;

namespace Loader
{
    public abstract class Loader<T> : ILoader<T>
    {
        /// <summary>
        /// This class stores all configuration data in it, it is appendable at runtime and queryable.
        /// </summary>
        public IList<T> Items { get; }

        protected Loader()
        {
            Items = new List<T>();
        }

        /// <summary>
        /// Load Settings.xml into DataSet and parses it into settings.
        /// </summary>
        /// <param name="settings"></param>
        public abstract DataSet Load(string filePath);

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
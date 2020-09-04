using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;

namespace EXCell
{

    public class GameManager : IList<Game>
    {
        public GameManager()
        {
        }

        public List<Game> Games = new List<Game>();

        public int Count => ((ICollection<Game>)Games).Count;

        public bool IsReadOnly => ((ICollection<Game>)Games).IsReadOnly;

        public Game this[int index] { get => ((IList<Game>)Games)[index]; set => ((IList<Game>)Games)[index] = value; }

        public void StartGame()
        {            
        }

        public int IndexOf(Game item)
        {
            return ((IList<Game>)Games).IndexOf(item);
        }

        public void Insert(int index, Game item)
        {
            ((IList<Game>)Games).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Game>)Games).RemoveAt(index);
        }

        public void Add(Game item)
        {
            ((ICollection<Game>)Games).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Game>)Games).Clear();
        }

        public bool Contains(Game item)
        {
            return ((ICollection<Game>)Games).Contains(item);
        }

        public void CopyTo(Game[] array, int arrayIndex)
        {
            ((ICollection<Game>)Games).CopyTo(array, arrayIndex);
        }

        public bool Remove(Game item)
        {
            return ((ICollection<Game>)Games).Remove(item);
        }

        public IEnumerator<Game> GetEnumerator()
        {
            return ((IEnumerable<Game>)Games).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Games).GetEnumerator();
        }
    }
}
using System.Collections.Generic;

namespace Game.DataStructure
{
    public struct GameCell : IGameCell
    {
        public string Name { get; }

        public object Value { get; set; }

        public object Options { get; set; }

        public override bool Equals(object obj)
        {
            return obj is IGameCell cell && Equals(cell);
        }

        public bool Equals(IGameCell other)
        {
            return EqualityComparer<object>.Default.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return -1937169414 + EqualityComparer<object>.Default.GetHashCode(Value);
        }

        new public bool Equals(object x, object y)
        {
            if (x == y)
            {
                return true;
            }
            else if (x == null || y == null)
            {
                return false;
            }
            else if (x is IGameCell a
                && y is IGameCell b)
            {
                return Equals(a, b);
            }
            else { return default; }
        }

        public int GetHashCode(object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            if (obj is IGameCell x)
            {
                return GetHashCode(x);
            }
            return default;
        }

        public static bool operator ==(GameCell left, IGameCell right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(GameCell left, IGameCell right)
        {
            return !(left == right);
        }
    }
}
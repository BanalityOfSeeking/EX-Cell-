using System;
using System.Collections.Generic;

namespace EXCell.DataStructure
{
    /// <summary>
    /// Cell stores a dynamic value.
    /// TEXT, LIST, 
    /// </summary>
    public struct Cell : ICell
    {
        public object Options { get; }

        public Cell(IParam cellParams)
        {
            Value = string.Empty;
            Name = cellParams.Name;
            Options = cellParams.Options;
        }

        public string Name { get; }
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ICell cell && Equals(cell);
        }

        public bool Equals(Cell other)
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

            if (x == null || y == null)
            {
                return false;
            }

            if (x is ICell a
                && y is ICell b)
            {
                return Equals(a, b);
            }

            throw new ArgumentException("", nameof(x));
        }

        public int GetHashCode(object obj)
        {
            if (obj == null)
            {
                return 0;
            }

            if (obj is ICell x)
            {
                return GetHashCode(x);
            }

            throw new ArgumentException("", nameof(obj));
        }

        public static bool operator ==(Cell left, Cell right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Cell left, Cell right)
        {
            return !(left == right);
        }
    }
}
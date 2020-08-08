using EXCell.ConfigurationStore;
using System;
using System.Collections.Generic;

namespace EXCell.DataStructure
{
    public struct ParamBuilder
    {
        public IRowLayoutManager Manager { get; }

        public IEnumerable<IParam> Params => Manager.Configs.Columns; 
        public ParamBuilder(IRowLayoutManager manager)
        {
            Manager = manager;
        }

        public ParamBuilder AddParam(string name, string text, int min, int max)
        {
            Manager.AddConfig(new Param(name, text, min, max));
            return this;
        }

        public ParamBuilder AddParam(string name, string constant)
        {
            Manager.AddConfig(new Param(name, constant, -1, -1));
            return this;
        }

        public ParamBuilder AddParam(string name, IEnumerable<string> list)
        {
            Manager.AddConfig(new Param(name, list));
            return this;
        }

        public ParamBuilder AddParam(string name, int integer)
        {
            Manager.AddConfig(new Param(name, integer));
            return this;
        }

        public ParamBuilder AddParam(string name, DateTime date)
        {
            Manager.AddConfig(new Param(name, date));
            return this;
        }
    }

    public class Param : IParam
    {
        public string Name { get; }
        public char T { get; }
        public object Options = null;
        public Param(string name, string text, int min, int max)
        {
            T = 'T';
            MinLen = min;
            MaxLen = max;
            Value = text;
            Name = name;
        }

        public Param(string name, string constant) : this(name, constant, -1, -1)
        {
        }

        public Param(string name, IEnumerable<string> list) : this(name, "", -1, -1)
        {
            T = 'L';
            Options = list;
            Name = name;
        }

        public Param(string name, int integer)
        {
            T = 'I';
            Value = integer.ToString();
            Name = name;
        }

        public Param(string name, DateTime date)
        {
            T = 'D';
            Value = date.ToString("yyyy-MM-dd'T'HH:mm:ss");
            Name = name;
        }

        public string Value { get; }
        public int MaxLen { get; internal set; }
        public int MinLen { get; internal set; }
    }

    /// <summary>
    /// Cell stores a dynamic value.
    /// TEXT, LIST, 
    /// </summary>
    public struct Cell : ICell
    {
        public object Options { get; }

        public Cell(Param cellParams)
        {
            Value = cellParams.T switch
            {
                'T' => cellParams.Value,
                'L' => cellParams.Value,
                'D' => cellParams.Value,
                'I' => cellParams.Value,
                _ => string.Empty
            };
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
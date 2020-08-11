using System;
using System.Collections.Generic;

namespace EXCell.DataStructure
{
    public struct Param : IParam
    {
        public string Name { get; }

        public object Options { get; }
        public Param(string name, string text, int min, int max)
        {

            MinLen = min;
            MaxLen = max;
            Value = text;
            Name = name;
            Options = null;
        }

        public Param(string name, string constant) : this(name, constant, -1, -1)
        {
        }

        public Param(string name, IEnumerable<string> list) : this(name, "", -1, -1)
        {
            Options = list;
        }

        public Param(string name, int integer) : this(name, integer.ToString(), -1, -1)
        {
        }

        public Param(string name, DateTime date) : this(name, date.ToString("yyyy-MM-dd'T'HH:mm:ss"), -1, -1)
        {
        }

        public string Value { get; }
        public int MaxLen { get; internal set; }
        public int MinLen { get; internal set; }
    }
}
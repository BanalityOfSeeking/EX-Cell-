using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace EXCell.DataStructure
{
    internal struct Param : IParam
    {
        public Type ParamType { get; }
        public string Name { get; }

        public object Options { get; }
        public Param(string name, string text, int min, int max)
        {

            MinLen = min;
            MaxLen = max;
            Value = text;
            Name = name;
            Options = null;
            ParamType = typeof(string);
        }

        public Param(string name, string constant) : this(name, constant, -1, -1)
        {
        }

        public Param(string name, IEnumerable<string> list)
        {
            MinLen = -1;
            MaxLen = -1;
            Value = string.Empty;
            Name = name;
            Options = list;
            ParamType = typeof(IEnumerable<string>);
        }

        public Param(string name, int integer)
        {
            MinLen = -1;
            MaxLen = -1;
            Value = string.Empty;
            Name = name;
            Options = null;
            ParamType = typeof(int);
        }

        public Param(string name, DateTime date) : this(name, date.ToString("yyyy-MM-dd'T'HH:mm:ss"), -1, -1)
        {
            Name = name; 
            Value = date.ToString("yyyy-MM-dd'T'HH:mm:ss"); 
            MinLen = -1; 
            MaxLen = -1;
            Options = null;
            ParamType = typeof(DateTime);

        }

        public string Value { get; }
        public int MaxLen { get; internal set; }
        public int MinLen { get; internal set; }
    }


    public class GenericParam<T> : IGenericParam<T> where T : class
    {
        public GenericParam(T component, Func<T,T> configuration = null, IParam param = default)
        {

            Configuration = configuration ?? default;
            if (Configuration != default)
            {
                Component = Configuration(component);
            }
            else
            {
                Component = component;

            }
            Param = param;

        }
        public T Component { get; }

        public Func<T, T> Configuration { get; }

        public IParam Param { get; }
    }
}
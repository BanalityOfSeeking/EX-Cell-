using EXCell.ConfigurationStore;
using System;
using System.Collections.Generic;

namespace EXCell.DataStructure
{
    public interface IParamBuilder
    {
        IRowLayoutManager Manager { get; }
        IEnumerable<IParam> Params { get; }

        ParamBuilder AddParam(string name, DateTime date);
        ParamBuilder AddParam(string name, IEnumerable<string> list);
        ParamBuilder AddParam(string name, int integer);
        ParamBuilder AddParam(string name, string constant);
        ParamBuilder AddParam(string name, string text, int min, int max);
    }
}
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
}
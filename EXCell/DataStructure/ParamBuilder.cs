using Game.ConfigurationStore;
using System;
using System.Collections.Generic;

namespace Game.DataStructure
{
    public class ParamBuilder : IParamBuilder
    {
        public IRowLayoutManager Manager { get; }
        private IList<IParam> NoManager { get; }
        public IEnumerable<IParam> Params => Manager == null ? NoManager : Manager.Configs.Columns;

        public ParamBuilder(IRowLayoutManager manager = null)
        {
            if (manager == null)
            {
                NoManager = new List<IParam>();
            }
            else
            {
                Manager = manager;
            }
        }

        public ParamBuilder AddParam(string name, string text, int min, int max)
        {
            if (Manager == null)
            {
                NoManager.Add(new Param(name, text, min, max));
            }
            else
            {
                Manager.AddConfig(new Param(name, text, min, max));
            }
            return this;
        }

        public ParamBuilder AddParam(string name, string constant)
        {
            if (Manager == null)
            {
                NoManager.Add(new Param(name, constant, -1, -1));
            }
            else
            {
                Manager.AddConfig(new Param(name, constant, -1, -1));
            }
            return this;
        }

        public ParamBuilder AddParam(string name, IEnumerable<string> list)
        {
            if (Manager == null)
            {
                NoManager.Add(new Param(name, list));
            }
            else
            {
                Manager.AddConfig(new Param(name, list));
            }
            return this;
        }

        public ParamBuilder AddParam(string name, int integer)
        {
            if (Manager == null)
            {
                NoManager.Add(new Param(name, integer));
            }
            else
            {
                Manager.AddConfig(new Param(name, integer));
            }
            return this;
        }

        public ParamBuilder AddParam(string name, DateTime date)
        {
            if (Manager == null)
            {
                NoManager.Add(new Param(name, date));
            }
            else
            {
                Manager.AddConfig(new Param(name, date));
            }
            return this;
        }
    }
}
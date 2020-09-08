using Game.ConfigurationStore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Game.DataStructure
{
    public interface ISheet : IListSource, ISupportInitializeNotification, ISerializable, IXmlSerializable
    {
        public IRowLayoutManager Manager { get; }

        public DataTable SheetTable { get; }

        public ISheet CreateFirstRow(ParamBuilder builder);

        public ISheet CreateFirstRow();

        public ISheet LoadRow(IEnumerable<IParam> items);
    }
}
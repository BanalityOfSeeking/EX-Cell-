using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;

namespace EXCell.DataStructure
{
    public interface ISheet
    {
        bool ContainsListCollection { get; }
        bool IsInitialized { get; }
        DataTable SheetTable { get; }

        event EventHandler Initialized;

        void BeginInit();
        Sheet CreateFirstRow();
        void EndInit();
        IList GetList();
        void GetObjectData(SerializationInfo info, StreamingContext context);
        XmlSchema GetSchema();
        Sheet LoadParams(IEnumerable<IParam> items);
        void ReadXml(XmlReader reader);
        void WriteXml(XmlWriter writer);
    }
}
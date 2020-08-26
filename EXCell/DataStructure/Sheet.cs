using EXCell.ConfigurationStore;
using EXCell.Layouts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EXCell.DataStructure
{
    [Serializable]
    public class Sheet : MarshalByValueComponent, ISheet
    {
        public DataTable SheetTable { get; }
        public IRowLayoutManager Manager { get; }

        public bool ContainsListCollection => ((IListSource)SheetTable).ContainsListCollection;

        public bool IsInitialized => SheetTable.IsInitialized;

        internal ReadOnlyRow[] RowArray = new ReadOnlyRow[1000];

        protected Sheet(SerializationInfo info, StreamingContext context)
        {
            SheetTable = info.GetValue("SheetTable", typeof(DataTable)) as DataTable;
            Manager = info.GetValue("Manager", typeof(RowLayoutManager)) as RowLayoutManager;
            RowArray = info.GetValue("RowArray", typeof(ReadOnlyRow)) as ReadOnlyRow[];
        }
        public Sheet(IRowLayoutManager manager, DataTable sheetTable)
        {
            Manager = manager;
            SheetTable = sheetTable;
        }

        public event EventHandler Initialized
        {
            add
            {
                ((ISupportInitializeNotification)SheetTable).Initialized += value;
            }

            remove
            {
                ((ISupportInitializeNotification)SheetTable).Initialized -= value;
            }
        }

        public ISheet CreateFirstRow(ParamBuilder builder)
        {
            LoadRow(builder.Params);
            Manager.Configs.ConfigurationComplete();
            RowArray[0] = new ReadOnlyRow(Manager); 
            SheetTable.Rows.Add(SheetTable.NewRow());
            return this;
        }

        public ISheet CreateFirstRow()
        {
            if (Manager.Configs.IsConfigurationComplete)
            {               
                RowArray[0] = new ReadOnlyRow(Manager);
                SheetTable.Rows.Add(SheetTable.NewRow());
            }
            return this;
        }

        public ISheet LoadRow(IEnumerable<IParam> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            DataColumnCollection dcc = SheetTable.Columns;

            foreach (var Item in items)
            {
                Manager.AddConfig(Item);

                DataColumn dc = new DataColumn(Item.Name, typeof(string))
                {
                    Caption = Item.Name,
                    ColumnName = Item.Name,
                };
                if (dc.DataType == typeof(string))
                {
                    dc.MaxLength = Item.MaxLen;
                }
                dcc.Add(dc);
            }
            return this;
        }

        public IList GetList()
        {
            return ((IListSource)SheetTable).GetList();
        }

        public void BeginInit()
        {
            ((ISupportInitialize)SheetTable).BeginInit();
        }

        public void EndInit()
        {
            ((ISupportInitialize)SheetTable).EndInit();
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            ((ISerializable)SheetTable).GetObjectData(info, context);
        }

        public XmlSchema GetSchema()
        {
            return ((IXmlSerializable)SheetTable).GetSchema();
        }

        public void ReadXml(XmlReader reader)
        {
            ((IXmlSerializable)SheetTable).ReadXml(reader);
        }

        public void WriteXml(XmlWriter writer)
        {
            ((IXmlSerializable)SheetTable).WriteXml(writer);
        }
    }
}
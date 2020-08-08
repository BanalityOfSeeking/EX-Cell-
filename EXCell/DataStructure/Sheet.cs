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
    public class Sheet : MarshalByValueComponent, IListSource, ISupportInitializeNotification, ISerializable, IXmlSerializable, ISheet
    {
        public DataTable SheetTable { get; }

        internal Sheet(SerializationInfo info, StreamingContext context)
        {
            SheetTable = info.GetValue("SheetTable", typeof(DataTable)) as DataTable;
            Manager = info.GetValue("Manager", typeof(RowLayoutManager)) as RowLayoutManager;
            RowArray = info.GetValue("RowArray", typeof(ReadOnlyRow)) as ReadOnlyRow[];
        }
        internal Sheet(IRowLayoutManager manager)
        {
            Manager = manager;
            SheetTable = new DataTable("Sheet");
        }

        public Sheet(IRowLayoutManager manager, ILayout layout)
        {
            
            Manager = manager;            
            SheetTable = new DataTable("Sheet");
            LoadParams(layout.LayoutParams(manager));
            CreateFirstRow();
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

        public bool ContainsListCollection => ((IListSource)SheetTable).ContainsListCollection;

        public bool IsInitialized => ((ISupportInitializeNotification)SheetTable).IsInitialized;

        internal IRowLayoutManager Manager;
        public ReadOnlyRow[] RowArray = new ReadOnlyRow[1000];

        public Sheet CreateFirstRow()
        {
            if (!Manager.Configs.IsConfigurationComplete)
            {
                var Configuration = Manager.Configs;
                Configuration.ConfigurationComplete();
                RowArray[0] = new ReadOnlyRow(Manager);
                SheetTable.Rows.Add(SheetTable.NewRow());

                ///
                /// Test getting and setting value in Cell
                /// basic impl.
                /// 
#if _TEST_
                for (int i = 0; i < RowArray[0].Cells.Count; i++)
                {
                    if (RowArray[0].Cells[i].Name == "Gtin")
                    {
                        RowArray[0].Cells[i].Value = "00012347825784";
                    }
                }
                var Gtin = RowArray[0].Cells.FirstOrDefault(x => x.Name == "Gtin")?.Value;

                ///
                /// Test getting and setting values in DataRow
                ///

                SheetTable.Rows[0].SetField<string>("Gtin", "00012347825784");
                Gtin = SheetTable.Rows[0].Field<string>("Gtin");
#endif
            }
            return this;
        }

        public Sheet LoadParams(IEnumerable<IParam> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            DataColumnCollection dcc = SheetTable.Columns;

            foreach (var Item in items)
            {
                Manager.AddConfig(Item);

                DataColumn dc = new DataColumn(Item.Name, Item.T switch
                {
                    'T' => typeof(string),
                    'L' => typeof(List<string>),
                    'D' => typeof(DateTime),
                    'I' => typeof(int),
                    _ => typeof(string)
                })
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
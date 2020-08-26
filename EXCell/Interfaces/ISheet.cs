﻿using EXCell.ConfigurationStore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace EXCell.DataStructure
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
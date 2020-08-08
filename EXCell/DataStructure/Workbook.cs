// ***********************************************************************
// Assembly         : SSDMGMT.Data.Service
// Author           : rapril
// Created          : 06-30-2020
//
// Last Modified By : rapril
// Last Modified On :
// ***********************************************************************
// <copyright file="ParseBasicTemplate.cs" company="Supply Side Data Management LLC">
//     Copyright ©  2020 Supply Side Data Management. All rights reserved
// </copyright>
// <summary></summary>
// ***********************************************************************

using EXCell.ConfigurationStore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EXCell.DataStructure
{
    public sealed class Workbook : IWorkbook
    {
        public readonly IConfiguration Configuration;
        internal DataSet Data;
        public ISheet[] Sheets;
        private int SheetsIndex = 0;
        /// <summary>
        /// Constructor for Workbook
        /// Loads Configuration file
        /// Creates 5 Sheets
        /// Create DataSet named Workbook
        /// </summary>
        /// <param name="configurationBuilder"></param>
        public Workbook(IConfigurationBuilder configurationBuilder)
        {
            Configuration = configurationBuilder.AddXmlFile("Settings.xml").Build();
            Sheets = new Sheet[5];
            Data = new DataSet("Workbook");
        }

        public override bool Equals(object obj)
        {
            return obj is Workbook workbook &&
                   EqualityComparer<IConfiguration>.Default.Equals(Configuration, workbook.Configuration) &&
                   EqualityComparer<DataSet>.Default.Equals(Data, workbook.Data) &&
                   EqualityComparer<ISheet[]>.Default.Equals(Sheets, workbook.Sheets);
        }
        /// <summary>
        /// AddSheet checks sheets
        /// </summary>
        public void AddSheet()
        {
            if (SheetsIndex < 5)
            {
                var cc = new CellConfiguration();
                var rlm = new RowLayoutManager(cc);
                Sheet sheet = new Sheet(rlm);
                Sheets[SheetsIndex] = sheet;
                SheetsIndex += 1;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Configuration, Data, Sheets);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public static bool operator ==(Workbook left, Workbook right)
        {
            return EqualityComparer<Workbook>.Default.Equals(left, right);
        }

        public static bool operator !=(Workbook left, Workbook right)
        {
            return !(left == right);
        }
    }
}
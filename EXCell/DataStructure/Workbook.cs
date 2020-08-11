
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
        internal ISheet[] Sheets = new Sheet[5];
        private int SheetsIndex = 0;
        private const int MaxSheets = 5;
        public ISheet CurrentSheet => Sheets[SheetsIndex -1];
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
            Data = new DataSet("Workbook");
        }
        /// <summary>
        /// AddSheet checks sheets
        /// </summary>
        public Workbook AddSheet()
        {
            Sheet sheet = default;
            if (SheetsIndex < 5)
            {
                var cc = new CellConfiguration();
                var rlm = new RowLayoutManager(cc);
                var dt = new DataTable("Sheet" + SheetsIndex.ToString());
                sheet = new Sheet(rlm, dt);
                Data.Tables.Add(dt);
                Sheets[SheetsIndex] = sheet;
                SheetsIndex += 1;
            }
            return this;
        }
    }
}
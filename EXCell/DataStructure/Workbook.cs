using EXCell.ConfigurationStore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EXCell.DataStructure
{
    public class Workbook : IWorkbook
    {
        public readonly IConfiguration Configuration;
        internal DataSet Data;
        internal ISheet[] Sheets = new Sheet[5];
        private int SheetsIndex = 0;
        private const int MaxSheets = 5;
        public ISheet CurrentSheet => Sheets[SheetsIndex - 1];

        public Workbook()
        {
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
using EXCell.DataStructure;
using System.Collections.Generic;

namespace EXCell.ConfigurationStore
{
    public class CellConfiguration : ICellConfiguration
    {
        public CellConfiguration() => RowConfiguration = new Dictionary<int, IParam>();

        public IDictionary<int, IParam> RowConfiguration { get; }

        public int ColumnCount => RowConfiguration.Keys.Count;

        public bool IsConfigurationComplete { get; internal set; }

        public void ConfigurationComplete() => IsConfigurationComplete = true;

        public override bool Equals(object obj)
        {
            return obj is CellConfiguration dictionary &&
                   EqualityComparer<IDictionary<int, IParam>>.Default.Equals(RowConfiguration, dictionary.RowConfiguration) &&
                   EqualityComparer<ICollection<int>>.Default.Equals(((ICellConfiguration)this).ColumnIds, dictionary.RowConfiguration.Keys) &&
                   EqualityComparer<ICollection<IParam>>.Default.Equals(((ICellConfiguration)this).Columns, dictionary.RowConfiguration.Values) &&
                   ColumnCount == dictionary.ColumnCount &&
                   IsConfigurationComplete == dictionary.IsConfigurationComplete;
        }

        public override int GetHashCode()
        {
            int hashCode = 1161236662;
            hashCode = (hashCode * -1521134295) + EqualityComparer<IDictionary<int, IParam>>.Default.GetHashCode(RowConfiguration);
            hashCode = (hashCode * -1521134295) + EqualityComparer<ICollection<int>>.Default.GetHashCode(((ICellConfiguration)this).ColumnIds);
            hashCode = (hashCode * -1521134295) + EqualityComparer<ICollection<IParam>>.Default.GetHashCode(((ICellConfiguration)this).Columns);
            hashCode = (hashCode * -1521134295) + ColumnCount.GetHashCode();
            hashCode = (hashCode * -1521134295) + IsConfigurationComplete.GetHashCode();
            return hashCode;
        }
    }
}
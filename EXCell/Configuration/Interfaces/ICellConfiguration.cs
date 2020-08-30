using EXCell.DataStructure;
using System.Collections.Generic;
using System.Linq;

namespace EXCell.ConfigurationStore
{
    public interface ICellConfiguration
    {
        int ColumnCount { get; }
        IEnumerable<int> ColumnIds => RowConfiguration.Keys;
        IEnumerable<IParam> Columns => RowConfiguration.Values;
        bool IsConfigurationComplete { get; }
        IDictionary<int, IParam> RowConfiguration { get; }

        void ConfigurationComplete();

        bool ContainsColumn(string columnName) => Columns?.FirstOrDefault(x => x.Name == columnName) != default;

        bool ContainsConfig(IParam ColumnConfig) => Columns?.Contains(ColumnConfig) ?? false;

        bool ContainsRow(int rowId) => RowConfiguration.ContainsKey(rowId);

        bool Equals(object obj);

        int GetHashCode();

        bool TryGetConfig(int rowId, out IParam value) => RowConfiguration.TryGetValue(rowId, out value);
    }
}
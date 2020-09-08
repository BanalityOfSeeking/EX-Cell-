using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Game.DataStructure
{
    public interface IReadOnlyRow
    {
        ReadOnlyCollection<ICell> Cells { get; }
        int RowId { get; }

        (bool Config, bool Cell) Contains(string Name);

        IEnumerator<ICell> GetEnumerator();

        int IndexOf(string Name);

        ReadOnlyRow UpdateCellInRow(string Name, string Value);
    }
}
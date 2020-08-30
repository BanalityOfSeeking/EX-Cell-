using EXCell.ConfigurationStore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EXCell.DataStructure
{
    public class ReadOnlyRow : IReadOnlyRow
    {
        public int RowId { get; }
        internal IRowLayoutManager Manager;

        public ReadOnlyRow(IRowLayoutManager manager)
        {
            Manager = manager;
            RowId = ((RowLayoutManager)Manager).RequestRowId;
            var CellList = new List<ICell>();
            foreach (IParam iparam in manager.Configs.Columns)
            {
                CellList.Add(new Cell(iparam));
            }
            Cells = new ReadOnlyCollection<ICell>(CellList);
        }

        public ReadOnlyRow UpdateCellInRow(string Name, string Value)
        {
            var cell = (from Cell in Cells
                        where Cell.Name == Name
                        select Cell).FirstOrDefault();
            if (cell != default)
            {
                var insert = new Cell(new Param(name: cell.Name, Value));
                var cellIndex = Cells.IndexOf(cell);
                var cl = Cells.ToList();
                cl.Insert(cellIndex, insert);
                cl.RemoveAt(cellIndex + 1);
                Cells = new ReadOnlyCollection<ICell>(cl);
            }
            return this;
        }

        public ReadOnlyCollection<ICell> Cells { get; internal set; }

        public (bool Config, bool Cell) Contains(string Name)
        {
            bool Conf = false;
            bool Cell = false;
            if (Cells.Any(x => Name == x.Name) == default)
            {
                return (Conf, Cell);
            }
            if (Cells.Any(x => Name == x.Name))
            {
                Conf = true;
            }
            if (Cells.Any(x => x.Name == Name))
            {
                Cell = true;
            }
            return (Conf, Cell);
        }

        public IEnumerator<ICell> GetEnumerator()
        {
            return Cells.GetEnumerator();
        }

        public int IndexOf(string Name)
        {
            for (int i = 0; i < Cells.Count; i++)
            {
                if (Cells[i].Name == Name)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
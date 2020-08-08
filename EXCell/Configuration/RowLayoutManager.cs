using EXCell.DataStructure;
using System.Runtime.CompilerServices;

namespace EXCell.ConfigurationStore
{
    public class RowLayoutManager : IRowLayoutManager
    {
        public ICellConfiguration Configs { get; }

        public RowLayoutManager(ICellConfiguration configs)
        {
            Configs = configs;
        }
        public int RequestColumnId => ((IRowLayoutManager)this).RequestColumnId(Configs);
        public int RequestRowId => ((IRowLayoutManager)this).RequestRowId(Configs);

        public int Column { get; set; }
        public int Row { get; set; }
    }
    public static class RowLayoutManagerExtensions
    {
        public static IRowLayoutManager AddConfig(this IRowLayoutManager manager, IParam config)
        {

            if (!manager.Configs.IsConfigurationComplete && !manager.Configs.ContainsConfig(config))
            {
                manager.Configs.RowConfiguration.Add(((RowLayoutManager)manager).RequestColumnId, config);
            }
            return manager;
        }
    }
}
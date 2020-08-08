using EXCell.DataStructure;
using EXCell.Layouts;
using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System.Dynamic;

namespace EXCell.ConfigurationStore
{

    public class WorkBookFactory
    {
        public Container InterfaceContainer { get; }
        private Lifestyle Style { get; }

        public WorkBookFactory()
        {
            InterfaceContainer = new Container();

            Style = Lifestyle.Singleton;
            InterfaceContainer.Register<IConfigurationBuilder, ConfigurationBuilder>(Style);
            InterfaceContainer.Register<ILayout, Layout>(Style);
            InterfaceContainer.Register<ICellConfiguration, CellConfiguration>(Style);
            InterfaceContainer.Register<IRowLayoutManager, RowLayoutManager>(Style);
            InterfaceContainer.Register<ISheet, Sheet>(Style);
            InterfaceContainer.Register<Workbook>(Style);
        }
        public Workbook GetWorkbook()
        {
            return InterfaceContainer.GetInstance<Workbook>();
        }
    }
}
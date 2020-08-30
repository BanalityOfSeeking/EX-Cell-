using EXCell.DataStructure;
using Microsoft.Extensions.Configuration;
using SimpleInjector;

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
            InterfaceContainer.Register<Workbook>(Style);
        }

        public Workbook GetWorkbook()
        {
            return InterfaceContainer.GetInstance<Workbook>();
        }
    }
}
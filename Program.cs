using EXCell.ConfigurationStore;

namespace EXCell
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            WorkBookFactory injector = new WorkBookFactory();
            var wb = injector.GetWorkbook();
        }
    }
}
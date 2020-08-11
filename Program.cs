using EXCell.ConfigurationStore;

namespace EXCell
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            WorkBookFactory wbFactory = new WorkBookFactory();
            var wb = wbFactory.GetWorkbook();
            //add new sheet
            wb.AddSheet()
                // Get Current Sheet
                .CurrentSheet
                // load the layout by pass the prebuilt  layout into the Sheet
                .LoadRow(new EXCell.Layouts.Layout(wb.Configuration)
                // Call LayoutParams to get the layout params to load into Sheet 
                .LayoutParams(wb.CurrentSheet.Manager));

        }
    }
}
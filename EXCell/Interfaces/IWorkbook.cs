// ***********************************************************************

namespace EXCell.DataStructure
{
    public interface IWorkbook
    {
        Workbook AddSheet();

        bool Equals(object obj);

        int GetHashCode();

        string ToString();
    }
}
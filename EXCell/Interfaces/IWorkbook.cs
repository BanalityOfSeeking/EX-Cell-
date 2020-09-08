// ***********************************************************************

namespace Game.DataStructure
{
    public interface IWorkbook
    {
        Workbook AddSheet();

        bool Equals(object obj);

        int GetHashCode();

        string ToString();
    }
}
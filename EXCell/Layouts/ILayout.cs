// ***********************************************************************

using EXCell.DataStructure;
using System.Collections.Generic;

namespace EXCell.Layouts
{
    public interface ILayout
    {
        IEnumerable<IParam> LayoutParams();
    }
}
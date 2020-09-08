// ***********************************************************************

using Game.DataStructure;
using System.Collections.Generic;

namespace Game.Layouts
{
    public interface ILayout
    {
        IEnumerable<IParam> LayoutParams();
    }
}
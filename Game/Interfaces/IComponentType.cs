using System;
using System.Collections.Generic;
using System.Text;

namespace EXCell
{
    public interface IComponentType
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
    }
}

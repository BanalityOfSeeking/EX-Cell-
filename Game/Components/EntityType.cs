using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace EXCell
{
    public struct EntityType : IComponentType
    {
        public List<IComponentType> ComponentList;

        public int ParentId { get; set; }
    }
}
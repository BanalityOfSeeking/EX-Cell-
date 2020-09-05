using System;
using System.Collections;
using System.Collections.Generic;

namespace EXCell
{
    public struct EntityType : IComponentType
    {
        internal List<IComponentType> ComponentList { get; set; }

        public EntityType(int parentId, int childId, List<IComponentType> componentList = null)
        {
            ComponentList = componentList ?? null;
            ParentId = parentId;
            ChildId = childId;
        }
        public int ParentId { get; set; }
        public int ChildId { get; set; }

        public void Add(IComponentType item)
        {
            item.ParentId = ParentId;
            ComponentList.Add(item);
        }
    }
}
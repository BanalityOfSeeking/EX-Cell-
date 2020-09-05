using System;
using System.Collections;
using System.Collections.Generic;

namespace EXCell
{
    public struct EntityType : IComponentType
    {
        internal List<IComponentType> ComponentList { get; set; }

        public EntityType(int parentId, List<IComponentType> componentList = null)
        {
            ComponentList = componentList ?? null;
            ParentId = parentId;
        }
        public int ParentId { get; set; }


        public void Add(IComponentType item)
        {
            item.ParentId = ParentId;
            ComponentList.Add(item);
        }
    }
}
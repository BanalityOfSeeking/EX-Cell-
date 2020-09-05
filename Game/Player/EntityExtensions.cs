using System.Collections.Generic;
using System.Linq;

namespace EXCell
{
    public static class EntityExtensions
    {
        public static void UpdateEntity(this ref Entity MainEntity, EntityType type)
        {
            var Entity = MainEntity.Entities.FirstOrDefault(x => x.ParentId == type.ParentId);

            MainEntity.Entities.Remove(Entity);
            MainEntity.Entities.Add(type);
            foreach (var cli in type.ComponentList)
            { }
        }
        public static void InitComponentList(this ref EntityType entity)
        {
            entity.ComponentList = new List<IComponentType>();
        }

        public static void update(this ref EntityType entityType)
        {

        }
    }
}
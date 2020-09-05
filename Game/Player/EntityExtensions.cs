using System.Collections.Generic;

namespace EXCell
{
    public static class EntityExtensions
    {
        public static void UpdateEntity(this ref Entity MainEntity, EntityType type)
        {
            foreach (var Entity in MainEntity.Entities)
            {
                if (Entity.ParentId == type.ParentId)
                {
                    MainEntity.Entities.Remove(Entity);
                    MainEntity.Entities.Add(type);
                    foreach (var cli in type.ComponentList)
                    { }
                }
            }
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
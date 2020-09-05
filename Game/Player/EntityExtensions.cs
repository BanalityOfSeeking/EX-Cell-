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
    }
}
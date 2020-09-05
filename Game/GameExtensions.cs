using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EXCell
{
    public static class EntityExtensions //: IGameStateMonitor
    {

        public static void InitComponentList(this ref EntityType entity)
        {
            entity.ComponentList = new List<IComponentType>();
        }

        public static void update(this EntityType entityType)
        {

        }

        public static IEnumerable<IComponentType> DoUpdates(this List<IComponentType> components, IComponentType Value)
        {
            foreach(IComponentType ct in components)
            {
                yield return ct;
            }
        }
    }
}
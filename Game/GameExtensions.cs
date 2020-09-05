using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace EXCell
{

    public static class EntityExtensions //: IGameStateMonitor
    {

        public static void InitComponentList(this ref EntityType entity)
        {
           entity.ComponentList = new List<IComponentType>();
        }

        public static void update(this ref EntityType entityType)
        {

        }
    }
}
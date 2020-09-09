using Game.Components;
using System.Collections.Generic;

namespace Game
{

    public static class ComponentManager
    {
        public static void RequestComponent<T>(int entityId) where T : IComponentType, new()
        {
            if (EntityMappings.TryGetValue(entityId, out IComponentType[] componentList))
            {
                for(int i = 0; i < componentList.Length; i++)
                {
                    if(componentList[i] == null)
                    {
                        componentList[i] = new T();
                        break;
                    }
                }
            }
            else
            {
                var MappingList = new IComponentType[20];
                MappingList[0] = new T();
                EntityMappings.Add(entityId, MappingList);
            }
        }
        public static void RequestCompoents<T>(in int entityId, IList<IComponentType> requests)
        {
            if (EntityMappings.TryGetValue(entityId, out IComponentType[] componentList))
            {
                requests.CopyTo(componentList, componentList.Length);
            }
            else
            {
                var MappingList = new IComponentType[requests.Count];
                requests.CopyTo(MappingList, 0);
                EntityMappings.Add(entityId, MappingList);
            }
        }

        public static bool DestroyEntityComponents(int entityId)
        {
            if (EntityMappings.ContainsKey(entityId))
            {
                EntityMappings.Remove(entityId);
                return true;
            }
            return false;
        }

        private static Dictionary<int, IComponentType[]> EntityMappings = new Dictionary<int, IComponentType[]>();

        public static bool TryGetEntityComponents(int entityId, out IList<IComponentType> components)
        {
            if (EntityMappings.TryGetValue(entityId, out IComponentType[] types))
            {
                components = types;
                return true;
            }
            components = default;
            return false;
        }
    }
}

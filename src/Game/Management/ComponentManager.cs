using Game.Components;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PubSub;
namespace Game
{

    public static class ComponentManager
    {
        public static void RequestComponent<T>(int entityId) where T : IComponentType, new()
        {
            if (EntityMappings.TryGetValue(entityId, out IComponentType[] componentList))
            {
                for (int i = 0; i < componentList.Length; i++)
                {
                    if (componentList[i] == null)
                    {
                        componentList[i] = new T();
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
        public static void RequestComponents<T>(int entityId, IList<IComponentType> requests)
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


        public static IEnumerable<(int Id, IComponentType component)> GetComponents()
        {
            foreach (var kvp in EntityMappings)
            {
                foreach (var value in kvp.Value)
                {
                    yield return (kvp.Key, value);
                }
            }
        }
        public static void ProcessComponents()
        {

            foreach(var x in GetComponents())
            {
                // Assign Id a role in game
                // Assign Id Needed components to fulfil game role 
                // Assign stage display requirements first (World | Path(s) | Environments props | Chests | Entrance
                // Assign Monsters ( stats | weapons | loot | Location (x, y, x ))
                // Assign Player resources over environment ( stats | weapons | loot | Location (x, y, x ))
            }
        }
    }
}

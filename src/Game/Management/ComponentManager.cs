using Game.Components;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PubSub;
using System;
using System.Windows.Input;

namespace Game
{

    public class ComponentManager : IDisposable
    {
        public void RequestComponent<T>(int entityId, T Type = default) where T : struct, IComponentType
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
        public void RequestComponents<T>(int entityId, IComponentType[] requests) where T : struct, IComponentType
        {
            if (EntityMappings.TryGetValue(entityId, out IComponentType[] componentList))
            {
                requests.CopyTo(componentList, componentList.Length);
            }
            else
            {
                var MappingList = new IComponentType[requests.Length];
                requests.CopyTo(MappingList, 0);
                EntityMappings.Add(entityId, MappingList);
            }
        }

        public bool DestroyEntityComponents(int entityId)
        {
            if (EntityMappings.ContainsKey(entityId))
            {
                EntityMappings.Remove(entityId);
                return true;
            }
            return false;
        }

        public Dictionary<int, IComponentType[]> EntityMappings = new Dictionary<int, IComponentType[]>();
        private bool disposedValue;

        public IEnumerable<(int Id, IComponentType component)> GetComponents()
        {
            foreach (var kvp in EntityMappings)
            {
                foreach (var value in kvp.Value)
                {
                    yield return (kvp.Key, value);
                }
            }
        }
        public void ProcessComponents()
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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~ComponentManager()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

using Game.Components;
using NoAlloq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public static class EntityComponent
    {
        private static EntityManager EntityManager = new EntityManager();
        private static ComponentManager ComponentManager = new ComponentManager();

        public static void RemoveEntityComponent<T>(short id) where T : IComponentType
        {
            for(int i = 0; i < ComponentManager.EntityMappings.Length;i++)
            {
                if(ComponentManager.EntityMappings[i].id == id && ComponentManager.EntityMappings[i].component is T)
                {
                    ComponentManager.EntityMappings[i].component = null;
                    ComponentManager.EntityMappings[i].id = -1;
                    break;
                }
            }
        }

        public static void DestroyEntityComponents( short id)
        {
            for (int i = 0; i < ComponentManager.EntityMappings.Length; i++)
            {
                if (ComponentManager.EntityMappings[i].id == id)
                {
                    ComponentManager.EntityMappings[i].component = null;
                    ComponentManager.EntityMappings[i].id = -1;
                }
            }
        }

        public static IEnumerable<IComponentType> GetEntityComponents(short id)
        {
            return (from map in ComponentManager.EntityMappings
                    where map.id == id && map.component != null
                    select map.component);
        }

        private static short InternalId { get; set; }

        private static void SetEntityComponent<T>() where T : IComponentType, new()
        {
            bool wasSet = false;
            for (int i = 0; i < ComponentManager.EntityMappings.Length; i++)
            {
                if (ComponentManager.EntityMappings[i].component is T && ComponentManager.EntityMappings[i].id == InternalId)
                {
                    ComponentManager.EntityMappings[i].component = new T();
                    wasSet = true;
                    break;
                }
            }
            if(!wasSet)
            {
                for (int i = 0; i < ComponentManager.EntityMappings.Length; i++)
                {
                    if (ComponentManager.EntityMappings[i].component == null)
                    {
                        ComponentManager.EntityMappings[i].component = new T();
                        ComponentManager.EntityMappings[i].id = InternalId;
                        break;
                    }
                }
            }
        }

        public static void SetEntityComponent<T>(short id) where T : IComponentType, new()
        {
            foreach(var mem in EntityManager.UsedEntities.Span)
            {
                if (mem.Id == id && mem.Used == true)
                {
                    InternalId = id;
                    SetEntityComponent<T>();
                    break;
                }
            }
        }

        public static IEnumerable<IComponentType> GetComponentsOfType<T>() where T : IComponentType
        {
            return (from mapping in ComponentManager.EntityMappings
                    where mapping.component is T
                    select mapping.component);
        }
        public static short GetEntityId()
        {
            return EntityManager.RentEntityId();
        }

        public static void ReturnEntityId(short id)
        {
            EntityManager.DestroyEntityId(id);
        }
    }
}

using Game.Entities;
using Game.Stages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;

namespace Game.Components
{
    public enum EntityRoles
    {
        NPC = 0, PLAYER, MONSTER, CHEST
    }

    public class ComponentManager
    {
        private EntityManager Entities { get; } 
        private ObjectPool<HealthComponent> HealthPool = ObjectPool.Create<HealthComponent>();
        private ObjectPool<PlayableComponent> PlayablePool = ObjectPool.Create<PlayableComponent>();
        private ObjectPool<LevelableComponent> LevelablePool = ObjectPool.Create<LevelableComponent>();

        HealthComponent GetHealthComponent() => HealthPool.Get();

        PlayableComponent GetPlayableComponent() => PlayablePool.Get();

        LevelableComponent GetLevelableComponent() => LevelablePool.Get();


        public int ActiveEntities = 0;
        public Dictionary<int, IComponentType[]> EntityMappings { get; }
        private Dictionary<int, IComponentType[]> EntityPriorStates { get; }

        public ComponentManager()
        {
            Entities = new EntityManager();
            EntityMappings = new Dictionary<int, IComponentType[]>();
            EntityPriorStates = new Dictionary<int, IComponentType[]>();
        }
        public StageHost AssignRequiredRoles(StageHost stage)
        {
            foreach (var role in stage.RequiredRoles)
            {
                var entityId = Entities.CreateEntityId().Value;

                IComponentType[] defReturn = new IComponentType[] 
                { GetHealthComponent(), GetLevelableComponent() };
                var Actor = role switch
                {
                    EntityRoles.PLAYER => defReturn,
                    EntityRoles.MONSTER => defReturn,
                    _ => defReturn
                };
                stage.AddEntity(entityId, Actor);
            }
            return stage;    
        }
    }
}

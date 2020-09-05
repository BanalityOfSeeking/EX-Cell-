using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Security.Policy;

namespace EXCell
{
    /// ECS NOTES
    /// only THESE TYPES!!!
    /// Boolean, Byte, SByte, Int16, UInt16, Int32, UInt32, Int64, UInt64, IntPtr, UIntPtr, Char, Double, and Single
    /// Entities are only an aggregation of Components, identified by a unique id
    /// Components are only data
    /// Systems publish/subscribe to Components, creating behavior


    public interface IComponentType
    {
        public int ParentId { get; set; }
    }
    public static class IComponentExtensions
    {
        public static void SetComponent(this EntityType type, IComponentType component)
        {            
            component.ParentId = type.ParentId;
        }
    }
    public struct Levelable : IComponentType
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }

        public int CurrentXP;
        public int Level;
    }

    //public struct Playable
    //{
    //    public BaseEntity EntityId { get; }
    //    public Levelable Level { get; }
    //    public HealthComponent Health { get; }//set; } = new HealthComponent(100,100);

    //    public Items Items { get; }//set; } = new PlayerItems();

    //    public AttackEventHandler AttackEvent { get; }
    //}
}
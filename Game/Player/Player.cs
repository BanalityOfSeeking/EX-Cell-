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
    public struct Levelable : IComponentType
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }

        public int CurrentXP;
        public int Level;

        public Levelable(int parentId, int childId, int currentXP, int level)
        {
            ParentId = parentId;
            ChildId = childId;
            CurrentXP = 0;
            Level = 0;
        }
    }
}
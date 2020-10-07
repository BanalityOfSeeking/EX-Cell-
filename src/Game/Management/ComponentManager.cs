using Game.Components;
using System.Collections.Generic;
using System;
using NoAlloq;

namespace Game
{
    public class ComponentManager
    {
        internal (short id, IComponentType component)[] EntityMappings { get; } =  new(short id, IComponentType component)[100];
    }
}

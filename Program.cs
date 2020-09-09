﻿using Game.Components;
using Game.Systems;
using System;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace Game
{
    internal ref struct Program
    {
        private static void Main(string[] args)
        {
            Console.SetWindowSize(40, 25);
            Console.SetBufferSize(40, 25);
            int? Id = EntityManager.CreateEntityId();
            if (Id.HasValue)
            {
                ComponentManager.RequestComponent<HeadComponent>(Id.Value);
                ComponentManager.RequestComponent<LeftArmComponent>(Id.Value);
                ComponentManager.RequestComponent<RightArmComponent>(Id.Value);
                ComponentManager.RequestComponent<ChestComponent>(Id.Value);
                ComponentManager.RequestComponent<LeftLegComponent>(Id.Value);
                ComponentManager.RequestComponent<RightLegComponent>(Id.Value);
            }
            GameBodySystem.RegisterBody(Id.Value);

        }
    }
}

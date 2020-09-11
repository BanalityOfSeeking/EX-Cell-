using Game.Components;
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
            ContainerFactory factory = new ContainerFactory();
            var Container = factory.GetContainer();
            Container.Register<BodySystem>();
            Container.Register(typeof(InjectBodyParts));
            Container.GetInstance<InjectBodyParts>();

        }
    }
    internal class InjectBodyParts
    {
        IBodyComponent BodyComponents { get; }
        public InjectBodyParts(BodySystem bodyComponents)
        {
            BodyComponents = bodyComponents;
        }
        IPartComponent Head { get => BodyComponents.BodyParts?[0]; }
        IPartComponent Chest { get => BodyComponents.BodyParts?[1]; }
        IPartComponent LeftArm { get => BodyComponents.BodyParts?[2]; }
        IPartComponent RightArm { get => BodyComponents.BodyParts?[3]; }
        IPartComponent LeftLeg { get => BodyComponents.BodyParts?[4]; }
        IPartComponent RightLeg { get => BodyComponents.BodyParts?[5]; }
    }
}

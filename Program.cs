using System;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace EXCell
{
    internal ref struct Program
    {
        private static void Main(string[] args)
        {
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 50);
            Console.Title = "Programming game 0.1c";

            Entity entity = new Entity();
            var ET = entity.CreateEntityType();
            ET.InitComponentList();
            ET.Add(new HealthComponent());
            ET.Add(new AttackEventComponent());
            ET.Add(new LevelableComponent());
            ET.Add(new PlayableComponent());
            entity.UpdateEntity(ET);

            var ET2 = entity.CreateEntityType();
            ET2.InitComponentList();
            ET2.Add(new HealthComponent());
            ET2.Add(new AttackEventComponent());
            ET2.Add(new LevelableComponent());
            entity.UpdateEntity(ET2);



        }
    }
}

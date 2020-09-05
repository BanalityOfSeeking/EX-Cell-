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
            Console.Title = "Programming game 0.1b";

            Entity entity = new Entity();
            var c = entity.CreateEntityType();
            c.InitComponentList();
            c.Add(new HealthComponent());
            c.Add(new AttackEventComponent());
            c.Add(new Levelable());
            entity.UpdateEntity(c);

            var m = entity.CreateEntityType();



        }
    }
}

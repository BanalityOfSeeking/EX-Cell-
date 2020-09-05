using System;
using System.Threading;
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
            c.ComponentList.Add(new Levelable());

            var m = entity.CreateEntityType();

            c.AttackEvent?.OnDamageEvent(c.Health, ref m.Health);


        }
    }
}

using Game.Components;

using System;
using System.Collections.Immutable;
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
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 50);
            Console.Title = "My Programming game 0.1d";
            ComponentManager componentManager = new ComponentManager();
            BodySystem bs = new BodySystem();
            componentManager.DeliverBody();

        }
    }
}

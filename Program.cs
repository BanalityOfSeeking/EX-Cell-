using System;
using System.Threading;

namespace EXCell
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 50);
            Console.Title = "Programming game 0.1b";

            GameManager Manager = new GameManager();

            Game game = new Game();
            game.InitComponentList();
            game.Components.Add(new ComponentType("Player1", true, 100, true, true));
            game.Components.Add(new ComponentType("Monster1", true, 100, true, true));
            game.Components.Add(new ComponentType("GameEnvironment", false, 1, false, false));
            Manager.Add(game);
            Manager.StartGame();
        }
    }
}

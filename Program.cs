using System;

namespace EXCell
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.SetWindowSize(100, 50);
            Console.SetBufferSize(100, 50);
            Console.Title = "Programming a game 0.1a";
            GameManager Manager = new GameManager();

            Game ThisGame = new Game()
            .ConfigureEquipement();
            Manager.Start(ThisGame);
        }
    }
}
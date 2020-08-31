using System;

namespace EXCell
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.SetWindowSize(45, 15);
            Console.SetBufferSize(45, 15);
            Console.SetWindowSize(60, 15);
            
            GameManager Manager = new GameManager();

            Game ThisGame = new Game()
            .ConfigureEquipement();
            SceneManager.DisplayScene(ThisGame);
            Manager.Start(ThisGame);
        }
    }
}
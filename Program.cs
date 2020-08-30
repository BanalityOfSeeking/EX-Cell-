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
            .ConfigPlayer("Player1")
            .ConfigureMonster("Monster1")
            .ConfigureEquipement()
            .ConfigureInventory();
            Manager.Start(ThisGame);
        }
    }
}
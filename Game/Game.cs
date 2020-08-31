using System;
using System.Collections.Generic;
using static System.Console;

namespace EXCell
{
    public class Game
    {
        public Random GameRoller = new Random();
        public static GamePools Pools = new GamePools();
        private GameManager Manager { get; set; }

        public Game()
        {
        }

        public Game ConfigureEquipement(IReadOnlyList<EquipId> equips = default)
        {
            EquipmentRulesManager.LoadEquipmentProgressionList(equips);
            return this;
        }
        public Player Player1 = Pools.PlayerPool.Get();
        public Monster Monster1 = Pools.MonstePool.Get();
        public void StartGame(GameManager manager)
        {
            Console.ReadLine();
            Manager = manager;
            var PlayerHealth = 100 + (Manager.WinCount * 10);
            var MonsterHealth = 100 + (Manager.WinCount * 10);

            WriteLine("Welcome Enter your Name Challenger!!", Player1.Name = ReadLine());
            WriteLine("You are now Sir {0} and have {1} health", Player1.Name, PlayerHealth);
            WriteLine("The Monster has {0} health.", MonsterHealth);
            if (Monster1.HasTreasure)
            {
                WriteLine("This Monster has treasure!");
            }
            WriteLine("Good luck {0}.", Player1.Name);
            WriteLine("Press any key to continue ");
            ReadKey(false);

            while (PlayerHealth > 0 && MonsterHealth > 0)
            {
                var PlayerRoll = GameRoller.Next(10, 99);
                var MonsterRoll = GameRoller.Next(10, 99);

                WriteLine("You have rolled {0}.", PlayerRoll);
                WriteLine("The dragon rolled {0}", MonsterRoll);

                if (PlayerRoll > MonsterRoll)
                {
                    MonsterHealth -= 10;
                    if (MonsterHealth > 0)
                    {
                        WriteLine("The dragon health left is {0}", MonsterHealth);
                    }
                    else
                    {
                        if (Monster1.HasTreasure)
                        {
                            Player1.Items.UpgradeItem(Monster1.TreasureCode);
                        }
                        Win(nameof(Player1), PlayerHealth);
                    }
                }
                else
                {
                    PlayerHealth -= 10;
                    if (PlayerHealth > 0)
                    {
                        WriteLine("{0} have left {1} health", nameof(Player1), PlayerHealth);
                    }
                    else
                    {
                        Lose(nameof(Player1), MonsterHealth);
                    }
                }
            }
            WriteLine("Press any key to continue ");
            ReadKey(false);

        }

        public void Restart(string Name)
        {
            WriteLine("{0} died, do you want to start a new character? press y to continue or any key to exit", Name);
            var c = ReadKey(true).KeyChar;
            if (c == 'y')
            {
                WriteLine("Welcome Enter your Name Challenger!!", Player1.Name = ReadLine());
                Player1.Items = new PlayerItems();
                StartGame(Manager);
            }
            return;
        }

        public void Continue(string name)
        {
            WriteLine("{0} won, do you want to start another game? press y to continue or any key to exit", name);
            var c = ReadKey(true).KeyChar;
            if (c == 'y')
            {
                Monster1 = new Monster();
                StartGame(Manager);
            }
            return;
        }

        public void Lose(string name, int health)
        {
            Manager.WinCount = 0;
            WriteLine("You lose");
            WriteLine("The Monster has {0} health left.", health);
            Restart(name);
        }

        public void Win(string name, int health)
        {
            Manager.WinCount += 1;
            WriteLine("You win");
            WriteLine("{0} have {1} health left .", name, health);
            Continue(name);
        }
    }
}
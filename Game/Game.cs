using System;
using System.Collections.Generic;


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
            SceneManager.DisplayScene(this, SceneType.PlayerSetup);
            return this;
        }

        public Player Player1 = Pools.PlayerPool.Get();
        public Monster Monster1 = Pools.MonstePool.Get();

        public void StartGame(GameManager manager)
        {
            Manager = manager;

            SceneManager.DisplayScene(this, SceneType.MonsterScene);
            Player1.Health.CurrentHealth = 100 + (Manager.WinCount * 10);
            Monster1.Health.CurrentHealth = 100 + (Manager.WinCount * 10);

            while (Player1.Health.CurrentHealth > 0 && Monster1.Health.CurrentHealth > 0)
            {
                DoDamageTo(GameRoller.Next(10, 99), GameRoller.Next(10, 99));
            }
        }

        public void DoDamageTo(int pr, int mr)
        {
            if (pr > mr)
            {
                Player1.DoDamage(Monster1);

                if (Monster1.Health.CurrentHealth > 0)
                {
                    Console.SetCursorPosition(0, 0);
                    SceneManager.DisplayScene(this, SceneType.MonsterScene);
                }
                else
                {
                    Player1.GainExpierence(Monster1.XP);
                    if (Monster1.HasTreasure)
                    {
                        Player1.Items.UpgradeItem(Monster1.TreasureCode);
                    }
                    Win(Player1.Name, Player1.Health.CurrentHealth);
                }
                Monster1.DoDamage(Player1);
                if (Player1.Health.CurrentHealth > 0)
                {
                    Console.SetCursorPosition(0, 0);
                    SceneManager.DisplayScene(this, SceneType.MonsterScene);
                }
                else
                {
                    Lose(Player1.Name, Monster1.Health.CurrentHealth);
                }
            }
        }

        public void Restart(string Name)
        {
            Console.Clear();
            Console.WriteLine("{0} died, do you want to start a new character? press y to continue or any key to exit", Name);
            var c = Console.ReadKey(true).KeyChar;
            if (c == 'y')
            {
                Console.WriteLine("Welcome Enter your Name Challenger!!", Player1.Name = Console.ReadLine());
                Player1.Items = new PlayerItems();
                StartGame(Manager);
            }
        }

        public void Continue(string name)
        {
            Console.WriteLine("{0} won, continue game? Press y to continue, or any key to exit.", name);
            var c = Console.ReadKey(true).KeyChar;
            if (c == 'y')
            {
                Pools.MonstePool.Return(Monster1);
                Monster1 = Pools.MonstePool.Get();
                StartGame(Manager);
            }
        }

        public void Lose(string name, int health)
        {
            Manager.WinCount = 0;
            Console.Clear();
            Console.WriteLine("You lose");
            Console.WriteLine("The Monster has {0} health left.", health);
            Restart(name);
        }

        public void Win(string name, int health)
        {
            Manager.WinCount += 1;
            Console.SetCursorPosition(0, 17);
            Console.WriteLine("You win");
            Console.WriteLine("{0} have {1} health left .", name, health);
            Continue(name);
        }
    }
}
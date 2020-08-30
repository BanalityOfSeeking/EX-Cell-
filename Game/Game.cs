using System;
using System.Collections.Generic;
using static System.Console;

namespace EXCell
{
    public class Game
    {
        public Random GameRoller = new Random();
        private Player Player1 { get; set; }
        private Monster Monster1 { get; set; }
        private EquipmentRulesManager EquipMgr { get; set; }
        private PlayerItems PlayerEquips { get; set; }
        private GameManager Manager { get; set; }

        public Game()
        {
        }

        public Game ConfigPlayer(string player)
        {
            Player1 = new Player();
            Console.Write(Player1.DisplayUnit,
                Player1.Health.CurrentHealth.ToString(),
                Player1.CurrentXP.ToString(),
                Player1.Level.ToString(),
                Player1.Name,
                "0",
                "/", "|", @"\",
                "/", @"\");
            return this;
        }

        public Game ConfigureMonster(string monster)
        {
            Monster1 = new Monster();
            Monster1.Display2ndUnit();
            return this;
        }

        public Game ConfigureEquipement(IReadOnlyList<EquipId> equips = default)
        {
            if (equips == default)
            {
                EquipMgr = new EquipmentRulesManager();
            }
            else
            {
                EquipMgr = new EquipmentRulesManager();
                EquipMgr.LoadEquipmentProgressionList(equips);
            }
            return this;
        }

        public Game ConfigureInventory()
        {
            PlayerEquips = new PlayerItems(EquipMgr);
            return this;
        }

        public void StartGame(GameManager manager)
        {
            if (Player1 == default | Monster1 == null | EquipMgr == null | PlayerEquips == null)
            {
                WriteLine("Not Configured correctly");
                return;
            }
            Manager = manager;
            var pHealth = 100 + (Manager.WinCount * 10);
            var dHealth = 100 + (Manager.WinCount * 10);

            WriteLine("Welcome {0}!!", nameof(Player1));
            WriteLine("You {0} have {1} health", nameof(Player1), pHealth);
            WriteLine("The Monster has {0} health.", dHealth);
            if (Monster1.HasTreasure)
            {
                WriteLine("This Monster has treasure!");
            }
            WriteLine("Good luck {0}.", nameof(Player1));
            WriteLine("Press any key to continue ");
            ReadKey(false);

            while (pHealth > 0 && dHealth > 0)
            {
                var PlayerRoll = GameRoller.Next(10, 99);
                var DragonRoll = GameRoller.Next(10, 99);

                WriteLine("You have rolled {0}.", PlayerRoll);
                WriteLine("The dragon rolled {0}", DragonRoll);

                if (PlayerRoll > DragonRoll)
                {
                    dHealth -= 10 + PlayerEquips.TotalEnchantments;
                    if (dHealth > 0)
                    {
                        WriteLine("The dragon health left is {0}", dHealth);
                    }
                    else
                    {
                        if (Monster1.HasTreasure)
                        {
                            PlayerEquips.UpgradeItem(Monster1.TreasureCode);
                        }
                        Win(nameof(Player1), pHealth);
                    }
                }
                else
                {
                    pHealth -= 10;
                    if (pHealth > 0)
                    {
                        WriteLine("{0} have left {1} health", nameof(Player1), pHealth);
                    }
                    else
                    {
                        Lose(nameof(Player1), dHealth);
                    }
                }
                WriteLine("Press any key to continue ");
                ReadKey(false);
            }
        }

        public void Restart(string Name)
        {
            WriteLine("{0} died, do you want to start a new character? press y to continue or any key to exit", Name);
            var c = ReadKey(true).KeyChar;
            if (c == 'y')
            {
                Player1 = new Player();
                PlayerEquips = new PlayerItems(EquipMgr);
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
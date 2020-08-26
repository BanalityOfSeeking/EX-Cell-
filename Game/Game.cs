using System;
using System.Collections.Generic;
using static System.Console;

namespace EXCell
{
    public class Game
    {
        public Random GameRoller = new Random();
        private string Name { get; set; }
        private Player Player1 { get; set; }
        private Monster Monster { get; set; }
        private EquipmentRulesManager EquipMgr { get; set; }
        private PlayerItems PlayerEquips { get; set; }
        private GameManager Manager { get; set; }
        public Game()
        {
        }

        public Game Config(string name)
        {
            Name = name;
            return this;
        }
        public Game ConfigPlayer(string player)
        {
            Player1 = new Player();
            Player1 = Player1.SetPlayerName(player);
            return this;
        }
        public Game ConfigureMonster(string monster)
        {
            Monster = new Monster(monster, 100, GameRoller);
            return this;
        }
        public Game ConfigureEquipement(IReadOnlyList<EquipId> equips = default)
        {
            if(equips == default)
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
            if(Name == null | Player1 == null | Monster == null | EquipMgr == null | PlayerEquips == null)
            {
                WriteLine("Not Configured correctly");
                return;
            }
            Manager = manager;
            
            WriteLine("Welcome {0}!!", Player1.Name);
            WriteLine("You {0} have {1} health", Player1.Name, Player1.Health);
            WriteLine("The Monster has {0} health.", Monster.Health);
            if (Monster.HasTreasure)
            {
                WriteLine("This Monster has treasure!");
            }
            WriteLine("Good luck {0}.", Player1.Name);
            WriteLine("Press any key to continue ");
            ReadKey(false);

            var pHealth = Player1.Health + (Manager.WinCount * 10);
            var dHealth = Monster.Health + (Manager.WinCount * 10);

            while (pHealth > 0 && dHealth > 0)
            {
                var PlayerRoll = GameRoller.Next(10, 99);
                var DragonRoll = GameRoller.Next(10, 99);

                WriteLine("You have roll {0}.", PlayerRoll);
                WriteLine("The dragon roll {0}", DragonRoll);

                if (PlayerRoll > DragonRoll)
                {
                    dHealth -= 10 + PlayerEquips.TotalEnchantments;
                    if (dHealth > 0)
                    {
                        WriteLine("The dragon health left is {0}", dHealth);
                    }
                    else
                    {
                        if (Monster.HasTreasure)
                        {
                            PlayerEquips.UpgradeItem(Monster.TreasureCode);
                        }
                        Win(Player1.Name, pHealth);
                    }
                }
                else
                {
                    pHealth -= 10;
                    if (pHealth > 0)
                    {
                        WriteLine("{0} have left {1} health", Player1.Name, pHealth);
                    }
                    else
                    {
                        Lose(Player1.Name, dHealth);
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
                Player1 = new Player().SetPlayerName(ReadLine());
                Monster = new Monster("Monster", 100 + (Manager.WinCount * 10), GameRoller);
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
                Player1 = new Player().SetPlayerName(name);
                Monster = new Monster("Monster", 100, GameRoller);
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
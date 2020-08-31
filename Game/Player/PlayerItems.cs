using static System.Console;

namespace EXCell
{
    public class PlayerItems : IPlayerItems
    {
        public PlayerItems()
        {
            Hood = new Head();
            Armor = new Chest();
            Pads = new Arms();
            Guards = new Legs();
        }

        public Head Hood { get; internal set; }
        public Chest Armor { get; internal set; }
        public Arms Pads { get; internal set; }
        public Legs Guards { get; internal set; }

        public void UpgradeItem(int treasureCode)
        {
            switch (treasureCode)
            {
                case 0:
                    {
                        break;
                    }

                case 1:
                    {
                        Pads.ApplyRule();
                        WriteLine("Recieved {0} upgrade", Pads.Id.Name);
                        break;
                    }

                case 2:
                    {
                        Guards.ApplyRule();
                        WriteLine("Recieved {0} upgrade", Guards.Id.Name);
                        break;
                    }

                case 3:
                    {
                        Hood.ApplyRule();
                        WriteLine("Recieved {0} upgrade", Hood.Id.Name);
                        break;
                    }
                case 4:
                    {
                        Armor.ApplyRule();
                        WriteLine("Recieved {0} upgrade", Armor.Id.Name);
                        break;
                    }
            }
        }

        public int TotalEnchantments => Hood.Id.Enchantment + Armor.Id.Enchantment + Guards.Id.Enchantment + Pads.Id.Enchantment;
    }
}
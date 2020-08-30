using static System.Console;

namespace EXCell
{
    public class PlayerItems : IPlayerItems
    {
        public PlayerItems(EquipmentRulesManager ruler)
        {
            Hood = new Head(ruler);
            Armor = new Chest(ruler);
            Pads = new Arms(ruler);
            Guards = new Legs(ruler);
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
                        Pads.ProgressArms();
                        WriteLine("Recieved {0} upgrade", Pads.Id.Name);
                        break;
                    }

                case 2:
                    {
                        Guards.ProgressLegs();
                        WriteLine("Recieved {0} upgrade", Guards.Id.Name);
                        break;
                    }

                case 3:
                    {
                        Hood.ProgressHead();
                        WriteLine("Recieved {0} upgrade", Hood.Id.Name);
                        break;
                    }
                case 4:
                    {
                        Armor.ProgressChest();
                        WriteLine("Recieved {0} upgrade", Armor.Id.Name);
                        break;
                    }
            }
        }

        public int TotalEnchantments => Hood.Id.Enchantment + Armor.Id.Enchantment + Guards.Id.Enchantment + Pads.Id.Enchantment;
    }
}
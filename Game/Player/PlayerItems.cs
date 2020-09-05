using System;
namespace EXCell
{
    // need to cut scene for item upgrades
    // removed Console reference. (not updated).

    public struct Items 
    {

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
                        Pads.Id = Pads.Id.ApplyRule();
                        Console.WriteLine("Recieved {0} upgrade", Pads.Id);
                        break;
                    }

                case 2:
                    {
                        Guards.Id = Guards.Id.ApplyRule();
                        Console.WriteLine("Recieved {0} upgrade", Guards.Id);
                        break;
                    }

                case 3:
                    {
                        Hood.Id = Hood.Id.ApplyRule();
                        Console.WriteLine("Recieved {0} upgrade", Hood.Id);
                        break;
                    }
                case 4:
                    {
                        Armor.Id = Armor.Id.ApplyRule();
                        Console.WriteLine("Recieved {0} upgrade", Armor.Id);
                        break;
                    }
            }
        }

        public int TotalEnchantments => Hood.Id.Enchantment + Armor.Id.Enchantment + Guards.Id.Enchantment + Pads.Id.Enchantment;
    }
}
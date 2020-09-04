using System;
namespace EXCell
{
    // need to cut scene for item upgrades
    // removed Console reference. (not updated).

    public struct Items : IItems
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
                        Pads.Id = Pads.ApplyRule();
                        Console.WriteLine("Recieved {0} upgrade", Pads.Id.Name);
                        break;
                    }

                case 2:
                    {
                        Guards.Id = Guards.ApplyRule();
                        Console.WriteLine("Recieved {0} upgrade", Guards.Id.Name);
                        break;
                    }

                case 3:
                    {
                        Hood.Id = Hood.ApplyRule();
                        Console.WriteLine("Recieved {0} upgrade", Hood.Id.Name);
                        break;
                    }
                case 4:
                    {
                        Armor.Id = Armor.ApplyRule();
                        Console.WriteLine("Recieved {0} upgrade", Armor.Id.Name);
                        break;
                    }
            }
        }

        public int TotalEnchantments => Hood.Id.Enchantment + Armor.Id.Enchantment + Guards.Id.Enchantment + Pads.Id.Enchantment;
    }
}
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Game.Components
{
    public class BodyPartComponent : IEquipment, Item, IPartComponent
    {
        public int ComponentType { get; set; }
        public int Role { get; set; }
        public int Value { get; set; } = 0;
        public int Enchantment { get; set; } = 0;
        public char[] Item { get; set; } = new char[1];
    }
    public static class BodyPartExtensions
    {
        public static BodyPartComponent SetComponentType(this BodyPartComponent bpc, int componentType)
        {
            bpc.ComponentType = componentType;
            return bpc;
        }

        public static BodyPartComponent SetRole(this BodyPartComponent bpc, int Role)
        {
           //StarterPick //Head     Chest         Right / Left Arm                      Legs

            //1/ Warrior Helmet     Armor         Weapon /Shield or Weapon / Weapon     Leg Guards
            //2/ Mage    Hat        Robe          (Wand Scepter, Staff) / Book          Boots & Leggings
            //3/ Archer  Visor      Padding       Sling Bow, CrossBox                   Leather panths, padded shoes

            //4/ LowMonster low xp, low coin (3 - 13),  Common drops
            //5/ MidMonster mid xp, coin mid +( low * 2.5) coin,  Common + 1 Rare + 2
            //6/ BossMonster mid xp + low xp, high coin,  Common Rare + 2, Rare + 3

        }
    }
}

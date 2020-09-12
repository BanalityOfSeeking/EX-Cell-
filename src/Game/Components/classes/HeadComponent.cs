namespace Game.Components
{
    public class HeadLoader
    {
        PlayerBodyComponent Head = new PlayerBodyComponent()
        {
            ComponentId = (int)ComponentTypes.Head,
            Value = 0,
            Enchantment = 0
        };
        public HeadLoader()
        {
            Head.DisplayItem = I0;
        }
        public char I0 { get => nameof(I0)[1]; }
    }

    //StarterPick //Head     Chest         Right / Left Arm                      Legs

    //1/ Warrior Helmet     Armor         Weapon /Shield or Weapon / Weapon     Leg Guards
    //2/ Mage    Hat        Robe          (Wand Scepter, Staff) / Book          Boots & Leggings
    //3/ Archer  Visor      Padding       Sling Bow, CrossBox                   Leather panths, padded shoes

    //4/ LowMonster low xp, low coin (3 - 13),  Common drops
    //5/ MidMonster mid xp, coin mid +( low * 2.5) coin,  Common + 1 Rare + 2
    //6/ BossMonster mid xp + low xp, high coin,  Common Rare + 2, Rare + 3
}

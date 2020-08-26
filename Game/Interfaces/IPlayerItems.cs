namespace EXCell
{
    public interface IPlayerItems
    {
        Chest Armor { get; }
        Legs Guards { get; }
        Head Hood { get; }
        Arms Pads { get; }
        int TotalEnchantments { get; }

        void UpgradeItem(int treasureCode);
    }
}
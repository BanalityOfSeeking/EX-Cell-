namespace EXCell
{
    public class Chest : IEquipment, Item
    {
        public char ReplaceChar = '_';

        public EquipId Id { get; set; }
        public char Item { get => ReplaceChar; }
        public Chest()
        {

            Id = new EquipId(0, 0, EquipType.Armors);
            Id = EquipmentRulesManager.ApplyRule(Id);
        }
    }
}
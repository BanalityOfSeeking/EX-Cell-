namespace EXCell
{
    public class Chest : IEquipment, Item
    {
        public IEquipId Id { get; set; }
        public char Item => '_';
        public Chest()
        {

            Id = new EquipId("", 0, 0, EquipType.Armors);
            Id = EquipmentRulesManager.ApplyRule(this);
        }
    }
}
namespace EXCell
{
    public class Legs : IEquipment, ItemLeftRight
    {
        public IEquipId Id { get; set; }

        public string Input { get; set; } = @"/ \";

        public string Left() => Input.Split(" ")[0];
        public string Right() => Input.Split(" ")[1];

        public Legs()
        {
            Id = new EquipId("", 0, 0, EquipType.LegGuards);
            Id = EquipmentRulesManager.ApplyRule(this);
        }
    }
}
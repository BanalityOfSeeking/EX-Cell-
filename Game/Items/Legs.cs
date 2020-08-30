namespace EXCell
{
    public class Legs : Equipment
    {
        private EquipmentRulesManager EquipManager { get; }

        public Legs(EquipmentRulesManager ruler)
        {
            EquipManager = ruler;
            Id = new EquipId("", 0, 0, EquipType.LegGuards);
            Id = EquipManager.ApplyRule(Id);
        }

        public void ProgressLegs()
        {
            Id = Progress(EquipManager);
        }
    }
}
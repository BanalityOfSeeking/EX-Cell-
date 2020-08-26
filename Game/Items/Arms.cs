namespace EXCell
{
    public class Arms : Equipment
    {
        EquipmentRulesManager EquipManager { get; }
        public Arms(EquipmentRulesManager ruler)
        {
            EquipManager = ruler;
            Id = new EquipId("", 0, 0, EquipType.Weapons);
            Id = EquipManager.ApplyRule(Id);
        }
        public void ProgressArms()
        {
            Id = Progress(EquipManager);
        }
    }
}
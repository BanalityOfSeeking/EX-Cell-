namespace EXCell
{
    public class Chest : Equipment
    {
        private EquipmentRulesManager EquipManager { get; }

        public Chest(EquipmentRulesManager ruler)
        {
            EquipManager = ruler;
            Id = new EquipId("", 0, 0, EquipType.Armors);
            Id = EquipManager.ApplyRule(Id);
        }

        public void ProgressChest()
        {
            Id = Progress(EquipManager);
        }
    }
}
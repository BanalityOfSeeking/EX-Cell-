namespace EXCell
{
    public class Arms : IEquipment, IDisplayUnit
    {
        private EquipmentRulesManager EquipManager { get; }

        public IEquipId Id { get; set; }

        public string DisplayUnit { get; set; } = "/";

        public int Top { get; }

        public int Left { get; }

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

        public void Display2ndUnit()
        {
            throw new System.NotImplementedException();
        }
    }
}
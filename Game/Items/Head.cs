namespace EXCell
{
    public class Head : IEquipment, IDisplayUnit
    {
        private IEquipmentRulesManager EquipManager { get; }
        public IEquipId Id { get; set; }

        public string DisplayUnit { get; set; } = "0";

        public int Top { get; }

        public int Left { get; }

        public Head(IEquipmentRulesManager ruler)
        {
            EquipManager = ruler;
            Id = new EquipId("", 0, 0, EquipType.Helmets);
            ProgressHead();
        }

        public void ProgressHead() => Id = ((IEquipment)this).Progress(EquipManager);

        public void Display2ndUnit()
        {
            throw new System.NotImplementedException();
        }
    }
}

namespace EXCell
{
    public class Head : Equipment
    {
        EquipmentRulesManager EquipManager { get; }
        public Head(EquipmentRulesManager ruler)
        {
            EquipManager = ruler;
            Id = new EquipId("", 0, 0, EquipType.Helmets);
            Id = EquipManager.ApplyRule(Id);
        }
        public void ProgressHead()
        {
            Id = Progress(EquipManager);
        }
    }
}
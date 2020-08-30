namespace EXCell
{
    public interface IEquipment
    {
        public IEquipId Id { get; }

        public sealed IEquipId Progress(IEquipmentRulesManager equipRuler)
        {
            return equipRuler.ApplyRule(Id);
        }
    }
}
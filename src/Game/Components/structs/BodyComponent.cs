namespace Game.Components
{
    public class BodyComponent : IComponentType
    {
        public BaseBodyComponent BodyParts;
        public int Strength { get; internal set; }
        public int CarryWeight => (10 * Strength);
        public int Intelligence { get; internal set; }
        public int BaseMana => (10 * Intelligence);
        public int Constitution { get; internal set; }
        public int BaseHealth => 10 * Constitution;
        public int Dexterity { get; internal set; }
        public int BaseMovement => 1 + (int)(Dexterity * .1);
        public int BaseInitiative => (int)(Dexterity / 4);
        public int Charisma { get; internal set; }
        public int BaseMarketBenefit => (int)((Charisma * .3) * 10);
    }
}

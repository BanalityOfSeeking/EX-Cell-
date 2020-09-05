namespace EXCell
{
    public struct LevelableComponent : IComponentType
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }

        public int CurrentXP;
        public int Level;

        public LevelableComponent(int parentId, int childId, int currentXP, int level)
        {
            ParentId = parentId;
            ChildId = childId;
            CurrentXP = 0;
            Level = 0;
        }
    }
}
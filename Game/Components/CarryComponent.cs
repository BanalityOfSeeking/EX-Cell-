namespace EXCell
{
    public struct CarryComponent : ICarry
    {
        public bool Treasure { get; set; }

        public int ParentId { get; set; }
        public int ChildId { get; set; }
    }
}
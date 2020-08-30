namespace EXCell
{
    public interface IDisplayUnit
    {
        public string DisplayUnit { get; }

        public void Display2ndUnit();

        public int Top { get; }
        public int Left { get; }
    }
}
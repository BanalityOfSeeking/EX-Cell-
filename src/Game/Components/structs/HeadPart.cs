using System.Drawing;
namespace Game.Components
{
    public struct HeadPart : IEquipment
    {
        public int Value { get; set; }
        public int Enchantment { get; set; }
        public Point Location { get; set; }
        public Size Size { get; set; }
    }
}

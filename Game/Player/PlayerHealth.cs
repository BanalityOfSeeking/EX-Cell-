using System.Collections.Generic;

namespace EXCell
{
    // a slightly different implementation
    public class PlayerHealth<T> : IHealth where T : System.Enum
    {
        public int MaxHealth { get; set; } = 100;
        public int CurrentHealth { get; set; }
        public string Status { get; set; }
        public List<(string Health, IEnumerable<int> Range)> HealthRanges { get; } = HealthExetensions.InitHealthWithEnum<T>(9);
    }
}
using System.Collections.Generic;

namespace EXCell
{
    public interface IHealth : IAnimatedHealth
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public string Status { get; set; }
        public new List<(string Health, IEnumerable<int> Range)> HealthRanges { get; }
    }
}
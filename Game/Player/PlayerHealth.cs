using System.Collections.Generic;

namespace EXCell
{
    // a slightly different implementation
    public class PlayerHealth : IHealth
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; } = 100;
        public string Status { get; set; }
    }
}
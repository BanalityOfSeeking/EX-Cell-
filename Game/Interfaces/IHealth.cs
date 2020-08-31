using System.Collections.Generic;

namespace EXCell
{
    public interface IHealth
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public string Status { get; set; }
    }
}
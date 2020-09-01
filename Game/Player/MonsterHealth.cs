using System.Collections.Generic;

namespace EXCell
{
    // an implementation of IBaseEntity, IManagedHealth, IHealth, ICarry, IDrop
    public class MonsterHealth<T> : IHealth where T : System.Enum
    {
        public int MaxHealth { get; set; } 
        public int CurrentHealth { get; set; } = 100;
        public string Status { get; set; }
    }
}
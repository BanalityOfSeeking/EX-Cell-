using System;

namespace EXCell
{
    // interfaces for all implementations of health implementations must work within

    public interface IBaseEntity
    {
        public Guid GameId { get; }
        public string Name { get; }
    }
}
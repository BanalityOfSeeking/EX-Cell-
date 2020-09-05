using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace EXCell
{
    public interface LeftRight
    {
        public char Left();
        public char Right();
    }
    
    public interface Item
    {
        public char Item { get; }
    }

    public interface ItemLeftRight : LeftRight
    {
        ImmutableList<char> Input { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace Game.Components
{
    public interface LeftRight
    {
        public char Left();
        public char Right();
    }
    
    public interface Item
    {
        public char[] Item { get; set; }
    }

    public interface ItemLeftRight : LeftRight
    {
        List<char> Input { get; set; }
    }
}
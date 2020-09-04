using System;

namespace EXCell
{
    public interface LeftRight
    {
        public string Left();
        public string Right();
    }
    
    public interface Item
    {
        char Item { get; }
    }

    public interface ItemLeftRight : LeftRight
    {
        string Input { get; }
    }
}
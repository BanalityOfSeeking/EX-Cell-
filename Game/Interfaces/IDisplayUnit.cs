using System;
using System.Collections.Generic;

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
    public interface IDisplay
    {
        public List<string> Unit { get; }
        public int X { get; }
        public int Y { get; }
    }
    public interface IScene
    {
        public string SceneUnit { get; }
        public void DisplayScene();

    }
}
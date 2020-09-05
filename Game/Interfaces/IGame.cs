using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EXCell
{
    public interface IGame
    {
        public List<ComponentType> Components { get; }
        public void Start();
        public void Stop();
    }
}
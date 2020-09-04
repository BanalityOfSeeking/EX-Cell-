using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace EXCell
{

    public struct Game : IGame
    {
        public Random GameRoller { get; internal set; }

        private int WinCount { get; set; }

        public List<ComponentType> Components { get; internal set; }

        public void InitComponentList()
        {
            Components = new List<ComponentType>();
        }

        public Game(params string[] args)
        {
            GameRoller = new Random();
            WinCount = 0;
            Components = null;
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }
    }
    public static class GameExtensions //: IGameStateMonitor
    {
        public static void Restart(this Game game)
        {
            game.Stop();
            game.Start();
        }

        public static IEnumerable<ComponentType> DoUpdates(this List<ComponentType> components, object Value)
        {
            foreach(ComponentType ct in components.Where(x => x.NeedUpdate == true))
            {
                if(ct.UpdateComponents())
                {
                    yield return ct;
                }
            }
        }
    }
}
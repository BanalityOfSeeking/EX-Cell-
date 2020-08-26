using EXCell.ConfigurationStore;
using EXCell.DataStructure;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace EXCell
{
    internal static class Program
    { 
    static void Main(string[] args)
    {
        GameManager Manager = new GameManager();
        Game ThisGame = new Game()
            .Config("AltonKoh Game")
            .ConfigPlayer("Player1")
            .ConfigureMonster("Monster1")
            .ConfigureEquipement()
            .ConfigureInventory();
        Manager.Start(ThisGame);
    }
    }
}
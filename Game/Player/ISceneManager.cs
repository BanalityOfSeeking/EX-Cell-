using System;
using System.Collections.Generic;
using static System.Console;

namespace EXCell
{
    public interface ISceneManager
    {
        void DiplayScene(Player player, Monster monster);
        
    }
    public static class SceneManager
    {
        public static string SceneUnit =
            @"\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/" + "\n" +
            @"                                      " + "\n" +
            @"                                      " + "\n" +
            @"                                      " + "\n" +
            @"                                      " + "\n" +
            @"                                      " + "\n" +
            @"                                      " + "\n" +
            @"    {3}            " + "\n" +
            @"--------{4}------    {10}" + "\n" +
            @"       {5}{6}{7}         {11}" + "\n" +
            @"  | | ({8}_{9})        {12}" + "\n" +
            @"                      " + "\n" +
            @"|=====================================" + "\n" +
            @"| Health:{0}  XP:{1}                  " + "\n" +
            @"| Level {2}                           " + "\n" +
            @"|=====================================";

        public static void DisplayScene(this Game game)
        {
            object obj = new object();
            lock (obj)
            {
                Write(SceneUnit,
              game.Player1.Health.CurrentHealth,//0
              game.Player1.CurrentXP,//1
              game.Player1.Level,//2
              game.Player1.Name,//3
              game.Player1.Items.Hood.Item,//4
              game.Player1.Items.Pads.Left(),//5
              game.Player1.Items.Armor.Item,//6
              game.Player1.Items.Pads.Right(),//7
              game.Player1.Items.Guards.Left(),//8
              game.Player1.Items.Guards.Right(),//9
              game.Monster1.Unit[0],
              game.Monster1.Unit[1],
              game.Monster1.Unit[2]);
            }
        }
    }
}
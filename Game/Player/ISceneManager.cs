using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;

namespace EXCell
{
    public interface ISceneManager
    {
        void DiplayScene(Player player, Monster monster);
        
    }
    public static class SceneManager
    {
        public static string MonsterScene =
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


        public static string TextScene =
            @"        {0}                           " + "\n" +
            @"        {1}{2}                           " + "\n" +
            @"        {3}                           " + "\n" +
            @"        {4}{5}                           " + "\n" +
            @"        {6}{7}                           " + "\n" +
            @"        {8}                           " + "\n" +
            @"        {9}                           " + "\n" +
            @"        {10}                           " + "\n" +
            @"                                      " + "\n";

        // opening scene
        public static List<string> TextList1 = new List<string>()
        {
            "Welcome, enter your Name Challenger!!",
     
            "You are now Knight your health is: ",
            "The Monster's health is: ",

            "This Monster has treasure!",
            "Good luck"
        };

        public static int MainSceneCount = 0;
        public static void DisplayScene(this Game game, SceneType type)
        {
            switch (type)
            {
                case SceneType.MonsterScene:
                    Console.SetCursorPosition(0, 0);
                    Write(MonsterScene,
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
                    break;
                case SceneType.PlayerSetup:
                    Write(TextScene,
                          TextList1[0],
                          "",
                          "",
                          "",
                          "",
                          "",
                          "",
                          "",
                          "",
                          "",
                          "");
                    game.Player1.Name = ReadLine();
                    Clear();
                                    //0  1             2                                  3   4             5                                   6   7  8                                              9             10
                    Write(TextScene,
                          "",
                          TextList1[1],
                          game.Player1.Health.CurrentHealth,
                          "",
                          TextList1[2],
                          game.Monster1.Health.CurrentHealth,
                          "",
                          "",
                          game.Monster1.HasTreasure ? TextList1[3] : "",
                          TextList1[4],
                          game.Player1.Name);
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    
                    Console.Clear();
                    break;
            }
        }
    }
}
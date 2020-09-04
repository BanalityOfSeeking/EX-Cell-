using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Console;

namespace EXCell
{
    public interface ISceneManager
    {
        void DiplayPlayerScene(ComponentType player,  ComponentType monster, SceneType scene);
        void DiplayMovementScene(ComponentType player, ComponentType closestEvnironmentComponent);
    }

    public static class SceneManager
    {
        
        public static string MonsterScene =
            @"\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/" + "\n" +
            @"                                        " + "\n" +
            @"                                        " + "\n" +
            @"                                        " + "\n" +
            @"                                        " + "\n" +
            @"                                        " + "\n" +
            @"                                        " + "\n" +
            @"    {3}            " + "\n" +
            @"--------{4}------    {10}" + "\n" +
            @"       {5}{6}{7}         {11}" + "\n" +
            @"  | | ({8}_{9})        {12}" + "\n" +
            @"                      " + "\n" +
            @"|========================================" + "\n" +
            @"| Health:{0} XP:{1}| Monster Health:{13} " + "\n" +
            @"| Level {2}        |                     " + "\n" +
            @"|========================================";


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
        public static void DisplayScene(this ComponentType Player1, ComponentType Monster1, SceneType type)
        {
            switch (type)
            {
                case SceneType.MonsterScene:
                    Console.SetCursorPosition(0, 0);
                    WriteLine(MonsterScene,
                         Player1.Health.CurrentHealth,//0
                         Player1.Level?.CurrentXP ?? 0,//1
                         Player1.Level?.Level ?? 1,//2
                         Player1.EntityId.Name,//3
                         Player1.Items?.Hood.Item,//4
                         Player1.Items?.Pads?.Left(),//5
                         Player1.Items?.Armor.Item,//6
                         Player1.Items?.Pads.Right(),//7
                         Player1.Items?.Guards.Left(),//8
                         Player1.Items?.Guards.Right(),//9
                         Monster1.Unit.Unit[0],
                         Monster1.Unit.Unit[1],
                         Monster1.Unit.Unit[2],
                         Monster1.Health.CurrentHealth);
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
                    Console.CursorLeft = TextList1[0].Length + 10;
                    Console.CursorTop = 0;
                    Clear();
                                    //0  1             2                                  3   4             5                                   6   7  8                                              9             10
                    Write(TextScene,
                          "",
                          TextList1[1],
                          Player1.Health.CurrentHealth,
                          "",
                          TextList1[2],
                          Monster1.Health.CurrentHealth,
                          "",
                          "",
                          Monster1.Items.HasValue ? TextList1[3] : "",
                          TextList1[4],
                          Player1.EntityId.Name);
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    
                    Console.Clear();
                    break;
            }
        }
    }
}
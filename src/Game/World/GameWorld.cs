using System;
using System.Collections.Generic;
using System.Text;
namespace Game.World
{
    class GameWorld
    {
        public static GameWorld Default = new GameWorld(10);
        
        public int IncompleteStages { get; set; }
        protected GameWorld(int stages)
        {
            IncompleteStages = stages;
            WorldGrid = new int[stages][,];

        }
        int[][,] WorldGrid { get; }
        
        public Stage CurrentStage { get; set; }
        
        public Stage DistributeStage()
        {
            if (IncompleteStages > 0)
            {
                IncompleteStages -= 1;
                WorldGrid[0] = new int[40, 20];
                CurrentStage = Stage.Default.InitStage(WorldGrid[0]);
                return CurrentStage;
            }
            return CurrentStage;
        }
    }
    internal class Stage
    {
        public static Stage Default = new Stage();

        protected static int[,] StageGrid { get; set; }
        
        protected Stage(int [,] gridPart)
        {
            StageGrid = gridPart;
            //SceneHandler = new MapHandler(40, 20, StageGrid, 40);
            CurrentScene = new Scene();
        }
        protected Stage()
        {
        }
        public Stage InitStage(int[,] gridPart) => new Stage(gridPart);

        public Scene CurrentScene { get; internal set; }

        // private MapHandler SceneHandler { get; }

    }
    class Scene
    {
        //public MapHandler CurrentMap { get; }
        public Scene()//MapHandler map)
        {
            //CurrentMap = map;
            //CurrentMap.RandomFillMap();
            
        }
	}
}

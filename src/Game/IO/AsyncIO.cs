using System;
using static System.Console;
using System.Drawing;
using System.Threading.Tasks;
using Game.World;
using System.Threading;
using System.IO;

namespace Game
{
    /// Status : not done.
    /// Iterations 1.
    /// Description:
    /// Class to handle IO Movement of monsters and players.
    /// 
    class IOParams
    {
        int updateCount { get; set; }
        int fromBottom { get; set; }
        int fromLeft { get; set; }
    }
    public class AsyncIO
    {
        public AsyncIO()
        {   
        }
        
        //private async Task<Rectangle> Update(object Area)
        //{

        //}
        //private async Task<Rectangle> MoveRightAsync(Rectangle gameArea)
        //{ 
        //}
        //private async Task<Rectangle> MoveLeftAsync(Rectangle rectangle)
        //{
        //}
    }
}


using Game.Components;
using System;

namespace Game.Components.classes
{
    public class LeftRightLoader
    {
        public PlayerBodyComponent[] Left0Right1 = new PlayerBodyComponent[2]
        {
            new PlayerBodyComponent() { ComponentId = (int)ComponentTypes.LeftArm,  Value = 0, Enchantment = 0 },
            new PlayerBodyComponent() { ComponentId = (int)ComponentTypes.RightArm,  Value = 0, Enchantment = 0}
        };
       
        public LeftRightLoader()
        {
            Console.OpenStandardError(1024);
            Console.OpenStandardInput(1024);
            Left0Right1[0].DisplayItem = '/';
            Left0Right1[1].DisplayItem = '\\';
        }
    }
}

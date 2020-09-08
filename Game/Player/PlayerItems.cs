using System;
namespace Game.Components
{

    public interface ITextBodyTemplate
    { 
        public char Head { get; set; }
        public char Chest { get; set; }
        public char LeftArm { get; set; }
        public char RightArm { get; set; }
        public char LeftLeg { get; set; }
        public char RightLeg { get; set; }
        public string[] DisplayPart { get; set; }
    }
    public class TextBodyTemplate : ITextBodyTemplate
    {
        ComponentManager ComponentManager { get; }
        public TextBodyTemplate(ComponentManager componentManager)
        {
            ComponentManager = componentManager;
        }
        public void SetupBodyTemplate(char head, char chest, char leftArm, char rightArm, char leftLeg, char rightLeg, string[] displayPart)
        {
            Head = head;
            Chest = chest;
            LeftArm = leftArm;
            RightArm = rightArm;
            LeftLeg = leftLeg;
            RightLeg = rightLeg;
            DisplayPart = displayPart;
        }

        public char Head { get; set; }
        public char Chest { get; set; }
        public char LeftArm { get; set; }
        public char RightArm { get; set; }
        public char LeftLeg { get; set; }
        public char RightLeg { get; set; }
        public string[] DisplayPart { get; set; }
    }
}
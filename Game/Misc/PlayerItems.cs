using System;
namespace Game.Components
{

    public interface ITextBodyTemplate
    { 
        public char CHead { get; set; }
        public char CChest { get; set; }
        public char CLeftArm { get; set; }
        public char CRightArm { get; set; }
        public char CLeftLeg { get; set; }
        public char CRightLeg { get; set; }
        public string[] DisplayPart { get; set; }
    }
    public class TextBodyTemplate : ITextBodyTemplate
    {
        public TextBodyTemplate()
        {
        }
        public void SetupBodyTemplate(char head, char chest, char leftArm, char rightArm, char leftLeg, char rightLeg, string[] displayPart)
        {
            CHead = head;
            CChest = chest;
            CLeftArm = leftArm;
            CRightArm = rightArm;
            CLeftLeg = leftLeg;
            CRightLeg = rightLeg;
            DisplayPart = displayPart;
        }

        public char CHead { get; set; }
        public char CChest { get; set; }
        public char CLeftArm { get; set; }
        public char CRightArm { get; set; }
        public char CLeftLeg { get; set; }
        public char CRightLeg { get; set; }
        public string[] DisplayPart { get; set; }
    }
}
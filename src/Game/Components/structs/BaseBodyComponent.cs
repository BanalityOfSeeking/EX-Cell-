namespace Game.Components
{
    public struct BaseBodyComponent
    {

        internal HeadPart Head { get; set; }
        internal TorsoPart Torso;
        internal ArmPart LeftArm;
        internal ArmPart RightArm;
        internal LegPart LeftLeg;
        internal LegPart RighLeg;
    }
}

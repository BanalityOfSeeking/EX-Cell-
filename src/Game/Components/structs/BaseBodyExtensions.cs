
using System;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Game.Components
{
    public static class BodyComponentExtensions
    {

        public static BodyComponent StrengthInit(this BodyComponent component, int strength)
        {
            component.Strength = strength;
            return component;
        }

        public static BodyComponent IntelligenceInit(this BodyComponent  component, int intelligence)
        {
            component.Intelligence = intelligence;
            return component;
        }

        public static BodyComponent ConstitutionInit(this BodyComponent component, int constitution)
        {
            component.Constitution = constitution;
            return component;
        }

        public static BodyComponent DexterityInit(this BodyComponent component, int dexterity)
        {
            component.Dexterity = dexterity;
            return component;
        }

        public static BodyComponent CharismaInit(this BodyComponent component, int charisma)
        {
            component.Charisma = charisma;
            return component;
        }
    }
    public static class BaseBodyComponentExtensions
    {
        public static void Config(this ref BaseBodyComponent baseBody, int x = 0, int y = 0)
        {
            if (baseBody.Head.Size.Width == 0)
            {
                baseBody.Head = new HeadPart { Value = 0, Enchantment = 0, Location = new Point(x,y), Size = new Size(10, 10) };
                baseBody.Torso = new TorsoPart
                {
                    Value = baseBody.Torso.Value,
                    Enchantment = baseBody.Torso.Enchantment,
                    Start = new Point(baseBody.Head.Location.X, baseBody.Head.Location.Y + baseBody.Head.Size.Height / 2),
                };
                baseBody.LeftArm = new ArmPart
                {
                    Value = baseBody.LeftArm.Value,
                    Enchantment = baseBody.LeftArm.Enchantment,
                    Start = new Point(baseBody.Head.Location.X, baseBody.Head.Location.Y + baseBody.Head.Size.Height / 2 + baseBody.Head.Size.Width / 4),

                };
                baseBody.RightArm = new ArmPart
                {
                    Value = baseBody.LeftArm.Value,
                    Enchantment = baseBody.LeftArm.Enchantment,
                    Start = new Point(baseBody.Head.Location.X, baseBody.Head.Location.Y + (baseBody.Head.Size.Height / 2 + baseBody.Head.Size.Width / 4)),
                };
                baseBody.LeftLeg = new LegPart { Value = 0, Enchantment = 0, Start = Point.Add(baseBody.Head.Location, new Size(0, baseBody.Head.Size.Width * 2)) };
                baseBody.RighLeg = new LegPart { Value = 0, Enchantment = 0, Start = Point.Add(baseBody.Head.Location, new Size(0, baseBody.Head.Size.Width * 2)) };
            }
            else
            {
                var Head = baseBody.Head;
                Head.Location = new Point(x, y);
                baseBody.Head = Head;
                baseBody.Torso.Start = new Point(x, y + Head.Size.Height / 2);
                baseBody.Torso.End = new Point(x, y + Head.Size.Height * 2);
                baseBody.LeftArm.Start = new Point(x, y + Head.Size.Height / 2 + Head.Size.Width / 4);
                baseBody.LeftArm.End = new Point(x - Head.Size.Width, y + Head.Size.Width);
                baseBody.RightArm.Start = new Point(x, y + (Head.Size.Height / 2 + Head.Size.Width / 4));
                baseBody.RightArm.End = new Point(x + Head.Size.Width, y + Head.Size.Height);
            }   
        }
    }
}

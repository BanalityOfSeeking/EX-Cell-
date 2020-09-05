using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EXCell
{
    public static class PartStore
    {
        public static List<char> LeftArms = new List<char>();
        public static List<char> RightArms = new List<char>();
        public static List<char> Heads = new List<char>();

        public static void InitPartStore()
        {
            //8
            LeftArms.Add('!');
            LeftArms.Add('/');
            LeftArms.Add('(');
            LeftArms.Add('1');
            LeftArms.Add('<');
            LeftArms.Add('Y');
            LeftArms.Add('[');
            LeftArms.Add('{');

            //8
            RightArms.Add('!');
            RightArms.Add('\\');
            RightArms.Add(')');
            RightArms.Add('1');
            RightArms.Add('>');
            RightArms.Add('Y');
            RightArms.Add(']');
            RightArms.Add('}');

            //8
            Heads.Add('X');
            Heads.Add('U');
            Heads.Add('0');
            Heads.Add('o');
            Heads.Add('D');
            Heads.Add('B');
            Heads.Add('X');
            Heads.Add('X');

        }
    }


    public class Arms : IEquipment, ItemLeftRight
    {
        public Arms(EquipId id, int parentId, int childId)
        {
            Id = id;
            ParentId = parentId;
            ChildId = childId;
        }


        public EquipId Id { get; set; }

        internal ImmutableList<char> input1 => @"/\".ToImmutableList();
        public ImmutableList<char> Input { get => ic2.Count > 0 ? ic2 : input1; set => ic2 = value; }
        internal ImmutableList<char> ic2 { get; set; }
        public int ParentId { get; set; }
        public int ChildId { get; set; }

        public char Left() => Input?[0] ?? input1[0];
        public char Right() => Input?[1] ?? input1[1];

    }
    public static class ArmsExtensions
    {
        public static void ChanceIC2(this Arms arms, ImmutableList<char> chars)
        {
            arms.ic2 = chars;
        }
        public static void UpdateEquipment(this Arms arms)
        {
            arms.Id = new EquipId(0, 0, EquipType.Weapons);
            arms.Id = EquipmentRulesManager.ApplyRule(arms.Id);
        }
    }
}
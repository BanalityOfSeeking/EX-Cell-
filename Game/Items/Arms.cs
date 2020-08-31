using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EXCell
{
    public class PartStore
    {
        public List<string> LeftArms = new List<string>();
        public List<string> RightArms = new List<string>();
        public List<string> Heads = new List<string>();
        
        public PartStore()
        {
            //8
            LeftArms.Add("!");
            LeftArms.Add("/");
            LeftArms.Add("(");
            LeftArms.Add("1");
            LeftArms.Add("<");
            LeftArms.Add("Y");
            LeftArms.Add("[");
            LeftArms.Add("{");
            
            //8
            RightArms.Add("!");
            RightArms.Add(@"\");
            RightArms.Add(")");
            RightArms.Add("1");
            RightArms.Add(">");
            RightArms.Add("Y");
            RightArms.Add("]");
            RightArms.Add("}");

            //8
            Heads.Add("X");
            Heads.Add("U");
            Heads.Add("0");
            Heads.Add("o");
            Heads.Add("D");
            Heads.Add("[o0]");
            Heads.Add("X");
            Heads.Add("X");

        }
    }


    public class Arms : IEquipment, ItemLeftRight
    {
        public IEquipId Id { get; set; }

        public string Input { get; set; } = @"/ \";
        public string Left() => Input.Split(" ")[0];
        public string Right() => Input.Split(" ")[1];

        public Arms()
        {
            Id = new EquipId("", 0, 0, EquipType.Weapons);
            Id = EquipmentRulesManager.ApplyRule(this);
        }
    }
}
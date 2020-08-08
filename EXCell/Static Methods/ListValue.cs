using System;
using System.Collections.Generic;

namespace EXCell.DataStructure
{
    public static class ListValue
    {
        public static (List<string> codes, List<string> descriptions) List(this Param param)
        {
            var Codes = new List<string>();
            var Descriptions = new List<string>();
            foreach (string s in param.Options as List<string>)
            {
                var Split = s.Split(new string[] { " -- " }, StringSplitOptions.None);
                if (Split.Length > 0)
                {
                    Codes.Add(Split[0]);
                    Descriptions.Add(Split[1]);
                }
            }
            return (Codes, Descriptions);
        }
    }
}
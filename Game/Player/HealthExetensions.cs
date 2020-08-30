using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EXCell
{
    public static class HealthExetensions
    {
        public static List<(string Health, IEnumerable<int> Range)> InitHealthWithEnum<T>(int modifier) where T : System.Enum
        {
            List<(string Health, IEnumerable<int> Range)> HealthRanges = new List<(string Health, IEnumerable<int> Range)>();
            string[] names = Enum.GetNames(typeof(T));
            int Id = 0;
            foreach (int value in Enum.GetValues(typeof(T)).Cast<int>())
            {
                var highValue = value + modifier;
                var thisRange = Enumerable.Range(value, highValue);
                HealthRanges.Add((names[Id], thisRange));
                Id++;
            }
            return HealthRanges;
        }

        public static string GetHealthDescriptor(this IHealth health, int i)
        {
            if (health.HealthRanges.Max(x => x.Range.Max()) > i)
            {
                return "Alive and well";
            }
            else if (i < 0)
            {
                return "You Dead.";
            }
            else
            {
                return health.HealthRanges
                    .OrderByDescending(x => x.Range.First())
                    .First(x => x.Range.Contains(i))
                    .Health;
            }
        }
    }
}
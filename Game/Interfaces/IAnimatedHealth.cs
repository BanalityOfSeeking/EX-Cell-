using System.Collections.Generic;

namespace EXCell
{
    public interface IAnimatedHealth
    {
        public List<(string Health, IEnumerable<int> Range)> HealthRanges { get; }

        public sealed void InitHealthEnum<T>(int modifier = 0) where T : System.Enum
            => HealthExetensions.InitHealthWithEnum<T>(modifier);
    }
}
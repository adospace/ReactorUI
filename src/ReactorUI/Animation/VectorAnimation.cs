using ReactorUI.Primitives;
using System;

namespace ReactorUI.Animation
{
    public class VectorAnimation : Animation
    {
        public Vector? From { get; }
        public Vector To { get; }

        public VectorAnimation(Vector from, Vector to, int duration, Func<double, double> easingFunction, bool reverse = false, bool loop = false, bool keepTargetValue = true)
            : base(duration, easingFunction, reverse, loop, keepTargetValue)
        {
            From = from;
            To = to;
        }

        public VectorAnimation(Vector to, int duration, Func<double, double> easingFunction, bool reverse = false, bool loop = false, bool keepTargetValue = true)
            : base(duration, easingFunction, reverse, loop, keepTargetValue)
        {
            To = to;
        }
    }
}

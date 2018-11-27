using ReactorUI.Contracts;
using System;

namespace ReactorUI.Animation
{
    public class DoubleAnimation : Animation, IAnimation<double>
    {
        public double From { get; }
        public double To { get; }

        public DoubleAnimation(double from, double to, int duration, Func<double, double> easingFunction, bool reverse = false, bool loop = false, bool keepTargetValue = false)
            :base(duration, easingFunction, reverse, loop, keepTargetValue)
        {
            From = from;
            To = to;
        }

        public double GetValueAtOffset(double offset)
        {
            return From + (To - From) * EasingFunction(offset);
        }
    }
}

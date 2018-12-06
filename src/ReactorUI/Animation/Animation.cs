using ReactorUI.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Animation
{
    public abstract class Animation : IAnimation
    {
        public Func<double, double> EasingFunction { get; }

        public int Duration { get; }

        public bool Reverse { get; }

        public bool Loop { get; }

        public bool KeepTargetValue { get; }

        public Animation(int duration, Func<double, double> easingFunction, bool reverse = false, bool loop = false, bool keepTargetValue = true)
        {
            if (duration < 0) throw new ArgumentException("can't be less than or equal to zero", "duration");

            Duration = duration;
            EasingFunction = easingFunction ?? throw new ArgumentNullException(nameof(easingFunction));
            Reverse = reverse;
            Loop = loop;
            KeepTargetValue = keepTargetValue;
        }
    }
}

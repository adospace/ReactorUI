using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface IAnimation
    {
        Func<double, double> EasingFunction { get; }

        int Duration { get; }

        bool Reverse { get; }

        bool Loop { get; }

        bool KeepTargetValue { get; }
    }

    public interface IAnimation<T>
    {
        T From { get; }

        T To { get; }

        T GetValueAtOffset(double v);
    }
}

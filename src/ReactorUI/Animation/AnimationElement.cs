using ReactorUI.Contracts;
using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ReactorUI.Animation
{
    internal class AnimationElement 
    {
        public IUIElement Element { get; }
        public string PropertyName { get; }
        public IAnimation Animation { get; }

        public AnimationElement(IUIElement element, string propertyName, IAnimation animation)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("can't be empty or null", nameof(propertyName));
            }

            Element = element ?? throw new ArgumentNullException(nameof(element));
            PropertyName = propertyName;
            Animation = animation ?? throw new ArgumentNullException(nameof(animation));
        }

        private readonly Stopwatch _runningStopwatch = Stopwatch.StartNew();
        private bool _reverseDirection = false;
        private bool _completed = false;

        public bool Tick<T>(Action<T> applyValueAction)
        {
            if (applyValueAction == null)
            {
                throw new ArgumentNullException(nameof(applyValueAction));
            }

            var animationT = (IAnimation<T>)Animation;
            if (animationT == null)
                throw new InvalidOperationException();

            if (_completed)
            {
                if (!Animation.KeepTargetValue)
                    return false;

                if (_reverseDirection)
                    applyValueAction(animationT.From);
                else
                    applyValueAction(animationT.To);

                return true;
            }

            double offset = _runningStopwatch.ElapsedMilliseconds / (double)Animation.Duration;

            if (offset >= 1.0)
            {
                offset = offset % 1.0;

                if (Animation.Reverse)
                {
                    _reverseDirection = true;
                }
                else if (Animation.Loop)
                {
                    _reverseDirection = !_reverseDirection;
                }
                else
                {
                    applyValueAction(animationT.To);

                    if (!Animation.KeepTargetValue)
                        _runningStopwatch.Stop();

                    _completed = true;
                }
            }
            else if (DoubleUtil.IsLessOrClose(offset, 1.0))
                applyValueAction(animationT.To);
            else if (DoubleUtil.IsGreaterOrClose(offset, 0.0))
                applyValueAction(animationT.From);
            else
            {
                applyValueAction(
                    animationT.GetValueAtOffset(_reverseDirection ? 1.0 - offset : offset));
            }

            return true;
        }
    }
}

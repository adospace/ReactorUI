using ReactorUI.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ReactorUI.Animation
{
    internal class OpacityAnimationActuator : IAnimationActuator<IUIElement>
    {
        private readonly DoubleAnimation _doubleAnimation;
        public IAnimation Animation => _doubleAnimation;

        public OpacityAnimationActuator(DoubleAnimation animation)
        {
            _doubleAnimation = animation ?? throw new ArgumentNullException(nameof(animation));
        }


        private readonly Stopwatch _runningStopwatch = Stopwatch.StartNew();
        private bool _reverseDirection = false;
        private bool _completed = false;
        private bool _initialValueSet = false;
        private double _from;

        public bool Tick(IUIElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (!_initialValueSet)
            {
                _initialValueSet = true;
                _from = _doubleAnimation.From ?? element.Opacity;
                Debug.WriteLine("_initialValueSet -> {0}", element.Opacity);
            }

            if (_completed)
            {
                if (!Animation.KeepTargetValue)
                    return false;

                if (_reverseDirection)
                    element.Opacity = _from;
                else
                    element.Opacity = _doubleAnimation.To;

                Debug.WriteLine("Element.Opacity -> {0}", element.Opacity);
                return true;
            }

            double offset = _runningStopwatch.ElapsedMilliseconds / (double)Animation.Duration;
            double from = !_reverseDirection ? _from : _doubleAnimation.To;
            double to = !_reverseDirection ? _doubleAnimation.To : _from;

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
                    element.Opacity = to;

                    if (!Animation.KeepTargetValue)
                        _runningStopwatch.Stop();

                    _completed = true;
                }
            }
            else if (DoubleUtil.IsLessOrClose(offset, 1.0))
                element.Opacity = to;
            else if (DoubleUtil.IsGreaterOrClose(offset, 0.0))
                element.Opacity = from;
            else
            {
                element.Opacity = from + (to - from) * _doubleAnimation.EasingFunction(offset);
                Debug.WriteLine("Element.Opacity -> {0}", element.Opacity);
            }

            return true;
        }
    }
}

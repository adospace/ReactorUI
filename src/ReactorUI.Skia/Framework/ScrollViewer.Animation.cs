using ReactorUI.Animation;
using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    public partial class ScrollViewer
    {
        private class OffsetAnimationActuator
        {
            private readonly IScrollableUIElement _scrollableUIElement;
            private readonly VectorAnimation _doubleAnimation;
            public IAnimation Animation => _doubleAnimation;

            public OffsetAnimationActuator(IScrollableUIElement scrollableUIElement, VectorAnimation animation)
            {
                _scrollableUIElement = scrollableUIElement;
                _doubleAnimation = animation ?? throw new ArgumentNullException(nameof(animation));
            }


            private readonly Stopwatch _runningStopwatch = Stopwatch.StartNew();
            private bool _reverseDirection = false;
            private bool _completed = false;
            private bool _initialValueSet = false;
            private Vector _from;

            public bool Tick()
            {
                if (!_initialValueSet)
                {
                    _initialValueSet = true;
                    _from = _doubleAnimation.From ?? default;
                    //Debug.WriteLine("_initialValueSet -> {0}", _from);
                }

                if (_completed)
                {
                    if (!Animation.KeepTargetValue)
                        return false;

                    if (_reverseDirection)
                        _scrollableUIElement.Offset += _from;
                    else
                        _scrollableUIElement.Offset += _doubleAnimation.To;

                    //Debug.WriteLine("Element.Offset -> {0}", _scrollableUIElement.Offset);
                    return true;
                }

                double offset = _runningStopwatch.ElapsedMilliseconds / (double)Animation.Duration;
                var from = !_reverseDirection ? _from : _doubleAnimation.To;
                var to = !_reverseDirection ? _doubleAnimation.To : _from;

                if (offset >= 1.0)
                {
                    offset %= 1.0;

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
                        _scrollableUIElement.Offset += to;

                        if (!Animation.KeepTargetValue)
                            _runningStopwatch.Stop();

                        _completed = true;
                    }
                }
                else if (DoubleUtil.IsLessOrClose(offset, 1.0))
                    _scrollableUIElement.Offset += to;
                else if (DoubleUtil.IsGreaterOrClose(offset, 0.0))
                    _scrollableUIElement.Offset += from;
                else
                {
                    _scrollableUIElement.Offset += from + (to - from) * _doubleAnimation.EasingFunction(offset);
                    //Debug.WriteLine("Element.Offset -> {0}", _scrollableUIElement.Offset);
                }

                return true;
            }
        }

    }
}

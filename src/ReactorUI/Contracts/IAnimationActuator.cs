using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface IAnimationActuator
    {
        IAnimation Animation { get; }

        bool Tick(IUIElement element);
    }

    public interface IAnimationActuator<T> : IAnimationActuator where T : IUIElement
    {
        bool Tick(T element);
    }
}

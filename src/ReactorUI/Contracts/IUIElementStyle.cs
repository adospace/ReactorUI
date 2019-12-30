using ReactorUI.Primitives;
using System;

namespace ReactorUI.Contracts
{
    public interface IUIElementStyle<T> : IStyle<T> where T : IUIElement
    {
        Action<T> OnMouseEnterAction { get; set; }
        Action<T> OnMouseLeaveAction { get; set; }
        Action<T> OnMouseDownAction { get; set; }
        Action<T> OnMouseUpAction { get; set; }

        double Opacity { get; set; }
        Transform Transform { get; set; }
    }
}

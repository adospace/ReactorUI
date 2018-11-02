using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface IUIElement
    {
        bool IsEnabled { get; set; }
        bool IsHitTestVisible { get; set; }
        bool IsVisible { get; set; }
        double Opacity { get; set; }

        LinkedList<Action<IUIElement>> OnMouseEnterActions { get; }
        LinkedList<Action<IUIElement>> OnMouseLeaveActions { get; }

    }
}

using ReactorUI.Widgets.Contracts;
using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Contracts
{
    public class FrameworkElementStyle<T> : UIElementStyle<T> where T : IFrameworkElement
    {
        Thickness Margin { get; set; }
    }
}

using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Styles
{
    public class FrameworkElementStyle<T> : UIElementStyle<T> where T : IFrameworkElement
    {
        Thickness Margin { get; set; }
    }
}

using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class FrameworkElement<T> : UIElement<T>, IFrameworkElement where T : class, IFrameworkElement
    {
    }
}

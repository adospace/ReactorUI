using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI
{
    public interface IApplication
    {
        Component Root { get; }

        WidgetRegistry WidgetRegistry { get; }

        void Run();
    }
}

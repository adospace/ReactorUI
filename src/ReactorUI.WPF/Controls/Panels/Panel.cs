using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;

namespace ReactorUI.WPF.Controls.Panels
{
    internal abstract class Panel<T, I, TS> : FrameworkElement<T, I, TS>, INativeControlContainer
        where T : System.Windows.Controls.Panel, new()
        where I : IPanel
        where TS : PanelStyle<I>
    {
        protected Panel()
        {
        }


        public void AddChild(object child)
        {
            _nativeControl.Children.Add((UIElement)child);
        }

        public void RemoveChild(object child)
        {
            _nativeControl.Children.Remove((UIElement)child);
        }

    }
}

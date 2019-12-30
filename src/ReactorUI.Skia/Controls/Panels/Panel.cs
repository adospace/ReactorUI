using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ReactorUI.Widgets;
using ReactorUI.Contracts;
using ReactorUI.Styles;
using ReactorUI.Skia.Framework;
using ReactorUI.Contracts.Panels;
using ReactorUI.Styles.Panels;

namespace ReactorUI.Skia.Controls.Panels
{
    public abstract class Panel<T, I> : FrameworkElement<T, I>, INativeControlContainer
        where T : Framework.Panels.Panel, new()
        where I : IPanel
    {
        protected Panel()
        {
        }

        public abstract void AddChild(IWidget widget, UIElement child);

        public abstract void RemoveChild(IWidget widget, UIElement child);

    }
}

using ReactorUI.Widgets;
using ReactorUI.WPF.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    public class Component : INativeControl, INativeControlContainer
    {
        private System.Windows.Controls.ContentControl _container;

        public Component()
        {
        }

        public void AddChild(object child)
        {
            _container.Content = child;
        }

        public void RemoveChild(object child)
        {
            _container.Content = null;
        }

        protected IWidget _widget;
        public void DidMount(IWidget widget)
        {
            _container = new System.Windows.Controls.ContentControl();

            _widget = widget;

            widget.ParentAsNativeControlContainer().AddChild(_container);
        }

        public void WillUnmount(IWidget widget)
        {
            widget.ParentAsNativeControlContainer().RemoveChild(_container);
        }

        public void Update(IWidget widget)
        {
            _widget = widget;
        }
    }
}

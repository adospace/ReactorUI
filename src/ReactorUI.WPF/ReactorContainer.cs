using ReactorUI.Widgets;
using ReactorUI.WPF.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace ReactorUI.WPF
{
    public abstract class ReactorContainer<T> : Widget, INativeControl, INativeControlContainer where T : System.Windows.Controls.ContentControl
    {
        public ReactorContainer(T container)
        {
            Container = container ?? throw new ArgumentNullException(nameof(container));
            NativeControl = this;
        }

        public T Container { get; }

        protected sealed override IEnumerable<VisualNode> RenderChildren()
        {
            yield return Render();
        }

        protected abstract VisualNode Render();

        public ReactorContainer<T> Run()
        {
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            return this;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            new VisualTree(this).Layout();
        }

        public ReactorContainer<T> Stop()
        {
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
            return this;
        }

        public void AddChild(FrameworkElement child)
        {
            Container.Content = child;
        }

        public void InsertChild(FrameworkElement child, int index)
        {
            Container.Content = child;
        }

        public void RemoveChild(FrameworkElement child)
        {
            Container.Content = null;
        }

        public void DidMount(IWidget widget)
        {
        }

        public void WillUnmount(IWidget widget)
        {
        }
    }
}

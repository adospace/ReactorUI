using ReactorUI.Contracts;
using ReactorUI.Skia.Controls;
using ReactorUI.Widgets;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReactorUI.Skia.WinForms
{
    public abstract class ReactorContainer<T> : Widget, INativeControl, INativeControlContainer, IWidgetContainer where T : System.Windows.Forms.Control
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

        System.Windows.Forms.Timer _timerRenderer;
        public ReactorContainer<T> Run()
        {
            _timerRenderer = new System.Windows.Forms.Timer();
            _timerRenderer.Interval = 16;
            _timerRenderer.Tick += _timerRenderer_Tick;
            _timerRenderer.Start();
            return this;
        }

        private void _root_LayoutUpdated(object sender, Framework.InvalidatedEventArgs e)
        {
            _skiaView.Invalidate();
        }

        private void _timerRenderer_Tick(object sender, EventArgs e)
        {
            new VisualTree(this).Layout();
        }

        public ReactorContainer<T> Stop()
        {
            _timerRenderer.Stop();
            _timerRenderer.Tick -= _timerRenderer_Tick;
            _timerRenderer.Dispose();
            _timerRenderer = null;
            return this;
        }

        SkiaSharp.Views.Desktop.SKGLControl _skiaView;
        Framework.UIElement _root;
        public void AddChild(IWidget widget, Framework.UIElement child)
        {
            _skiaView = new SkiaSharp.Views.Desktop.SKGLControl();
            this._skiaView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._skiaView.PaintSurface += _skiaView_PaintSurface;
            this._skiaView.MouseMove += _skiaView_MouseMove;
            Container.Controls.Add(_skiaView);

            _root = child;
            _root.Invalidated += _root_LayoutUpdated;

            _skiaView.Invalidate();
        }

        private void _skiaView_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _root.HitTest(e.X, e.Y);
        }

        private void _skiaView_PaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
        {
            _root.Measure(new Primitives.Size(Container.ClientSize.Width, Container.ClientSize.Height));

            _root.Arrange(new Primitives.Rect(0, 0, Container.ClientSize.Width, Container.ClientSize.Height));

            _root.Render(e.Surface.Canvas);
        }

        public void RemoveChild(IWidget widget, Framework.UIElement child)
        {
            this._skiaView.PaintSurface -= _skiaView_PaintSurface;

            Container.Controls.Remove(_skiaView);

            this._skiaView.Dispose();
            this._skiaView = null;

            _root.Invalidated -= _root_LayoutUpdated;
            _root = null;
        }

        public void DidMount(IWidget widget)
        {
        }

        public void WillUnmount(IWidget widget)
        {

        }

        public void Update(IWidget widget)
        {

        }

        
    }
}

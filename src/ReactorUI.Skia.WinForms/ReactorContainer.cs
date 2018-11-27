using ReactorUI.Contracts;
using ReactorUI.Primitives;
using ReactorUI.Skia.Controls;
using ReactorUI.Skia.Framework;
using ReactorUI.Widgets;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
            _timerRenderer = new System.Windows.Forms.Timer
            {
                Interval = 16
            };
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
            this._skiaView.MouseDown += _skiaView_MouseDown;
            this._skiaView.MouseUp += _skiaView_MouseUp;

            Container.Controls.Add(_skiaView);

            _root = child;
            _root.Invalidated += _root_LayoutUpdated;

            _skiaView.Invalidate();
        }

        Framework.UIElement _capturedMouseEvents = null;
        private void _skiaView_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _capturedMouseEvents = null;
            var context = new Framework.Input.MouseEventsContext((Framework.Input.MouseButtons)e.Button, e.Clicks, e.Delta);
            _root.HandleMouseDown(e.X, e.Y, context);
            _capturedMouseEvents = context.CaptureTo;
        }

        private void _skiaView_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var context = new Framework.Input.MouseEventsContext((Framework.Input.MouseButtons)e.Button, e.Clicks, e.Delta)
            {
                CaptureTo = _capturedMouseEvents
            };

            if (_capturedMouseEvents != null)
            {
                _capturedMouseEvents.HandleMouseMove(e.X, e.Y, context);
            }
            else
            {
                _root.HandleMouseMove(e.X, e.Y, context);
            }

            _capturedMouseEvents = context.CaptureTo;
        }

        private void _skiaView_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var context = new Framework.Input.MouseEventsContext((Framework.Input.MouseButtons)e.Button, e.Clicks, e.Delta)
            {
                CaptureTo = _capturedMouseEvents
            };

            if (_capturedMouseEvents != null)
            {
                _capturedMouseEvents.HandleMouseUp(e.X, e.Y, context);
                _capturedMouseEvents = null;
            }
            else
            {
                _root.HandleMouseUp(e.X, e.Y, new Framework.Input.MouseEventsContext((Framework.Input.MouseButtons)e.Button, e.Clicks, e.Delta));
            }
        }

        private void _skiaView_PaintSurface(object sender, SKPaintGLSurfaceEventArgs e)
        {
            Stopwatch renderStopWatch = null;
            if (RenderOptions.ShowClipRects)
            {
                renderStopWatch = Stopwatch.StartNew();
            }

            e.Surface.Canvas.Clear(new SKColor(Container.BackColor.R, Container.BackColor.G, Container.BackColor.B, Container.BackColor.A));

            _root.Measure(new Primitives.Size(Container.ClientSize.Width, Container.ClientSize.Height));

            _root.Arrange(new Primitives.Rect(0, 0, Container.ClientSize.Width, Container.ClientSize.Height));

            _root.Render(e.Surface.Canvas);

            if (renderStopWatch != null)
            {
                renderStopWatch.Stop();
                using (var ptRect = new SkiaSharp.SKPaint()
                    .ApplyBrush(new SolidColorBrush(new Color(0, 0, 0))))
                using (var ptText = new SkiaSharp.SKPaint()
                    .ApplyBrush(new SolidColorBrush(new Color(255, 255, 255))))
                {
                    e.Surface.Canvas.DrawRect(Container.ClientSize.Width - 50.0f, 0.0f, 100.0f, 10.0f, ptRect);
                    var elapsedString = renderStopWatch.ElapsedMilliseconds == 0 ? "-" : $"{(1.0 / renderStopWatch.ElapsedMilliseconds * 1000).ToString("##.00", CultureInfo.InvariantCulture)}FPS";
                    e.Surface.Canvas.DrawText(elapsedString, new SKPoint(Container.ClientSize.Width - 50.0f, 10.0f), ptText);
                }
                renderStopWatch.Reset();
            }
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

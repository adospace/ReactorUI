using ReactorUI.Contracts;
using ReactorUI.Primitives;
using ReactorUI.Skia.Controls;
using ReactorUI.Skia.Framework;
using ReactorUI.Widgets;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xamarin.Forms;

namespace ReactorUI.Skia.Xamarin
{
    public abstract class ReactorContainer<T> : Widget, INativeControl, INativeControlContainer, IWidgetContainer where T : ContentPage
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
            Device.StartTimer(TimeSpan.FromMilliseconds(16), () =>
            {
                new VisualTree(this).Layout();

                return true; // True = Repeat again, False = Stop the timer
            });

            return this;
        }

        private void _root_LayoutUpdated(object sender, Framework.InvalidatedEventArgs e)
        {
            _skiaView.InvalidateSurface();
        }


        SKCanvasView _skiaView;
        Framework.UIElement _root;
        public void AddChild(IWidget widget, Framework.UIElement child)
        {
            _skiaView = new SKCanvasView()
            {
                EnableTouchEvents = true
            };
            //this._skiaView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._skiaView.PaintSurface += _skiaView_PaintSurface;
            this._skiaView.Touch += _skiaView_Touch;

            Vapolia.Lib.Ui.Gesture.SetTapCommand2(_skiaView, 
                new Command<global::Xamarin.Forms.Point>(OnTap));

            Container.Content = _skiaView;

            _root = child;
            _root.Invalidated += _root_LayoutUpdated;

            _skiaView.InvalidateSurface();
        }

        Framework.UIElement _capturedMouseEvents = null;

        private void OnTap(global::Xamarin.Forms.Point location)
        { 
        
        }


        private void _skiaView_Touch(object sender, SKTouchEventArgs e)
        {
            var scaleDpi = new Primitives.Point(_skiaView.CanvasSize.Width / _skiaView.Width, _skiaView.CanvasSize.Height / _skiaView.Height);

            var location = new Primitives.Point(e.Location.X / scaleDpi.X, e.Location.Y / scaleDpi.Y);

            if (e.ActionType == SKTouchAction.Pressed)
            {
                _capturedMouseEvents = null;
                var context = new Framework.Input.MouseEventsContext((Framework.Input.MouseButtons)e.MouseButton, 1, e.WheelDelta);
                _root.HandleMouseMove(location.X, location.Y, context);
                _root.HandleMouseDown(location.X, location.Y, context);
                _root.HandleMouseUp(location.X, location.Y, context);
                _capturedMouseEvents = context.CaptureTo;
            }
            else if (e.ActionType == SKTouchAction.Moved)
            {
                var context = new Framework.Input.MouseEventsContext((Framework.Input.MouseButtons)e.MouseButton, 1, e.WheelDelta)
                {
                    CaptureTo = _capturedMouseEvents
                };

                if (_capturedMouseEvents != null)
                {
                    _capturedMouseEvents.HandleMouseMove(location.X, location.Y, context);
                }
                else
                {
                    _root.HandleMouseMove(location.X, location.Y, context);
                }

                _capturedMouseEvents = context.CaptureTo;
            }
            else if (e.ActionType == SKTouchAction.Released)
            {
                var context = new Framework.Input.MouseEventsContext((Framework.Input.MouseButtons)e.MouseButton, 1, e.WheelDelta)
                {
                    CaptureTo = _capturedMouseEvents
                };

                if (_capturedMouseEvents != null)
                {
                    _capturedMouseEvents.HandleMouseUp(location.X, location.Y, context);
                    _capturedMouseEvents = null;
                }
                else
                {
                    _root.HandleMouseUp(location.X, location.Y, new Framework.Input.MouseEventsContext((Framework.Input.MouseButtons)e.MouseButton, 1, e.WheelDelta));
                }
            }
        }

        private void _skiaView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            Stopwatch renderStopWatch = null;
            if (RenderOptions.ShowFrameRate)
            {
                renderStopWatch = Stopwatch.StartNew();
            }

            //e.Surface.Canvas.Clear(new SKColor(Container.BackgroundColor.R, Container.BackgroundColor.G, Container.BackgroundColor.B, Container.BackgroundColor.A));
            e.Surface.Canvas.Clear(SKColors.White);

            using (new SKAutoCanvasRestore(e.Surface.Canvas))
            {
                var deviceSize = new Primitives.Size(e.Info.Width, e.Info.Height);
                var deviceIndSize = new Primitives.Size(_skiaView.Width, _skiaView.Height);
                var scaleDpi = new Primitives.Point(e.Info.Width / _skiaView.Width, e.Info.Height / _skiaView.Height);

                e.Surface.Canvas.Scale((float)scaleDpi.X, (float)scaleDpi.Y);

                _root.Measure(deviceIndSize);

                _root.Arrange(new Primitives.Rect(0, 0, deviceIndSize.Width, deviceIndSize.Height));

                _root.Render(e.Surface.Canvas);
            }

            if (renderStopWatch != null)
            {
                renderStopWatch.Stop();
                using (var ptRect = new SkiaSharp.SKPaint()
                    .ApplyBrush(new SolidColorBrush(new Primitives.Color(0, 0, 0))))
                using (var ptText = new SkiaSharp.SKPaint()
                    .ApplyBrush(new SolidColorBrush(new Primitives.Color(255, 255, 255))))
                {
                    e.Surface.Canvas.DrawRect(e.Info.Width - 50.0f, 0.0f, 100.0f, 10.0f, ptRect);
                    var elapsedString = renderStopWatch.ElapsedMilliseconds == 0 ? "-" : $"{(1.0 / renderStopWatch.ElapsedMilliseconds * 1000).ToString("##.00", CultureInfo.InvariantCulture)}FPS";
                    e.Surface.Canvas.DrawText(elapsedString, new SKPoint(e.Info.Width - 50.0f, 10.0f), ptText);
                }
                renderStopWatch.Reset();
            }
        }

        public void RemoveChild(IWidget widget, Framework.UIElement child)
        {
            this._skiaView.PaintSurface -= _skiaView_PaintSurface;

            Container.Content = null;

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

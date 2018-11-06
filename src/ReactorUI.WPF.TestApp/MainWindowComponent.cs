using ReactorUI.Widgets;
using ReactorUI.Widgets.Panels;
using ReactorUI.Primitives;
using System;

namespace ReactorUI.WPF.TestApp
{
    public class MainWindowComponent : ReactorContainer<System.Windows.Window>
    {
        public MainWindowComponent(System.Windows.Window window) : base(window)
        {
        }

        private int _counter;

        private void OnButtonClicked()
        {
            _counter--;
            this.Invalidate();
        }

        protected override VisualNode Render()
        {
            return
                new Border(Component.Host<TimerComponent>()
                            .Foreground(new SolidColorBrush(Color.FromRGB(255, 255, 255)))
                            .Background(new SolidColorBrush(Color.FromRGB(200, 10, 200)))
                            .VerticalAlignment(VerticalAlignment.Bottom)
                            .HorizontalAlignment(HorizontalAlignment.Left))
                    .Margin(100)
                    .Background(new SolidColorBrush(Color.FromRGB(255, 0, 0)))
                    .OnMouseEnter(_ => _.Background = new SolidColorBrush(Color.FromRGB(0, 255, 0)))
                    .OnMouseLeave(_ => _.Background = new SolidColorBrush(Color.FromRGB(0, 0, 255)))
                    ;
        }
    }
}

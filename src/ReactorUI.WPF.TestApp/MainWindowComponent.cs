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
                new Border(
                    new StackPanel(
                        new Button(_counter.ToString())
                            .OnClick(OnButtonClicked)
                            .Padding(5)
                            .Style(Styles.CustomButtonStyle),
                        Component.Host<TimerComponent>()))
                    .VerticalAlignment(VerticalAlignment.Center)
                    .HorizontalAlignment(HorizontalAlignment.Center);
        }
    }
}

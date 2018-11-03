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
                Component.Host<CounterComponent>()
                    .VerticalAlignment(VerticalAlignment.Center)
                    .HorizontalAlignment(HorizontalAlignment.Center);
        }
    }
}

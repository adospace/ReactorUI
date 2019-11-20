using ReactorUI.Widgets;
using ReactorUI.Widgets.Panels;
using ReactorUI.Primitives;
using System;

namespace ReactorUI.WPF.TestApp
{
    public class MainWindowComponent : Component
    {
        public MainWindowComponent()
        {
        }

        private int _counter;

        private void OnButtonClicked()
        {
            _counter--;
            this.Invalidate();
        }

        public override VisualNode Render()
        {
            return
                new Button("Click Me!");
        }
    }
}

using ReactorUI.Widgets;
using ReactorUI.Widgets.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.TestApp
{
    class CounterComponent : Component
    {
        int _counter = 0;

        public override VisualNode Render()
        {
            return new StackPanel(
                new TextBlock(_counter.ToString())
                    .Margin(4),
                new Button("+")
                    .Margin(0,4,4,4)
                    .Style(Styles.CustomButtonStyle)
                    .OnClick(OnIncrement),
                new Button("-")
                    .Margin(0, 4, 4, 4)
                    .Style(Styles.CustomButtonStyle)
                    .OnClick(OnDecrement));
        }

        private void OnDecrement()
        {
            _counter--;
            Invalidate();
        }

        private void OnIncrement()
        {
            _counter++;
            Invalidate();
        }
    }
}

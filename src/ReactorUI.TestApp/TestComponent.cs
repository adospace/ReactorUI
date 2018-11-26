using ReactorUI.Primitives;
using ReactorUI.Widgets;
using System;

namespace ReactorUI.TestApp
{
    public class TestComponent : Component
    {
        public override VisualNode Render()
        {
            return
                new TextBlock("Hello World>")
                    .Foreground(new SolidColorBrush(Color.FromRGB(255,255,255)))
                    ;
        }
    }

}

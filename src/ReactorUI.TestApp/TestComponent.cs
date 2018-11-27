using ReactorUI.Primitives;
using ReactorUI.Widgets;
using ReactorUI.Widgets.Panels;
using System;
using static ReactorUI.TestApp.TestComponent;

namespace ReactorUI.TestApp
{
    public class TestComponent : Component<TestState>
    {
        public class TestState
        {
            public int Counter { get; set; }
        }

        public override VisualNode Render(TestState state)
        {
            return
                new StackPanel(
                    new TextBlock($"Counter: {state.Counter}")
                        .Foreground(new SolidColorBrush(Color.FromRGB(0, 0, 0)))
                        .Margin(4.0),
                    new Button("Click Here!!!")
                        .Margin(4.0)
                        .Padding(4.0)
                        .Background(new SolidColorBrush(new Color(100, 100, 100)))
                        .OnClick(() => this.SetState(_ => _.Counter-=100))
                        )
                        .Orientation(Orientation.Vertical)
                        .VerticalAlignment(VerticalAlignment.Center)
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        ;
        }
    }

}

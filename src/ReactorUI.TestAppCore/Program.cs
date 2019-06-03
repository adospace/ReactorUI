using ReactorUI.Primitives;
using ReactorUI.Widgets;
using ReactorUI.Widgets.Panels;
using System;

namespace ReactorUI.TestAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class TestComponent : Component<TestComponent.TestState>
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
                        .HitTestVisible(true)
                        .Margin(14.0)
                        //.Transform(new Transform().ScaleWidthHeight(2.0, 2.0))
                        //.OnMouseEnter(_ => _.Transform(new Transform().ScaleWidth(2.0)))
                        //.OnMouseLeave(_ => _.Transform(new Transform().ScaleWidth(1.0)))
                        ,
                    new Button("Click Here!!!")
                        .Opacity(0.5)
                        //.OnMouseEnter(_ => _.AnimateOpacity(1.0, 400, Easing.Linear).Transform(new Transform().ScaleWidth(1.5)))
                        //.OnMouseLeave(_ => _.AnimateOpacity(0.5, 400, Easing.Linear).Transform(new Transform().ScaleWidth(1.0)))
                        .Margin(14.0)
                        .Padding(20.0)
                        .IsVisible(true)
                        .Background(new SolidColorBrush(new Color(100, 100, 100)))
                        .OnClick(() => this.SetState(_ => _.Counter += 10))
                        )
                    .Orientation(Orientation.Vertical)
                    .VerticalAlignment(VerticalAlignment.Center)
                    .HorizontalAlignment(HorizontalAlignment.Center)
                    ;
        }
    }

}

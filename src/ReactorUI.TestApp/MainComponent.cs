using ReactorUI.Animation;
using ReactorUI.Primitives;
using ReactorUI.Widgets;
using ReactorUI.Widgets.Panels;
using System;

namespace ReactorUI.TestApp
{
    public class MainComponentState
    {
        public int Counter { get; set; }
    }

    public class MainComponent : Component<MainComponentState>
    {
        public override VisualNode Render(MainComponentState state) 
            => new Border(
                new ContainerPanel(
                    new TextBlock($"You have pressed the button {state.Counter} times")
                        .VerticalAlignment(VerticalAlignment.Center)
                        .HorizontalAlignment(HorizontalAlignment.Center)
                        .FontSize(14.0),
                    new Button("Click Here!")
                        .VerticalAlignment(VerticalAlignment.Bottom)
                        .HorizontalAlignment(HorizontalAlignment.Right)
                        .Margin(10.0)
                        .FontSize(14.0)
                        .OnClick(() => SetState(s => s.Counter++)))
                )
                .Background(new SolidColorBrush(255, 255, 255));


        //public override VisualNode Render(MainComponentState state)
        //{
        //    return
        //        new StackPanel(
        //            new TextBlock($"Counter: {state.Counter}")
        //                .Foreground(new SolidColorBrush(0, 0, 0))
        //                .HitTestVisible(true)
        //                .Margin(14.0)
        //                //.Transform(new Transform().ScaleWidthHeight(2.0, 2.0))
        //                //.OnMouseEnter(_ => _.Transform(new Transform().ScaleWidth(2.0)))
        //                //.OnMouseLeave(_ => _.Transform(new Transform().ScaleWidth(1.0)))
        //                ,
        //            new Button("Click Here!!!")
        //                //.Opacity(0.5)
        //                //.OnMouseEnter(_ => _.AnimateOpacity(1.0, 400, Easing.Linear).Transform(new Transform().ScaleWidth(1.5)))
        //                //.OnMouseLeave(_ => _.AnimateOpacity(0.5, 400, Easing.Linear).Transform(new Transform().ScaleWidth(1.0)))
        //                .OnMouseEnter(_ => _.Background(new SolidColorBrush(100, 100, 100)).Foreground(new SolidColorBrush(255,255,255)))
        //                .OnMouseLeave(_ => _.Background = new SolidColorBrush(200, 0, 0))
        //                .Margin(14.0)
        //                .Padding(20.0)
        //                .IsVisible(true)
        //                .Background(new SolidColorBrush(new Color(200, 200, 200)))
        //                .OnClick(() => this.SetState(_ => _.Counter -= 10000000))
        //                )
        //            .Orientation(Orientation.Vertical)
        //            .VerticalAlignment(VerticalAlignment.Center)
        //            .HorizontalAlignment(HorizontalAlignment.Center)
        //            ;
        //}
    }

}

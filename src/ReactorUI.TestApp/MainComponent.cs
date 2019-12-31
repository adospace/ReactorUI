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
    }

}

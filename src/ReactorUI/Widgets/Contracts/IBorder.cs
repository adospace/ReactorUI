using ReactorUI.Widgets.Primitives;

namespace ReactorUI.Widgets.Contracts
{
    public interface IBorder : IFrameworkElement
    {
        Thickness BorderThickness { get; set; }
        Thickness Padding { get; set; }
        CornerRadius CornerRadius { get; set; }
        Brush BorderBrush { get; set; }
        Brush Background { get; set; }
    }
}

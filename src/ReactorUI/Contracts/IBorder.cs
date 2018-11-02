using ReactorUI.Primitives;

namespace ReactorUI.Contracts
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

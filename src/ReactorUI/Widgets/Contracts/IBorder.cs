using ReactorUI.Widgets.Primitives;

namespace ReactorUI.Widgets.Contracts
{
    public interface IBorder
    {
        Brush Background { get; set; }
        VisualNode Child { get; set; }
    }
}

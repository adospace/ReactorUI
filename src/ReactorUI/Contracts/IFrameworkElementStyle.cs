using ReactorUI.Primitives;

namespace ReactorUI.Contracts
{
    public interface IFrameworkElementStyle<T> : IUIElementStyle<T> where T : IFrameworkElement
    {
        double Height { get; set; }
        HorizontalAlignment HorizontalAlignment { get; set; }
        Thickness Margin { get; set; }
        double MaxHeight { get; set; }
        double MaxWidth { get; set; }
        double MinHeight { get; set; }
        double MinWidth { get; set; }
        VerticalAlignment VerticalAlignment { get; set; }
        double Width { get; set; }
    }
}

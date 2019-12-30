using ReactorUI.Primitives;

namespace ReactorUI.Contracts
{
    public interface IControlStyle<T>  : IFrameworkElementStyle<T> where T : IControl
    {
        Brush Background { get; set; }
        Brush BorderBrush { get; set; }
        Thickness BorderThickness { get; set; }
        string FontFamily { get; set; }
        double FontSize { get; set; }
        FontStretch FontStretch { get; set; }
        FontStyle FontStyle { get; set; }
        FontWeight FontWeight { get; set; }
        Brush Foreground { get; set; }
        HorizontalAlignment HorizontalContentAlignment { get; set; }
        Thickness Padding { get; set; }
        VerticalAlignment VerticalContentAlignment { get; set; }
    }
}

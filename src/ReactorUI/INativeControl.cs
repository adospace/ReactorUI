using ReactorUI.Widgets;

namespace ReactorUI
{
    public interface INativeControl
    {
        void DidMount(IWidget widget);

        void WillUnmount(IWidget widget);
    }

    public interface INativeControl<T> : INativeControl
    {
        void Update(T widget);
    }
}

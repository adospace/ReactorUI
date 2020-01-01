using ReactorUI.Contracts;
using ReactorUI.Widgets;

namespace ReactorUI
{
    public interface INativeControl
    {
        void DidMount(IWidget widget);

        void WillUnmount(IWidget widget);

        void Update(IWidget widget);
        void Animate();
    }

}

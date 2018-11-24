using ReactorUI.Widgets;
using ReactorUI.Widgets.Panels;
using ReactorUI.Primitives;
using System;
using ReactorUI.Skia.WinForms;

namespace ReactorUI.Skia.WinFormsTestApp
{
    public class MainWindowComponent : Component
    {
        public MainWindowComponent()
        {
        }

        private int _counter;

        private void OnButtonClicked()
        {
            _counter--;
            this.Invalidate();
        }

        public override VisualNode Render()
        {
            return
                new ScrollBar()
                    .Orientation(Orientation.Vertical)
                    .Width(10)
                    .HorizontalAlignment(HorizontalAlignment.Center)
                    .Background(100,100,100)
                    .ThumbBrush(new Color(200,200,200))
                    .Extent(100)
                    .Viewport(10)
                    ;
        }
    }
}

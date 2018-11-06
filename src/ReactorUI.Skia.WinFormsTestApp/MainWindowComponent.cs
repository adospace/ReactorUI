using ReactorUI.Widgets;
using ReactorUI.Widgets.Panels;
using ReactorUI.Primitives;
using System;
using ReactorUI.Skia.WinForms;

namespace ReactorUI.Skia.WinFormsTestApp
{
    public class MainWindowComponent : ReactorContainer<System.Windows.Forms.Form>
    {
        public MainWindowComponent(System.Windows.Forms.Form window) : base(window)
        {
        }

        private int _counter;

        private void OnButtonClicked()
        {
            _counter--;
            this.Invalidate();
        }

        protected override VisualNode Render()
        {
            return
                new Border(new TextBlock(DateTime.Now.ToString())
                            .Foreground(new SolidColorBrush(Color.FromRGB(255,255,255))))
                    .Width(100)
                    .Height(100)
                    .VerticalAlignment(VerticalAlignment.Center)
                    .HorizontalAlignment(HorizontalAlignment.Center)
                    .Background(new SolidColorBrush(Color.FromRGB(255, 0, 0)));
        }
    }
}

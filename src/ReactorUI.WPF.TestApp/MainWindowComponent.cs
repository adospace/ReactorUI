using ReactorUI.Widgets;
using ReactorUI.Widgets.Panels;
using ReactorUI.Widgets.Primitives;
using System;

namespace ReactorUI.WPF.TestApp
{
    public class MainWindowComponent : ReactorContainer<System.Windows.Window>
    {
        public MainWindowComponent() : base(new System.Windows.Window())
        {
            //System.Threading.Timer timer = new System.Threading.Timer(new System.Threading.TimerCallback(_ => this.Invalidate()));
            //timer.Change(0, 1000);
        }

        private int _counter;

        private void OnButtonClicked()
        {
            _counter--;
            this.Invalidate();
        }



        protected override VisualNode Render()
        {
            return new Border(
                new Button(_counter.ToString())
                    .OnClick(OnButtonClicked)
                    .Padding(5)
                    //.Background(new SolidColorBrush(Color.FromRGB(255, 0, 0)))
                    .Style(Styles.CustomButtonStyle)
                    )
                .VerticalAlignment(VerticalAlignment.Center)
                .HorizontalAlignment(HorizontalAlignment.Center);
        }
    }
}

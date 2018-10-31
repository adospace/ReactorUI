using ReactorUI.Widgets;
using ReactorUI.Widgets.Primitives;
using System;
using System.Windows;

namespace ReactorUI.WPF.TestApp
{
    public class MainWindowComponent : ReactorContainer<System.Windows.Window>
    {
        public MainWindowComponent() : base(new System.Windows.Window())
        {
            System.Threading.Timer timer = new System.Threading.Timer(new System.Threading.TimerCallback(_ => this.Invalidate()));
            timer.Change(0, 1000);
        }


        private void OnButtonClicked()
        {
            MessageBox.Show("Clicked!");
        }

        protected override VisualNode Render()
        {
            return this.TextBlock("test");
        }
    }
}

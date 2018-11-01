using ReactorUI.Widgets;
using ReactorUI.Widgets.Primitives;
using System;

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
            System.Windows.MessageBox.Show("Clicked!");
        }

        protected override VisualNode Render()
        {
            return this.TreeView(
                new TreeViewNode("Node1", DateTime.Now.Second % 2 == 0 ? new TreeViewNode("Node1_1") : null, new TreeViewNode("Node1_2")).IsExpanded(true),
                new TreeViewNode("Node2"),
                new TreeViewNode("Node3", "pack://application:,,/Images/FieldPrivate_16x.png")

                );
            
        }
    }
}

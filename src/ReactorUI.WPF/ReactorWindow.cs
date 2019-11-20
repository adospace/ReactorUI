using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF
{
    public class ReactorWindow : ReactorContainer<System.Windows.Window>
    {
        public ComponentHost RootHost { get; }

        public ReactorWindow(Component root)
            : this(root, new System.Windows.Window())
        {
        }

        public ReactorWindow(Component root, System.Windows.Window window)
            : base(window)
        {
            RootHost = Component.Host(root ?? throw new ArgumentNullException(nameof(root)));
        }

        public ReactorWindow(ComponentHost componentHost, System.Windows.Window window)
            : base(window)
        {
            RootHost = componentHost ?? throw new ArgumentNullException(nameof(componentHost));
        }

        protected override VisualNode Render()
        {
            return RootHost;
        }
    }
}

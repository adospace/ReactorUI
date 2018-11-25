using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.Skia.WinForms
{
    public class ReactorForm : ReactorContainer<System.Windows.Forms.Form>
    {
        public ComponentHost RootHost { get; }

        public ReactorForm(Component root)
            : this(root, new System.Windows.Forms.Form())
        {
        }

        public ReactorForm(Component root, System.Windows.Forms.Form form)
            : base(form)
        {
            RootHost = Component.Host(root ?? throw new ArgumentNullException(nameof(root)));
        }

        public ReactorForm(ComponentHost componentHost, System.Windows.Forms.Form form)
            : base(form)
        {
            RootHost = componentHost ?? throw new ArgumentNullException(nameof(componentHost));
        }

        protected override VisualNode Render()
        {
            return RootHost;
        }
    }
}

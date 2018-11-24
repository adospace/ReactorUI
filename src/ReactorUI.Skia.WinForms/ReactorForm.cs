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
        public Component Root { get; }

        public ReactorForm(Component root)
            :base(new System.Windows.Forms.Form())
        {
            Root = root ?? throw new ArgumentNullException(nameof(root));
        }

        protected override VisualNode Render()
        {
            return Component.Host(Root);
        }
    }
}

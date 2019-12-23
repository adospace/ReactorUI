using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReactorUI.Skia.Xamarin
{
    public class ReactorWindow : ReactorContainer<ContentPage>
    {
        public ComponentHost RootHost { get; }

        public ReactorWindow(Component root)
            : this(root, new ContentPage())
        {
        }

        public ReactorWindow(Component root, ContentPage form)
            : base(form)
        {
            RootHost = Component.Host(root ?? throw new ArgumentNullException(nameof(root)));
        }

        public ReactorWindow(ComponentHost componentHost, ContentPage form)
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

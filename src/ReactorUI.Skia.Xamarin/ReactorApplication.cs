using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReactorUI.Skia.Xamarin
{
    public class ReactorApplication : IApplication
    {
        static ReactorApplication()
        {

        }

        protected ReactorApplication()
        { }

        public ComponentHost RootHost { get; private set; }

        //public Component Root => RootHost.Compoent;

        public ContentPage Page { get; private set; }

        public WidgetRegistry WidgetRegistry { get; } = new WidgetRegistry();


        public static IApplication Create(Component root, ContentPage page = null)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return Application.Register(new ReactorApplication()
            {
                RootHost = Component.Host(root),
                Page = page
            });
        }

        public static IApplication Create<T>(ComponentHost rootHost) where T : ContentPage, new()
        {
            if (rootHost == null)
            {
                throw new ArgumentNullException(nameof(rootHost));
            }

            return Application.Register(new ReactorApplication()
            {
                RootHost = rootHost,
                Page = new T()
            });
        }

        public void Run()
        {
            Run(Page ?? new ContentPage());
        }

        public void Run(ContentPage page)
        {
            var reactorForm = new ReactorWindow(RootHost, page);

            reactorForm.Run();

            global::Xamarin.Forms.Application.Current.MainPage = reactorForm.Container;
        }
    }
}

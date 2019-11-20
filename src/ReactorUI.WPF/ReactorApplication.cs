using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF
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

        public System.Windows.Window Window { get; private set; }

        public WidgetRegistry WidgetRegistry { get; } = new WidgetRegistry();

        public static IApplication Create(Component root, System.Windows.Window window = null)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return Application
                .Register(new ReactorApplication()
                {
                    RootHost = Component.Host(root),
                    Window = window
                })
                .DefaultTheme();
        }

        public static IApplication Create<T>(ComponentHost rootHost) where T : System.Windows.Window, new()
        {
            if (rootHost == null)
            {
                throw new ArgumentNullException(nameof(rootHost));
            }

            return Application.Register(new ReactorApplication()
            {
                RootHost = rootHost,
                Window = new T()
            });
        }

        public void Run()
        {
            Run(Window ?? new System.Windows.Window());
        }

        public void Run(System.Windows.Window window)
        {
            var reactorWindow = new ReactorWindow(RootHost, window);

            reactorWindow.Run();

            window.Show();
        }
    }

}

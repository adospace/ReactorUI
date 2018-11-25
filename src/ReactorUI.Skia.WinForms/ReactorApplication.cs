using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.Skia.WinForms
{
    public class ReactorApplication : IApplication
    {
        static ReactorApplication()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
        }

        protected ReactorApplication()
        { }

        public ComponentHost RootHost { get; private set; }

        //public Component Root => RootHost.Compoent;

        public System.Windows.Forms.Form Form { get; private set; }

        public WidgetRegistry WidgetRegistry { get; } = new WidgetRegistry();


        public static IApplication Create(Component root, System.Windows.Forms.Form form = null)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return Application.Register(new ReactorApplication()
            {
                RootHost = Component.Host(root),
                Form = form
            });
        }

        public static IApplication Create<T>(ComponentHost rootHost) where T : System.Windows.Forms.Form, new()
        {
            if (rootHost == null)
            {
                throw new ArgumentNullException(nameof(rootHost));
            }

            return Application.Register(new ReactorApplication()
            {
                RootHost = rootHost,
                Form = new T()
            });
        }

        public void Run()
        {
            Run(Form ?? new System.Windows.Forms.Form());
        }

        public void Run(System.Windows.Forms.Form form)
        {
            var reactorForm = new ReactorForm(RootHost, form);

            reactorForm.Run();

            System.Windows.Forms.Application.Run(reactorForm.Container);
        }
    }
}

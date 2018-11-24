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
        protected ReactorApplication()
        { }

        public Component Root { get; private set; }

        public WidgetRegistry WidgetRegistry { get; } = new WidgetRegistry();

        public static IApplication Create(Component root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            return Application.Register(new ReactorApplication()
            {
                Root = root
            });
        }

        public void Run()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var mainWindowComponent = new ReactorForm(Root).Run();

            System.Windows.Forms.Application.Run(mainWindowComponent.Container);
        }
    }
}

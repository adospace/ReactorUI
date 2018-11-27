using ReactorUI.Widgets;
using ReactorUI.Contracts;
using ReactorUI.Skia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.Skia
{
    public static class ApplicationExtensions
    {
        public static IApplication ModernTheme(this IApplication application)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }

            application.WidgetRegistry.Register<IScrollBar>(() => new Controls.ScrollBar());

            application.WidgetRegistry.Register<IComponentHost>(() => new Controls.ComponentHost());

            application.WidgetRegistry.Register<ITextBlock>(() => new Controls.TextBlock());
            application.WidgetRegistry.Register<IBorder>(() => new Controls.Border());
            application.WidgetRegistry.Register<IButton>(() => new Controls.Button());

            application.WidgetRegistry.Register<IDockPanel>(() => new Controls.Panels.DockPanel());
            application.WidgetRegistry.Register<IStackPanel>(() => new Controls.Panels.StackPanel());

            return application;
        }
    }
}

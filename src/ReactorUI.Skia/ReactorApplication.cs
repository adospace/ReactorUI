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
    public static class ReactorApplication
    {
        public static void Initialize()
        {
            WidgetRegistry.Instance.Register<IComponentHost>(() => new Controls.ComponentHost());

            WidgetRegistry.Instance.Register<ITextBlock>(()=> new Controls.TextBlock());
            WidgetRegistry.Instance.Register<IBorder>(() => new Controls.Border());
            WidgetRegistry.Instance.Register<IButton>(() => new Controls.Button());
            WidgetRegistry.Instance.Register<IScrollBar>(() => new Controls.ScrollBar());
            //WidgetRegistry.Instance.Register<ITreeView>(() => new Controls.TreeView());
            //WidgetRegistry.Instance.Register<ITreeViewNode>(() => new Controls.TreeViewNode());
            //WidgetRegistry.Instance.Register<IImage>(() => new Controls.Image());

            //WidgetRegistry.Instance.Register<IStackPanel>(() => new Controls.Panels.StackPanel());
            //WidgetRegistry.Instance.Register<IDockPanel>(() => new Controls.Panels.DockPanel());
        }
    }
}

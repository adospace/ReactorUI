using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
using ReactorUI.WPF.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF
{
    public static class ReactorApplication
    {
        public static void Initialize()
        {
            WidgetRegistry.Instance.Register<ITextBlock>(()=> new Controls.TextBlock());
            WidgetRegistry.Instance.Register<IBorder>(() => new Controls.Border());
            WidgetRegistry.Instance.Register<IButton>(() => new Controls.Button());
            WidgetRegistry.Instance.Register<ITreeView>(() => new Controls.TreeView());
            WidgetRegistry.Instance.Register<ITreeViewNode>(() => new Controls.TreeViewNode());
            WidgetRegistry.Instance.Register<IImage>(() => new Controls.Image());
            WidgetRegistry.Instance.Register<IComponent>(() => new Controls.Component());

            WidgetRegistry.Instance.Register<IStackPanel>(() => new Controls.Panels.StackPanel());
        }
    }
}

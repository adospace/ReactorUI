using ReactorUI.Contracts;
using ReactorUI.Styles;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using ReactorUI.Contracts.Panels;
using ReactorUI.Styles.Panels;

namespace ReactorUI.Widgets.Panels
{
    public class ContainerPanel : Panel<IContainerPanel, ContainerPanelStyle>, IContainerPanel
    {
        public ContainerPanel(params VisualNode[] children)
            : base(children)
        {
        }
    }

    public static class ContainerPanelExtensions
    {
        public static ContainerPanel ContainerPanel(this IWidgetContainer parent, params VisualNode[] children)
        {
            return new ContainerPanel(children);
        }
    }
}

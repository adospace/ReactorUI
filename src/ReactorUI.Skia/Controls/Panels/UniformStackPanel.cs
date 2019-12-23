using ReactorUI.Widgets;
using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactorUI.Styles;
using ReactorUI.Skia.Framework;
using ReactorUI.Contracts.Panels;
using ReactorUI.Styles.Panels;

namespace ReactorUI.Skia.Controls.Panels
{
    public class ContainerPanel : Panel<Framework.Panels.ContainerPanel, IContainerPanel, ContainerPanelStyle>
    {
        public ContainerPanel()
        {

        }

        public override void AddChild(IWidget widget, UIElement child)
        {
            _nativeControl.Children.Add(child);
        }

        public override void RemoveChild(IWidget widget, UIElement child)
        {
            _nativeControl.Children.Remove(child);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}

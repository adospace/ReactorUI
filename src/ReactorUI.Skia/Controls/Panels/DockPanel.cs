using ReactorUI.Contracts;
using ReactorUI.Primitives;
using ReactorUI.Skia.Framework;
using ReactorUI.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.Skia.Controls.Panels
{
    public class DockPanel : Panel<Framework.Panels.DockPanel, IDockPanel, DockPanelStyle>
    {
        public DockPanel()
        {

        }

        public override void AddChild(IWidget widget, UIElement child)
        {
            var metadataProvider = widget as IMetadataProvider;

            _nativeControl.Orientation = ((IDockPanel)widget).Orientation;

            if (metadataProvider.ContainsMetadata(ReactorUI.Widgets.Panels.DockPanel.DockMetadataKey))
            {
                var dock = metadataProvider.GetMetadata<Dock>(ReactorUI.Widgets.Panels.DockPanel.DockMetadataKey);

                if (dock == Dock.Left || dock == Dock.Top)
                    _nativeControl.DockPreviousChildren.Add(child);
                if (dock == Dock.Right || dock == Dock.Bottom)
                    _nativeControl.DockNextChildren.Add(child);
            }
            else
            {
                _nativeControl.FillChild = child;
            }
        }

        public override void RemoveChild(IWidget widget, UIElement child)
        {
            if (_nativeControl.DockPreviousChildren.Remove(child))
                return;
            if (_nativeControl.DockNextChildren.Remove(child))
                return;

            if (_nativeControl.FillChild == child)
                _nativeControl.FillChild = null;
        }

        protected override void OnUpdate()
        {
            
            base.OnUpdate();
        }
    }
}

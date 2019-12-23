using ReactorUI.Contracts;
using ReactorUI.Contracts.Panels;
using ReactorUI.Primitives;
using ReactorUI.Styles;
using ReactorUI.Styles.Panels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls.Panels
{
    internal class DockPanel : Panel<System.Windows.Controls.DockPanel, IDockPanel, DockPanelStyle>
    {
        public DockPanel()
        {

        }

        bool _lastChildFill = false;
        public override void AddChild(IWidget widget, object child)
        {
            var metadataProvider = widget as IMetadataProvider;
            if (metadataProvider.ContainsMetadata(ReactorUI.Widgets.Panels.DockPanel.DockMetadataKey))
            {
                var childElement = (System.Windows.UIElement)child;
                System.Windows.Controls.DockPanel.SetDock(childElement,
                    (System.Windows.Controls.Dock)metadataProvider.GetMetadata<Dock>(ReactorUI.Widgets.Panels.DockPanel.DockMetadataKey));

                if (_lastChildFill)
                {
                    _nativeControl.Children.Insert(_nativeControl.Children.Count - 1, childElement);
                    return;
                }
            }
            else
            {
                _lastChildFill = true;
            }

            _nativeControl.LastChildFill = _lastChildFill;

            base.AddChild(widget, child);
        }

        protected override void OnUpdate()
        {
            
            base.OnUpdate();
        }
    }
}

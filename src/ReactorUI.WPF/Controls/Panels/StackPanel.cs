using ReactorUI.Widgets;
using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactorUI.Styles;
using ReactorUI.Contracts.Panels;
using ReactorUI.Styles.Panels;

namespace ReactorUI.WPF.Controls.Panels
{
    internal class StackPanel : Panel<System.Windows.Controls.StackPanel, IStackPanel, StackPanelStyle>
    {
        public StackPanel()
        {

        }


        protected override void OnUpdate()
        {
            _nativeControl.Orientation = (System.Windows.Controls.Orientation)_widget.Orientation;
            base.OnUpdate();
        }
    }
}

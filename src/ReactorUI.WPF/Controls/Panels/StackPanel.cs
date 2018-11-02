using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls.Panels
{
    internal class StackPanel : Panel<System.Windows.Controls.StackPanel, IStackPanel, StackPanelStyle>
    {
        public StackPanel()
        {

        }


        protected override void OnUpdate()
        {
            NativePanel.Orientation = (System.Windows.Controls.Orientation)_widget.Orientation;
            base.OnUpdate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    public interface INativeControlContainer
    {
        void AddChild(System.Windows.UIElement child);

        void InsertChild(System.Windows.UIElement child, int index);

        void RemoveChild(System.Windows.UIElement child);

    }
}

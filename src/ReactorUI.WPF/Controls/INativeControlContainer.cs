using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    public interface INativeControlContainer
    {
        void AddChild(System.Windows.FrameworkElement child);

        void InsertChild(System.Windows.FrameworkElement child, int index);

        void RemoveChild(System.Windows.FrameworkElement child);

    }
}

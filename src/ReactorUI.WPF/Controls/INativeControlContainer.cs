using ReactorUI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    public interface INativeControlContainer
    {
        void AddChild(IWidget widget, object child);

        void RemoveChild(IWidget widget, object child);

    }
}

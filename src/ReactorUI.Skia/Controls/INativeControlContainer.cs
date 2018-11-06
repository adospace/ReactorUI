using ReactorUI.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.Skia.Controls
{
    public interface INativeControlContainer
    {
        void AddChild(IWidget widget, Framework.UIElement child);

        void RemoveChild(IWidget widget, Framework.UIElement child);

    }
}

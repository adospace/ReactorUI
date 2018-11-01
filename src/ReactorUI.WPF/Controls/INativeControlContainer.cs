using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    public interface INativeControlContainer
    {
        void AddChild(object child);

        void RemoveChild(object child);

    }
}

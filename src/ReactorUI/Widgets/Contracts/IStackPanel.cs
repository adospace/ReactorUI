using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Contracts
{
    public interface IStackPanel : IPanel
    {
        Orientation Orientation { get; set; }
    }
}

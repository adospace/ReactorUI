using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts.Panels
{
    public interface IStackPanel : IPanel
    {
        Orientation Orientation { get; set; }
    }
}

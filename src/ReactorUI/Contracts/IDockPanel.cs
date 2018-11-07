using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface IDockPanel : IPanel
    {
        Orientation Orientation { get; set; }
    }
}

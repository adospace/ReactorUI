using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts.Panels
{
    public interface IUniformStackPanel : IPanel
    {
        Orientation Orientation { get; set; }

        Size ChildSize { get; set; }

        Vector Offset { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public interface IWidget
    {
        INativeControl NativeControl { get; set; }

        IWidget Parent { get; }
    }
}

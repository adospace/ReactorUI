using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface IWidget
    {
        INativeControl NativeControl { get; set; }

        IWidget Parent { get; }

        void Invalidate();
    }
}

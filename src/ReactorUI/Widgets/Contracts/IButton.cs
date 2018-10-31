using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Contracts
{
    public interface IButton : IContentControl
    {
        string Text { get; set; }

        Action Click { get; set; }
    }
}

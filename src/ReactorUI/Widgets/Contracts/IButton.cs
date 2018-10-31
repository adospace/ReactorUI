using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Contracts
{
    public interface IButton : IContentControl
    {
        string Text { get; set; }

        Action OnClick { get; set; }
    }
}

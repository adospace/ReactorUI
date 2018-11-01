using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Contracts
{
    public interface IImage : IFrameworkElement
    {
        string Url { get; set; }
    }
}

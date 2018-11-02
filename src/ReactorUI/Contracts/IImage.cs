using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface IImage : IFrameworkElement
    {
        string Url { get; set; }
    }
}

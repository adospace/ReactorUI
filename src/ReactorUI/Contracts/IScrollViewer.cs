using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface IScrollViewer : IFrameworkElement
    {
        ScrollMode VerticalScrollMode { get; set; }

        ScrollMode HorizontalScrollMode { get; set; }
    }
}

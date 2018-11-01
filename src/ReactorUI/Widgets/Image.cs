using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class Image : FrameworkElement<Image>, IImage
    {
        public string Url { get; set; }
    }
}

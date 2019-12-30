using ReactorUI.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Styles
{
    public class ContentControlStyle<T> : ControlStyle<T>, IContentControlStyle<T> where T : IContentControl
    {
    }
}

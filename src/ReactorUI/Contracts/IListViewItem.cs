using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface IListViewItem : IControl
    {
        string Text { get; set; }
    }
}

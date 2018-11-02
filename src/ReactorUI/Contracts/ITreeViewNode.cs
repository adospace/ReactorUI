using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Contracts
{
    public interface ITreeViewNode : IControl
    {
        bool IsExpanded { get; set; }

        string Text { get; set; }

        string IconUrl { get; set; }

    }
}

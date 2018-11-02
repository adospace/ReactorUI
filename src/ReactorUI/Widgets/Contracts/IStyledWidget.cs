using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Contracts
{
    public interface IStyledWidget<TS>
    {
        TS Style { get; }
    }
}

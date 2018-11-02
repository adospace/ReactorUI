using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets.Contracts
{
    public interface IFrameworkElement : IUIElement
    {
        double Width { get; set; }
        double MinWidth { get; set; }
        double MaxHeight { get; set; }
        double Height { get; set; }
        double MinHeight { get; set; }
        double MaxWidth { get; set; }
        //object Tag { get; set; }
        //string Name { get; set; }
        Thickness Margin { get; set; }
        //Style Style { get; set; }
        VerticalAlignment VerticalAlignment { get; set; }
        //bool OverridesDefaultStyle { get; set; }
        HorizontalAlignment HorizontalAlignment { get; set; }
        //ContextMenu ContextMenu { get; set; }
        //object ToolTip { get; set; }
        //Cursor Cursor { get; set; }
    }
}

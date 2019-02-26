using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    public interface IPopupContainer
    {
        void ShowPopup(UIElement popupElement);

        void ShowTooltip(string tooltip);
    }
}

using ReactorUI.Contracts;
using ReactorUI.Skia.Controls;
using ReactorUI.Styles;
using System;
using System.Collections.Generic;
using System.Text;


namespace ReactorUI.Skia.Theme.Modern.Controls
{
    internal class Button : ReactorUI.Skia.Controls.Button
    {
        public Button()
        { 
            
        }

        protected override Skia.Framework.Button CreateNativeControl() => new Framework.Button();

    }

}

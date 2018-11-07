using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework.Input
{
    public class MouseEventsContext
    {
        public MouseEventsContext(MouseButtons mouseButtons, int clicks, int delta)
        {
            MouseButtons = mouseButtons;
            Clicks = clicks;
            Delta = delta;
        }

        public MouseButtons MouseButtons { get; }
        public int Clicks { get; }
        public int Delta { get; }

        public UIElement CaptureTo { get; set; }
    }
}

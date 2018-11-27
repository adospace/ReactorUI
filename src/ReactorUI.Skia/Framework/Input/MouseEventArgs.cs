using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework.Input
{
    public class MouseEventArgs : EventArgs
    {
        [System.Diagnostics.DebuggerStepThrough]
        public MouseEventArgs(MouseButtons mouseButtons, int clicks, int x, int y, int delta)
        {
            MouseButtons = mouseButtons;
            Clicks = clicks;
            X = x;
            Y = y;
            Delta = delta;
        }

        public MouseButtons MouseButtons { get; }
        public int Clicks { get; }
        public int X { get; }
        public int Y { get; }
        public int Delta { get; }
    }
}

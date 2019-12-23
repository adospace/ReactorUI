using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework.Input
{
    public class MouseEventArgs : EventArgs
    {
        [System.Diagnostics.DebuggerStepThrough]
        public MouseEventArgs(MouseButtons mouseButtons, int clicks, double x, double y, int delta)
        {
            MouseButtons = mouseButtons;
            Clicks = clicks;
            X = x;
            Y = y;
            Delta = delta;
        }

        public MouseButtons MouseButtons { get; }
        public int Clicks { get; }
        public double X { get; }
        public double Y { get; }
        public int Delta { get; }
    }
}

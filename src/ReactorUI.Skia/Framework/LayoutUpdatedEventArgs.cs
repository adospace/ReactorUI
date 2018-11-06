using System;

namespace ReactorUI.Skia.Framework
{
    public class InvalidatedEventArgs : EventArgs
    {
        public InvalidatedEventArgs(InvalidateMode mode)
        {
            Mode = mode;
        }

        public InvalidateMode Mode { get; }
    }
}
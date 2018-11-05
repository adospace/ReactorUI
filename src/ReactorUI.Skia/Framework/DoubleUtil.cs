using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    internal static class DoubleUtil
    {
        public static bool AreClose(double v1, double v2) =>
            Math.Abs(v1 - v2) < 1e-10;
    }
}

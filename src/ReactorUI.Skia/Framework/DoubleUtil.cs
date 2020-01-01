using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    internal static class DoubleUtil
    {
        public static bool AreClose(double v1, double v2) =>
            Math.Abs(v1 - v2) < 1e-10;

        public static bool IsLessOrClose(double v1, double v2) =>
            v1 < v2 && Math.Abs(v1 - v2) < 1e-10;

        public static bool IsGreaterOrClose(double v1, double v2) =>
            v1 > v2 && Math.Abs(v1 - v2) < 1e-10;
    }
}

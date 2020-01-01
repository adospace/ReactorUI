using ReactorUI.Contracts;
using ReactorUI.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    internal interface IScrollableUIElement
    {
        Vector Offset { get; set; }

        Size ViewportSize { get; }
    }


    internal static class ScrollableUIElementExtensions
    {
        public static void IncrementOffset(this IScrollableUIElement element, Vector vector)
        {
            element.Offset += vector;
        }

        public static void DecrementOffset(this IScrollableUIElement element, Vector vector)
        {
            element.Offset -= vector;
        }
    }
}

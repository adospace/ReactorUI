using ReactorUI.Primitives;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    public class RenderContext
    {
        internal RenderContext(SKCanvas canvas, Vector offset)
        {
            Canvas = canvas;
            Offset = offset;
        }

        public SKCanvas Canvas { get; }
        public Vector Offset { get; }
    }
}

using ReactorUI.Primitives;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Framework
{
    public static class SKCanvasExtensions
    {
        public static void ApplyTransform(this SKCanvas canvas, Transform transform, Size renderSize)
        {
            if (canvas == null)
            {
                throw new ArgumentNullException(nameof(canvas));
            }

            if (transform == null)
            {
                throw new ArgumentNullException(nameof(transform));
            }

            foreach (var operation in transform.Operations)
            {
                if (operation is Transform.Scale)
                    ApplyTransform(canvas, (Transform.Scale)operation);
                else if (operation is Transform.ScaleOrigin)
                    ApplyTransform(canvas, (Transform.ScaleOrigin)operation);
                else if (operation is Transform.ScaleRelativeOrigin)
                    ApplyTransform(canvas, (Transform.ScaleRelativeOrigin)operation, renderSize);
            }
        }

        private static void ApplyTransform(this SKCanvas canvas, Transform.Scale transformOperation)
        {
            canvas.Scale((float)transformOperation.X, (float)transformOperation.Y);
        }

        private static void ApplyTransform(this SKCanvas canvas, Transform.ScaleOrigin transformOperation)
        {
            canvas.Scale((float)transformOperation.X, (float)transformOperation.Y, (float)transformOperation.XOrigin, (float)transformOperation.YOrigin);
        }

        private static void ApplyTransform(this SKCanvas canvas, Transform.ScaleRelativeOrigin transformOperation, Size renderSize)
        {
            canvas.Scale((float)transformOperation.X, (float)transformOperation.Y, (float)(transformOperation.XOffset * renderSize.Width), (float)(transformOperation.YOffset * renderSize.Height));
        }
    }
}

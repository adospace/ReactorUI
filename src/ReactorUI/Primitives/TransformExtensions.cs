using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public static class TransformExtensions
    {
        public static Transform Scale(this Transform transform, double x, double y)
        {
            transform.Enqueue(new Transform.Scale(x, y));
            return transform;
        }

        public static Transform ScaleFromCenter(this Transform transform, double x, double y)
        {
            transform.Enqueue(new Transform.ScaleRelativeOrigin(x, y, 0.5, 0.5));
            return transform;
        }

        public static Transform Translate(this Transform transform, double x, double y)
        {
            transform.Enqueue(new Transform.Translate(x, y));
            return transform;
        }

        public static Transform RotateFromCenter(this Transform transform, double degrees)
        {
            transform.Enqueue(new Transform.RotateRelativeOrigin(degrees, 0.5, 0.5));
            return transform;
        }

        public static Transform ScaleX(this Transform transform, double x)
        {
            transform.Scale(x, 1.0);
            return transform;
        }

        public static Transform ScaleY(this Transform transform, double y)
        {
            transform.Scale(1.0, y);
            return transform;
        }

        public static Transform ScaleWidth(this Transform transform, double x)
        {
            transform.ScaleFromCenter(x, 1.0);
            return transform;
        }

        public static Transform ScaleHeight(this Transform transform, double y)
        {
            transform.ScaleFromCenter(1.0, y);
            return transform;
        }

        public static Transform ScaleWidthHeight(this Transform transform, double x, double y)
        {
            transform.ScaleFromCenter(x, y);
            return transform;
        }
    }
}

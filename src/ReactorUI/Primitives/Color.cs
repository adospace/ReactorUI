using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Primitives
{
    public struct Color
    {
        public byte A;

        public byte R;

        public byte G;

        public byte B;

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
            A = 255;
        }

        public Color(byte a, byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

        public static Color FromRGB(byte r, byte g, byte b)
        {
            return new Color() { A = 255, R = r, G = g, B = b };
        }

        public static Color FromARGB(byte a, byte r, byte g, byte b)
        {
            return new Color() { A = a, R = r, G = g, B = b };
        }
    }
}

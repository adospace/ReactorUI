using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Animation
{
    /* 
     * Functions taken from Tween.js - Licensed under the MIT license
     * at https://github.com/sole/tween.js
     */
    public class Easing
    {

        public static double Linear(double k)
        {
            return k;
        }

        public class Quadratic
        {
            public static double In(double k)
            {
                return k * k;
            }

            public static double Out(double k)
            {
                return k * (2f - k);
            }

            public static double InOut(double k)
            {
                if ((k *= 2f) < 1f) return 0.5f * k * k;
                return -0.5f * ((k -= 1f) * (k - 2f) - 1f);
            }
        };

        public class Cubic
        {
            public static double In(double k)
            {
                return k * k * k;
            }

            public static double Out(double k)
            {
                return 1f + ((k -= 1f) * k * k);
            }

            public static double InOut(double k)
            {
                if ((k *= 2f) < 1f) return 0.5f * k * k * k;
                return 0.5f * ((k -= 2f) * k * k + 2f);
            }
        };

        public class Quartic
        {
            public static double In(double k)
            {
                return k * k * k * k;
            }

            public static double Out(double k)
            {
                return 1f - ((k -= 1f) * k * k * k);
            }

            public static double InOut(double k)
            {
                if ((k *= 2f) < 1f) return 0.5f * k * k * k * k;
                return -0.5f * ((k -= 2f) * k * k * k - 2f);
            }
        };

        public class Quintic
        {
            public static double In(double k)
            {
                return k * k * k * k * k;
            }

            public static double Out(double k)
            {
                return 1f + ((k -= 1f) * k * k * k * k);
            }

            public static double InOut(double k)
            {
                if ((k *= 2f) < 1f) return 0.5f * k * k * k * k * k;
                return 0.5f * ((k -= 2f) * k * k * k * k + 2f);
            }
        };

        public class Sinusoidal
        {
            public static double In(double k)
            {
                return 1f - Math.Cos(k * Math.PI / 2f);
            }

            public static double Out(double k)
            {
                return Math.Sin(k * Math.PI / 2f);
            }

            public static double InOut(double k)
            {
                return 0.5f * (1f - Math.Cos(Math.PI * k));
            }
        };

        public class Exponential
        {
            public static double In(double k)
            {
                return k == 0f ? 0f : Math.Pow(1024f, k - 1f);
            }

            public static double Out(double k)
            {
                return k == 1f ? 1f : 1f - Math.Pow(2f, -10f * k);
            }

            public static double InOut(double k)
            {
                if (k == 0f) return 0f;
                if (k == 1f) return 1f;
                if ((k *= 2f) < 1f) return 0.5f * Math.Pow(1024f, k - 1f);
                return 0.5f * (-Math.Pow(2f, -10f * (k - 1f)) + 2f);
            }
        };

        public class Circular
        {
            public static double In(double k)
            {
                return 1f - Math.Sqrt(1f - k * k);
            }

            public static double Out(double k)
            {
                return Math.Sqrt(1f - ((k -= 1f) * k));
            }

            public static double InOut(double k)
            {
                if ((k *= 2f) < 1f) return -0.5f * (Math.Sqrt(1f - k * k) - 1);
                return 0.5f * (Math.Sqrt(1f - (k -= 2f) * k) + 1f);
            }
        };

        public class Elastic
        {
            public static double In(double k)
            {
                if (k == 0) return 0;
                if (k == 1) return 1;
                return -Math.Pow(2f, 10f * (k -= 1f)) * Math.Sin((k - 0.1f) * (2f * Math.PI) / 0.4f);
            }

            public static double Out(double k)
            {
                if (k == 0) return 0;
                if (k == 1) return 1;
                return Math.Pow(2f, -10f * k) * Math.Sin((k - 0.1f) * (2f * Math.PI) / 0.4f) + 1f;
            }

            public static double InOut(double k)
            {
                if ((k *= 2f) < 1f) return -0.5f * Math.Pow(2f, 10f * (k -= 1f)) * Math.Sin((k - 0.1f) * (2f * Math.PI) / 0.4f);
                return Math.Pow(2f, -10f * (k -= 1f)) * Math.Sin((k - 0.1f) * (2f * Math.PI) / 0.4f) * 0.5f + 1f;
            }
        };

        public class Back
        {
            static double s = 1.70158f;
            static double s2 = 2.5949095f;

            public static double In(double k)
            {
                return k * k * ((s + 1f) * k - s);
            }

            public static double Out(double k)
            {
                return (k -= 1f) * k * ((s + 1f) * k + s) + 1f;
            }

            public static double InOut(double k)
            {
                if ((k *= 2f) < 1f) return 0.5f * (k * k * ((s2 + 1f) * k - s2));
                return 0.5f * ((k -= 2f) * k * ((s2 + 1f) * k + s2) + 2f);
            }
        };

        public class Bounce
        {
            public static double In(double k)
            {
                return 1f - Out(1f - k);
            }

            public static double Out(double k)
            {
                if (k < (1f / 2.75f))
                {
                    return 7.5625f * k * k;
                }
                else if (k < (2f / 2.75f))
                {
                    return 7.5625f * (k -= (1.5f / 2.75f)) * k + 0.75f;
                }
                else if (k < (2.5f / 2.75f))
                {
                    return 7.5625f * (k -= (2.25f / 2.75f)) * k + 0.9375f;
                }
                else
                {
                    return 7.5625f * (k -= (2.625f / 2.75f)) * k + 0.984375f;
                }
            }

            public static double InOut(double k)
            {
                if (k < 0.5f) return In(k * 2f) * 0.5f;
                return Out(k * 2f - 1f) * 0.5f + 0.5f;
            }
        };
    }
}

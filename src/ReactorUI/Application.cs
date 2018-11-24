using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI
{
    public static class Application
    {
        public static IApplication Current { get; private set; }

        public static IApplication Register(IApplication application)
        {
            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }

            if (Current != null)
                throw new InvalidOperationException();

            Current = application;
            return application;
        }
    }
}

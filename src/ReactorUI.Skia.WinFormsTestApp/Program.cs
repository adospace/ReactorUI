using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactorUI.Skia.WinFormsTestApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ReactorControls.Initialize();
            //ModernTheme.Initialize();

            WinForms.ReactorApplication
                .Create(new MainWindowComponent())
                .ModernTheme()
                .Run();
        }
    }
}

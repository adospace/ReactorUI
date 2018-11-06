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
            ReactorApplication.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var frmMain = new Form();
            var mainWindowComponent =
                new MainWindowComponent(frmMain)
                .Run();
            
            Application.Run(frmMain);
        }
    }
}

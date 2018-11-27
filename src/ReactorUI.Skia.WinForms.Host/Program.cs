using CommandLine;
using ReactorUI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactorUI.Skia.WinForms.Host
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] arguments)
        {
            Parser.Default.ParseArguments<RunOptions>(arguments)
                .WithParsed(RunWithOptions);
        }

        private static void RunWithOptions(RunOptions options)
        {
            RenderOptions.ShowClipRects = options.ShowClipRects;
            RenderOptions.ShowFrameRate = options.ShowFrameRate;

            ReactorApplication
                .Create<FormHost>(new ComponentLoaderHost(options.AssemblyPath, options.ComponentTypeName))
                .ModernTheme()
                .Run();
        }
    }
}

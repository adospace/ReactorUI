using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.Skia.WinForms.Host
{
    internal class RunOptions
    {
        [Option('a', "assembly", Required = true, HelpText = "Path to assembly containing Component to host.")]
        public string AssemblyPath { get; set; }

        [Option('c', "component", Required = true, HelpText = "Type name of the Component to host.")]
        public string ComponentTypeName { get; set; }

        [Option('r', "clip-rects", Required = false, HelpText = "Show clip rects before render visuals.")]
        public bool ShowClipRects { get; set; }

        [Option('f', "show-fps", Required = false, HelpText = "Show frame rate indicator.")]
        public bool ShowFrameRate { get; set; }
    }
}

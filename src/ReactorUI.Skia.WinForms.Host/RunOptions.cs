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
    }
}

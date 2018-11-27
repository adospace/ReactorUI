using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace ReactorUI.Widgets
{
    public class ComponentLoaderHost : ComponentHost
    {

        public string AssemblyPath { get; }
        public string TypeName { get; }

        public ComponentLoaderHost(string assemblyPath, string typeName)
        {
            if (string.IsNullOrWhiteSpace(assemblyPath))
            {
                throw new ArgumentException("can't be empty or null", nameof(assemblyPath));
            }

            if (string.IsNullOrWhiteSpace(typeName))
            {
                throw new ArgumentException("can't be empty or null", nameof(typeName));
            }

            AssemblyPath = assemblyPath;
            TypeName = typeName;
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            if (_componentChanged)
            {
                _componentChanged = false;
                System.Diagnostics.Debug.WriteLine($"AssemblyChanged");
                Component = CreateInstance<Component>(AssemblyPath, TypeName);
            }

            return base.RenderChildren();
        }

        protected override void OnMount()
        {
            if (Component == null)
            {
                Component = CreateInstance<Component>(AssemblyPath, TypeName);
                var fileSystemWatcher = new FileSystemWatcher(Path.GetDirectoryName(AssemblyPath), Path.GetFileName(AssemblyPath));
                fileSystemWatcher.Changed += AssemblyChanged;
                fileSystemWatcher.NotifyFilter = NotifyFilters.LastWrite;
                fileSystemWatcher.EnableRaisingEvents = true;
            }

            base.OnMount();
        }

        private bool _componentChanged;
        private void AssemblyChanged(object sender, FileSystemEventArgs e)
        {
            _componentChanged = true;
            Invalidate();
        }

        private static T CreateInstance<T>(string assemblyPath, string typeName, params object[] args)
        {
            var assembly = Assembly.Load(File.ReadAllBytes(assemblyPath));
            if (assembly == null)
                throw new InvalidOperationException($"Unable to load assembly '{typeName}'");

            var obj = assembly.CreateInstance(typeName, true, BindingFlags.Default, null, args, null, null);
            if (obj == null)
                throw new InvalidOperationException($"Unable to load type '{assemblyPath}' from assembly '{typeName}'");
            return (T)obj;
        }
    }
}

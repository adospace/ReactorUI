using System;
using System.Collections.Generic;
using System.Runtime.Loader;
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

        protected override void OnMount()
        {
            Component = Component ?? CreateInstance<Component>(AssemblyPath, TypeName);


            base.OnMount();
        }

        private static Type Load(string assemblyPath, string typeName)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
            return assembly.GetType(typeName);
        }

        private static T CreateInstance<T>(string assemblyPath, string typeName, params object[] args)
        {
            var type = Load(assemblyPath, typeName);
            return (T)Activator.CreateInstance(type, args);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.Skia.WinForms.Host
{
    public static class TypeLoader
    {
        public static T CreateInstance<T>(string assemblyPath, string typeName, params object[] args)
        {
            if (assemblyPath == null)
            {
                throw new ArgumentNullException(nameof(assemblyPath));
            }

            if (typeName == null)
            {
                throw new ArgumentNullException(nameof(typeName));
            }

            var objectHandle = Activator.CreateInstance(assemblyPath, typeName, true, BindingFlags.Default, null, args, null, null);
            if (objectHandle == null)
                throw new InvalidOperationException($"Type {typeName} not found in assembly {assemblyPath}");

            return (T)objectHandle.Unwrap();
        }
    }
}

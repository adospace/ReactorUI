using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public sealed class WidgetRegistry
    {
        public WidgetRegistry()
        {
        }

        //public static WidgetRegistry Instance { get; } = new WidgetRegistry();

        private readonly ConcurrentDictionary<Type, object> _registry = new ConcurrentDictionary<Type, object>();

        public WidgetRegistry Register<I>(Func<INativeControl> constructorFunc)
        {
            _registry[typeof(I)] = constructorFunc;

            return this;
        }

        public INativeControl CreateNew<I>()
        {
            if (!_registry.TryGetValue(typeof(I), out var constructorFunc))
                throw new InvalidOperationException($"Unable to create a native control that implements interface '{typeof(I)}': constructor function not registered");

            var nativeControl = ((Func<INativeControl>)constructorFunc)();

            if (nativeControl == null)
                throw new InvalidOperationException($"Unable to create a native control that implements interface '{typeof(I)}': registered constructor function returned null");

            //if (!(nativeControl is INativeControl))
            //    throw new InvalidOperationException($"Unable to create a native control that implements interface '{typeof(I)}': ensure that type '{nativeControl.GetType()}' implements interface '{typeof(I)}'");

            return nativeControl;
        }
    }
}

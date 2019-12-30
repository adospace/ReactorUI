using ReactorUI.Contracts;
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

        private readonly ConcurrentDictionary<Type, object> _nativeControlTypeRegistry = new ConcurrentDictionary<Type, object>();
        private readonly ConcurrentDictionary<Type, object> _defaultActionRegistry = new ConcurrentDictionary<Type, object>();

        public WidgetRegistry Register<I>(Func<INativeControl> constructorFunc)
        {
            _nativeControlTypeRegistry[typeof(I)] = constructorFunc;

            return this;
        }

        public WidgetRegistry RegisterDefaultStyle<T, TS>(TS defaultStyle) where T : IUIElement
        {
            _defaultActionRegistry[typeof(T)] = defaultStyle;

            return this;
        }

        internal void ApplyDefaultStyle<T, TS>(IStyledWidget<TS> element)
        {
            if (_defaultActionRegistry.TryGetValue(typeof(T), out var defaultAction))
            {
                element.SetStyle((TS)defaultAction);
            }
        }

        internal INativeControl CreateNew<I>()
        {
            if (!_nativeControlTypeRegistry.TryGetValue(typeof(I), out var constructorFunc))
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

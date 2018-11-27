using ReactorUI.Contracts;
using ReactorUI.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class ComponentHost : ContentControl<IComponentHost, ComponentHostStyle>, IComponentHost
    {
        private Component _component;
        protected Component Component
        {
            get => _component;
            set
            {
                if (_component != value)
                {
                    var oldComponent = _component;
                    _component = value;
                    _component.SetOwner(this);
                    if (oldComponent != null)
                        _component.MigrateStateFrom(oldComponent);
                }
            }
        }

        protected ComponentHost()
        { }

        public ComponentHost(Component component)
        {
            Component = component ?? throw new ArgumentNullException(nameof(component));
        }

        internal override void MergeWith(VisualNode newNode)
        {
            if (GetType() == newNode.GetType())
            {
                var newHost = (ComponentHost)newNode;
                newHost.Component = Component;
            }

            base.MergeWith(newNode);
        }

        protected override void OnUnmount()
        {
            Component.Deactivate();

            base.OnUnmount();
        }

        protected override IEnumerable<VisualNode> RenderChildren()
        {
            yield return _component.Render();
        }

        void IComponentHost.Invalidate()
        {
            Invalidate();
        }
    }


    public class ComponentHost<T> : ComponentHost where T : Component, new()
    {
        protected override void OnMount()
        {
            Component = Component ?? new T();

            base.OnMount();
        }
    }
}

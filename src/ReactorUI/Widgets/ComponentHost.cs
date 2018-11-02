using ReactorUI.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class ComponentHost<T> : VisualNode, IComponentHost where T : Component, new()
    {
        private T _component;
        private T Component {
            get => _component;
            set
            {
                _component = value;
                _component.SetOwner(this);
            }
        }

        public ComponentHost()
        {
        }

        internal override void MergeWith(VisualNode newNode)
        {
            if (GetType() == newNode.GetType())
            {
                var newHost = ((ComponentHost<T>)newNode);
                newHost.Component = Component;
            }

            base.MergeWith(newNode);
        }

        protected override void OnMount()
        {
            Component = Component ?? new T();

            base.OnMount();
        }

        protected override void OnUnmount()
        {
            Component.Deactivate();

            base.OnUnmount();
        }

        protected sealed override IEnumerable<VisualNode> RenderChildren()
        {
            yield return _component.Render();
        }

        void IComponentHost.Invalidate()
        {
            Invalidate();
        }
    }
}

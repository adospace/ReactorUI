using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ReactorUI.Widgets
{
    public abstract class Component : Widget<IComponent>, IComponent, IWidgetContainer
    {
        protected sealed override IEnumerable<VisualNode> RenderChildren()
        {
            yield return Render();
        }

        protected sealed override void OnUpdate()
        {
            base.OnUpdate();
        }

        protected abstract VisualNode Render();

    }



    public abstract class Component<S> : Component where S : class, new()
    {
        public class ComponentState
        {
            public S Value { get; private set; }
            private Component<S> _owner;

            public ComponentState(S state, Component<S> initialOwner)
            {
                Value = state;
                _owner = initialOwner;
            }

            public void Set(Action<S> actionOnState)
            {
                if (actionOnState == null)
                {
                    throw new ArgumentNullException(nameof(actionOnState));
                }

                actionOnState(Value);
                _owner.Invalidate();
            }

            internal S GetRenderState()
            {
                S renderState = null;
                Interlocked.Exchange(ref renderState, Value);

                return renderState;
            }

            internal void SetOwner(Component<S> owner)
            {
                this._owner = owner;
                this._owner.CurrentState = this;
            }
        }

        public ComponentState CurrentState { get; private set; }
    
        protected Component()
        {
        }

        internal override void MergeWith(VisualNode newNode)
        {
            this.OnReleaseState();
            if (GetType() == newNode.GetType())
            {
                var newComponent = (Component<S>)newNode;
                CurrentState.SetOwner(newComponent);
                newComponent.OnAttachState();
            }

            base.MergeWith(newNode);
        }

        protected virtual void OnAttachState()
        {
            System.Diagnostics.Debug.WriteLine($"{GetType()} OnDetachState");
        }

        protected virtual void OnReleaseState()
        {
            System.Diagnostics.Debug.WriteLine($"{GetType()} OnAttachState");
        }

        protected override void OnMount()
        {
            CurrentState = new ComponentState(new S(), this);
            OnAttachState();

            base.OnMount();
        }
        
        protected sealed override VisualNode Render()
        {
            return Render(CurrentState.GetRenderState());
        }

        protected abstract VisualNode Render(S state);
    }

}

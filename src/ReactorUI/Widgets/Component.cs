using ReactorUI.Widgets;
using ReactorUI.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ReactorUI.Widgets
{
    public abstract class Component
    {
        protected Component()
        { }

        public abstract VisualNode Render();

        protected virtual void OnDeactivate()
        {

        }

        protected void Invalidate()
        {
            _host.Invalidate();
        }

        internal void Deactivate()
        {
            OnDeactivate();
        }

        private IComponentHost _host;

        internal void SetOwner(IComponentHost host)
        {
            _host = host;
        }

        public static ComponentHost<T> Host<T>() where T : Component, new()
        {
            return new ComponentHost<T>();
        }

        public static ComponentHost Host(Component component)
        {
            return new ComponentHost(component);
        }

        internal virtual void MigrateStateFrom(Component component)
        {

        }

    }

    internal interface IStatefulComponent
    {
        object GetState();
    }

    public abstract class Component<S> : Component, IStatefulComponent where S : class, new()
    {
        public S State { get; private set; }

        protected Component(S state = null)
        {
            State = state ?? new S();
        }

        public void SetState(Action<S> actionOnState)
        {
            if (actionOnState == null)
            {
                throw new ArgumentNullException(nameof(actionOnState));
            }

            actionOnState(State);
            Invalidate();
        }

        public sealed override VisualNode Render()
        {
            S renderState = null;
            Interlocked.Exchange(ref renderState, State);

            return Render(renderState);
        }

        public abstract VisualNode Render(S state);

        internal sealed override void MigrateStateFrom(Component component)
        {
            if (component is IStatefulComponent statefulComponent)
            {
                var otherState = statefulComponent.GetState();

                otherState.CopyProperties(State);
            }

            base.MigrateStateFrom(component);
        }

        object IStatefulComponent.GetState()
        {
            return State;
        }
    }

}

using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
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
   }



    public abstract class Component<S> : Component where S : class, new()
    {
        public S State { get; private set; }

        protected Component(S state)
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
    }

}

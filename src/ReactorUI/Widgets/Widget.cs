using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public abstract class Widget : VisualNode, IWidget
    {
        protected INativeControl NativeControl { get; set; }

        public new IWidget Parent => base.Parent as IWidget;

        INativeControl IWidget.NativeControl { get => NativeControl; set => NativeControl = value; }

        internal override void MergeWith(VisualNode newNode)
        {
            if (newNode.GetType() == GetType())
            {
                ((Widget)newNode).NativeControl = this.NativeControl;
                ((Widget)newNode)._isMounted = this.NativeControl != null;
            }
            else
            {
                this.NativeControl.WillUnmount(this);
            }

            base.MergeWith(newNode);
        }

        protected override void OnUnmount()
        {
            NativeControl.WillUnmount(this);

            base.OnUnmount();
        }

    }

    public abstract class Widget<T> : Widget where T : class
    {
        protected override void OnMount()
        {
            NativeControl = WidgetRegistry.Instance.CreateNew<T>();
            NativeControl.DidMount(this);

            base.OnMount();
        }

        protected override void OnUpdate()
        {
            ((INativeControl<T>)NativeControl).Update(this as T);

            base.OnUpdate();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ReactorUI.Skia.Framework.Input;

namespace ReactorUI.Skia.Framework
{
    public class Button : ContentControl
    {
        #region Public Properties

        #endregion

        #region Public Events
        public event EventHandler<Input.MouseEventArgs> Click;
        protected virtual void OnClick(double x, double y, Input.MouseEventsContext context)
        {
            Click?.Invoke(this, new Input.MouseEventArgs(context.MouseButtons, context.Clicks, x, y, context.Delta));
        }
        #endregion

        bool _mouseDown = false;

        protected override void OnMouseDown(double x, double y, MouseEventsContext context)
        {
            _mouseDown = true;
            context.CaptureTo = this;

            base.OnMouseDown(x, y, context);
        }

        protected override void OnMouseUp(double x, double y, MouseEventsContext context)
        {
            if (_mouseDown)
            {
                OnClick(x, y, context);
                _mouseDown = false;
            }
            base.OnMouseUp(x, y, context);
        }

    }
}

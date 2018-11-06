using System;
using System.Collections.Generic;
using System.Text;
using ReactorUI.Skia.Framework.Input;

namespace ReactorUI.Skia.Framework
{
    internal class Button : ContentControl
    {
        #region Public Properties

        #endregion

        #region Public Events
        public event EventHandler<Input.MouseEventArgs> Click;
        protected virtual void OnClick(Input.MouseEventArgs mouseEventArgs)
        {
            Click?.Invoke(this, mouseEventArgs);
        }
        #endregion

        bool _mouseDown = false;
        protected override void OnMouseDown(MouseEventArgs mouseEventArgs)
        {
            _mouseDown = true;
            base.OnMouseDown(mouseEventArgs);
        }

        protected override void OnMouseUp(MouseEventArgs mouseEventArgs)
        {
            if (_mouseDown)
            {
                OnClick(mouseEventArgs);
                _mouseDown = false;
            }
            base.OnMouseUp(mouseEventArgs);
        }
    }
}

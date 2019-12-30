using ReactorUI.Contracts;
using ReactorUI.Styles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Skia.Controls
{
    public class Button : ContentControl<Framework.Button, IButton>
    {
        public Button()
        {
        }

        private bool _actionToFireOnClick;

        protected override void OnDidMount()
        {

            base.OnDidMount();
        }

        protected override void OnWillUnmount()
        {
            if (_actionToFireOnClick)
                _nativeControl.Click -= _nativeButton_Click;

            base.OnWillUnmount();
        }

        protected override void OnUpdate()
        {
            if (!HasContent)
            {
                _nativeControl.Content = _widget.Text;
            }

            if (!_actionToFireOnClick && _widget.OnClickAction != null)
                _nativeControl.Click += _nativeButton_Click;
            else if (_actionToFireOnClick && _widget.OnClickAction == null)
                _nativeControl.Click -= _nativeButton_Click;

            _actionToFireOnClick = _widget.OnClickAction != null;

            base.OnUpdate();
        }

        private void _nativeButton_Click(object sender, Framework.Input.MouseEventArgs e)
        {
            _widget.OnClickAction(_widget);
        }
    }
}

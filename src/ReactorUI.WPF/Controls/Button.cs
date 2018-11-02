using ReactorUI.Widgets;
using ReactorUI.Widgets.Contracts;
using ReactorUI.Widgets.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReactorUI.WPF.Controls
{
    internal class Button : ContentControl<System.Windows.Controls.Button, IButton, ButtonStyle>
    {
        public Button()
        {
        }

        private Action<IButton> _actionToFireOnClick;

        protected override void OnDidMount()
        {

            base.OnDidMount();
        }

        protected override void OnWillUnmount()
        {
            if (_actionToFireOnClick != null)
                _nativeControl.Click -= _nativeButton_Click;

            base.OnWillUnmount();
        }

        protected override void OnUpdate()
        {
            if (!HasContent)
            {
                _nativeControl.Content = _widget.Text;
            }

            if (_actionToFireOnClick == null && _widget.OnClickAction != null)
                _nativeControl.Click += _nativeButton_Click;
            else if (_actionToFireOnClick != null && _widget.OnClickAction == null)
                _nativeControl.Click -= _nativeButton_Click;

            _actionToFireOnClick = _widget.OnClickAction;

            base.OnUpdate();
        }

        private void _nativeButton_Click(object sender, RoutedEventArgs e)
        {
            _actionToFireOnClick(_widget);
        }
    }
}

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
    internal class Button : ContentControl<System.Windows.Controls.Button, IButton>
    {
        public Button()
        {
        }

        public override void Update(IButton widget)
        {
            if (!HasContent)
            {
                _nativeControl.Content = widget.Text;
            }

            if (widget.Click != null && _actionToFireOnClick == null)
                _nativeControl.Click += _nativeButton_Click;
            else if (widget.Click == null && _actionToFireOnClick != null)
                _nativeControl.Click -= _nativeButton_Click;

            _actionToFireOnClick = widget.Click;

            base.Update(widget);
        }

        private Action _actionToFireOnClick;
        private void _nativeButton_Click(object sender, RoutedEventArgs e)
        {
            _actionToFireOnClick();
        }
    }
}

using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    internal class Image : FrameworkElement<System.Windows.Controls.Image, IImage, ImageStyle>
    {
        protected override void OnUpdate()
        {
            if (_widget.Url != null)
                _nativeControl.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(_widget.Url));

            base.OnUpdate();
        }
    }
}

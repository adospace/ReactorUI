using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactorUI.WPF.Controls
{
    internal class Image : FrameworkElement<System.Windows.Controls.Image, IImage>
    {
        public override void Update(IImage widget)
        {
            if (widget.Url != null)
                _nativeControl.Source = new System.Windows.Media.Imaging.BitmapImage(new Uri(widget.Url));

            base.Update(widget);
        }
    }
}

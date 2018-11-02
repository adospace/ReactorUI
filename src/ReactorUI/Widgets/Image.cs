using ReactorUI.Widgets.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReactorUI.Widgets
{
    public class Image : FrameworkElement<IImage, ImageStyle>, IImage
    {
        public Image(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
    }


    public static class ImageExtensions
    {
        public static Image Image(this IWidgetContainer parent, string url)
        {
            return new Image(url);
        }
    }
}

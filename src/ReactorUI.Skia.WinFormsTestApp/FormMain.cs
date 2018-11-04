using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReactorUI.Skia.WinFormsTestApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            var timer = new Timer
            {
                Interval = 16
            };
            timer.Tick += (s, e) => skiaView.Invalidate();
            timer.Enabled = true;
        }

        private void SkiaView_PaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintSurfaceEventArgs e)
        {
            // the the canvas and properties
            var canvas = e.Surface.Canvas;

            // get the screen density for scaling
            var scale = 1f;
            var scaledSize = new SKSize(e.Info.Width / scale, e.Info.Height / scale);

            // handle the device screen density
            canvas.Scale(scale);

            // make sure the canvas is blank
            canvas.Clear(SKColors.White);

            // draw some text
            var paint = new SKPaint
            {
                Color = SKColors.Black,
                IsAntialias = true,
                Style = SKPaintStyle.Fill,
                TextAlign = SKTextAlign.Center,
                TextSize = 24
            };
            var coord = new SKPoint(scaledSize.Width / 2, (scaledSize.Height + paint.TextSize) / 2);
            canvas.DrawText(DateTime.Now.ToString(), coord, paint);

        }
    }
}

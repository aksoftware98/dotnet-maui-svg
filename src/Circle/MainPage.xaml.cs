using SkiaSharp.Views.Maui.Controls;
using SkiaSharp;
using System.Reflection;
using SkiaSharp.Extended.Svg;
using Svg.Skia;
using System.Xml;

namespace Circle
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private string _svgString = 
            """
              <svg viewBox="0 0 40 40" width="200" height="200" style="background-color: transparent;">
                  <circle class="track-ring" cx="20" cy="20" r="15.91549430918954"
                      stroke="lightgray" fill="none" stroke-width="5" stroke-alignment="center"></circle>

                  <circle class="progress-ring" cx="20" cy="20" r="15.91549430918954"
                      stroke="red" fill="none" stroke-width="5" stroke-dashoffset="25" stroke-dasharray="40 60"
                      stroke-alignment="center" stroke-linecap="round"></circle>
            </svg>
            """;

        private SkiaSharp.Extended.Svg.SKSvg _svg = new SkiaSharp.Extended.Svg.SKSvg();
        public MainPage()
        {
            InitializeComponent();

            XmlReader reader = XmlReader.Create(new StringReader(_svgString));
            _svg.Load(reader);

        }

        private void CanvasView_PaintSurface(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear();

            var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.Red
            };

            canvas.DrawPicture(_svg.Picture, paint);
        }
    }
}
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gradient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Title = "Gradient";
            //Вид, который можно рисовать с помощью команд рисования SkiaSharp
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSerface;
            Content = canvasView;
            InitializeComponent();
        }

        void OnCanvasViewPaintSerface(object sender, SKPaintSurfaceEventArgs args)
        {
            //информацию о рисуемой в данный момент поверхности
            SKImageInfo info = args.Info;
            //поверхность, на которой в данный момент рисуется
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            //new SKPoint(rect.Left, rect.Top),
            //new SKPoint(rect.Right, rect.Bottom),
            using (SKPaint paint = new SKPaint())
            {
                paint.Shader = SKShader.CreateLinearGradient(
                    //SkPoint - cоздает новый экземпляр точки с указанными координатами.
                    //начальная точка
                    new SKPoint(0, 0),
                    //конечная точка
                    new SKPoint(info.Width, info.Height),
                    new SKColor[] { SKColors.Blue, SKColors.White },
                    //расположение цветов в линии градиента
                    new float[] { 0, 1 },
                    SKShaderTileMode.Repeat);
                canvas.DrawRect(info.Rect, paint);
            }
        }
    }
}

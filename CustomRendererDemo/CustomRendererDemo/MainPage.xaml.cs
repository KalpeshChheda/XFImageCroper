using System;
using System.Collections.Generic;
using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using CustomRendererDemo.Interface;
using System.IO;

namespace CustomRendererDemo
{
    public partial class MainPage : ContentPage
    {
        SKBitmap _bitmap;
        private readonly Random random = new Random();
        SKPath path2;
        private SKRect rectangle2;
        private SKRect squareleft;
        private SKRect squaretop;
        private SKRect squareright;
        private SKRect squarebottom;
        int strokeWidth = 3;
        private bool onMove = false;
        private bool leftPress = false;
        private bool bottomPress = false;
        private bool rightPress = false;
        private bool topPress = false;
        float cX;
        float cY;
        float newCX = 0;
        float newCY = 0;
        float rleft = 0;
        float rtop = 0;
        float rright = 0;
        float rbottom = 0;
        public MainPage()
        {
            InitializeComponent();

            path2 = new SKPath();
            rectangle2 = SKRect.Create(100, 100, 400, 400);
            squareleft = SKRect.Create(rectangle2.Left + 5, rectangle2.Top + 5, 40, 40);
            squareright = SKRect.Create(rectangle2.Right - 45, rectangle2.Bottom - 45, 40, 40);
            squaretop = SKRect.Create(rectangle2.Right - 45, rectangle2.Top + 5, 40, 40);
            squarebottom = SKRect.Create(rectangle2.Left + 5, rectangle2.Bottom - 45, 40, 40);
        }

        private void canvasView_Released(SKPoint mousePoint)
        {
            leftPress = false;
            bottomPress = false;
            rightPress = false;
            topPress = false;
            onMove = false;
        }
        private void canvasView_Pressed(SKPoint mousePoint)
        {
            cX = mousePoint.X;
            cY = mousePoint.Y;


            rleft = rectangle2.Left;
            rtop = rectangle2.Top;
            rright = rectangle2.Right;
            rbottom = rectangle2.Bottom;
            if (mousePoint.X > squareleft.Left && mousePoint.Y > squareleft.Top && mousePoint.X < (squareleft.Left + squareleft.Width) && mousePoint.Y < (squareleft.Top + squareleft.Height))
            {
                leftPress = true;
            }
            else if (mousePoint.X < squareright.Right && mousePoint.Y < squareright.Bottom && mousePoint.X > (squareright.Right - squareright.Width) && mousePoint.Y > (squareright.Bottom - squareright.Height))
            {
                bottomPress = true;
            }
            else if (mousePoint.X < squaretop.Right && mousePoint.Y > squaretop.Top && mousePoint.X > (squaretop.Right - squaretop.Width) && mousePoint.Y < (squaretop.Top + squaretop.Height))
            {
                rightPress = true;
            }
            else if (mousePoint.X > squarebottom.Left && mousePoint.Y < squarebottom.Bottom && mousePoint.X < (squarebottom.Left + squarebottom.Width) && mousePoint.Y > (squarebottom.Bottom - squarebottom.Height))
            {
                topPress = true;
            }

            if (mousePoint.X > rectangle2.Left && mousePoint.Y > rectangle2.Top && mousePoint.X < (rectangle2.Left + rectangle2.Width) && mousePoint.Y < (rectangle2.Top + rectangle2.Height))
            {
                if (topPress == false && rightPress == false && bottomPress == false && leftPress == false)
                {
                    onMove = true;
                }
            }

            canvasView.InvalidateSurface();
        }
        private void canvasView_Moved(SKPoint mousePoint)
        {
            if (leftPress)
            {
                if (cX > mousePoint.X)
                {
                    newCX = cX - mousePoint.X;
                    rectangle2.Left = rleft - newCX;
                }
                else
                {
                    newCX = mousePoint.X - cX;
                    rectangle2.Left = rleft + newCX;
                }
                if (cY > mousePoint.Y)
                {
                    newCY = cY - mousePoint.Y;
                    rectangle2.Top = rtop - newCY;
                }
                else
                {
                    newCY = mousePoint.Y - cY;
                    rectangle2.Top = rtop + newCY;
                }
            }
            if (bottomPress)
            {
                if (cX > mousePoint.X)
                {
                    newCX = cX - mousePoint.X;
                    rectangle2.Right = rright - newCX;
                }
                else
                {
                    newCX = mousePoint.X - cX;
                    rectangle2.Right = rright + newCX;
                }
                if (cY > mousePoint.Y)
                {
                    newCY = cY - mousePoint.Y;
                    rectangle2.Bottom = rbottom - newCY;
                }
                else
                {
                    newCY = mousePoint.Y - cY;
                    rectangle2.Bottom = rbottom + newCY;
                }
            }
            if (rightPress)
            {
                if (cX > mousePoint.X)
                {
                    newCX = cX - mousePoint.X;
                    rectangle2.Right = rright - newCX;
                }
                else
                {
                    newCX = mousePoint.X - cX;
                    rectangle2.Right = rright + newCX;
                }
                if (cY > mousePoint.Y)
                {
                    newCY = cY - mousePoint.Y;
                    rectangle2.Top = rtop - newCY;
                }
                else
                {
                    newCY = mousePoint.Y - cY;
                    rectangle2.Top = rtop + newCY;
                }
            }
            if (topPress)
            {
                if (cX > mousePoint.X)
                {
                    newCX = cX - mousePoint.X;
                    rectangle2.Left = rleft - newCX;
                }
                else
                {
                    newCX = mousePoint.X - cX;
                    rectangle2.Left = rleft + newCX;
                }
                if (cY > mousePoint.Y)
                {
                    newCY = cY - mousePoint.Y;
                    rectangle2.Bottom = rbottom - newCY;
                }
                else
                {
                    newCY = mousePoint.Y - cY;
                    rectangle2.Bottom = rbottom + newCY;
                }
            }
            if (onMove)
            {
                if (cX > mousePoint.X)
                {
                    newCX = cX - mousePoint.X;
                    rectangle2.Left = rleft - newCX;
                    rectangle2.Right = rright - newCX;
                }
                else
                {
                    newCX = mousePoint.X - cX;
                    rectangle2.Left = rleft + newCX;
                    rectangle2.Right = rright + newCX;
                }
                if (cY > mousePoint.Y)
                {
                    newCY = cY - mousePoint.Y;
                    rectangle2.Bottom = rbottom - newCY;
                    rectangle2.Top = rtop - newCY;

                }
                else
                {
                    newCY = mousePoint.Y - cY;
                    rectangle2.Bottom = rbottom + newCY;
                    rectangle2.Top = rtop + newCY;
                }
            }
            squareleft = SKRect.Create(rectangle2.Left + 5, rectangle2.Top + 5, 40, 40);
            squareright = SKRect.Create(rectangle2.Right - 45, rectangle2.Bottom - 45, 40, 40);
            squaretop = SKRect.Create(rectangle2.Right - 45, rectangle2.Top + 5, 40, 40);
            squarebottom = SKRect.Create(rectangle2.Left + 5, rectangle2.Bottom - 45, 40, 40);
            canvasView.InvalidateSurface();
        }
        protected override void OnAppearing()
        {
            Stream FileStream = DependencyService.Get<ImageFile>().readFile("Assets/flower.jpg");
            using (var stream = new SKManagedStream(FileStream))
            {
                _bitmap = SKBitmap.Decode(stream);
            }
            base.OnAppearing(); 
        }
        private void OnPainting(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            var canvas = e.Surface.Canvas;
            canvas.Clear(SKColors.White);
            
            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = 2;
                paint.Color = Color.Black.ToSKColor();
                
                canvas.DrawBitmap(_bitmap, SKRect.Create(_bitmap.Width, _bitmap.Height), paint);

                canvas.DrawRect(rectangle2, paint);

                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = strokeWidth;
                paint.Color = Color.Black.ToSKColor();
                if (path2 != null)
                {
                    canvas.DrawPath(path2, paint);
                }
                paint.Style = SKPaintStyle.Stroke;
                paint.StrokeWidth = strokeWidth;
                paint.Color = Color.Black.ToSKColor();
                if (path2 != null)
                {
                    canvas.DrawRect(squareleft, paint);
                    canvas.DrawRect(squareright, paint);
                    canvas.DrawRect(squaretop, paint);
                    canvas.DrawRect(squarebottom, paint);
                }
                canvas.DrawPositionedText("TA", new SKPoint[] { new SKPoint(cX, cY) }, paint);
            };

        }

        private void Crop_Clicked(object sender, EventArgs e)
        {
            CropImage.cropImage(rectangle2);
        }
    }
}

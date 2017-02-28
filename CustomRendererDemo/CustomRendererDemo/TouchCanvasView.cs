using System;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace CustomRendererDemo
{
	public class TouchCanvasView : SKCanvasView, ITouchCanvasViewController
	{
		
        public event Action<SKPoint> Pressed;
        public event Action<SKPoint> Moved;
        public event Action<SKPoint> Released;
        public void OnMove(SKPoint rect)
        {
            Moved?.Invoke(rect);
        }

        public void OnPress(SKPoint rect)
        {
            Pressed?.Invoke(rect);
        }

        public void OnRelease(SKPoint rect)
        {
            Released?.Invoke(rect);
        }
	}

	public interface ITouchCanvasViewController : IViewController
	{
        void OnRelease(SKPoint point);
        void OnMove(SKPoint point);
        void OnPress(SKPoint point);
    }
}

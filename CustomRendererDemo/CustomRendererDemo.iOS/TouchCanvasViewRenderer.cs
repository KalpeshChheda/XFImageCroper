using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

using SkiaSharp;
using SkiaSharp.Views.iOS;
using SkiaSharp.Views.Forms;

[assembly: ExportRenderer(typeof(CustomRendererDemo.TouchCanvasView), typeof(CustomRendererDemo.iOS.TouchCanvasViewRenderer))]

namespace CustomRendererDemo.iOS
{
	public class TouchCanvasViewRenderer : SKCanvasViewRenderer
	{
		private readonly UIPanGestureRecognizer panGestureRecognizer;

		public TouchCanvasViewRenderer()
		{
			panGestureRecognizer = new UIPanGestureRecognizer(OnMoved);
		}


        protected override void OnElementChanged(ElementChangedEventArgs<SkiaSharp.Views.Forms.SKCanvasView> e)
		{
			// clean up old native control
			if (Control != null)
			{
				Control.RemoveGestureRecognizer(panGestureRecognizer);
			}

			// do clean up old element
			if (Element != null)
			{
				var oldTouchCanvas = (TouchCanvasView)Element;
				var oldTouchController = (ITouchCanvasViewController)Element;

				// ...
			}

			base.OnElementChanged(e);

			// set up new native control
			if (Control != null)
			{
				Control.UserInteractionEnabled = true;
				Control.AddGestureRecognizer(panGestureRecognizer);
			}

			// set up new element
			if (e.NewElement != null)
			{
				var newTouchCanvas = (TouchCanvasView)Element;
				var newTouchController = (ITouchCanvasViewController)Element;

				// ...
			}
		}

        private void OnMoved(UIPanGestureRecognizer recognizer)
        {
            var touchController = Element as ITouchCanvasViewController;

            if (recognizer.State == UIGestureRecognizerState.Changed)
            {
                touchController.OnMove(recognizer.LocationInView(Control).ToSKPoint());
            }
            if (recognizer.State == UIGestureRecognizerState.Began)
            {
                touchController.OnPress(recognizer.LocationInView(Control).ToSKPoint());
            }
            if (recognizer.State == UIGestureRecognizerState.Ended)
            {
                touchController.OnRelease(recognizer.LocationInView(Control).ToSKPoint());
            }
        }


        //      private void OnTapped(UITapGestureRecognizer recognizer)
        //{
        //	var touchController = Element as ITouchCanvasViewController;
        //	if (touchController != null)
        //	{
        //		touchController.OnPress(recognizer.LocationInView(Control).ToSKPoint());

        //	}
        //}
    }
}

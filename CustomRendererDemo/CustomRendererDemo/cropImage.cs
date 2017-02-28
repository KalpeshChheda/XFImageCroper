using CustomRendererDemo.Interface;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomRendererDemo
{
   public static class CropImage
    {
        public static void cropImage(SKRect rect)
        {
            SKBitmap resized = null;
            using (var input = DependencyService.Get<ImageFile>().readFile("flower.jpg"))
            {
                using (var inputStream = new SKManagedStream(input))
                {
                    var original = SKBitmap.Decode(inputStream);
                    int x = 0, y = 0, len = 0;
                    if (original.Width > original.Height)
                    {
                        x = (original.Width - original.Height) / 2;
                        len = original.Height;
                    }
                    else
                    {
                        y = (original.Width - original.Height) / 2;
                        len = original.Height;
                    }
                    using (var bitmap = new SKBitmap(new SKImageInfo(len, len)))
                    {
                        var ok = original.ExtractSubset(bitmap, SKRectI.Create((int)rect.Left, (int)rect.Top, (int)rect.Width, (int)rect.Height));
                        try
                        {
                            resized = bitmap;
                        }
                        catch (Exception e)
                        {
                            throw;
                        }
                        DependencyService.Get<ImageFile>().wirteFile(resized);
                    }
                }
            }
        }
    }
}

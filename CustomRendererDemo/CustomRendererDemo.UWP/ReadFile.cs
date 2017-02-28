using CustomRendererDemo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using CustomRendererDemo.UWP;
using SkiaSharp;
using Windows.Storage;

[assembly: Dependency(typeof(ReadFile))]
namespace CustomRendererDemo.UWP
{
    public class ReadFile : ImageFile
    {
        public Stream readFile(string path)
        {
            var imagedata = File.OpenRead(path);
            return imagedata;
        }

        public void wirteFile(SKBitmap resized)
        {
            using (var output = File.OpenWrite(ApplicationData.Current.LocalFolder.Path + "\\" + "imagesC2UXOO7F(Converted).jpg"))
            {
                using (var image = SKImage.FromBitmap(resized))
                {
                    using (output)
                    {
                        image.Encode(SKImageEncodeFormat.Jpeg, 75).SaveTo(output);
                    }
                }
            }
        }
    }
}

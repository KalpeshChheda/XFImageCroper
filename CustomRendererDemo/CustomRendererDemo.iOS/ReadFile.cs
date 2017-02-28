using CustomRendererDemo.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Xamarin.Forms;
using CustomRendererDemo.iOS;
using SkiaSharp;

[assembly: Dependency(typeof(ReadFile))]
namespace CustomRendererDemo.iOS
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
            var Imgfile = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            using (var output = File.OpenWrite(Imgfile + "\\" + "imagesC2UXOO7F(Converted).jpg"))

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

using SkiaSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomRendererDemo.Interface
{
    public interface  ImageFile
    {
        Stream readFile(string path);
        void wirteFile(SKBitmap resized);
    }
}

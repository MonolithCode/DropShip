using System.Collections.Generic;
using System.Drawing;
using System.IO;
using ImageResizer;

namespace MonolithDS.Image
{
    public interface IImageHelper
    {
        FitMode Mode { get; set; }
        SearchOption DirectoryMode { get; set; }
        SaveMode SaveOption { get; set; }
        string SaveExtension { get; set; }
        string AltSaveLocation { get; set; }
            
        ImageHistroy AdjustImage(string imagePath, int maxWidth, int maxHeight);
        List<ImageHistroy> ReduceDirectoryImages(string path, int maxWidth, int maxHeight);
    }
}
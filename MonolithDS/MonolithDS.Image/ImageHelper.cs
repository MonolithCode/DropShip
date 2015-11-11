using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using ImageResizer;

namespace MonolithDS.Image
{
    public class ImageHelper : IImageHelper
    {
        public FitMode Mode { get; set; }
        public SearchOption DirectoryMode { get; set; }
        public SaveMode SaveOption { get; set; }
        public string SaveExtension { get; set; }
        public string AltSaveLocation { get; set; }

        public ImageHelper(FitMode mode = FitMode.Max, SearchOption directoryMode = SearchOption.TopDirectoryOnly, 
            SaveMode saveOption = SaveMode.Overwrite)
        {
            Mode = mode;
            DirectoryMode = directoryMode;
            SaveOption = saveOption;
            SaveExtension = "jpg";
        }
        
        /// <summary>
        /// Reduce the size of images in a directory
        /// </summary>
        /// <param name="path">Directory Path</param>
        /// <param name="maxWidth">Max Width</param>
        /// <param name="maxHeight">Max Height</param>
        /// <returns></returns>
        public List<ImageHistroy> ReduceDirectoryImages(string path, int maxWidth, int maxHeight)
        {
            if (SaveOption == SaveMode.SaveAs && string.IsNullOrEmpty(AltSaveLocation)){
                throw new NotImplementedException("AltSaveLocation");
            }

            var files = Directory.GetFiles(path, "*." + SaveExtension, DirectoryMode);
            return files.Select(file => AdjustImage(file, maxWidth, maxHeight)).ToList();
        }

        /// <summary>
        /// Get file details
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private ImageHistroy GetFileInfo(string path)
        {
            var ih = new ImageHistroy
            {
                ImageName = Path.GetFileName(path),
                Location = Path.GetFullPath(path),
                OldSize = new FileInfo(path).Length
            };

            return ih;
        }

        /// <summary>
        /// Resize the image
        /// </summary>
        /// <param name="file"></param>
        /// <param name="maxWidth"></param>
        /// <param name="maxHeight"></param>
        /// <returns></returns>
        public ImageHistroy AdjustImage(string file, int maxWidth, int maxHeight)
        {
            if (SaveOption == SaveMode.SaveAs && string.IsNullOrEmpty(AltSaveLocation))
            {
                throw new NotImplementedException("AltSaveLocation");
            }

            var image = GetFileInfo(file);
            switch (SaveOption)
            {
                case SaveMode.Overwrite:
                    ImageBuilder.Current.Build(file, file, new ResizeSettings(maxWidth, maxHeight, Mode, SaveExtension));
                    image.NewSize = new FileInfo(file).Length;
                    image.NewLocation = image.Location;
                    image.Image = new Bitmap(file);
                    break;
                case SaveMode.SaveAs:
                    ImageBuilder.Current.Build(file, Path.Combine(AltSaveLocation, image.ImageName), new ResizeSettings(maxWidth, maxHeight, Mode, SaveExtension));
                    image.NewSize = new FileInfo(Path.Combine(AltSaveLocation, image.ImageName)).Length;
                    image.NewLocation = Path.Combine(AltSaveLocation, image.ImageName);
                    image.Image = new Bitmap(Path.Combine(AltSaveLocation, image.ImageName));
                    break;
            }

            return image;
        }
    }
}

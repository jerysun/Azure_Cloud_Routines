using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace FARescalePics
{
    public static class FRescalePics
    {
        [FunctionName("FRescalePic")]
        public static void Run([BlobTrigger("pics/{name}", Connection = "AzureWebJobsStorage")]Stream pic, 
            [Blob("pics-sm/{name}", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream picSmall,
            [Blob("pics-md/{name}", FileAccess.Write, Connection = "AzureWebJobsStorage")] Stream picMedium)
        {
            IImageFormat format;

            using (Image<Rgba32> input = Image.Load<Rgba32>(pic, out format))
            {
                RescalePic(input, picSmall, PicSize.Small, format);
            }

            pic.Position = 0;
            using (Image<Rgba32> input = Image.Load<Rgba32>(pic, out format))
            {
                RescalePic(input, picMedium, PicSize.Medium, format);
            }
        }

        public static void RescalePic(Image<Rgba32> input, Stream output, PicSize size, IImageFormat format)
        {
            var dimensions = picDimensions[size];

            input.Mutate(x => x.Resize(dimensions.Item1, dimensions.Item2));
            input.Save(output, format);
        }
        public enum PicSize { ExtraSmall, Small, Medium }

        private static Dictionary<PicSize, (int, int)> picDimensions = new Dictionary<PicSize, (int, int)>() {
            {PicSize.ExtraSmall, (320, 200) },
            {PicSize.Small, (640, 400) },
            {PicSize.Medium, (800, 600) }
        };
    }
}

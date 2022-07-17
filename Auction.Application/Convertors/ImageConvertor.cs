using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Auction.Application.Convertors
{
    public class ImageConvertor
    {
        public void Image_resize(string inputImagePath, string outputImagePath, int newWidth)
        {

            const long quality = 50L;

            Bitmap sourceBitmap = new Bitmap(inputImagePath);

            double dblWidthOriginal = sourceBitmap.Width;

            double dblHeightOriginal = sourceBitmap.Height;

            double relationHeightWidth = dblHeightOriginal / dblWidthOriginal;

            int newHeight = (int)(newWidth * relationHeightWidth);

            var newDrawArea = new Bitmap(newWidth, newHeight);

            using (var graphicOfDrawArea = Graphics.FromImage(newDrawArea))

            {
                graphicOfDrawArea.CompositingQuality = CompositingQuality.HighSpeed;

                graphicOfDrawArea.InterpolationMode = InterpolationMode.HighQualityBicubic;

                graphicOfDrawArea.CompositingMode = CompositingMode.SourceCopy;

                graphicOfDrawArea.DrawImage(sourceBitmap, 0, 0, newWidth, newHeight);

                using (var output = System.IO.File.Open(outputImagePath, FileMode.Create))

                {
                    var qualityParamId = System.Drawing.Imaging.Encoder.Quality;

                    var encoderParameters = new EncoderParameters(1);

                    encoderParameters.Param[0] = new EncoderParameter(qualityParamId, quality);

                    var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(c => c.FormatID == ImageFormat.Jpeg.Guid);

                    newDrawArea.Save(output, codec, encoderParameters);

                    output.Close();

                }
                graphicOfDrawArea.Dispose();
            }

            sourceBitmap.Dispose();
        }

        public bool CheckImage(IFormFile file,int checkW,int checkH)
        {

            var folderName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/check");

            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);



            var name = Generator.Generator.GenerateUniqCode() + Path.GetExtension(file.FileName);
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/check", name);
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Bitmap bitmap = new Bitmap(imagePath);
            int iWidth = bitmap.Width;
            int iHeight = bitmap.Height;
            bitmap.Dispose();
            if (iHeight==checkH&&iWidth==checkW)
            {
                File.Delete(imagePath);
                return true;
            }

            File.Delete(imagePath);
            return false;
        }
    }
}

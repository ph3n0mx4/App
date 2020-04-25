using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data
{
    public class CloudinaryService : ICloudinaryService
    {
        public async Task<string> UploadAsyncFile(Cloudinary cloudinary, IFormFile file)
        {
            var image = string.Empty;

            byte[] destinationImage;

            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                destinationImage = memoryStream.ToArray();
            }

            using (var destinationStream = new MemoryStream(destinationImage))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, destinationStream),
                };

                var result = await cloudinary.UploadAsync(uploadParams);

                image = result.Uri.AbsolutePath;
            }

            return image;
        }

        public async Task<IEnumerable<string>> UploadAsyncFiles(Cloudinary cloudinary, IEnumerable<IFormFile> files)
        {
            var images = new List<string>();

            foreach (var file in files)
            {
                byte[] destinationImage;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    destinationImage = memoryStream.ToArray();
                }

                using (var destinationStream = new MemoryStream(destinationImage))
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, destinationStream),
                    };

                    var result = await cloudinary.UploadAsync(uploadParams);

                    images.Add(result.Uri.AbsolutePath);
                }
            }

            return images;
        }
    }
}

namespace CarSalesApp.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Http;

    public interface ICloudinaryService
    {
        Task<IEnumerable<string>> UploadAsyncFiles(Cloudinary cloudinary, IEnumerable<IFormFile> files);

        Task<string> UploadAsyncFile(Cloudinary cloudinary, IFormFile file);
    }
}

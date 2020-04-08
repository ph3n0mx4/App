using System.Collections.Generic;
using System.Threading.Tasks;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;

namespace CarSalesApp.Services.Data
{
    public interface ICloudinaryService
    {
        Task<IEnumerable<string>> UploadAsync(Cloudinary cloudinary, ICollection<IFormFile> files);
    }
}

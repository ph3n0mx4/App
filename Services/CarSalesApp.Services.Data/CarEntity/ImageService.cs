using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data.CarEntity
{
    public class ImageService : IImageService
    {
        private readonly IDeletableEntityRepository<Image> imageRepository;

        public ImageService(IDeletableEntityRepository<Image> imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        public async Task<int> AddAsync(int carId, string url)
        {
            var image = new Image
            {
                Url = url,
                CarId = carId,
            };

            await this.imageRepository.AddAsync(image);
            await this.imageRepository.SaveChangesAsync();
            return image.Id;
        }
    }
}

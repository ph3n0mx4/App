using CarSalesApp.Data.Common.Repositories;
using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using CarSalesApp.Services.Data.CarEntity;
using CarSalesApp.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesApp.Services.Data
{
    public class CarService : ICarService
    {
        private IDeletableEntityRepository<Car> carRepository;
        private IDeletableEntityRepository<Feature> featureRepository;
        private readonly IImageService imageService;

        public CarService(IDeletableEntityRepository<Car> carRepository, IDeletableEntityRepository<Feature> featureRepository, IImageService imageService)
        {
            this.carRepository = carRepository;
            this.featureRepository = featureRepository;
            this.imageService = imageService;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Car> query = this.carRepository.All();

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public async Task<int> AddAsync(int makeId, int modelId, int driveId, int bodyId, MonthsOfYear month, int year, int fuelId, ColorType color, ICollection<int> inputFeatures, IEnumerable<string> inputImages, int mileage, decimal price, string inputMainImage, string description)
        {
            var car = new Car
            {
                MakeId = makeId,
                ModelId = modelId,
                DriveId = driveId,
                BodyId = bodyId,
                FirstRegistration = new DateTime(year, (int)month, 1),
                Color = color,
                Price = price,
                Mileage = mileage,
                MainImage = inputMainImage,
                Description = description,
            };

            foreach (var imageUrl in inputImages)
            {
                var image = new Image
                {
                    Url = imageUrl,
                    Car = car,
                };

                car.Images.Add(image);
            }

            foreach (var featureId in inputFeatures)
            {
                var feature = this.featureRepository.All().FirstOrDefault(x => x.Id == featureId);

                if (feature == null)
                {
                    continue;
                }

                car.CarsFeatures.Add(new CarFeature
                {
                    Car = car,
                    Feature = feature,
                });
            }

            await this.carRepository.AddAsync(car);
            await this.carRepository.SaveChangesAsync();
            return car.Id;
        }
    }
}

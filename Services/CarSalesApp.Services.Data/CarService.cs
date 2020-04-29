namespace CarSalesApp.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarSalesApp.Data.Common.Repositories;
    using CarSalesApp.Data.Models;
    using CarSalesApp.Data.Models.Enums;
    using CarSalesApp.Services.Mapping;

    public class CarService : ICarService
    {
        private IDeletableEntityRepository<Car> carRepository;
        private IDeletableEntityRepository<Feature> featureRepository;
        private readonly IDeletableEntityRepository<CarFeature> carFeatureRepository;

        public CarService(IDeletableEntityRepository<Car> carRepository, IDeletableEntityRepository<Feature> featureRepository, IDeletableEntityRepository<CarFeature> carFeatureRepository)
        {
            this.carRepository = carRepository;
            this.featureRepository = featureRepository;
            this.carFeatureRepository = carFeatureRepository;
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

        public async Task<int> AddAsync(int makeId, int modelId, int driveId, int bodyId, MonthsOfYear month, int year, ColorType color, ICollection<int> inputFeatures, IEnumerable<string> inputImages, int mileage, decimal price, string inputMainImage, string description, string userId)
        {
            var car = new Car
            {
                UserId = userId,
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

        public T GetById<T>(int id)
        {
            var model = this.carRepository.All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();
            return model;
        }

        public async Task<int> EditAsync(int carId, int makeId, int modelId, int driveId, int bodyId, MonthsOfYear month, int year, ColorType color, ICollection<int> inputFeatures, int mileage, decimal price, string description)
        {
            var car = this.carRepository.All().FirstOrDefault(m => m.Id == carId);

            car.MakeId = makeId;
            car.ModelId = modelId;
            car.DriveId = driveId;
            car.BodyId = bodyId;
            car.FirstRegistration = new DateTime(year, (int)month, 1);
            car.Color = color;
            car.Mileage = mileage;
            car.Price = price;
            car.Description = description;

            var currentFeatures = this.carFeatureRepository.All().Where(x => x.CarId == carId);
            foreach (var item in currentFeatures)
            {
                this.carFeatureRepository.HardDelete(item);
            }

            await this.carFeatureRepository.SaveChangesAsync();

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

            this.carRepository.Update(car);
            await this.carRepository.SaveChangesAsync();
            return car.Id;
        }
    }
}

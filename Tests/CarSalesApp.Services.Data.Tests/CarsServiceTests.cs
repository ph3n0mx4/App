using CarSalesApp.Data.Models;
using CarSalesApp.Data.Models.Enums;
using CarSalesApp.Web.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CarSalesApp.Services.Mapping;

namespace CarSalesApp.Services.Data.Tests
{
    public class CarsServiceTests : BaseServiceTests
    {
        private Car test1;
        private Make test2;
        private Model test3;
        private Body test4;
        private Drive test5;
        private Feature test6;
        private Feature test7;
        private Feature test8;
        private FeatureType test9;

        public CarsServiceTests()
        {
            this.InitializeFields();
        }

        [Fact]
        public async Task AddAsyncWorkCorrectly()
        {
            await this.SeedDatabase();

            //var actualModelId = await this.CarsService.AddAsync(10, 11, 13, 12, (MonthsOfYear)1, 2002, (ColorType)1, new List<int> { 1, 2, 3 }, new List<string> { "image1", "image2", }, 1000000, 9999.99m, "MainImage1", "Description1");

            var expectedModelId = this.CarsRepository.All()
                .Where(x => x.MakeId == 10 && x.ModelId == 11 && x.DriveId == 13 && x.BodyId == 12 && x.MainImage == "MainImage1" && x.Description == "Description1" && x.Price == 9999.99m && x.Mileage == 1000000 && x.FirstRegistration.Year == 2002 && x.FirstRegistration.Month == 1)
                .Select(x => x.Id).FirstOrDefault();

            //Assert.Equal(expectedModelId, actualModelId);
        }

        [Theory]
        [InlineData(999999)]
        public async Task GetByIdReturnModel(int id)
        {
            await this.SeedDatabase();

            var actualModel = this.CarsService.GetById<CarAdDetailsViewModel>(id);

            var expectedModel = this.CarsRepository.All()
                .Where(x => x.Id == id)
                .To<CarAdDetailsViewModel>()
                .FirstOrDefault();

            Assert.Equal(expectedModel.PowerDescription, actualModel.PowerDescription);
            Assert.Equal(expectedModel.Id, actualModel.Id);
        }

        [Fact]
        public async Task GetAllReturnWholeCount()
        {//zaradi userId
            await this.SeedDatabase();
            //var actualModelId = await this.CarsService.AddAsync(10, 11, 13, 12, (MonthsOfYear)1, 2002, (ColorType)1, new List<int> { 1, 2, 3 }, new List<string> { "image1", "image2", }, 1000000, 9999.99m, "MainImage1", "Description1");

            var actualCarsCount = this.CarsService.GetAll<CarAdDetailsViewModel>().Count();
            var expectedCarsCount = this.CarsRepository.All().ToList().Count();

            Assert.Equal(expectedCarsCount, actualCarsCount);
            Assert.Equal(2, actualCarsCount);
        }
        private void InitializeFields()
        {
            this.test1 = new Car
            {
                Id = 999999,
                MakeId = 10,
                ModelId = 11,
                DriveId = 13,
                BodyId = 12,
                FirstRegistration = new DateTime(2002, 1, 1),
                Color = (ColorType)1,
                Price = 9999.99m,
                Mileage = 1000000,
                MainImage = "MainImage",
                Description = "Description",
            };

            this.test2 = new Make
            {
                Id = 10,
                Name = "Opel",
            };

            this.test3 = new Model
            {
                Id = 11,
                Name = "Astra",
                MakeId = 10,
            };

            this.test4 = new Body
            {
                Id = 12,
                Category = (CategoryType)1,
                Seats = 4,
                Doors = (DoorType)1,
            };

            this.test5 = new Drive
            {
                Id = 13,
                ModelId = 11,
                Fuel = (FuelType)1,
                Displacement = 9999,
                Power = 8888,
                GearType = (GearType)1,
                Gear = 5,
                YearFrom = new DateTime(2002, 1, 1),
                YearTo = new DateTime(2002, 1, 1),
            };

            this.test6 = new Feature
            {
                Id = 1,
                TypeId = 1,
            };

            this.test7 = new Feature
            {
                Id = 2,
                TypeId = 1,
            };

            this.test8 = new Feature
            {
                Id = 3,
                TypeId = 1,
            };

            this.test9 = new FeatureType
            {
                Id = 1,
                Name = "a",
            };
        }


        private async Task SeedDatabase()
        {
            await this.CarsRepository.AddAsync(this.test1);
            await this.MakesRepository.AddAsync(this.test2);
            await this.ModelsRepository.AddAsync(this.test3);
            await this.BodiesRepository.AddAsync(this.test4);
            await this.DrivesRepository.AddAsync(this.test5);
            await this.FeaturesRepository.AddAsync(this.test6);
            await this.FeaturesRepository.AddAsync(this.test7);
            await this.FeaturesRepository.AddAsync(this.test8);
            await this.FeatureTypesRepository.AddAsync(this.test9);
            await this.MakesRepository.SaveChangesAsync();
            await this.ModelsRepository.SaveChangesAsync();
            await this.BodiesRepository.SaveChangesAsync();
            await this.DrivesRepository.SaveChangesAsync();
            await this.FeatureTypesRepository.SaveChangesAsync();
            await this.FeaturesRepository.SaveChangesAsync();
            await this.CarsRepository.SaveChangesAsync();
        }
    }
    
}

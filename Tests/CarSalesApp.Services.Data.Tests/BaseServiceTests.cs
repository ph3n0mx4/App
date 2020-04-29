using CarSalesApp.Data;
using CarSalesApp.Data.Models;
using CarSalesApp.Data.Repositories;
using CarSalesApp.Data.Seeding;
using CarSalesApp.Services.Data.CarEntity;
using CarSalesApp.Services.Mapping;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CarSalesApp.Services.Data.Tests
{
    public abstract class BaseServiceTests : IDisposable
    {
        public BaseServiceTests()
        {
            this.InitializeMapper();
            this.InitializeDatabaseAndRepositories();
            this.MakesService = new MakeCarService(this.MakesRepository);
            this.ModelsService = new ModelCarService(this.ModelsRepository);
            this.BodiesService = new BodyCarService(this.BodiesRepository);
            this.DrivesService = new EngineService(this.DrivesRepository);
            this.ImagesService = new ImageService(this.ImagesRepository);
            this.CarsService = new CarService(this.CarsRepository, this.FeaturesRepository, this.CarsFeaturessRepository);

        }

        public SqliteConnection Connection { get; set; }

        protected MakeCarService MakesService { get; set; }

        protected EfDeletableEntityRepository<Make> MakesRepository { get; set; }

        protected ModelCarService ModelsService { get; set; }

        protected EfDeletableEntityRepository<Model> ModelsRepository { get; set; }

        protected CarService CarsService { get; set; }

        protected EfDeletableEntityRepository<Car> CarsRepository { get; set; }

        protected FeatureService FeaturesService { get; set; }

        protected EfDeletableEntityRepository<Feature> FeaturesRepository { get; set; }

        protected EfDeletableEntityRepository<FeatureType> FeatureTypesRepository { get; set; }

        protected BodyCarService BodiesService { get; set; }

        protected EfDeletableEntityRepository<Body> BodiesRepository { get; set; }

        protected EngineService DrivesService { get; set; }

        protected EfDeletableEntityRepository<Drive> DrivesRepository { get; set; }

        protected ImageService ImagesService { get; set; }

        protected EfDeletableEntityRepository<Image> ImagesRepository { get; set; }

        protected EfDeletableEntityRepository<CarFeature> CarsFeaturessRepository { get; set; }

        public void Dispose()
        {
            this.Connection.Close();
            this.Connection.Dispose();
        }

        private void InitializeDatabaseAndRepositories()
        {
            this.Connection = new SqliteConnection("DataSource=:memory:");
            this.Connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(this.Connection);
            var dbContext = new ApplicationDbContext(options.Options);

            dbContext.Database.EnsureCreated();

            this.CarsRepository = new EfDeletableEntityRepository<Car>(dbContext);
            this.MakesRepository = new EfDeletableEntityRepository<Make>(dbContext);
            this.ModelsRepository = new EfDeletableEntityRepository<Model>(dbContext);
            this.FeaturesRepository = new EfDeletableEntityRepository<Feature>(dbContext);
            this.FeatureTypesRepository = new EfDeletableEntityRepository<FeatureType>(dbContext);
            this.BodiesRepository = new EfDeletableEntityRepository<Body>(dbContext);
            this.DrivesRepository = new EfDeletableEntityRepository<Drive>(dbContext);
            this.ImagesRepository = new EfDeletableEntityRepository<Image>(dbContext);
            this.CarsFeaturessRepository = new EfDeletableEntityRepository<CarFeature>(dbContext);
        }

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("CarSalesApp.Web.ViewModels"));
    }
}

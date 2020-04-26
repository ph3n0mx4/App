namespace CarSalesApp.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using CarSalesApp.Data;
    using CarSalesApp.Data.Models;
    using CarSalesApp.Data.Repositories;
    using CarSalesApp.Services.Mapping;
    using CarSalesApp.Web.ViewModels.Cars;
    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using Xunit;

    public class MakesServiceTests
    {
        private EfDeletableEntityRepository<Make> makesRepository;
        private MakeCarService makesService;
        private Make testMake1;
        private Make testMake2;

        public MakesServiceTests()
        {
            this.InitializeMapper();
            this.InitializeDatabaseAndRepositories();
            this.InitializeFields();
            this.makesService = new MakeCarService(this.makesRepository);
        }

        [Fact]
        public async Task AddAsyncAddFewMakes()
        {
            for (int i = 0; i < 3; i++)
            {
                await this.makesService.AddAsync($"BMW{i}");
            }

            var isSuccessful = this.makesRepository.All().Count() == 3;

            Assert.True(isSuccessful);
        }

        [Fact]
        public async Task AddAsyncReturnMakeIdAfterAdd()
        {
            var makeId = await this.makesService.AddAsync($"BMW");
            var expectedId = this.makesRepository.All().FirstOrDefault().Id;

            Assert.Equal(expectedId, makeId);
        }

        [Fact]
        public async Task GetAllReturnWholeCount()
        {
            await this.SeedDatabase();

            var makesCountActual = this.makesService.GetAll<MakeInputViewModel>().Count();
            var expectedMakesCount = this.makesRepository.All().ToList().Count();

            Assert.Equal(expectedMakesCount, makesCountActual);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("Opel")]
        public async Task GetByNameInputWrongString(string input)
        {
            await this.SeedDatabase();

            var actualMake = this.makesService.GetByName<MakeInputViewModel>(input);

            Assert.Null(actualMake);
        }

        [Fact]
        public async Task GetByNameReturnMake()
        {
            await this.SeedDatabase();

            var actualMake = this.makesService.GetByName<MakeInputViewModel>("BMW");

            Assert.Equal(123456, actualMake.Id);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("       ")]
        [InlineData("Opel")]
        [InlineData("123124")]
        public async Task IsHasMakeNameReturnFalse(string input)
        {
            await this.SeedDatabase();

            var result = this.makesService.IsHasMakeName(input);

            Assert.False(result);
        }

        [Theory]
        [InlineData("BMW")]
        public async Task IsHasMakeNameReturnTrue(string input)
        {
            await this.SeedDatabase();

            var result = this.makesService.IsHasMakeName(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData(123456)]
        [InlineData(789666)]
        public async Task GetByIdReturnMake(int id)
        {
            await this.SeedDatabase();

            var actualMake = this.makesService.GetById<MakeInputViewModel>(id);

            var expectedMake = this.makesRepository.All()
                .Where(x => x.Id == id)
                .To<MakeInputViewModel>()
                .FirstOrDefault();

            Assert.Equal(expectedMake.Name, actualMake.Name);
            Assert.Equal(expectedMake.Id, actualMake.Id);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1.2)]
        [InlineData(null)]
        public async Task GetByIdReturnNull(int id)
        {
            await this.SeedDatabase();

            var actualMake = this.makesService.GetById<MakeInputViewModel>(id);

            Assert.Null(actualMake);
        }

        private void InitializeDatabaseAndRepositories()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(connection);
            var dbContext = new ApplicationDbContext(options.Options);

            dbContext.Database.EnsureCreated();

            this.makesRepository = new EfDeletableEntityRepository<Make>(dbContext);
        }

        private void InitializeFields()
        {
            this.testMake1 = new Make
            {
                Id = 789666,
                Name = "Audi",
            };

            this.testMake2 = new Make
            {
                Id = 123456,
                Name = "BMW",
            };
        }

        private async Task SeedDatabase()
        {
            await this.makesRepository.AddAsync(this.testMake1);
            await this.makesRepository.AddAsync(this.testMake2);
            await this.makesRepository.SaveChangesAsync();
        }

        private void InitializeMapper() => AutoMapperConfig.
            RegisterMappings(Assembly.Load("CarSalesApp.Web.ViewModels"));
    }
}

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

    public class MakesServiceTests : BaseServiceTests
    {
        private Make test1;
        private Make test2;

        public MakesServiceTests()
        {
            this.InitializeFields();
        }

        [Fact]
        public async Task AddAsyncAddFewMakes()
        {
            for (int i = 0; i < 3; i++)
            {
                await this.MakesService.AddAsync($"BMW{i}");
            }

            var isSuccessful = this.MakesRepository.All().Count() == 3;

            Assert.True(isSuccessful);
        }

        [Fact]
        public async Task AddAsyncReturnMakeIdAfterAdd()
        {
            var makeId = await this.MakesService.AddAsync($"BMW");
            var expectedId = this.MakesRepository.All().FirstOrDefault().Id;

            Assert.Equal(expectedId, makeId);
        }

        [Fact]
        public async Task GetAllReturnWholeCount()
        {
            await this.SeedDatabase();

            var makesCountActual = this.MakesService.GetAll<MakeInputViewModel>().Count();
            var expectedMakesCount = this.MakesRepository.All().ToList().Count();

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

            var actualMake = this.MakesService.GetByName<MakeInputViewModel>(input);

            Assert.Null(actualMake);
        }

        [Fact]
        public async Task GetByNameReturnMake()
        {
            await this.SeedDatabase();

            var actualMake = this.MakesService.GetByName<MakeInputViewModel>("BMW");

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

            var result = this.MakesService.IsHasMakeName(input);

            Assert.False(result);
        }

        [Theory]
        [InlineData("BMW")]
        public async Task IsHasMakeNameReturnTrue(string input)
        {
            await this.SeedDatabase();

            var result = this.MakesService.IsHasMakeName(input);

            Assert.True(result);
        }

        [Theory]
        [InlineData(123456)]
        [InlineData(789666)]
        public async Task GetByIdReturnMake(int id)
        {
            await this.SeedDatabase();

            var actualMake = this.MakesService.GetById<MakeInputViewModel>(id);

            var expectedMake = this.MakesRepository.All()
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

            var actualMake = this.MakesService.GetById<MakeInputViewModel>(id);

            Assert.Null(actualMake);
        }

        private void InitializeFields()
        {
            this.test1 = new Make
            {
                Id = 789666,
                Name = "Audi",
            };

            this.test2 = new Make
            {
                Id = 123456,
                Name = "BMW",
            };
        }

        private async Task SeedDatabase()
        {
            await this.MakesRepository.AddAsync(this.test1);
            await this.MakesRepository.AddAsync(this.test2);
            await this.MakesRepository.SaveChangesAsync();
        }
    }
}

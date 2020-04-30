namespace CarSalesApp.Services.Data.Tests
{
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Mapping;
    using CarSalesApp.Web.ViewModels.Cars;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class ModelsServiceTests : BaseServiceTests
    {
        private Model test1;
        private Model test2;
        private Make test3;

        public ModelsServiceTests()
        {
            this.InitializeFields();
        }

        [Fact]
        public async Task GetAllReturnWholeCount()
        {
            await this.SeedDatabase();

            var actualModelsCount = this.ModelsService.GetAll<ModelInputViewModel>().Count();
            var expectedModelsCount = this.ModelsRepository.All().ToList().Count();

            Assert.Equal(expectedModelsCount, actualModelsCount);
        }

        [Fact]
        public async Task AddAsyncWorkCorrectly()
        {
            await this.SeedDatabase();

            int actualModelId = await this.ModelsService.AddAsync("Signum", 789);
            var expectedModelId = this.ModelsRepository.All()
                .Where(x => x.Name == "Signum" && x.MakeId == 789)
                .Select(x => x.Id).FirstOrDefault();

            Assert.Equal(expectedModelId, actualModelId);
        }

        [Fact]
        public async Task EditAsyncWorkCorrectly()
        {
            await this.SeedDatabase();

            var id = await this.ModelsService.EditAsync(789666, "VectraC", "OpelS");

            var actualModelName = this.ModelsRepository.All()
                .Where(x => x.Id == 789666).FirstOrDefault().Name;
            var actualMakeName = this.ModelsRepository.All()
                .Where(x => x.Id == 789666).FirstOrDefault().Make.Name;
            Assert.Equal("VectraC", actualModelName);
            Assert.Equal("OpelS", actualMakeName);
        }

        [Fact]
        public async Task GetByNameWorkCorrectly()
        {
            await this.SeedDatabase();
            var nameModel = "Vectra";
            var actualModelId = this.ModelsService.GetByName<ModelInputViewModel>(nameModel).Id;
            var expectedModelId = this.ModelsRepository.All()
                .Where(x => x.Name == nameModel).FirstOrDefault().Id;

            Assert.Equal(expectedModelId, actualModelId);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("       ")]
        [InlineData("Opel")]
        [InlineData("123124")]
        public async Task GetByNameWorkReturnNull(string input)
        {
            await this.SeedDatabase();

            var actualModel = this.ModelsService.GetByName<ModelInputViewModel>(input);

            Assert.Null(actualModel);
        }

        [Theory]
        [InlineData(123456)]
        [InlineData(789666)]
        public async Task GetByIdReturnModel(int id)
        {
            await this.SeedDatabase();

            var actualModel = this.ModelsService.GetById<ModelInputViewModel>(id);

            var expectedModel = this.ModelsRepository.All()
                .Where(x => x.Id == id)
                .To<ModelInputViewModel>()
                .FirstOrDefault();

            Assert.Equal(expectedModel.Name, actualModel.Name);
            Assert.Equal(expectedModel.Id, actualModel.Id);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1.2)]
        [InlineData(null)]
        public async Task GetByIdReturnNull(int id)
        {
            await this.SeedDatabase();

            var actualMake = this.ModelsService.GetById<ModelInputViewModel>(id);

            Assert.Null(actualMake);
        }

        private void InitializeFields()
        {
            this.test1 = new Model
            {
                Id = 789666,
                Name = "Vectra",
                MakeId = 789,
            };

            this.test2 = new Model
            {
                Id = 123456,
                Name = "Astra",
                MakeId = 789,
            };

            this.test3 = new Make
            {
                Id = 789,
                Name = "Opel",
            };
        }

        private async Task SeedDatabase()
        {
            await this.ModelsRepository.AddAsync(this.test1);
            await this.ModelsRepository.AddAsync(this.test2);
            await this.MakesRepository.AddAsync(this.test3);
            await this.ModelsRepository.SaveChangesAsync();
            await this.MakesRepository.SaveChangesAsync();
        }
    }
}

namespace CarSalesApp.Web.Areas.Administration.Controllers
{
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Data;
    using CarSalesApp.Web.ViewModels.Cars;
    using CarSalesApp.Web.ViewModels.Administration.Entities;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using CarSalesApp.Services.Data.CarEntity;

    public class EntitiesController : AdministrationController
    {
        private readonly IMakeCarService makeCarService;
        private readonly IModelCarService modelCarService;
        private readonly IEngineService engineService;
        private readonly IBodyCarService bodyCarService;

        public EntitiesController(IMakeCarService makeCarService, IModelCarService modelCarService, IEngineService engineService, IBodyCarService bodyCarService)
        {
            this.makeCarService = makeCarService;
            this.modelCarService = modelCarService;
            this.engineService = engineService;
            this.bodyCarService = bodyCarService;
        }

        public IActionResult AddEntities()
        {
            return this.View();
        }

        public IActionResult AddEngine()
        {
            var viewModel = new AddDriveViewModel();
            viewModel.Makes = this.makeCarService.GetAll<MakeInputViewModel>();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddEngine(AddDriveViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Makes = this.makeCarService.GetAll<MakeInputViewModel>();
                return this.View(input);
            }

            await this.engineService.AddAsync(input.ModelId, input.FuelId, input.Displacement, input.Power, input.GearType, input.Gear, input.YearFrom, input.YearTo);

            return this.Redirect("/");
        }

        public IActionResult AddMakeAndModel()
        {
            var makes = this.makeCarService.GetAll<MakeInputViewModel>().ToList();
            makes.Add(new MakeInputViewModel { Id = 999999999, Name = "Other" });
            var viewModel = new AddMakeAndModelViewModel()
            {
                Makes = makes,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddMakeAndModel(AddMakeAndModelViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var makes = this.makeCarService.GetAll<MakeInputViewModel>().ToList();
                makes.Add(new MakeInputViewModel { Id = 999999999, Name = "Other" });
                input.Makes = makes;
                return this.View(input);
            }

            var inputMakeName = input.Make;
            var inputModelName = input.Model;
            var isMakeId = int.TryParse(inputMakeName, out int makeId);

            if (isMakeId)
            {
                await this.modelCarService.AddAsync(inputModelName, makeId);
            }
            else
            {
                if (this.makeCarService.IsHasMakeName(inputMakeName)) //if user is selected "other", but he entered existing makeName
                {
                    var make = this.makeCarService.GetByName<Make>(inputMakeName);
                    await this.modelCarService.AddAsync(inputModelName, make.Id);
                }

                var newMakeId = await this.makeCarService.AddAsync(inputMakeName);
                await this.modelCarService.AddAsync(inputModelName, newMakeId);
            }

            return this.Redirect("/"); //<<< tuk MUST da se redirekne kym view s markite i modelite kym markata edit delete
        }
        
        public IActionResult AddFeature()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult AddFeature(string input)
        {
            return this.View();
        }

        public IActionResult AddBody()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBody(AddBodyViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.bodyCarService.AddAsync(input.Category, input.Seats, input.Doors);
            return this.Redirect("/");
        }
    }
}

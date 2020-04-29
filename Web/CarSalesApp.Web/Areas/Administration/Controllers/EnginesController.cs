using CarSalesApp.Services.Data;
using CarSalesApp.Services.Data.CarEntity;
using CarSalesApp.Web.ViewModels.Administration.Engines;
using CarSalesApp.Web.ViewModels.Administration.Entities;
using CarSalesApp.Web.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarSalesApp.Web.Areas.Administration.Controllers
{
    public class EnginesController : AdministrationController
    {
        private readonly IEngineService engineService;
        private readonly IMakeCarService makeCarService;

        public EnginesController(IEngineService engineService, IMakeCarService makeCarService)
        {
            this.engineService = engineService;
            this.makeCarService = makeCarService;
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

            var engineId = await this.engineService.AddAsync(input.ModelId, input.FuelId, input.Displacement, input.Power, input.GearType, input.Gear, input.YearFrom, input.YearTo);

            return this.RedirectToAction(nameof(this.Details), "Engines", new { Id = engineId });
        }

        public IActionResult All()
        {
            var viewModel = new AllEngineViewModel
            {
                Makes = this.makeCarService.GetAll<MakeInputViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var engine = this.engineService.GetById<DriveInputViewModel>(id);

            if (engine == null)
            {
                return this.NotFound();
            }

            var viewModel = new EditEngineViewModel
            {
                Id = engine.Id,
                Displacement = engine.Displacement,
                Gear = engine.Gear,
                GearType = (int)engine.GearType,
                Power = engine.Power,
                YearFrom = engine.YearFrom.Year,
                YearTo = engine.YearTo.Year,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditEngineViewModel input)
        {
            var engine = this.engineService.GetById<DriveInputViewModel>(input.Id);

            if (engine == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                var viewModel = new EditEngineViewModel
                {
                    Id = engine.Id,
                    Displacement = engine.Displacement,
                    Gear = engine.Gear,
                    GearType = (int)engine.GearType,
                    Power = engine.Power,
                    YearFrom = engine.YearFrom.Year,
                    YearTo = engine.YearTo.Year,
                };
                return this.View(viewModel);
            }

            await this.engineService.EditAsync(input.Id, input.Displacement, input.Gear, input.GearType, input.Power, input.YearFrom, input.YearTo);

            return this.RedirectToAction(nameof(this.Details), "Engines", new { Id = engine.Id });
        }

        public IActionResult Details(int id)
        {
            var modelView = this.engineService.GetById<DetailsEngineViewModel>(id);
            return this.View(modelView);
        }
    }
}

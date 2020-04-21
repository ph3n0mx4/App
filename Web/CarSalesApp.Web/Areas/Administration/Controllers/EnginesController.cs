using CarSalesApp.Services.Data;
using CarSalesApp.Services.Data.CarEntity;
using CarSalesApp.Web.ViewModels.Administration.Entities;
using CarSalesApp.Web.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

            await this.engineService.AddAsync(input.ModelId, input.FuelId, input.Displacement, input.Power, input.GearType, input.Gear, input.YearFrom, input.YearTo);

            return this.Redirect("/");
        }
    }
}

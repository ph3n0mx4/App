using CarSalesApp.Data.Models;
using CarSalesApp.Services.Data;
using CarSalesApp.Web.ViewModels.Cars;
using CarSalesApp.Web.ViewModels.Entites;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesApp.Web.Controllers
{
    public class EntitiesController : BaseController
    {
        private readonly IMakeCarService makeCarService;
        private readonly IModelCarService modelCarService;

        public EntitiesController(IMakeCarService makeCarService, IModelCarService modelCarService)
        {
            this.makeCarService = makeCarService;
            this.modelCarService = modelCarService;
        }

        public IActionResult AddEntities()
        {
            return this.View();
        }

        public IActionResult AddEngine()
        {
            return this.View();
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
                if (this.makeCarService.IsHasMakeName(inputMakeName))
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
            ;
            return this.View();
        }
    }
}

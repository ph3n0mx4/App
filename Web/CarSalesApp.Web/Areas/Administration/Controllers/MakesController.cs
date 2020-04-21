using CarSalesApp.Services.Data;
using CarSalesApp.Web.ViewModels.Administration.Makes;
using CarSalesApp.Web.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesApp.Web.Areas.Administration.Controllers
{
    public class MakesController : AdministrationController
    {
        private readonly IMakeCarService makeCarService;
        private readonly IModelCarService modelCarService;

        public MakesController(IMakeCarService makeCarService, IModelCarService modelCarService)
        {
            this.makeCarService = makeCarService;
            this.modelCarService = modelCarService;
        }

        public IActionResult Details()
        {
            var viewModel = new DetailsMakesViewModel
            {
                Makes = this.makeCarService.GetAll<MakeInputViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Edit(int Id)
        {
            var model = this.modelCarService.GetById<ModelInputViewModel>(Id);

            if (model == null)
            {
                return this.NotFound();
            }

            var viewModel = new EditMakeAndModelViewModel
            {
                Id = model.Id,
                Make = model.Make,
                Name = model.Name,
            };

            return this.View(viewModel);
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
                    var make = this.makeCarService.GetByName<MakeInputViewModel>(inputMakeName);
                    await this.modelCarService.AddAsync(inputModelName, make.Id);
                }
                else
                {
                    var newMakeId = await this.makeCarService.AddAsync(inputMakeName);
                    await this.modelCarService.AddAsync(inputModelName, newMakeId);
                }
            }

            return this.Redirect("/"); //<<< tuk MUST da se redirekne kym view s markite i modelite kym markata edit delete
        }
    }
}

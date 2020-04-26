using CarSalesApp.Services.Data;
using CarSalesApp.Web.ViewModels.Administration.Makes;
using CarSalesApp.Web.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult All()
        {
            var viewModel = new AllMakesViewModel
            {
                Makes = this.makeCarService.GetAll<MakeInputViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Edit(int id)
        {
            var model = this.modelCarService.GetById<ModelInputViewModel>(id);

            if (model == null)
            {
                return this.NotFound();
            }

            var viewModel = new EditModelViewModel
            {
                Id = model.Id,
                Name = model.Name,
                MakeName = model.Make.Name,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditModelViewModel input)
        {
            var model = this.modelCarService.GetById<ModelInputViewModel>(input.Id);

            if (model == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                var viewModel = new EditModelViewModel
                {
                    Id = model.Id,
                    Name = model.Name,
                    MakeName = model.Make.Name,
                };
                return this.View(viewModel);
            }

            await this.modelCarService.EditAsync(input.Id, input.Name, input.MakeName);

            return this.RedirectToAction(nameof(this.Details), "Makes", new { Id = model.Make.Id });
        }

        public IActionResult Details(int id)
        {
            var modelView = this.makeCarService.GetById<DetailsMakeViewModel>(id);
            return this.View(modelView);
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
                    makeId = make.Id;
                }
                else
                {
                    makeId = await this.makeCarService.AddAsync(inputMakeName);
                    await this.modelCarService.AddAsync(inputModelName, makeId);
                }
            }

            return this.RedirectToAction(nameof(this.Details), "Makes", new { Id = makeId });
        }
    }
}

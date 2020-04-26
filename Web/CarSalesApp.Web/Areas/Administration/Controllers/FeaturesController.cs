using CarSalesApp.Services.Data.CarEntity;
using CarSalesApp.Web.ViewModels.Administration.Entities;
using CarSalesApp.Web.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarSalesApp.Web.Areas.Administration.Controllers
{
    public class FeaturesController : AdministrationController
    {
        private readonly IFeatureTypeService featureTypeService;
        private readonly IFeatureService featureService;

        public FeaturesController(IFeatureTypeService featureTypeService, IFeatureService featureService)
        {
            this.featureTypeService = featureTypeService;
            this.featureService = featureService;
        }

        public IActionResult AddFeature()
        {
            var types = this.featureTypeService.GetAll<FeatureTypeInputViewModel>().ToList();
            types.Add(new FeatureTypeInputViewModel { Id = 999999999, Name = "Other" });
            var viewModel = new AddFeatureViewModel()
            {
                Types = types,
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddFeature(AddFeatureViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var types = this.featureTypeService.GetAll<FeatureTypeInputViewModel>().ToList();
                types.Add(new FeatureTypeInputViewModel { Id = 999999999, Name = "Other" });
                input.Types = types;
                return this.View(input);
            }

            var inputTypeName = input.Type;
            var inputFeatureName = input.Feature;
            var isTypeId = int.TryParse(inputTypeName, out int typeId);

            if (isTypeId)
            {
                await this.featureService.AddAsync(inputFeatureName, typeId);
            }
            else
            {
                if (this.featureTypeService.IsHasTypeName(inputTypeName)) //if user is selected "other", but he entered existing makeName
                {
                    var type = this.featureTypeService.GetByName<FeatureTypeInputViewModel>(inputTypeName);
                    await this.featureService.AddAsync(inputFeatureName, type.Id);
                }
                else
                {
                    var newTypeId = await this.featureTypeService.AddAsync(inputTypeName);
                    await this.featureService.AddAsync(inputFeatureName, newTypeId);
                }
            }

            return this.Redirect("/");
        }
    }
}

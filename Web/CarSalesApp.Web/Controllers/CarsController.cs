namespace CarSalesApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CarSalesApp.Common;
    using CarSalesApp.Data;
    using CarSalesApp.Data.Models;
    using CarSalesApp.Services.Data;
    using CarSalesApp.Services.Data.CarEntity;
    using CarSalesApp.Web.ViewModels.Cars;
    using CloudinaryDotNet;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : BaseController
    {
        private readonly ICarService carService;
        private readonly IModelCarService modelCarService;
        private readonly IMakeCarService makeCarService;
        private readonly IBodyCarService bodyCarService;
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IFeatureService featureService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEngineService engineService;

        public CarsController(ICarService carService, IModelCarService modelCarService, IMakeCarService makeCarService, IBodyCarService bodyCarService, ApplicationDbContext db, Cloudinary cloudinary, ICloudinaryService cloudinaryService, IFeatureService featureService, UserManager<ApplicationUser> userManager, IEngineService engineService)
        {
            this.carService = carService;
            this.modelCarService = modelCarService;
            this.makeCarService = makeCarService;
            this.bodyCarService = bodyCarService;
            this.db = db;
            this.cloudinary = cloudinary;
            this.cloudinaryService = cloudinaryService;
            this.featureService = featureService;
            this.userManager = userManager;
            this.engineService = engineService;
        }

        [Authorize]
        public async Task<IActionResult> CreateAdCar()
        {
            var viewModel = new CreateAdCarInputFormViewModel();
            viewModel.Makes = this.makeCarService.GetAll<MakeInputViewModel>();
            viewModel.Models = this.modelCarService.GetAll<ModelInputViewModel>();
            viewModel.Bodies = this.bodyCarService.GetAll<BodyInputViewModel>();
            viewModel.Safety = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameSafety);
            viewModel.Extras = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameExtras);
            viewModel.Entartaiment = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameEntertainment);
            viewModel.Comfort = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameComfort);

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateAdCar(CreateAdCarInputFormViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.Makes = this.makeCarService.GetAll<MakeInputViewModel>();
                input.Models = this.modelCarService.GetAll<ModelInputViewModel>();
                input.Bodies = this.bodyCarService.GetAll<BodyInputViewModel>();
                input.Safety = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameSafety);
                input.Extras = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameExtras);
                input.Entartaiment = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameEntertainment);
                input.Comfort = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameComfort);
                return this.View(input);
            }

            string inputMainImage = string.Empty;
            if (input.MainImage == null)
            {
                inputMainImage = GlobalConstants.ImageNotFound;
            }
            else
            {
                inputMainImage = await this.cloudinaryService.UploadAsyncFile(this.cloudinary, input.MainImage);
            }

            IEnumerable<string> inputImages = null;
            if (input.Images == null)
            {
                inputImages.ToList().Add(GlobalConstants.ImageNotFound);
            }
            else
            {
                inputImages = await this.cloudinaryService.UploadAsyncFiles(this.cloudinary, input.Images);
            }

            var userId = this.userManager.GetUserId(this.User);

            var carId = await this.carService.AddAsync(input.MakeId, input.ModelId, input.DriveId, input.BodyId, input.Month, input.Year, input.Color, input.InputFeatures, inputImages, input.Mileage, input.Price, inputMainImage, input.Description, userId);

            return this.RedirectToAction(nameof(this.DetailsAdCar), "Cars", new { Id = carId });
        }

        public async Task<IActionResult> DetailsAdCar(int id)
        {
            var carViewModel = this.carService.GetById<CarAdDetailsViewModel>(id);

            if (carViewModel == null)
            {
                return this.NotFound();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            carViewModel.IsUserAuthorOrAdmin = await this.IsUserAuthorOrAdmin(user, carViewModel.UserId);
            carViewModel.Safety = await this.featureService.GetAllOfTypeByCarIdAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameSafety, carViewModel.Id);
            carViewModel.Extras = await this.featureService.GetAllOfTypeByCarIdAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameExtras, carViewModel.Id);
            carViewModel.Entartaiment = await this.featureService.GetAllOfTypeByCarIdAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameEntertainment, carViewModel.Id);
            carViewModel.Comfort = await this.featureService.GetAllOfTypeByCarIdAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameComfort, carViewModel.Id);

            return this.View(carViewModel);
        }

        [Authorize]
        public async Task<IActionResult> EditAdCar(int id)
        {
            var carViewModel = this.carService.GetById<EditCarAdViewModel>(id);
            var user = await this.userManager.GetUserAsync(this.User);
            if (carViewModel == null)
            {
                return this.NotFound();
            }

            if (await this.IsUserAuthorOrAdmin(user, carViewModel.UserId))
            {
                return this.RedirectToAction("/");
            }

            if (carViewModel == null)
            {
                return this.NotFound();
            }

            carViewModel.Makes = this.makeCarService.GetAll<MakeInputViewModel>();
            carViewModel.Models = this.modelCarService.GetAllByMakeId<ModelInputViewModel>(carViewModel.MakeId);
            carViewModel.Bodies = this.bodyCarService.GetAll<BodyInputViewModel>();
            carViewModel.Drives = this.engineService.GetAllByModelIdAndFuelId<DriveInputViewModel>(carViewModel.ModelId, carViewModel.FuelId);

            carViewModel.CarFeatures = await this.featureService.GetAllByCarIdAsync<FeatureViewModel>(id);

            carViewModel.Safety = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameSafety);
            carViewModel.Extras = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameExtras);
            carViewModel.Entartaiment = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameEntertainment);
            carViewModel.Comfort = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameComfort);

            return this.View(carViewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditAdCar(EditCarAdViewModel input)
        {
            var carViewModel = this.carService.GetById<EditCarAdViewModel>(input.Id);
            var user = await this.userManager.GetUserAsync(this.User);
            if (carViewModel == null)
            {
                return this.NotFound();
            }

            if (await this.IsUserAuthorOrAdmin(user, input.UserId))
            {
                return this.RedirectToAction("Login", "Account");
            }

            if (!this.ModelState.IsValid)
            {
                input.Makes = this.makeCarService.GetAll<MakeInputViewModel>();
                input.Models = this.modelCarService.GetAllByMakeId<ModelInputViewModel>(input.MakeId);
                input.Bodies = this.bodyCarService.GetAll<BodyInputViewModel>();
                input.Drives = this.engineService.GetAllByModelIdAndFuelId<DriveInputViewModel>(input.ModelId, input.FuelId);

                input.CarFeatures = await this.featureService.GetAllByCarIdAsync<FeatureViewModel>(input.Id);

                input.Safety = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameSafety);
                input.Extras = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameExtras);
                input.Entartaiment = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameEntertainment);
                input.Comfort = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameComfort);

                return this.View(input);
            }

            var carId = await this.carService.EditAsync(input.Id, input.MakeId, input.ModelId, input.DriveId, input.BodyId, input.Month, input.Year, input.Color, input.InputFeatures, input.Mileage, input.Price, input.Description);

            return this.RedirectToAction(nameof(this.DetailsAdCar), "Cars", new { Id = carId });
        }

        private async Task<bool> IsUserAuthorOrAdmin(ApplicationUser user, string userId)
        {
            if (user == null)
            {
                return false;
            }

            var bool1 = await this.IsUserAdmin(user);
            var bool2 = userId == user.Id;

            return bool1 || bool2;
        }

        private async Task<bool> IsUserAdmin(ApplicationUser user)
        {
            if (user == null)
            {
                return false;
            }

            var userRoles = await this.userManager.GetRolesAsync(user);
            return userRoles.Contains(GlobalConstants.AdministratorRoleName);
        }
    }
}

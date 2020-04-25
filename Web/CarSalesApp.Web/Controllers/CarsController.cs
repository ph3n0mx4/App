using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarSalesApp.Data;
using CarSalesApp.Data.Models;
using CarSalesApp.Web.ViewModels.Administration.Dashboard;
using CarSalesApp.Web.ViewModels.Cars;
using Microsoft.AspNetCore.Mvc;
using CarSalesApp.Services.Mapping;
using CarSalesApp.Services.Data;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using CarSalesApp.Services.Data.CarEntity;
using CarSalesApp.Common;
using CarSalesApp.Data.Models.Enums;

namespace CarSalesApp.Web.Controllers
{
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

        public CarsController(ICarService carService, IModelCarService modelCarService, IMakeCarService makeCarService, IBodyCarService bodyCarService, ApplicationDbContext db, Cloudinary cloudinary, ICloudinaryService cloudinaryService, IFeatureService featureService)
        {
            this.carService = carService;
            this.modelCarService = modelCarService;
            this.makeCarService = makeCarService;
            this.bodyCarService = bodyCarService;
            this.db = db;
            this.cloudinary = cloudinary;
            this.cloudinaryService = cloudinaryService;
            this.featureService = featureService;
        }

        public async Task<IActionResult> CreateAdCar()
        {//opraY serviZA !
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

            var carId = await this.carService.AddAsync(input.MakeId, input.ModelId, input.DriveId, input.BodyId, input.Month, input.Year, input.FuelId, input.Color, input.InputFeatures, inputImages, input.Mileage, input.Price, inputMainImage, input.Description);


            return this.RedirectToAction(nameof(this.DetailsAdCar), "Cars", new { Id = carId });
        }

        public async Task<IActionResult> DetailsAdCar(int id)
        {
            var carViewModel = this.db.Cars.Where(x => x.Id == id).To<CarAdDetailsViewModel>().FirstOrDefault();
            carViewModel.Safety = await this.featureService.GetAllOfTypeByCarIdAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameSafety, carViewModel.Id);
            carViewModel.Extras = await this.featureService.GetAllOfTypeByCarIdAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameExtras, carViewModel.Id);
            carViewModel.Entartaiment = await this.featureService.GetAllOfTypeByCarIdAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameEntertainment, carViewModel.Id);
            carViewModel.Comfort = await this.featureService.GetAllOfTypeByCarIdAsync<FeatureViewModel>(GlobalConstants.FeatureTypeNameComfort, carViewModel.Id);

            if (carViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(carViewModel);
        }
    }
}

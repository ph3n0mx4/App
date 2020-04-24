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

namespace CarSalesApp.Web.Controllers
{
    public class CarsController : BaseController
    {
        //private readonly ICarService carService;
        private readonly IModelCarService modelCarService;
        private readonly IMakeCarService makeCarService;
        private readonly IBodyCarService bodyCarService;
        private readonly ApplicationDbContext db;
        private readonly Cloudinary cloudinary;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IFeatureService featureService;

        public CarsController(/*ICarService carService, */IModelCarService modelCarService, IMakeCarService makeCarService, IBodyCarService bodyCarService, ApplicationDbContext db, Cloudinary cloudinary, ICloudinaryService cloudinaryService, IFeatureService featureService)
        {
            //this.carService = carService;
            this.modelCarService = modelCarService;
            this.makeCarService = makeCarService;
            this.bodyCarService = bodyCarService;
            this.db = db;
            this.cloudinary = cloudinary;
            this.cloudinaryService = cloudinaryService;
            this.featureService = featureService;
        }

        public IActionResult CreateAdCar()
        {
            var viewModel = new CreateAdCarInputFormViewModel();
            viewModel.Makes = this.makeCarService.GetAll<MakeInputViewModel>();
            viewModel.Models = this.modelCarService.GetAll<ModelInputViewModel>();
            viewModel.Bodies = this.bodyCarService.GetAll<BodyInputViewModel>();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdCar(CreateAdCarInputFormViewModel input)
        {
            var opel = this.db.Makes
                .Where(x => x.Name == "Opel")
                .Select(x => x.Models).ToList();

            Make vw = this.db.Makes.Where(x => x.Name == "VW")
                .Select(x => new Make
                {
                    Name = x.Name,
                    Models = x.Models,
                })
                .FirstOrDefault();
            var a = input;
            var images = await this.cloudinaryService.UploadAsync(this.cloudinary, input.Files);
            return this.Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {
            var a = await this.cloudinaryService.UploadAsync(this.cloudinary, files);

            ;

            return this.Redirect("/");
        }

        public async Task<IActionResult> DetailsAdCar(int id)
        {
            var carViewModel = this.db.Cars.Where(x => x.Id == id).To<CarAdDetailsViewModel>().FirstOrDefault();
            var safety = await this.featureService.GetAllOfTypeAsync<FeatureViewModel>(GlobalConstants.featureTypeNameSafety);
            if (carViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(carViewModel);
        }
    }
}

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

        public CarsController(/*ICarService carService, */IModelCarService modelCarService, IMakeCarService makeCarService, IBodyCarService bodyCarService, ApplicationDbContext db, Cloudinary cloudinary, ICloudinaryService cloudinaryService)
        {
            //this.carService = carService;
            this.modelCarService = modelCarService;
            this.makeCarService = makeCarService;
            this.bodyCarService = bodyCarService;
            this.db = db;
            this.cloudinary = cloudinary;
            this.cloudinaryService = cloudinaryService;
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
    }
}

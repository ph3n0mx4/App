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

namespace CarSalesApp.Web.Controllers
{
    public class CarsController : BaseController
    {
        //private readonly ICarService carService;
        //private readonly IModelCarService modelCarService;
        //private readonly IMakeCarService makeCarService;
        //private readonly IBodyCarService bodyCarService;
        private readonly ApplicationDbContext db;

        public CarsController(/*ICarService carService, IModelCarService modelCarService, IMakeCarService makeCarService, IBodyCarService bodyCarService,*/ ApplicationDbContext db)
        {
            //this.carService = carService;
            //this.modelCarService = modelCarService;
            //this.makeCarService = makeCarService;
            //this.bodyCarService = bodyCarService;
            this.db = db;
        }

        public IActionResult CreateAdCar()
        {
            var viewModel = new CreateAdCarInputFormViewModel();
            //viewModel.Makes = this.makeCarService.GetAll<MakeInputViewModel>();
            //viewModel.Models = this.modelCarService.GetAll<ModelInputViewModel>();
            //viewModel.Bodies = this.bodyCarService.GetAll<BodyInputViewModel>();

            var bodies = this.db
                .Bodies
                .To<BodyInputViewModel>()
                .ToList();

            viewModel.Bodies = bodies;

            var makes = this.db.Makes.To<MakeInputViewModel>().ToList();
            var models = this.db.Models.To<ModelInputViewModel>().ToList();
            viewModel.Makes = makes;
            viewModel.Models = models;


            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateAdCar(CreateAdCarInputFormViewModel input)
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
            return this.Redirect("/");
        }
    }
}

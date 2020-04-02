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

namespace CarSalesApp.Web.Controllers
{
    public class CarsController : BaseController
    {
        private readonly ApplicationDbContext db;

        public CarsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult CreateAdCar()
        {
            var viewModel = new CreateAdCarInputFormViewModel();
           

            var bodies = this.db
                .Bodies
                .To<BodyInputViewModel>()
                .ToList();

            viewModel.Bodies = bodies;

            var makes2 = this.db.Makes.ToList();
            var models = this.db.Models.ToList();
            viewModel.Makes = makes2;
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
            var model = input.Model;
            var make = this.db.Makes.FirstOrDefault(x => x.Models.All(y => y.Name == model));
            return this.Redirect("/");
        }
    }
}

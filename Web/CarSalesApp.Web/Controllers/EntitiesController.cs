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

        public EntitiesController(IMakeCarService makeCarService)
        {
            this.makeCarService = makeCarService;
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
            var viewModel = new AddMakeAndModelViewModel();
            var makes = this.makeCarService.GetAll<MakeInputViewModel>().ToList();
            makes.Add(new MakeInputViewModel { Id = 999999999, Name = "Other" });
            viewModel.Makes = makes;

            return this.View(viewModel);
        }

        public IActionResult AddFeature()
        {
            return this.View();
        }
    }
}

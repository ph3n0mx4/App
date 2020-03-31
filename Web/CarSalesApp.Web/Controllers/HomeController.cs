namespace CarSalesApp.Web.Controllers
{
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using CarSalesApp.Data;
    using CarSalesApp.Data.Common.Repositories;
    using CarSalesApp.Data.Models;
    using CarSalesApp.Web.ViewModels;
    using CarSalesApp.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();
            var cars = this.db.Cars.Select(x => new IndexCarViewModel
            {
                Title = x.Title,//x.Make.Name.ToString() + x.Model.Name.ToString(),
                Power = x.Drive.Power == null ? x.Drive.Power.ToString() : " " + "hp",
                //Power = x.Drive.Power.ToString() + "hp",
                Description = "To Do Description",
                CreatedOn = x.CreatedOn.ToString("d"),
                //ModifiedOn = "null",
                ModifiedOn = x.ModifiedOn.HasValue ? x.ModifiedOn.ToString() : " ",
                UrlImg = x.GeneralImg,
                FirstRegistration = x.FirstRegistration.ToString("y", CultureInfo.CurrentUICulture),
            }).ToList();

            viewModel.Cars = cars;

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            //var car = new Car
            //{
            //    Title = "Opel",
            //    BodyId = 2,
            //};

            //bool veiwModel = this.carsRepository.All().Contains(car);
            //var a = this.db.Cars.Find(car);
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}

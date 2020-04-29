namespace CarSalesApp.Web.Controllers
{
    using CarSalesApp.Services.Data;
    using CarSalesApp.Web.ViewModels;
    using CarSalesApp.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        private readonly ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();

            var cars = this.carService.GetAll<IndexCarViewModel>();
            viewModel.Cars = cars;

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
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

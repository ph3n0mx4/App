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
            //var cars = this.db.All().Select(x => new IndexCarViewModel
            //{     towa ili w HTML-a ili v mapping-a na viewmodel-a
            //    Title = x.Title,//x.Make.Name.ToString() + x.Model.Name.ToString(),
            //    Power = x.Drive.Power == null ? x.Drive.Power.ToString() : " " + "hp",
            //    //Power = x.Drive.Power.ToString() + "hp",
            //    Description = "To Do Description",
            //    CreatedOn = x.CreatedOn.ToString("d"),
            //    //ModifiedOn = "null",
            //    ModifiedOn = x.ModifiedOn.HasValue ? x.ModifiedOn.ToString() : " ",
            //    GeneralImg = x.GeneralImg,
            //    FirstRegistration = x.FirstRegistration.ToString("y", CultureInfo.CurrentUICulture),
            //}).ToList();

            var cars = this.carService.GetAll<IndexCarViewModel>();
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
